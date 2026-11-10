using System;
using System.IO;
using System.Runtime.InteropServices;

namespace _7ZipSharp
{
    internal sealed class SelfExtractorOptions
    {
        internal string Title { get; set; }
        internal string InstallPath { get; set; }
        internal string BeginPrompt { get; set; }
        internal string RunProgram { get; set; }
        internal string IconPath { get; set; }
        internal bool ShowProgress { get; set; }

        internal static SelfExtractorOptions FromUserSettings()
        {
            var settings = Properties.Settings.Default;
            return new SelfExtractorOptions
            {
                Title = string.IsNullOrWhiteSpace(settings.SfxTitle) ? "SharpCompress - Archivo autoextraíble" : settings.SfxTitle,
                InstallPath = string.IsNullOrWhiteSpace(settings.SfxInstallPath) ? "." : settings.SfxInstallPath,
                BeginPrompt = settings.SfxBeginPrompt ?? string.Empty,
                RunProgram = settings.SfxRunProgram ?? string.Empty,
                IconPath = settings.SfxIconPath ?? string.Empty,
                ShowProgress = settings.SfxShowProgress
            };
        }
    }

    internal static class SelfExtractorIcon
    {
        private const int RtIcon = 3;
        private const int RtGroupIcon = 14;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr BeginUpdateResource(string fileName, bool deleteExistingResources);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool UpdateResource(IntPtr update, IntPtr type, IntPtr name,
            ushort language, byte[] data, uint dataSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool EndUpdateResource(IntPtr update, bool discard);

        internal static void Apply(string executablePath, string iconPath)
        {
            if (string.IsNullOrWhiteSpace(iconPath)) return;
            if (!File.Exists(iconPath)) throw new FileNotFoundException("No se encontró el icono SFX seleccionado.", iconPath);

            byte[] iconFile = File.ReadAllBytes(iconPath);
            if (iconFile.Length < 6 || BitConverter.ToUInt16(iconFile, 0) != 0 || BitConverter.ToUInt16(iconFile, 2) != 1)
                throw new InvalidDataException("El archivo seleccionado no es un icono ICO válido.");

            int count = BitConverter.ToUInt16(iconFile, 4);
            if (count == 0 || iconFile.Length < 6 + count * 16)
                throw new InvalidDataException("El archivo ICO no contiene imágenes válidas.");

            byte[] group = new byte[6 + count * 14];
            Buffer.BlockCopy(iconFile, 0, group, 0, 6);
            IntPtr update = BeginUpdateResource(executablePath, false);
            if (update == IntPtr.Zero) ThrowLastError("No se pudo abrir el ejecutable SFX para actualizar su icono.");

            bool completed = false;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    int sourceOffset = 6 + i * 16;
                    int groupOffset = 6 + i * 14;
                    uint imageSize = BitConverter.ToUInt32(iconFile, sourceOffset + 8);
                    uint imageOffset = BitConverter.ToUInt32(iconFile, sourceOffset + 12);
                    if (imageOffset > iconFile.Length || imageSize > iconFile.Length - imageOffset)
                        throw new InvalidDataException("El ICO contiene una imagen truncada.");

                    byte[] image = new byte[(int)imageSize];
                    Buffer.BlockCopy(iconFile, (int)imageOffset, image, 0, (int)imageSize);
                    ushort resourceId = (ushort)(0x7000 + i);
                    if (!UpdateResource(update, MakeResourceId(RtIcon), MakeResourceId(resourceId),
                        0, image, (uint)image.Length))
                        ThrowLastError("No se pudo insertar una imagen del icono en el SFX.");

                    Buffer.BlockCopy(iconFile, sourceOffset, group, groupOffset, 12);
                    byte[] id = BitConverter.GetBytes(resourceId);
                    Buffer.BlockCopy(id, 0, group, groupOffset + 12, 2);
                }

                if (!UpdateResource(update, MakeResourceId(RtGroupIcon), MakeResourceId(1),
                    0, group, (uint)group.Length))
                    ThrowLastError("No se pudo establecer el icono principal del SFX.");

                if (!EndUpdateResource(update, false)) ThrowLastError("No se pudieron guardar los recursos del SFX.");
                completed = true;
            }
            finally
            {
                if (!completed) EndUpdateResource(update, true);
            }
        }

        private static IntPtr MakeResourceId(int id) { return new IntPtr(id); }

        private static void ThrowLastError(string message)
        {
            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error(), message);
        }
    }
}
