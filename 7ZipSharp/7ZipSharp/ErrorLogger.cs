using System;
using System.IO;
using System.Text;

namespace _7ZipSharp
{
    internal static class ErrorLogger
    {
        private static readonly object Sync = new object();

        internal static string LogPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "KrDev", "SharpCompress", "Logs", "errors.log");
            }
        }

        internal static void Write(Exception exception, string context)
        {
            if (exception == null) return;
            try
            {
                string path = LogPath;
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                string entry = string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff zzz}] {1}{2}{3}{2}{2}",
                    DateTimeOffset.Now, context ?? "Unhandled application error", Environment.NewLine, exception);
                lock (Sync) File.AppendAllText(path, entry, new UTF8Encoding(false));
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
        }
    }
}
