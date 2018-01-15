# Launching Platform and Using Devtools

## Prerequisites

- [Download and install the SDK](setup.md)

## Folder structure
```
+---DevTools
|   |   RuyiDev.exe
|   \---Ruyi
|       \---Presentation
|           \---Web
|               |   index.html
|                       
+---Layer0
|   |   Layer0.exe
|                               
+---MainClient
|   |   Client.exe
|           
\---SDK
    +---RuyiSDK
    |   \---netstandard2.0
    +---RuyiSDK.nf2.0
    \---RuyiSDKCpp
```

## Layer0

[Layer0](../topics/layer0.md) must be running on a host machine before you can access most of the Ruyi platform.

1. Run Layer0.exe  
![](/docs/img/layer0.png)
1. Register and login as a new user

## Developer tools

All [developer tools](../topics/devtool.md) are available via RuyiDev.exe.

Double-click RuyiDev.exe to launch the GUI:
![](/docs/img/ruyidev_gui.png)

All plugins are listed on the left side of the window.

Open a command prompt and run RuyiDev.exe with an option (e.g. `RuyiDev.exe -h`) to use the commandline interface (CLI):
![](/docs/img/ruyidev_cli.png)
	
All plugins are used via `RuyiDev.exe <plugin> <arguments>`.
Assistance for any plugin is available via `RuyiDev.exe <plugin> -h`.

For example, `RuyiDev.exe settingtool -h` outputs:

```
D:\git\jade\dev_tools\Main\bin\Debug>ruyidev.exe settingtool -h

Usage: 'RuyiDev [<Options>+] settingtool [<args>]'

      --commandline=VALUE      Input command line directly
      --buttonruncommand       Run the command line, required:
                               [CommandLine]
      --listformat=VALUE       The format of list result
      --listfilterby=VALUE     The filter by string used to filter result
      --listfilter=VALUE       The json file used to filter result
      --listtoconsole=VALUE    If output result to console
      --listtocapture=VALUE    Output result to which file
      --listhost=VALUE         Hostname or ip address of device for list.
                               Default: localhost
      --buttonlist             Run list command, required:
                               [ListFormat] [ListFilterBy] [ListFilter]
                               [ListToConsole] [ListToCapture] [ListHost]
      --setkey=VALUE           The key of item to set
      --setvalue=VALUE         The value of item to set
      --setmodule=VALUE        The module of item to set
      --sethost=VALUE          Hostname or ip address of device for set.
                               Default: localhost
      --buttonset              Run set command, required:
                               [SetKey] [SetValue] [SetModule] [SetHost]
      --playbackfile=VALUE     The file used to playback
      --playbackhost=VALUE     Hostname or ip address of device for playback.
                               Default: localhost
      --buttonplayback         Run playback command, required:
                               [PlaybackFile] [PlaybackHost]
```

## View Current Settings

1. Run `RuyiDev.exe` to launch the GUI
1. Select `Setting Tool` plugin
1. For _Format_ select `simple`
1. Enable `Console`
1. Click `Run List` button
1. Output will show all current settings:

![](/docs/img/ruyidev_gui_settings_list.png)

Alternatively:

1. From command prompt run `RuyiDev.exe -v verbose SettingTool --buttonlist --listformat=simple --listtoconsole=true`
1. Console output is similar to GUI:
```
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    Found setting amount: 22
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    ScreenShot null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIFocusUp null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIFocusDown null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIFocusLeft null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIFocusRight null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIAuxUp null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIAuxDown null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIAuxLeft null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIAuxRight null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIConfirm null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UICancel null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UISetting null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UIX null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    Mute false systemsetting
...
```

## Change setting value

1. Get current value of _Mute_:

	> [12/29/2017 6:26:04 PM] [         SettingTool]  [      Info]    Mute false systemsetting
	
1. Set _Mute_ to __true__ with `RuyiDev.exe -v verbose SettingTool --buttonset --setkey=Mute --setvalue=true --setmodule=systemsetting`:
	
	> [12/29/2017 6:26:39 PM] [         SettingTool]  [      Info]    Set Mute to true result: True
	
1. Verify value of _Mute_ changed:
	
	> [12/29/2017 6:27:53 PM] [         SettingTool]  [      Info]    Mute true systemsetting