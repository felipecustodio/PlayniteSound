# Playnite Sounds Extension

Playnite Sounds is a C# extension plugin for Playnite that plays audio files during Playnite events. It supports WAV and MP3 files for different events like game startup, shutdown, selection, etc. The extension also supports downloading music from YouTube and provides custom controls for theme integration.

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
- Alternative: Open `PlayniteSounds.sln` in Visual Studio and build via IDE (Ctrl+Shift+B)

### Packaging for Distribution
- Create playnite directory: `mkdir playnite`
- Download Playnite for toolbox.exe: `Invoke-WebRequest -Uri "https://github.com/JosefNemec/Playnite/releases/download/9.16/Playnite916.zip" -OutFile "playnite\Playnite916.zip"` -- takes 1-2 minutes. NEVER CANCEL. Set timeout to 5+ minutes.
- Extract: `Expand-Archive "playnite\playnite916.zip" -DestinationPath "playnite"`
- Create release directory: `mkdir release`
- Package: `playnite\toolbox.exe pack "bin\release" "release"` -- creates .pext file, takes 30 seconds. NEVER CANCEL. Set timeout to 2+ minutes.
- Find packaged file: Look for `*.pext` files in the `release` folder

Alternative using UpdatePlaynite.ps1 script:
- `powershell.exe -ExecutionPolicy Bypass -File "Scripts\UpdatePlaynite.ps1"`

### Testing the Extension
**MANUAL VALIDATION REQUIREMENT**: Testing must be done within Playnite application:
- Install Playnite from https://playnite.link/
- Copy built DLL and resources to Playnite extensions folder: `%APPDATA%\Playnite\Extensions\Playnite.Sounds.Mod.{guid}\`
- Launch Playnite and verify extension loads in Extensions menu
- Test key scenarios:
  - Extension appears in Extensions > Playnite Sounds menu
  - "Open Audio Files Folder" opens the Sound Files directory
  - "Open Music Folder" functionality works
  - "Reload Audio Files" command executes without errors
  - Settings page (Extensions > Playnite Sounds > Settings) opens properly
  - Audio playback works (requires placing WAV/MP3 files in Sound Files folder)
  - Game menu items appear when right-clicking games

## Validation

- Always build the extension using the exact commands above before making changes
- The extension targets .NET Framework 4.6.2 and uses WPF - these are Windows-only
- Manual testing requires Playnite installation and cannot be automated
- Audio playback testing requires actual sound files and working audio system
- No unit test infrastructure exists - testing is manual only

## Verified Working Commands

These commands are validated to work based on the CI/CD pipeline (Windows only):

### Complete Build and Package Workflow
```powershell
# Restore packages
nuget restore PlayniteSounds.sln

# Build extension  
msbuild PlayniteSounds.sln /p:Configuration=Release

# Setup Playnite toolbox (one-time)
mkdir playnite
Invoke-WebRequest -Uri "https://github.com/JosefNemec/Playnite/releases/download/9.16/Playnite916.zip" -OutFile "playnite\Playnite916.zip"
Expand-Archive "playnite\playnite916.zip" -DestinationPath "playnite"

# Package extension
mkdir release
playnite\toolbox.exe pack "bin\release" "release"
```

**CRITICAL TIMING**: Each command above has specific timeout requirements:
- `nuget restore`: NEVER CANCEL, 5+ minute timeout
- `msbuild`: NEVER CANCEL, 10+ minute timeout  
- `Invoke-WebRequest`: NEVER CANCEL, 5+ minute timeout
- `toolbox.exe pack`: NEVER CANCEL, 2+ minute timeout

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
- `PlayniteSounds.cs` - Main plugin entry point, handles all Playnite events and menu items
- `PlayniteSoundsSettingsViewModel.cs` - Settings management and UI binding
- `PlayniteSoundsSettingsView.xaml` - Settings UI layout (WPF)
- `extension.yaml` - Plugin metadata (ID: Playnite.Sounds.Mod.baf1744c-72f6-4bc1-92cc-474403b279fb)
- `Sound Files/` - Default audio files for D_ (desktop) and F_ (fullscreen) events
- `Localization/` - Translation files for 15+ languages (managed via Crowdin)
- `Common/Dism.cs` - Windows Media Player feature enabler
- `Downloaders/` - YouTube music download functionality
- `MusicFader.cs` - Audio volume control and fading
- `MediaElementsMonitor.cs` - WPF MediaElement monitoring

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
2. Build: `msbuild PlayniteSounds.sln /p:Configuration=Release` -- NEVER CANCEL, takes 2-3 minutes, set timeout to 10+ minutes
3. Copy `bin/Release/` contents to Playnite extensions folder: `%APPDATA%\Playnite\Extensions\Playnite.Sounds.Mod.{guid}\`
4. Restart Playnite to load changes
5. Test functionality through Playnite UI:
   - Verify Extensions > Playnite Sounds menu appears
   - Test "Open Audio Files Folder" and "Open Music Folder" commands
   - Check settings UI loads without errors
   - Verify game context menu items appear
   - Test audio playback with sample files in Sound Files folder
6. For YouTube download testing: Configure yt-dlp and FFmpeg paths in settings

### Dependencies and External Tools
- **PlayniteSDK 6.11.0** - Core plugin framework (NuGet package)
- **HtmlAgilityPack 1.11.46** - HTML parsing for downloads (NuGet package)
- **System.Net.Http 4.3.4** - HTTP client functionality (NuGet package)
- **System.IO.Compression 4.3.0** - Archive handling (NuGet package)
- **yt-dlp** - YouTube music downloads (optional external executable)
- **FFmpeg** - Audio processing and normalization (optional external executable)
- **Windows Media Player** - Required for audio playback (can auto-install via DISM)

### Cannot Do on Non-Windows Systems
- Build the project (requires WPF/.NET Framework)
- Test the extension (requires Playnite which is Windows-only)
- Package for distribution (requires Playnite toolbox.exe)
- Debug UI components (WPF designer requires Windows)
- Validate audio functionality (Windows MediaElement dependency)

### Platform-Specific Instructions
**On Windows:**
- Use PowerShell or Command Prompt for build commands
- Visual Studio 2019+ recommended for full development experience
- Can use VS Code with C# extension for basic editing
- Install Windows Media Feature Pack if audio playback fails

**On Linux/macOS:**
- Can view/edit source code only
- Cannot build, test, or run the extension
- Use for documentation and non-build tasks only
- Document any issues to be tested later on Windows

### Expected Build Times and Timeouts
- **NuGet restore**: 1-2 minutes typical, set timeout to 5+ minutes
- **MSBuild**: 2-3 minutes typical, set timeout to 10+ minutes  
- **Playnite download**: 1-2 minutes depending on connection, set timeout to 5+ minutes
- **Extension packaging**: 30 seconds typical, set timeout to 2+ minutes
- **NEVER CANCEL** any build operation - .NET builds can appear to hang but are working

### Troubleshooting
- **Audio not playing**: Check Sound Files folder has proper WAV/MP3 files. Verify Windows Media Player is installed.
- **Extension not loading**: Verify all dependencies copied to extensions folder. Check Playnite logs for errors.
- **Settings not saving**: Check Playnite permissions and settings file paths in %APPDATA%
- **Build errors**: Ensure all NuGet packages restored and .NET Framework 4.6.2+ installed
- **"Media failed" errors**: Install Windows Media Player feature pack via Settings or manually
- **YouTube downloads fail**: Configure correct yt-dlp.exe path in extension settings
- **Audio normalization fails**: Configure correct FFmpeg path in extension settings
- **Missing translations**: Check Localization folder contains .json files for your language

## Quick Reference

### Essential Commands (Windows Only)
```powershell
# Build extension
nuget restore PlayniteSounds.sln
msbuild PlayniteSounds.sln /p:Configuration=Release

# Test build output
dir bin\Release\

# Package for distribution  
playnite\toolbox.exe pack "bin\release" "release"
```

### Key Directories
- `bin\Release\` - Build output
- `Sound Files\` - Default audio files 
- `Localization\` - Translation files
- `%APPDATA%\Playnite\Extensions\` - Installed extensions

### Remember
- **Windows only** - Cannot build/test on Linux/macOS
- **NEVER CANCEL** builds - Use generous timeouts
- **Manual testing required** - No automated tests exist
- **Audio files needed** - Extension needs WAV/MP3 files to function