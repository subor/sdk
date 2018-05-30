# 开发者工具

和[layer0](layer0.md)类似, Ruyi开发者工具是一个可执行文件，它可以载入功能各异的插件(可在`Plugins/`文件夹中找到)。以下是运行方式:

| Executable | Details | Image
|-|-|-
| RuyiDev.exe | 直接双击或不附加参数运行'RuyiDev.exe' | ![](/docs/img/ruyidev_gui.png)
| RuyiDev.exe | 附加参数运行'RuyiDev.exe'(比如`RuyiDev.exe -h`) | ![](/docs/img/ruyidev_cli.png)
| RuyiShell.exe | 仅限于CLI

## 插件

在命令行运行`RuyiDev.exe <plugin> <arguments>`使用插件。
查看插件帮助信息`RuyiDev.exe <plugin> -h`。

| 名称 | 功能
|-|-
| API 工具 | 处理Thrift文件和生成API(参考[编译SDK源码](build_sdk_source.md))
| App Runner | 在主机上安装和运行/停止应用(游戏)
| Layer0 Debugger | 调试SDK API
| Localization Tool | 
| Setting Tool | 查看/设置配置参数
| TRC Tool | 检查应用是否符合在Ruyi平台上的TRC需求，支持静态和运行时查看