# Developer Tools

Similer to [layer0](layer0.md), the Z+ developer tools are designed as an executable with multiple feature plugins (found in the `Plugins/` folder).  The following executables exist:

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