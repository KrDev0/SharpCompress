; SharpCompress Windows installer
#define MyAppName "SharpCompress"
#define MyAppVersion "1.2.1"
#define MyAppPublisher "KrDev"
#define MyAppURL "https://kr-dev.site/?app=sharpcompres"
#define MyAppExeName "SharpCompress.exe"

[Setup]
AppId={{C339D386-5B43-4767-8EA7-290322219D65}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\KrDev\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
UninstallDisplayIcon={app}\{#MyAppExeName}
PrivilegesRequired=admin
ArchitecturesAllowed=x86 x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
ChangesAssociations=yes
LicenseFile=..\..\..\LICENSE.txt
SetupIconFile=..\sharpCompress.ico
OutputDir=Output
OutputBaseFilename=SharpCompress_Setup_{#MyAppVersion}
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Files]
Source: "..\bin\Release\*"; DestDir: "{app}"; Excludes: "*.pdb,32.ico"; Flags: ignoreversion
Source: "..\sharpCompress.ico"; DestDir: "{app}"; Flags: ignoreversion

[Registry]
; Un único menú de compresión cubre archivos, carpetas y selecciones mixtas.
Root: HKA; Subkey: "Software\Classes\AllFileSystemObjects\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\AllFileSystemObjects\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\AllFileSystemObjects\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\AllFileSystemObjects\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\AllFileSystemObjects\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue

; La apertura de la selección también queda dentro del menú en cascada SharpCompress.

; Menú de fondo: abrir la ubicación o comprimir la carpeta actual en un solo paso.
Root: HKA; Subkey: "Software\Classes\Directory\Background\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\Directory\Background\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\Directory\Background\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.OpenHere;|;KrDev.SharpCompress.CompressHere"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\Directory\Background\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue

; Las opciones de extracción y apertura solo aparecen sobre extensiones de archivo comprimido.
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell"; Flags: uninsdeletekeyifempty
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.7z\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.7z\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.7z\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.7z\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.7z\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.scz\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.scz\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.scz\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.scz\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.scz\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zip\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zip\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zip\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zip\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zip\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rar\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rar\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rar\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rar\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rar\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.tar\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.tar\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.tar\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.tar\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.tar\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.gz\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.gz\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.gz\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.gz\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.gz\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.bz2\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.bz2\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.bz2\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.bz2\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.bz2\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.xz\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.xz\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.xz\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.xz\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.xz\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cab\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cab\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cab\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cab\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cab\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.wim\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.wim\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.wim\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.wim\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.wim\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzma\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzma\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzma\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzma\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzma\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.arj\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.arj\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.arj\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.arj\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.arj\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzh\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzh\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzh\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzh\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzh\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lha\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lha\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lha\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lha\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lha\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.iso\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.iso\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.iso\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.iso\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.iso\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.chm\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.chm\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.chm\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.chm\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.chm\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rpm\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rpm\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rpm\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rpm\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.rpm\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.deb\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.deb\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.deb\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.deb\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.deb\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cpio\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cpio\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cpio\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cpio\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.cpio\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.z\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.z\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.z\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.z\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.z\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzip\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzip\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzip\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzip\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lzip\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz4\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz4\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz4\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz4\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.lz4\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zst\shell\SharpCompress"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zst\shell\SharpCompress"; ValueType: string; ValueName: "MUIVerb"; ValueData: "SharpCompress"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zst\shell\SharpCompress"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zst\shell\SharpCompress"; ValueType: string; ValueName: "SubCommands"; ValueData: "KrDev.SharpCompress.CompressFiles;|;KrDev.SharpCompress.Files7z;KrDev.SharpCompress.FilesScz;KrDev.SharpCompress.FilesZip;KrDev.SharpCompress.FilesTar;|;KrDev.SharpCompress.OpenArchive;KrDev.SharpCompress.ExtractNamed;KrDev.SharpCompress.ExtractHere;|;KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\SystemFileAssociations\.zst\shell\SharpCompress"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName},0"; Flags: uninsdeletevalue

; Comandos de Explorer con selección y rutas citadas para Windows.
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.CompressFiles"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.CompressFiles"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Comprimir…"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.CompressFiles"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.CompressFiles\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /files ""%1"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.Files7z"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.Files7z"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Comprimir como 7z"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.Files7z"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.Files7z\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /f7z ""%1"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesScz"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesScz"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Comprimir como SCZ (SharpCompress)"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesScz"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesScz\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /fScz ""%1"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesZip"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesZip"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Comprimir como ZIP"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesZip"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesZip\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /fZip ""%1"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesTar"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesTar"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Comprimir como TAR"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesTar"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Player"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.FilesTar\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /fTar ""%1"""

Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenSelection"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenSelection"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Abrir con SharpCompress"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenSelection"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Single"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenSelection\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /open ""%1"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenArchive"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenArchive"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Abrir archivo"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenArchive"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Single"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenArchive\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /open ""%1"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.ExtractNamed"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.ExtractNamed"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Extraer en carpeta del archivo"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.ExtractNamed"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Single"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.ExtractNamed\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /extractTo ""%1"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.ExtractHere"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.ExtractHere"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Extraer aquí"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.ExtractHere"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Single"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.ExtractHere\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /extractHere ""%1"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenHere"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenHere"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Abrir ubicación"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenHere"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Single"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.OpenHere\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /openD ""%V"""
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.CompressHere"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.CompressHere"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Comprimir contenido aquí…"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.CompressHere"; ValueType: string; ValueName: "MultiSelectModel"; ValueData: "Single"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.CompressHere\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" /here ""%V"""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

[Run]
//Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait skipifsilent
Filename: "ms-settings:defaultapps?registeredAppMachine=SharpCompress"; Description: "Confirmar en Windows las asociaciones seleccionadas de SharpCompress"; Flags: postinstall shellexec skipifsilent; Check: HasSelectedArchiveAssociations

[Code]
var
  ArchiveDefaultsPage: TInputOptionWizardPage;
  ArchiveExtensions: TArrayOfString;
  ArchiveDefaultsButton: TNewButton;

procedure RemoveLegacyMenu(const RootKey: Integer; const SubKey: String);
var
  MenuName, IconPath: String;
begin
  if RegQueryStringValue(RootKey, SubKey, 'MUIVerb', MenuName) then
    if CompareText(MenuName, 'SharpCompress') = 0 then
      if RegQueryStringValue(RootKey, SubKey, 'Icon', IconPath) then
        if Pos('\sharpcompress\', Lowercase(IconPath)) > 0 then
          RegDeleteKeyIncludingSubkeys(RootKey, SubKey);
end;

procedure RemoveLegacyCommand(const RootKey: Integer; const SubKey: String);
var
  IconPath, CommandPath: String;
  IsProductCommand: Boolean;
begin
  IsProductCommand := False;
  if RegQueryStringValue(RootKey, SubKey, 'Icon', IconPath) then
    IsProductCommand := Pos('\sharpcompress\', Lowercase(IconPath)) > 0;
  if not IsProductCommand then
    if RegQueryStringValue(RootKey, SubKey + '\command', '', CommandPath) then
      IsProductCommand := Pos('\sharpcompress\', Lowercase(CommandPath)) > 0;
  if IsProductCommand then
    RegDeleteKeyIncludingSubkeys(RootKey, SubKey);
end;

procedure RemoveObsoleteProductCommand(const CommandName: String);
begin
  RegDeleteKeyIncludingSubkeys(HKLM,
    'SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\KrDev.SharpCompress.' + CommandName);
end;

procedure SelectRecommendedArchiveDefaults(Sender: TObject);
var
  I: Integer;
  Extension: String;
begin
  if ArchiveDefaultsPage = nil then Exit;
  for I := 0 to GetArrayLength(ArchiveExtensions) - 1 do
  begin
    Extension := ArchiveExtensions[I];
    ArchiveDefaultsPage.Values[I] :=
      (Extension = '.7z') or (Extension = '.scz') or (Extension = '.zip') or (Extension = '.rar') or
      (Extension = '.tar') or (Extension = '.gz') or (Extension = '.bz2') or
      (Extension = '.xz') or (Extension = '.cab');
  end;
end;

procedure InitializeWizard;
var
  I: Integer;
begin
  ArchiveExtensions := ['.7z', '.scz', '.zip', '.rar', '.tar', '.gz', '.bz2', '.xz', '.cab', '.wim',
    '.lz', '.lzma', '.arj', '.lzh', '.lha', '.iso', '.chm', '.rpm', '.deb', '.cpio',
    '.z', '.lzip', '.lz4', '.zst'];
  ArchiveDefaultsPage := CreateInputOptionPage(wpSelectTasks,
    'Formatos de archivos comprimidos',
    'Selecciona para qué formatos quieres registrar SharpCompress.',
    'Predeterminado marca los formatos más comunes. Al terminar, Windows abrirá la configuración para confirmar las asociaciones seleccionadas.',
    False, True);
  for I := 0 to GetArrayLength(ArchiveExtensions) - 1 do
    ArchiveDefaultsPage.Add(Uppercase(Copy(ArchiveExtensions[I], 2, Length(ArchiveExtensions[I]) - 1) + ' (' + ArchiveExtensions[I] + ')'));

  ArchiveDefaultsButton := TNewButton.Create(WizardForm);
  ArchiveDefaultsButton.Parent := ArchiveDefaultsPage.Surface;
  ArchiveDefaultsButton.Caption := 'Predeterminado';
  ArchiveDefaultsButton.Width := ScaleX(120);
  ArchiveDefaultsButton.Height := ScaleY(23);
  ArchiveDefaultsButton.SetBounds(
    ArchiveDefaultsPage.SurfaceWidth - ArchiveDefaultsButton.Width,
    ArchiveDefaultsPage.SurfaceHeight - ArchiveDefaultsButton.Height,
    ArchiveDefaultsButton.Width,
    ArchiveDefaultsButton.Height);
  ArchiveDefaultsButton.Anchors := [akRight, akBottom];
  ArchiveDefaultsButton.OnClick := @SelectRecommendedArchiveDefaults;

  ArchiveDefaultsPage.CheckListBox.Anchors := [akLeft, akTop, akRight];
  ArchiveDefaultsPage.CheckListBox.Height :=
    ArchiveDefaultsButton.Top - ScaleY(6) - ArchiveDefaultsPage.CheckListBox.Top;
end;

function HasSelectedArchiveAssociations: Boolean;
var
  I: Integer;
begin
  Result := False;
  if ArchiveDefaultsPage = nil then Exit;
  for I := 0 to GetArrayLength(ArchiveExtensions) - 1 do
    if ArchiveDefaultsPage.Values[I] then
    begin
      Result := True;
      Exit;
    end;
end;

procedure RegisterArchiveDefaults;
var
  I, SelectedCount: Integer;
  Extension, ProgId, Executable, CapabilitiesPath: String;
begin
  CapabilitiesPath := 'Software\KrDev\SharpCompress\Capabilities';
  Executable := ExpandConstant('{app}\{#MyAppExeName}');
  SelectedCount := 0;
  if ArchiveDefaultsPage = nil then Exit;
  for I := 0 to GetArrayLength(ArchiveExtensions) - 1 do
    if ArchiveDefaultsPage.Values[I] then
      SelectedCount := SelectedCount + 1;

  RegDeleteKeyIncludingSubkeys(HKLM, CapabilitiesPath);
  RegDeleteValue(HKLM, 'Software\RegisteredApplications', '{#MyAppName}');
  if SelectedCount = 0 then Exit;

  RegWriteStringValue(HKLM, CapabilitiesPath, 'ApplicationName', '{#MyAppName}');
  RegWriteStringValue(HKLM, CapabilitiesPath, 'ApplicationDescription',
    'Abrir y administrar archivos comprimidos con SharpCompress.');
  RegWriteStringValue(HKLM, 'Software\RegisteredApplications', '{#MyAppName}', CapabilitiesPath);

  for I := 0 to GetArrayLength(ArchiveExtensions) - 1 do
  begin
    Extension := ArchiveExtensions[I];
    ProgId := 'KrDev.SharpCompress.' + Copy(Extension, 2, Length(Extension) - 1);
    if ArchiveDefaultsPage.Values[I] or RegKeyExists(HKLM, 'Software\Classes\' + ProgId) then
    begin
      if ArchiveDefaultsPage.Values[I] then
        RegWriteStringValue(HKLM, CapabilitiesPath + '\FileAssociations', Extension, ProgId);
      RegWriteStringValue(HKLM, 'Software\Classes\' + ProgId, '', 'SharpCompress archive (' + Extension + ')');
      RegWriteStringValue(HKLM, 'Software\Classes\' + ProgId, 'FriendlyTypeName',
        'SharpCompress archive (' + Extension + ')');
      RegWriteStringValue(HKLM, 'Software\Classes\' + ProgId + '\DefaultIcon', '', '"' + Executable + '",0');
      RegWriteStringValue(HKLM, 'Software\Classes\' + ProgId + '\shell\open\command', '',
        '"' + Executable + '" /open "%1"');
    end;
  end;
end;

procedure RemoveArchiveDefaults;
var
  Extensions: TArrayOfString;
  I: Integer;
  ProgId: String;
begin
  Extensions := ['.7z', '.scz', '.zip', '.rar', '.tar', '.gz', '.bz2', '.xz', '.cab', '.wim',
    '.lz', '.lzma', '.arj', '.lzh', '.lha', '.iso', '.chm', '.rpm', '.deb', '.cpio',
    '.z', '.lzip', '.lz4', '.zst'];
  for I := 0 to GetArrayLength(Extensions) - 1 do
  begin
    ProgId := 'KrDev.SharpCompress.' + Copy(Extensions[I], 2, Length(Extensions[I]) - 1);
    RegDeleteKeyIncludingSubkeys(HKLM, 'Software\Classes\' + ProgId);
  end;
  RegDeleteKeyIncludingSubkeys(HKLM, 'Software\KrDev\SharpCompress\Capabilities');
  RegDeleteValue(HKLM, 'Software\RegisteredApplications', '{#MyAppName}');
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  CommandIndex: Integer;
  ExtensionIndex: Integer;
  CommandStorePath: String;
begin
  if CurStep = ssPostInstall then
    RegisterArchiveDefaults;

  if CurStep = ssInstall then
  begin
    RemoveLegacyMenu(HKLM, 'Software\Classes\*\shell\Item0');
    RemoveLegacyMenu(HKLM, 'Software\Classes\Directory\shell\Item0');
    RemoveLegacyMenu(HKLM, 'Software\Classes\Directory\Background\shell\Item0');
    RemoveLegacyMenu(HKLM, 'Software\Classes\*\shell\SharpCompress');
    RemoveLegacyMenu(HKLM, 'Software\Classes\AllFileSystemObjects\shell\SharpCompress');
    RemoveLegacyMenu(HKLM, 'Software\Classes\Directory\shell\SharpCompress');
    RemoveLegacyMenu(HKLM, 'Software\Classes\Directory\Background\shell\SharpCompress');
    RemoveLegacyMenu(HKCU, 'Software\Classes\*\shell\Item0');
    RemoveLegacyMenu(HKCU, 'Software\Classes\Directory\shell\Item0');
    RemoveLegacyMenu(HKCU, 'Software\Classes\Directory\Background\shell\Item0');
    RemoveLegacyMenu(HKCU, 'Software\Classes\*\shell\SharpCompress');
    RemoveLegacyMenu(HKCU, 'Software\Classes\AllFileSystemObjects\shell\SharpCompress');
    RemoveLegacyMenu(HKCU, 'Software\Classes\Directory\shell\SharpCompress');
    RemoveLegacyMenu(HKCU, 'Software\Classes\Directory\Background\shell\SharpCompress');

    for ExtensionIndex := 0 to GetArrayLength(ArchiveExtensions) - 1 do
    begin
      RegDeleteKeyIncludingSubkeys(HKLM, 'Software\Classes\SystemFileAssociations\' + ArchiveExtensions[ExtensionIndex] + '\shell\SharpCompressExtract');
      RegDeleteKeyIncludingSubkeys(HKCU, 'Software\Classes\SystemFileAssociations\' + ArchiveExtensions[ExtensionIndex] + '\shell\SharpCompressExtract');
    end;

    CommandStorePath := 'SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\';
    for CommandIndex := 0 to 13 do
      RemoveLegacyCommand(HKLM, CommandStorePath + 'Item' + IntToStr(CommandIndex));

    RemoveObsoleteProductCommand('OpenFolder');
    RemoveObsoleteProductCommand('CompressFolder');
    RemoveObsoleteProductCommand('FolderTar');
    RemoveObsoleteProductCommand('FolderGzip');
    RemoveObsoleteProductCommand('FolderZip');
    RemoveObsoleteProductCommand('FolderSevenZip');
    RemoveObsoleteProductCommand('HereTar');
    RemoveObsoleteProductCommand('HereGzip');
    RemoveObsoleteProductCommand('HereZip');
    RemoveObsoleteProductCommand('HereSevenZip');

    RegDeleteKeyIncludingSubkeys(HKLM, 'Software\Classes\Directory\shell\SharpCompressOpen');
    RegDeleteKeyIncludingSubkeys(HKCU, 'Software\Classes\Directory\shell\SharpCompressOpen');
    RegDeleteKeyIncludingSubkeys(HKLM, 'Software\Classes\Directory\shell\SharpCompressBrowse');
    RegDeleteKeyIncludingSubkeys(HKCU, 'Software\Classes\Directory\shell\SharpCompressBrowse');
  end;
end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if CurUninstallStep = usPostUninstall then
    RemoveArchiveDefaults;
end;
