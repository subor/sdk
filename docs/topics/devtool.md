# Developer Tools

Similer to [layer0](layer0.md), the developer tools are designed as an executable with multiple feature plugins (found in the `Plugins/` folder).  The following executables exist:

| Executable | Details | Image
|-|-|-
| RuyiDev.exe | Double-click or run _without_ an argument | ![](/docs/img/ruyidev_gui.png)
| RuyiDev.exe | Run with any argument (e.g. `RuyiDev.exe -h`) | ![](/docs/img/ruyidev_cli.png)
| RuyiShell.exe | CLI only

## Plugins

All plugins are used via `RuyiDev.exe <plugin> <arguments>`.
Assistance for any plugin is available via `RuyiDev.exe <plugin> -h`.

| Name | Functionality
|-|-
| API Tool | Process Thrift files and generate API (see [building SDK source](build_sdk_source.md))
| App Runner | Installation and starting/stopping of apps
| Layer0 Debugger | Debug SDK API usage
| Localization Tool | 
| Setting Tool | Get/set configuration parameters
| TRC Tool | Both static and runtime checking of app conformance to Ruyi platform requirements

## App Runner

Applications can be packed, deployed, started, and stopped with App Runner.

1. Select __AppRunner__
1. __Host Address__: blank for local machine or ip address of console
1. __Working Channel__: always select `dev`
1. __App Root Folder__: select the folder containing `RuyiManifest.json`
1. Press __PackApp__ button and wait for it to complete (it depends on the size of your application)
1. __Select install App__: select the zip file output next to "App Root Folder"
1. Press __Install App__ button and wait for installation to complete (duration depends on size of your application)
1. If successful, you should see your game option in "Installed App List" options, then you can choose it, press "Run App" button, you should see your game running on the console


- You can stop your game by selecting it for __Running App__ and pressing __Stop App__ button
- To uninstall an application, select it from __Installed App List__ and press __Uninstall App__ button, note your game can't be running if your want to uninstall it
- each time you reopen AppRunner plugin in develop tool( RuyiDev.exe), you need to press "ForceRefresh" button to refresh all the installed game state
