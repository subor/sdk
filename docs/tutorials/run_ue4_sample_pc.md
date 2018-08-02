# 在开发机上运行虚幻4示例程序

在本文中我们将安装一个基于[虚幻4](https://www.unrealengine.com/)引擎的示例程序到开发机上并运行。

## 前期条件
- Unreal 4.18.3
- Visual Studio 2017 (需要Win SDK 8.1以上)
- Ruyi主机或Win10的PC

## 以下所有步骤都应在您的开发机上完成：

1. [启动平台并登陆](layer0_devtools.md#Layer0)
2. [下载示例程序源码工程](https://bitbucket.org/playruyi/unreal_demo). 我们将其解压到`c:\ue4_demo\`.
3. 编译示例工程
4. 打包示例程序，更多信息参看[程序打包](how_to_pack.md)，我们默认打包后的文件放在`c:\ue4_pack\`目录下。
   也可以在命令行运行以下命令：
    ```
    ruyidev.exe apprunner --pack --apppath=c:\ue4_pack\
    ```
5. 安装程序:
    ```
    ruyidev.exe apprunner --installapp --workingchannellist=dev --installedapplist=com.playruyi.unreal_demo
    ```
6. 启动程序:
    ```
    ruyidev.exe apprunner --runapp --workingchannellist=dev --installedapplist=com.playruyi.unreal_demo
    ```
