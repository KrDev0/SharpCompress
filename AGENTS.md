# Repository Guidelines

## Project Structure

`7ZipSharp/7ZipSharp/` is the .NET Framework 4.7.2 WinForms app; `MainForm.cs` hosts archive browsing, `ShellCommands.cs` classifies Explorer arguments, and `Services/ArchiveService.cs` handles archive operations. `7ZipSharp/ContextMenu/` contains Explorer integration; `setup/sharpSetup.iss` is the canonical installer and registry definition. The `.reg` files in `7ZipSharp/reg/` are legacy snapshots with fixed paths; do not import them as current configuration. `SevenZipSharp-dev/SevenZip/` is the library; NUnit tests and fixtures are in `SevenZipSharp-dev/SevenZip.Tests/`. Keep the root `LICENSE.txt` and `third-party-licenses/` notices synchronized with files shipped by the installer.

## Build and Test

Run from a Visual Studio Developer PowerShell on Windows:

```powershell
msbuild .\7ZipSharp\7ZipSharp.sln /restore /p:RestorePackagesConfig=true /p:RestoreConfigFile=NuGet.Config /p:Configuration=Release
msbuild .\7ZipSharp\7ZipSharp.sln /p:Configuration=Debug
msbuild .\7ZipSharp\7ZipSharp.sln /p:Configuration=Release
dotnet test .\SevenZipSharp-dev\SevenZip.Tests\SevenZip.Tests.csproj --configuration Debug
ISCC.exe .\7ZipSharp\7ZipSharp\setup\sharpSetup.iss
```

`NuGet.Config` restricts this repository's restores to nuget.org so machine-specific feeds do not affect the build. The first command restores SDK and `packages.config` dependencies through MSBuild. MSBuild compiles the desktop app and ContextMenu projects. `dotnet test` runs the library NUnit suite; the desktop app has no automated test project. The last command packages the Release output and requires Inno Setup 6. No dedicated formatter or linter is configured.

## Testing Guidelines

Library tests use NUnit `[TestFixture]` classes named `*Tests`, with `[Test]` or `[TestCase]`; fixtures are under `TestData/`. No coverage threshold is configured. Add focused regression cases for library changes.

## Code Style

Use four spaces, PascalCase for types and methods, and camelCase for locals and parameters. Keep WinForms event handlers focused on UI coordination; place archive behavior in `Services/`. The legacy app project uses explicit `<Compile>` entries, so add new source files to `7ZipSharp.csproj` as well as the filesystem.

Material buttons default to `AutoSize = false`; set their dimensions and anchors in the WinForms designer. Enable auto sizing only for controls that intentionally size themselves to their text.

## Archive and Windows Integration

Keep `7z.dll` and `7z64.dll` beside the app; runtime architecture selects the library. The installer uses the native registry view on x64-compatible Windows and supports 32-bit Windows. Static Explorer selection commands use quoted `%1` with `MultiSelectModel=Player`; Windows can launch one process per selected item, so keep `Program.AggregateExplorerSelection` to batch them into one dialog. Do not replace this with `%*`. Folder-background commands use `%V`. Keep folder opening inside the SharpCompress cascade and remove the legacy standalone verb during repair/install. Review registry paths, quoting, and uninstall behavior when changing shell integration.

The `.scz` extension is SharpCompress's branded 7z profile, not a new codec: it must continue using `OutArchiveFormat.SevenZip` so LZMA2, AES-256, encrypted headers, volumes, SFX, and content-based archive readers remain compatible. Keep `.scz` synchronized across the format selector, archive detection/open filters, context-menu commands, installer associations/default-format lists, and README. Never claim a universal compression-ratio advantage.

Long compression and extraction run on worker tasks. Compression checks cancellation while validating inputs, enumerating source trees, and between archive entries; temporary output must be removed when an operation stops.

## Commits and Pull Requests

Existing commit subjects are short and direct, mostly Spanish (for example, `Agregar archivos de proyecto.`). Keep commits focused and use the repository’s language consistently. Pull requests should explain user-visible behavior, include build/test results, link related issues, and add screenshots for UI changes. Call out installer, registry, dependency, or native DLL changes.

## Repository Memory

Read `MEMORY.md` at task start and update it at task end with current state and durable decisions. Keep it under 50 lines and never store secrets. Promote lasting contributor rules into this guide.
