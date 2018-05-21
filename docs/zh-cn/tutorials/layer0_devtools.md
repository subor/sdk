# 启动平台及使用开发者工具

## 前提条件

- [注册成为Ruyi开发者及安装开发环境](../topics/dev_onboarding.md)
- [安装SDK及访客身份登陆](setup.md)

## 开发者工具

所有的[开发者工具](../topics/devtool.md)都可以通过运行`DevTools/RuyiDev.exe`使用.

```
+---DevTools
|   |   RuyiDev.exe
|                       
+---Layer0
|   |   Layer0.exe
|                               
+---MainClient
|   |   Client.exe
|           
\---SDK
```

双击RuyiDev.exe来启动图形界面程序：
![](/docs/img/ruyidev_gui.png)

所有的插件都会在窗口左侧列出。

打开Windows的命令行窗口(左下角搜索窗输入cmd)，带参数运行RuyiDev.exe(比如`RuyiDev.exe -h`)来启动命令行界面(CLI):
![](/docs/img/ruyidev_cli.png)
	
所有插件均可通过`RuyiDev.exe <plugin> <arguments>`的命令格式来运行使用。
所有插件的帮助说明可以通过`RuyiDev.exe <plugin> -h`来访问。

比如, 运行`RuyiDev.exe settingtool -h`会输出:

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

## 显示当前设置

1. 运行`RuyiDev.exe`启动图形界面
1. 选择`Setting Tool`插件
1. _Format_栏选`simple`
1. 勾选`Console`
1. 点击`Run List`按钮
1. 输出界面会显示当前所有设置:

![](/docs/img/ruyidev_gui_settings_list.png)

也可以使用命令行:

1. 打开命令行窗口，运行`RuyiDev.exe -v verbose SettingTool --buttonlist --listformat=simple --listtoconsole=true`
1. 输出的信息类似图形界面：
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

## 更改设置参数

1. 得到当前“_静音_(_Mute_)”的参数值:

	> [12/29/2017 6:26:04 PM] [         SettingTool]  [      Info]    Mute false systemsetting
	
1. 运行`RuyiDev.exe -v verbose SettingTool --buttonset --setkey=Mute --setvalue=true --setmodule=systemsetting`把“_静音_(_Mute_)”值设置为__true__:
	
	> [12/29/2017 6:26:39 PM] [         SettingTool]  [      Info]    Set Mute to true result: True
	
1. 验证“_静音_(_Mute_)”值是否更新:
	
	> [12/29/2017 6:27:53 PM] [         SettingTool]  [      Info]    Mute true systemsetting