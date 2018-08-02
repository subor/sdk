# 在开发机上运行Unity3D示例程序

在本文中我们将安装一个基于[Unity3D](https://unity3d.com/)引擎的示例程序到开发机上并运行。

## 前期条件
- Unity 2017.1.1f1 (更高版本可能也可以运行)
- Ruyi主机或Win10的PC(示例程序没有在移动/Linux/OSX平台上测试过)

## 以下所有步骤都应在您的开发机上完成

1. 在开发机上, [启动平台并登陆](layer0_devtools.md#Layer0)
1. 得到开发机的IPv4地址。启动命令行窗口运行“ipconfig”（这里我们假设为“192.168.1.1”）。
1. [下载示例工程](https://bitbucket.org/playruyi/space_shooter)到本地主机(这里我们放到`d:\dev\unity_demo`文件夹下).
1. 下载并安装Ruyi插件
    - 从[下载列表](http://dev.playruyi.com/udownloadslist/SDK)下载DLL文件(下载RuyiSDK/RuyiSDK.nf2.0.zip链接)
    - 将解压出来的DLL文件放到d:\dev\unity_demo\Assets\Plugins\x64下
1. 启动Unity，打开位于`d:\dev\unity_demo`下的项目工程。
1. 在菜单栏，选择 __File->Build Settings__  
![](/docs/img/unity_build.png)
    - 选择 __PC, Mac & Linux Standalone__
    - _Target Platform_ 选择 `Windows`
    - _Architecture_ 选择 `x86_64`
    - 点击 __Build__ 按钮
    - 在弹出的文件对话框中，文件保存到`d:\dev\unity_demo\SpaceShooter\SpaceShooter\`, 文件名使用SpaceShooter.exe，点击__Save__按钮。
    - 完成后会在生成文件`d:\dev\unity_demo\SpaceShooter\SpaceShooter.exe`。
1. 打包示例程序到`d:\dev\unity_demo\SpaceShooter.zip`, 更多信息参看[程序打包](how_to_pack.md)，我们默认打包后的文件放在`d:\dev\unity_demo\SpaceShooter`目录下
    `ruyidev.exe apprunner --pack --apppath=d:\dev\unity_demo\SpaceShooter`
1. 安装程序:
    `ruyidev.exe apprunner --hostaddress=192.168.1.1 --installapp --workingchannellist=dev --selectedinstallapp=d:\dev\unity_demo\SpaceShooter.zip`
1. 启动程序:
    `ruyidev.exe apprunner --hostaddress=192.168.1.1 --runapp --workingchannellist=dev --installedapplist=SpaceShooter`