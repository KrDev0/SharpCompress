#if UNMANAGED

namespace SevenZip
{
    using System;

    /// <summary>
    /// Describes an archive entry that could not be extracted.
    /// </summary>
    public sealed class FileExtractionFailedEventArgs : EventArgs
    {
        /// <summary>
        /// Creates details for a failed archive entry.
        /// </summary>
        public FileExtractionFailedEventArgs(string fileName, string errorMessage)
        {
            FileName = fileName ?? string.Empty;
            ErrorMessage = errorMessage ?? string.Empty;
        }

        /// <summary>
        /// Gets the archive entry name.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Gets the reason extraction failed.
        /// </summary>
        public string ErrorMessage { get; }
    }
}

#endif
