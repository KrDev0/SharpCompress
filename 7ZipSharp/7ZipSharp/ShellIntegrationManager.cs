using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace _7ZipSharp
{
    internal static class ShellIntegrationManager
    {
        private const string CommandStorePath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell";
        private const string ClassesPath = @"Software\Classes";
        private static readonly string[] ArchiveExtensions =
        {
            ".7z", ".scz", ".zip", ".rar", ".tar", ".gz", ".bz2", ".xz", ".cab", ".wim", ".lz", ".lzma",
            ".arj", ".lzh", ".lha", ".iso", ".chm", ".rpm", ".deb", ".cpio", ".z", ".lzip", ".lz4", ".zst"
        };

        private sealed class CommandDefinition
        {
            internal string Id;
            internal string Label;
            internal string SelectionModel;
            internal string Arguments;
        }

        private static readonly CommandDefinition[] Commands =
        {
            new CommandDefinition { Id = "CompressFiles", Label = "Comprimir…", SelectionModel = "Player", Arguments = "/files \"%1\"" },
            new CommandDefinition { Id = "Files7z", Label = "Comprimir como 7z", SelectionModel = "Player", Arguments = "/f7z \"%1\"" },
            new CommandDefinition { Id = "FilesScz", Label = "Comprimir como SCZ (SharpCompress)", SelectionModel = "Player", Arguments = "/fScz \"%1\"" },
            new CommandDefinition { Id = "FilesZip", Label = "Comprimir como ZIP", SelectionModel = "Player", Arguments = "/fZip \"%1\"" },
            new CommandDefinition { Id = "FilesTar", Label = "Comprimir como TAR", SelectionModel = "Player", Arguments = "/fTar \"%1\"" },
            new CommandDefinition { Id = "OpenSelection", Label = "Abrir con SharpCompress", SelectionModel = "Single", Arguments = "/open \"%1\"" },
            new CommandDefinition { Id = "OpenArchive", Label = "Abrir archivo", SelectionModel = "Single", Arguments = "/open \"%1\"" },
            new CommandDefinition { Id = "ExtractNamed", Label = "Extraer en carpeta del archivo", SelectionModel = "Single", Arguments = "/extractTo \"%1\"" },
            new CommandDefinition { Id = "ExtractHere", Label = "Extraer aquí", SelectionModel = "Single", Arguments = "/extractHere \"%1\"" },
            new CommandDefinition { Id = "OpenHere", Label = "Abrir ubicación", SelectionModel = "Single", Arguments = "/openD \"%V\"" },
            new CommandDefinition { Id = "CompressHere", Label = "Comprimir contenido aquí…", SelectionModel = "Single", Arguments = "/here \"%V\"" }
        };

        internal static bool IsMachineIntegrationInstalled
        {
            get
            {
                try
                {
                    using (RegistryKey machine = OpenMachineKey(false))
                    using (RegistryKey root = machine.OpenSubKey(ClassesPath + @"\AllFileSystemObjects\shell\SharpCompress"))
                    using (RegistryKey extraction = machine.OpenSubKey(ClassesPath + @"\SystemFileAssociations\.7z\shell\SharpCompress"))
                        return root != null && extraction != null;
                }
                catch (UnauthorizedAccessException) { return false; }
                catch (System.Security.SecurityException) { return false; }
            }
        }

        internal static void RepairMachineIntegration(string iconPath)
        {
            EnsureAdministrator();
            string executable = Application.ExecutablePath;
            string icon = !string.IsNullOrWhiteSpace(iconPath) && File.Exists(iconPath)
                ? Path.GetFullPath(iconPath)
                : executable + ",0";

            using (RegistryKey machine = OpenMachineKey(true))
            {
                using (RegistryKey classes = machine.CreateSubKey(ClassesPath))
                {
                    WriteKey(classes, @"AllFileSystemObjects\shell\SharpCompress", new Dictionary<string, string>
                    {
                        { "MUIVerb", "SharpCompress" },
                        { "MultiSelectModel", "Player" },
                        { "SubCommands", "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenSelection" },
                        { "Icon", icon }
                    });
                    DeleteTree(classes, @"Directory\shell\SharpCompressBrowse");
                    WriteKey(classes, @"Directory\Background\shell\SharpCompress", new Dictionary<string, string>
                    {
                        { "MUIVerb", "SharpCompress" },
                        { "SubCommands", "KrDev.SharpCompress.OpenHere;|;KrDev.SharpCompress.CompressHere" },
                        { "Icon", icon }
                    });

                    foreach (string extension in ArchiveExtensions)
                    {
                        string associationPath = @"SystemFileAssociations\" + extension + @"\shell\";
                        DeleteTree(classes, associationPath + "SharpCompressExtract");
                        WriteKey(classes, associationPath + "SharpCompress", new Dictionary<string, string>
                        {
                            { "MUIVerb", "SharpCompress" },
                            { "MultiSelectModel", "Player" },
                            { "SubCommands", "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection" },
                            { "Icon", icon }
                        });
                    }
                }

                using (RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                    Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32))
                using (RegistryKey userClasses = currentUser.CreateSubKey(ClassesPath))
                    DeleteTree(userClasses, @"Directory\shell\SharpCompressBrowse");

                using (RegistryKey commandStore = machine.CreateSubKey(CommandStorePath))
                {
                    DeleteTree(commandStore, "KrDev.SharpCompress.OpenFolder");
                    foreach (CommandDefinition command in Commands)
                    {
                        string id = "KrDev.SharpCompress." + command.Id;
                        WriteKey(commandStore, id, new Dictionary<string, string>
                        {
                            { "MUIVerb", command.Label },
                            { "MultiSelectModel", command.SelectionModel }
                        });
                        WriteDefaultValue(commandStore, id + @"\command", Quote(executable) + " " + command.Arguments);
                    }
                }
            }

            NotifyShell();
        }

        internal static void RemoveMachineIntegration()
        {
            EnsureAdministrator();
            using (RegistryKey machine = OpenMachineKey(true))
            {
                using (RegistryKey classes = machine.CreateSubKey(ClassesPath))
                {
                    DeleteTree(classes, @"AllFileSystemObjects\shell\SharpCompress");
                    DeleteTree(classes, @"Directory\shell\SharpCompressBrowse");
                    DeleteTree(classes, @"Directory\Background\shell\SharpCompress");
                    foreach (string extension in ArchiveExtensions)
                    {
                        DeleteTree(classes, @"SystemFileAssociations\" + extension + @"\shell\SharpCompressExtract");
                        DeleteTree(classes, @"SystemFileAssociations\" + extension + @"\shell\SharpCompress");
                    }
                }
                using (RegistryKey currentUser = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                    Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32))
                using (RegistryKey userClasses = currentUser.CreateSubKey(ClassesPath))
                    DeleteTree(userClasses, @"Directory\shell\SharpCompressBrowse");
                using (RegistryKey commandStore = machine.CreateSubKey(CommandStorePath))
                {
                    foreach (CommandDefinition command in Commands)
                        DeleteTree(commandStore, "KrDev.SharpCompress." + command.Id);
                    DeleteTree(commandStore, "KrDev.SharpCompress.OpenFolder");
                }
            }
            NotifyShell();
        }

        internal static void StartElevatedRepair(string iconPath)
        {
            string args = "/repair-shell " + Quote(iconPath ?? string.Empty);
            StartElevated(args);
        }

        internal static void StartElevatedRemoval()
        {
            StartElevated("/remove-shell");
        }

        private static void StartElevated(string arguments)
        {
            var start = new ProcessStartInfo(Application.ExecutablePath, arguments)
            {
                UseShellExecute = true,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = Application.StartupPath
            };
            using (Process process = Process.Start(start))
            {
                if (process == null) throw new InvalidOperationException("No se pudo iniciar la reparación elevada.");
                process.WaitForExit();
                if (process.ExitCode != 0)
                    throw new InvalidOperationException("Windows no pudo actualizar las claves del menú contextual. Consulta el registro de errores.");
            }
        }

        private static RegistryKey OpenMachineKey(bool writable)
        {
            RegistryView view = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view);
        }

        private static void WriteKey(RegistryKey parent, string path, IDictionary<string, string> values)
        {
            using (RegistryKey key = parent.CreateSubKey(path))
            {
                foreach (KeyValuePair<string, string> value in values)
                    key.SetValue(value.Key, value.Value, RegistryValueKind.String);
            }
        }

        private static void WriteDefaultValue(RegistryKey parent, string path, string value)
        {
            using (RegistryKey key = parent.CreateSubKey(path))
                key.SetValue(string.Empty, value, RegistryValueKind.String);
        }

        private static void DeleteTree(RegistryKey parent, string path)
        {
            parent.DeleteSubKeyTree(path, false);
        }

        private static string Quote(string value)
        {
            return "\"" + (value ?? string.Empty).Replace("\"", "\\\"") + "\"";
        }

        private static void EnsureAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                    throw new UnauthorizedAccessException("Se requieren permisos de administrador para cambiar el menú contextual global.");
            }
        }

        private static void NotifyShell()
        {
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        [DllImport("shell32.dll")]
        private static extern void SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
    }
}
