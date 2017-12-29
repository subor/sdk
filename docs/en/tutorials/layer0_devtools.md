# Layer0 and Devtools

## Layer0

1. Run layer0.exe
	![](/img/layer0.png)

## Developer tools

All developer tools are available via RuyiDev.exe.  It's designed as an interface and one or more plugins (found in the `Plugins/` folder).

A GUI is available by running RuyiDev.exe:
![](/img/ruyidev_gui.png)

A commandline interface (CLI) is available by running RuyiDev.exe with an option (e.g. `RuyiDev.exe -h`):
![](/img/ruyidev_cli.png)
	
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

1. Select `Setting Tool` in GUI
1. For _Format_ select `simple`
1. Enable `Console`
1. Click `Run List` button
1. Output will show all current settings:

![](/img/ruyidev_gui_settings_list.png)

Alternatively:

1. Run `RuyiDev.exe -v verbose SettingTool --buttonlist --listformat=simple --listtoconsole=true`
1. Console output is the same:
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
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    VolumeUp null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    AudioVolume 20 systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    SpeakerVolume 20 systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    Language 0 systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    CommandLine "-help" systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    DevModeOn false systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    FileMappings null systemsetting
[12/29/2017 6:00:57 PM] [         SettingTool]  [      Info]    UnionMountsLayers null systemsetting
```

## Change setting value

1. Get current value of _Mute_:

	> [12/29/2017 6:26:04 PM] [         SettingTool]  [      Info]    Mute false systemsetting
	
1. Set _Mute_ with `RuyiDev.exe -v verbose SettingTool --buttonset --setkey=Mute --setvalue=true --setmodule=systemsetting`:
	
	> [12/29/2017 6:26:39 PM] [         SettingTool]  [      Info]    Set Mute to true result: True
	
1. Verify value of _Mute_ changed:
	
	> [12/29/2017 6:27:53 PM] [         SettingTool]  [      Info]    Mute true systemsetting