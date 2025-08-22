# Playnite Sounds Extension

Playnite Sounds is a C# extension plugin for Playnite that plays audio files during Playnite events. It supports WAV and MP3 files for different events like game startup, shutdown, selection, etc.

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

## Working Effectively

**CRITICAL: This project can ONLY be built on Windows**. It uses WPF (Windows Presentation Foundation) and .NET Framework 4.6.2 which are Windows-specific technologies. Do not attempt to build on Linux/macOS.

### Prerequisites (Windows Only)
- Windows operating system
- Visual Studio 2019 or later with .NET desktop development workload
- .NET Framework 4.6.2 or later
- NuGet CLI tools
- Playnite application (for testing)

### Building the Extension
- `nuget restore PlayniteSounds.sln` -- restores NuGet packages, takes 1-2 minutes. NEVER CANCEL. Set timeout to 5+ minutes.
- `msbuild PlayniteSounds.sln /p:Configuration=Release` -- builds the extension, takes 2-3 minutes. NEVER CANCEL. Set timeout to 10+ minutes.

### Packaging for Distribution
- Download Playnite for toolbox.exe: `Invoke-WebRequest -Uri "https://github.com/JosefNemec/Playnite/releases/download/9.16/Playnite916.zip" -OutFile "playnite\Playnite916.zip"`
- Extract: `Expand-Archive "playnite\playnite916.zip" -DestinationPath "playnite"`
- Package: `playnite\toolbox.exe pack "bin\release" "release"` -- creates .pext file, takes 30 seconds. NEVER CANCEL. Set timeout to 2+ minutes.

### Testing the Extension
**MANUAL VALIDATION REQUIREMENT**: Testing must be done within Playnite application:
- Install Playnite from https://playnite.link/
- Copy built DLL and resources to Playnite extensions folder
- Launch Playnite and verify extension loads in Extensions menu
- Test key scenarios:
  - Extension appears in Extensions > Playnite Sounds menu
  - Audio files can be opened/managed via "Open Audio Files Folder"
  - Sound events work (requires audio files in Sound Files folder)
  - Settings UI opens without errors

## Validation

- Always build the extension using the exact commands above before making changes
- The extension targets .NET Framework 4.6.2 and uses WPF - these are Windows-only
- Manual testing requires Playnite installation and cannot be automated
- Audio playback testing requires actual sound files and working audio system
- No unit test infrastructure exists - testing is manual only

## Common Tasks

### Repository Structure
```
PlayniteSound/
├── .github/
│   └── workflows/build.yaml     # CI/CD for Windows builds
├── Common/                      # Utility classes (Dism.cs)
├── Controls/                    # WPF user controls
├── Downloaders/                 # Music download functionality
├── Localization/               # Translation files (multiple languages)
├── Models/                     # Data models and settings
├── Scripts/                    # PowerShell build scripts
├── Sound Files/                # Default audio files
├── ViewModels/                 # MVVM view models
├── Views/                      # WPF views/windows
├── PlayniteSounds.cs           # Main plugin class
├── PlayniteSounds.csproj       # Project file
├── PlayniteSounds.sln          # Solution file
├── extension.yaml              # Plugin metadata
└── README.md                   # Documentation
```

### Key Files and Their Purpose
- `PlayniteSounds.cs` - Main plugin entry point and core functionality
- `PlayniteSoundsSettingsViewModel.cs` - Settings management
- `extension.yaml` - Plugin metadata and configuration
- `Sound Files/` - Contains default audio files for various Playnite events
- `Localization/` - Translation files for multiple languages

### Build Artifacts
After successful build, find output in:
- `bin/Release/` - Contains compiled DLL and dependencies
- Built extension creates `PlayniteSounds.dll` and copies resources

### Common Build Issues
- **"MSBuild not found"** - Install Visual Studio with .NET desktop development workload
- **"WPF not supported"** - This happens on non-Windows systems. Build is Windows-only.
- **"PlayniteSDK not found"** - Run `nuget restore` first
- **Package restore fails** - Check internet connection and NuGet sources

### Extension Development Notes
- Plugin inherits from `GenericPlugin` (PlayniteSDK)
- Uses MVVM pattern with WPF
- Settings stored in `PlayniteSoundsSettings` model
- Audio playback via Windows MediaElement
- Supports multiple languages via Crowdin localization
- Downloads music from YouTube using yt-dlp (external dependency)

### Manual Workflow for Changes
1. Make code changes
2. Build: `msbuild PlayniteSounds.sln /p:Configuration=Release`
3. Copy `bin/Release/` contents to Playnite extensions folder (typically `%APPDATA%\Playnite\Extensions\`)
4. Restart Playnite to load changes
5. Test functionality through Playnite UI
6. Verify extension menu items work
7. Test audio playback (requires audio files)

### Dependencies and External Tools
- **PlayniteSDK 6.11.0** - Core plugin framework
- **HtmlAgilityPack** - HTML parsing for downloads
- **yt-dlp** - YouTube music downloads (optional external tool)
- **FFmpeg** - Audio processing (optional external tool)

### Cannot Do on Non-Windows Systems
- Build the project (requires WPF/.NET Framework)
- Test the extension (requires Playnite which is Windows-only)
- Package for distribution (requires Playnite toolbox.exe)
- Debug UI components (WPF designer requires Windows)

### Platform-Specific Instructions
**On Windows:**
- Use PowerShell or Command Prompt
- Visual Studio recommended for development
- Can use VS Code with C# extension for basic editing

**On Linux/macOS:**
- Can view/edit source code only
- Cannot build, test, or run the extension
- Use for documentation and non-build tasks only
- Document any issues to be tested later on Windows

### Troubleshooting
- **Audio not playing**: Check Sound Files folder has proper WAV/MP3 files
- **Extension not loading**: Verify all dependencies copied to extensions folder
- **Settings not saving**: Check Playnite permissions and settings file paths
- **Build errors**: Ensure all NuGet packages restored and .NET Framework installed