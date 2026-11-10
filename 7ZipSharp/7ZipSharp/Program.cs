using _7ZipSharp;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

static class Program
{

    [STAThread]
    static void Main(string[] args)
    {
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += OnUiThreadException;
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (args.Length > 0 && string.Equals(args[0], "/repair-shell", StringComparison.OrdinalIgnoreCase))
        {
            try { ShellIntegrationManager.RepairMachineIntegration(args.Length > 1 ? args[1] : null); }
            catch (Exception ex) { ErrorLogger.Write(ex, "Repairing Windows Explorer integration"); Environment.ExitCode = 1; }
            return;
        }
        if (args.Length > 0 && string.Equals(args[0], "/remove-shell", StringComparison.OrdinalIgnoreCase))
        {
            try { ShellIntegrationManager.RemoveMachineIntegration(); }
            catch (Exception ex) { ErrorLogger.Write(ex, "Removing Windows Explorer integration"); Environment.ExitCode = 1; }
            return;
        }

        if (args.Length == 0)
        {
            Application.Run(new fm(null, "/personal"));
            return;
        }

        string[] folderModes = { "/here", "/com", "/comTar", "/comGz", "/comZip", "/com7z", "/comScz" };
        string[] fileModes = { "/files", "/fTar", "/fGz", "/fZip", "/f7z", "/fScz" };
        string mode = args.FirstOrDefault(argument =>
            folderModes.Contains(argument, StringComparer.OrdinalIgnoreCase) ||
            fileModes.Contains(argument, StringComparer.OrdinalIgnoreCase));

        if (mode != null)
        {
            string[] paths = args.Skip(Array.FindIndex(args, argument =>
                    string.Equals(argument, mode, StringComparison.OrdinalIgnoreCase)) + 1)
                .Where(path => !path.StartsWith("/", StringComparison.Ordinal) || File.Exists(path) || Directory.Exists(path))
                .Select(path => path.Trim('"'))
                .Where(path => File.Exists(path) || Directory.Exists(path))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            if (paths.Length > 0)
            {
                if (!string.Equals(mode, "/here", StringComparison.OrdinalIgnoreCase))
                    paths = AggregateExplorerSelection(mode, paths);
                if (paths.Length == 0) return;

                Application.Run(new CompressForm(paths, GetCompressionPreset(mode)));
            }
            else
            {
                ErrorLogger.Write(new InvalidOperationException("No valid Explorer inputs. Arguments: " + string.Join(" | ", args)),
                    "Parsing Explorer compression command");
                _7ZipSharp.Msg.AppMessage.Show("No se recibieron archivos o carpetas válidos para comprimir.", "SharpCompress",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return;
        }

        string extractMode = args.FirstOrDefault(argument =>
            new[] { "/ext", "/extractHere", "/extractTo" }.Contains(argument, StringComparer.OrdinalIgnoreCase));
        if (extractMode != null)
        {
            string archive = args.Skip(Array.FindIndex(args, argument =>
                    string.Equals(argument, extractMode, StringComparison.OrdinalIgnoreCase)) + 1)
                .Select(path => path.Trim('"'))
                .FirstOrDefault(File.Exists) ?? string.Empty;
            if (File.Exists(archive))
            {
                string outputDirectory = null;
                if (string.Equals(extractMode, "/extractHere", StringComparison.OrdinalIgnoreCase))
                    outputDirectory = Path.GetDirectoryName(Path.GetFullPath(archive));
                Application.Run(new extractF(archive, outputDirectory));
            }
            else
                _7ZipSharp.Msg.AppMessage.Show("Selecciona un archivo comprimido válido para extraer.", "SharpCompress",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (args.Contains("/open", StringComparer.OrdinalIgnoreCase) || args.Contains("/openD", StringComparer.OrdinalIgnoreCase))
        {
            string openMode = args.First(argument =>
                string.Equals(argument, "/open", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(argument, "/openD", StringComparison.OrdinalIgnoreCase));
            string target = args.Skip(Array.IndexOf(args, openMode) + 1).FirstOrDefault() ?? string.Empty;
            bool openDirectory = Directory.Exists(target) || string.Equals(openMode, "/openD", StringComparison.OrdinalIgnoreCase);
            Application.Run(new fm(target, openDirectory ? "/openD" : string.Empty));
        }
    }

    private static void OnUiThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        ErrorLogger.Write(e.Exception, "Unhandled UI-thread exception");
        _7ZipSharp.Msg.AppMessage.Show("Ocurrió un error inesperado. Se guardaron los detalles en el registro de la aplicación.",
            "SharpCompress", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Exception exception = e.ExceptionObject as Exception;
        if (exception != null) ErrorLogger.Write(exception, "Unhandled process exception");
    }

    private static void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
    {
        ErrorLogger.Write(e.Exception, "Unobserved background-task exception");
        e.SetObserved();
    }

    private static string GetCompressionPreset(string mode)
    {
        if (string.Equals(mode, "/fTar", StringComparison.OrdinalIgnoreCase) || string.Equals(mode, "/comTar", StringComparison.OrdinalIgnoreCase)) return "/fTar";
        if (string.Equals(mode, "/fGz", StringComparison.OrdinalIgnoreCase) || string.Equals(mode, "/comGz", StringComparison.OrdinalIgnoreCase)) return "/fGz";
        if (string.Equals(mode, "/fZip", StringComparison.OrdinalIgnoreCase) || string.Equals(mode, "/comZip", StringComparison.OrdinalIgnoreCase)) return "/fZip";
        if (string.Equals(mode, "/f7z", StringComparison.OrdinalIgnoreCase) || string.Equals(mode, "/com7z", StringComparison.OrdinalIgnoreCase)) return "/f7z";
        if (string.Equals(mode, "/fScz", StringComparison.OrdinalIgnoreCase) || string.Equals(mode, "/comScz", StringComparison.OrdinalIgnoreCase)) return "/fScz";
        return null;
    }

    // Explorer may start one process for each selected item even with Player.
    // Collect those invocations and let only the first process open the dialog.
    private static string[] AggregateExplorerSelection(string mode, string[] paths)
    {
        string queueDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KrDev", "SharpCompress", "ShellQueue");
        Directory.CreateDirectory(queueDirectory);
        string queueFile = Path.Combine(queueDirectory, "selection.txt");

        using (var queueLock = new Mutex(false, @"Local\KrDev.SharpCompress.SelectionQueue"))
        using (var batchLock = new Mutex(false, @"Local\KrDev.SharpCompress.SelectionBatch"))
        {
            bool isLeader;
            bool queueLockAcquired = false;
            try
            {
                try { queueLock.WaitOne(); queueLockAcquired = true; }
                catch (AbandonedMutexException) { queueLockAcquired = true; }

                try { isLeader = batchLock.WaitOne(0); }
                catch (AbandonedMutexException) { isLeader = true; }

                if (isLeader) File.WriteAllText(queueFile, string.Empty, Encoding.UTF8);
                using (var writer = new StreamWriter(queueFile, true, Encoding.UTF8))
                {
                    foreach (string path in paths)
                    {
                        string row = mode + "\t" + Path.GetFullPath(path);
                        writer.WriteLine(Convert.ToBase64String(Encoding.UTF8.GetBytes(row)));
                    }
                }
            }
            finally
            {
                if (queueLockAcquired) queueLock.ReleaseMutex();
            }

            if (!isLeader) return new string[0];

            try
            {
                DateTime batchStart = DateTime.UtcNow;
                DateTime lastUpdate = File.GetLastWriteTimeUtc(queueFile);
                while (DateTime.UtcNow - batchStart < TimeSpan.FromSeconds(4))
                {
                    Thread.Sleep(100);
                    DateTime currentUpdate = File.GetLastWriteTimeUtc(queueFile);
                    if (currentUpdate > lastUpdate) lastUpdate = currentUpdate;
                    else if (DateTime.UtcNow - lastUpdate >= TimeSpan.FromMilliseconds(800)) break;
                }

                string[] rows;
                queueLockAcquired = false;
                try { queueLock.WaitOne(); queueLockAcquired = true; }
                catch (AbandonedMutexException) { queueLockAcquired = true; }
                try
                {
                    rows = File.ReadAllLines(queueFile, Encoding.UTF8);
                    File.WriteAllText(queueFile, string.Empty, Encoding.UTF8);
                    batchLock.ReleaseMutex();
                }
                finally
                {
                    if (queueLockAcquired) queueLock.ReleaseMutex();
                }

                return rows.Select(row =>
                    {
                        try { return Encoding.UTF8.GetString(Convert.FromBase64String(row)); }
                        catch (FormatException) { return string.Empty; }
                    })
                    .Where(row => !string.IsNullOrWhiteSpace(row))
                    .Select(row => row.Substring(row.IndexOf('\t') + 1))
                    .Where(path => File.Exists(path) || Directory.Exists(path))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToArray();
            }
            catch
            {
                try { batchLock.ReleaseMutex(); } catch (ApplicationException) { }
                throw;
            }
        }
    }

}
