# Developer Tools

Similer to [layer0](layer0.md), the developer tools are designed as an executable with multiple feature plugins (found in the `Plugins/` folder).  The following executables exist:

| Executable | Details | Image
|-|-|-
| RuyiDev.exe | Double-click or run _without_ an argument | ![](/docs/img/ruyidev_gui.png)
| RuyiDev.exe | Run with any argument (e.g. `RuyiDev.exe -h`) | ![](/docs/img/ruyidev_cli.png)

## Plugins

All plugins are used via `RuyiDev.exe <plugin> <arguments>`.
Assistance for any plugin is available via `RuyiDev.exe <plugin> -h`.

| Name | Functionality
|-|-
| API Tool | Process Thrift files and generate API (see [building SDK source](build_sdk_source.md))
| [App Runner](#app-runner) | Installation and starting/stopping of apps
| Localization Tool | 
| Setting Tool | Get/set configuration parameters
| Sign Tool | Sign applications
| TRC Tool | Both static and runtime checking of app conformance to Ruyi platform requirements

## App Runner

Applications can be installed, started, and stopped with App Runner.

1. Select __AppRunner__
1. __Host Address__: blank for local machine or ip address of console
1. __Working Channel__: always select `dev`
1. __App's RuyiManifest__: select the app's [`RuyiManifest.json`](app_metadata)
1. Press __Install App__ button and wait for installation to complete (duration depends on size of your application)
1. If successful, you should see your app listed in "Installed Apps" list
1. Select it and press __Run App__ button to launch it


- You can stop your app by selecting it from __Running Apps__ and pressing __Stop App__ button
- To uninstall an app, select it from __Installed Apps__ and press __Uninstall App__ button, note it can't be running if you want to uninstall it
- Press __Force Refresh__ to update __Running Apps__ and __Installed Apps__ lists
