# Ruyi系统

Ruyi主机上所安装的操作系统是Win10,版本为__Windows 10 IoT Enterprise__或__Windows 10 Enterprise LTSB 2016__。注意和[Windows 10 IoT Core](https://developer.microsoft.com/en-us/windows/iot)并非同一版本。   

Ruyi主机的Win10有以下特点:

* 更新至RS1(又称为Redstone 1，年度更新，版本号1607)
* 拥有Win10企业版的安全保护功能(比如[AppLocker](https://docs.microsoft.com/en-us/windows/security/threat-protection/applocker/applocker-overview), [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview)，和[Device Guard](https://docs.microsoft.com/en-us/windows/security/threat-protection/device-guard/device-guard-deployment-guide))
* 没有Microsoft的Edge，Store，Cortana以及Mail，Calendar等应用。

这所有包括配置，驱动以及内核我们统称为__Ruyi系统__。

相对于普通Win10环境的几个关键修改点：

* 使用Bitlocker加密硬盘驱动（包括`c:\`）
* 禁用大量组合键（`Ctrl-Alt-Del`, `Alt-tab`等等）
* (_未来_)会使用Ruyi客户端UI取代Win桌面内核(Desktop)
* (_UPCOMING_)提供安全保护策略(Device Guard Code)集成(目前称为应用管理(Application Control))

标准Win桌面环境可以在[PC模式](pc_mode.md)下使用。

## 版本

__查看主机的Ruyi系统版本号__

如果是__0.7__或之后版本, 清查看注册表`HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Subor\MachineInfo`的键值。

__0.7__前的版本，查看`c:\windows\ad.log`中:
```
Initial all Process on 02-05-2018 20:03:26
RUYI OS v0.5_20180205B
```

__查看Ruyi系统安装镜像的版本号__

Check `<root>\sources\version.txt`:
```
v0.5_20180208
```

## 安装

![](/docs/img/warning.png) 在安装对应版本系统 __之前__ ，更新当前BIOS版本(参见[BIOS](bios.md)).

系统必须安装在[主硬盘驱动](harddrive.md).

安装过程需要20-40分钟。

1. 准备至少 __6__ GB空间和FAT32格式的USB驱动。
1. 下载[Ruyi系统镜像](http://dev.playruyi.com/uservices)
    - 我们只提供最新版本链接，如果需要更早版本，请联系[技术支持](support.md).
1. 解压系统安装文件到USB驱动盘的根目录。结构如下所示：  
    ```
    │   bootmgr
    │   bootmgr.efi
    │
    ├───Boot
    │   │   BCD
    │   │   boot.sdi
    │   │   bootfix.bin
    │   │   memtest.exe
    │   ├───Resources
    │
    ├───sources
    │       boot.wim
    │       dd.wim
    │       install.swm
    │       install2.swm
    │
    └───EFI
        ├───Boot
        │   │   bootx64.efi
        │   │   RUYIboot.efi
    ```
1. 复制/安装完成后，拔出USB。然后插入到需要安装的目标机器上，重启目标机器。
1. 出现命令行窗口，等待系统安装。
1. 出现以下提示时，移除USB，按下`Enter`键重启机器。
    - During the remainder of the installation process the machine may reboot, open PowerShell/Command Prompt windows, or display a black screen several times
1. 进入Win桌面，安装成功。

## 来源链接

* [关于Win10版本的维基百科](https://en.wikipedia.org/wiki/Windows_10_editions)
* [下载Windows 10 IoT 企业版镜像](https://www.microsoft.com/en-us/evalcenter/evaluate-windows-10-enterprise)
