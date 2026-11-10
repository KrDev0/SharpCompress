# SCZ archive profile

`.scz` is SharpCompress's branded archive extension. In this release it contains a standard 7z archive stream, created with the bundled 7-Zip engine. This gives the format immediate support for LZMA2 compression, AES-256 passwords, optional encrypted headers, split volumes, integrity verification, and Windows self-extracting output without implementing custom cryptography or an incompatible codec.

SCZ files can be opened by SharpCompress through the normal archive browser, extraction form, Explorer menu, and archive file association. The payload remains 7z; other 7z-capable tools can read it when they inspect the file contents or allow the user to select it explicitly. Split archives use the engine's numbered volume convention (for example, `.scz.001`, `.scz.002`). SFX output is a Windows `.exe` containing a 7z payload, not an `.scz` file.

SCZ does not promise to compress files better than 7z or every other format. Compression depends on the input: already-compressed, encrypted, or high-entropy files often have little room for further reduction. The Ultra level can improve some workloads at a cost in time and memory, but no fixed percentage applies to all data.

If a future release needs an independently versioned binary format, it should define and review a complete container specification first, including versioning, integrity, encryption, volume discovery, recovery behavior, and safe migration. Do not prepend private headers to this 7z-compatible profile without implementing and testing those readers across browsing, extraction, verification, SFX, and multi-volume operations.
