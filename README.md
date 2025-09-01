# Playnite Sounds Extension
![DownloadCountTotal](https://img.shields.io/github/downloads/ashpynov/PlayniteSound/total?label=total%20downloads&style=plastic) ![DownloadCountLatest](https://img.shields.io/github/downloads/ashpynov/PlayniteSound/latest/total?style=plastic) ![LatestVersion](https://img.shields.io/github/v/tag/ashpynov/PlayniteSound?label=Latest%20version&style=plastic) ![License](https://img.shields.io/github/license/ashpynov/PlayniteSound?style=plastic)

Playnite Sounds is an extension to play audio files during Playnite events.
It can only play WAV audio files and mp3 for music, nothing else.

[Latest Release](https://github.com/ashpynov/PlayniteSound/releases/latest)

## Local Development and Installation

Since this is a fork and not listed on the official Playnite addon list, you'll need to install it manually. Here's how to build and install the extension locally.

### Prerequisites

**⚠️ Windows Only**: This extension can only be built and run on Windows due to WPF and .NET Framework dependencies.

- **Windows 10/11**
- **Visual Studio 2019 or later** with .NET desktop development workload
- **.NET Framework 4.6.2 or later**
- **NuGet CLI tools** (usually included with Visual Studio)
- **Playnite** installed on your system ([Download here](https://playnite.link/))

### Building the Extension

1. **Clone this repository:**
   ```bash
   git clone https://github.com/felipecustodio/PlayniteSound.git
   cd PlayniteSound
   ```

2. **Restore NuGet packages:**
   ```bash
   nuget restore PlayniteSounds.sln
   ```
   *This may take 1-2 minutes. Do not cancel.*

3. **Build the extension:**
   ```bash
   msbuild PlayniteSounds.sln /p:Configuration=Release
   ```
   *This may take 2-3 minutes. Do not cancel.*

4. **Verify build output:**
   After successful build, you should find the compiled extension in `bin\Release\` containing:
   - `PlayniteSounds.dll` (main extension file)
   - `extension.yaml` (metadata)
   - `icon.png`
   - `Localization\` folder (translations)
   - `Sound Files\` folder (default audio files)
   - Other dependencies

### Installation Methods

#### Method 1: Using .pext Package (Recommended)

1. **Setup Playnite toolbox** (one-time setup):
   ```bash
   mkdir playnite
   Invoke-WebRequest -Uri "https://github.com/JosefNemec/Playnite/releases/download/9.16/Playnite916.zip" -OutFile "playnite\Playnite916.zip"
   Expand-Archive "playnite\playnite916.zip" -DestinationPath "playnite"
   ```

2. **Package the extension:**
   ```bash
   mkdir release
   playnite\toolbox.exe pack "bin\release" "release"
   ```

3. **Install the .pext file:**
   - Locate the generated `.pext` file in the `release\` folder
   - Double-click the `.pext` file, or
   - In Playnite: `Extensions` → `Install Extension` → Select the `.pext` file

#### Method 2: Manual Installation

1. **Locate Playnite extensions folder:**
   ```
   %APPDATA%\Playnite\Extensions\
   ```

2. **Create extension folder:**
   Create a new folder named `Playnite.Sounds.Mod.baf1744c-72f6-4bc1-92cc-474403b279fb`

3. **Copy files:**
   Copy all contents from `bin\Release\` to the extension folder created above.

4. **Restart Playnite:**
   Close and restart Playnite to load the extension.

### Verifying Installation

After installation, verify the extension is working:

1. **Check extension menu:**
   - In Playnite, go to `Extensions` → `Playnite Sounds`
   - You should see options like "Open Audio Files Folder", "Open Music Folder", etc.

2. **Check settings:**
   - Go to `Extensions` → `Playnite Sounds` → `Settings`
   - The settings window should open without errors

3. **Test audio (optional):**
   - Place some `.wav` or `.mp3` files in the Sound Files folder
   - Use `Extensions` → `Playnite Sounds` → `Reload Audio Files`
   - Audio should play during Playnite events

### Quick Build Script

You can use the included PowerShell script for faster development:

```bash
powershell.exe -ExecutionPolicy Bypass -File "Scripts\UpdatePlaynite.ps1"
```

This script builds and packages the extension automatically.

### Troubleshooting

**Build Issues:**
- **"MSBuild not found"**: Install Visual Studio with .NET desktop development workload
- **"PlayniteSDK not found"**: Run `nuget restore` first
- **"WPF not supported"**: This extension requires Windows

**Installation Issues:**
- **Extension not appearing**: Check that folder name matches exactly: `Playnite.Sounds.Mod.baf1744c-72f6-4bc1-92cc-474403b279fb`
- **Audio not playing**: Ensure Windows Media Player is installed (`Settings` → `Apps` → `Optional features` → `Windows Media Player`)
- **Settings not opening**: Check Playnite logs for errors in `%APPDATA%\Playnite\playnite.log`

**For Developers:**
- Use Visual Studio for full IDE experience with debugging
- Extension hot-reload: Copy new DLL to extension folder and restart Playnite
- Check `PlayniteSounds.cs` for the main plugin entry point

## If you feel like supporting
I do everything in my spare time for free, if you feel something aided you and you want to support me, you can always buy me a "koffie" as we say in dutch, no obligations whatsoever...

<a href='https://ko-fi.com/ashpynov' target='_blank'><img height='36' style='border:0px;height:36px;' src='https://cdn.ko-fi.com/cdn/kofi2.png?v=3' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>

If you may not use Ko-Fi in you country, it should not stop you! On [boosty](https://boosty.to/ashpynov/donate) you may support me and other creators.


## Audio Files

### Generic Info
There are 2 seperate set of sound files. Audio Files starting with 'D_' and files starting with 'F_'.
The 'D_' files are the audio files for desktop mode, the 'F_' files for fullscreen mode.
If you don't want to hear a certain file you can just delete the wav file of the event you don't want to hear.
You can also change the files with your own files. Be sure to use the 'Open Audio Files Folder' menu for doing so.
It will make sure loaded audio files get closed so you can overwrite them. Make sure playnite does not play any audio	anymore after opening the folder or it's possible you can't overwrite that specific file. With my testings it did seem you could still first erase the files. After changing the audio files use the 'Reload Audio Files' menu to clear any loaded files and use your new files, or just restart Playnite. Do NOT use a long audio file for ApplicationStopped as Playnite will not quit until that audio file has finished playing. The same applies for switching between desktop and fullscreen mode.

### Audio files that can be used
They are located in the sounds folder of the extension, you can open that folder using the main playnite menu -> Extensions -> Playnite sounds -> Open Audio Files Folder

| Event         | Desktop       | Fullscreen |
| ------------- |---------------|-------|
| Playnite Startup | D_ApplicationStarted.wav | F_ApplicationStarted.wav |
| Playnite Exit     | D_ApplicationStopped.wav | F_ApplicationStopped.wav |
| Game Installing | D_GameInstall.wav | F_GameInstall.wav |
| Game Installed | D_GameInstalled.wav | F_GameInstalled.wav |
| Game UnInstalled | D_GameUninstalled.wav | F_GameUninstalled.wav |
| Game Selected | D_GameSelected.wav |  F_GameSelected.wav |
| Game Starting | D_GameStarting.wav | F_GameStarting.wav |
| Game Started | D_GameStarted.wav | F_GameStarted.wav |
| Game Stopped | D_GameStopped.wav | F_GameStopped.wav |
| Game LibraryUpdated | D_LibraryUpdated.wav | F_LibraryUpdated.wav |

### Create your own Audio files
A very simple and free tool to create (game) sounds is SFXR, you can use it to create certain blip and blop sounds and perhaps use it to create your own sound files to be used with Playnite Sound extension. If you want to record your own sounds or edit existing sounds you could use audacity

SFXR: https://www.drpetter.se/project_sfxr.html

Audacity: https://www.audacityteam.org/

## Translation
The project is translatable on [Crowdin](https://crowdin.com/project/playnite-game-speak)

Thanks to the following people who have contributed with translations:
* Spanish: Darklinpower
* French: M0ylik
* Polish: Renia
* Italian: Federico Pezzuolo (3XistencE-STUDIO), StarFang208
* German: kristheb
* Hungarian: myedition8
* Porutgese, Brazillian: atemporal_ (Atemporal), JCraftPlay
* Ukrainian: SmithMD24
* Norwegian: MeatBoy
* Czech: SilverRoll (silveroll)
* Korean: Min-Ki Jeong
* Chinese Simplified: ATNewHope
* Arabic: X4Lo

## Credits
* Original Playnite Sound Plugin by [joyrider3774](https://github.com/joyrider3774)
* Used Icon made by [Freepik](http://www.freepik.com/)
* Original Localization file loader by [Lacro59](https://github.com/Lacro59)
* Sound Manager by [dfirsht](https://github.com/dfirsht)
* Downloader Manager by [cnapolit](https://github.com/cnapolit)

## Theme Integration
Extension expose custom control to manage Music playing: ```Sounds_MusicControl```. Using this control it is possible to:
* **Pause/Resume music** for example during trailer playback
* **Retrieve current Music filename** to show music title

### Show current Music name

Current Music filename (no path, no extension) is exposed via Content.CurrentMusicName property and {PluginSettings Plugin=Sounds Path=CurrentMusicName} you may use in via binding:

```xml
    <ContentControl x:Name="Sounds_MusicControl" />
    <TextBlock
        Text="{Binding ElementName=Sounds_MusicControl, Path=Content.CurrentMusicName}"
    />
```

or

```xml
    <TextBlock
        Text="{PluginSettings Plugin=Sounds, Path=CurrentMusicName}"
    />
```



### Pause/Resume during trailer playback
Theme may control music track via Tag property manipulation and pause Music on 'True' value and Resume on false.
<details>
  <summary>Here how it can be implemented in theme GameDetail.xaml</summary>

```xml
  <Style TargetType="{x:Type GameDetails}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type GameDetails}">
                    <Grid>
                        ...
                        <ContentControl x:Name="Sounds_MusicControl" />
                        ...
                    </Grid>
                    ...
                    <ControlTemplate.Triggers>
                        <DataTrigger
                            Binding="{Binding ElementName=ExtraMetadataLoader_VideoLoaderControl_NoControls_Sound, Path=Content.IsPlayerMuted, FallbackValue={StaticResource False}}"
                            Value="{StaticResource False}">
                            <Setter
                                Property="Tag"
                                Value="{Binding ElementName=ExtraMetadataLoader_VideoLoaderControl_NoControls_Sound, Path=Content.SettingsModel.Settings.IsVideoPlaying}"
                                TargetName="Sounds_MusicControl" />
                        </DataTrigger>

                        <DataTrigger
                            Binding="{Binding ElementName=ExtraMetadataLoader_VideoLoaderControl_NoControls_Sound, Path=Content.IsPlayerMuted, FallbackValue={StaticResource False}}"
                            Value="{StaticResource True}">
                            <Setter
                                Property="Tag"
                                Value="False"
                                TargetName="Sounds_MusicControl" />
                        </DataTrigger>

                        <DataTrigger
                            Binding="{Binding ElementName=PART_ElemGameDetails, Path=Visibility}"
                            Value="Collapsed">
                            <Setter
                                Property="Tag"
                                Value="False"
                                TargetName="Sounds_MusicControl" />
                        </DataTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
```
</details>
