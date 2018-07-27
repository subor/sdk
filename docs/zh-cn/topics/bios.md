# BIOS

和其他设备一样，Ruyi主机也有自己的BIOS固件。

## 版本

__查看主机BIOS版本__

- 开机时
    1. 按`F2`进入BIOS设置界面
    1. 进入__Setup Utility -> Main -> BIOS Version__

或者

- 已进入系统情况下
    1. 使用命令行(cmd)运行`msinfo32.exe`
    1. 查看__System Summary -> BIOS Version/Date__的值  
    ![](/docs/img/msinfo32_bios.png)

__查看安装镜像的BIOS版本__

如果安装文件名是`DA220013.zip`那么版本号是__0.13__。

查看`DA220REL.txt`文件顶部:
```
*   [Version]:
*   BIOS Version:  DA220013.rom (V0.13)
```

__重要__:

![](/docs/img/warning.png) BIOS版本 __必须__ 和[Ruyi系统](os.md)相匹配，因为BIOS是和相兼容的AMD驱动配对的。具体版本号匹配如下：
- 如果要从BIOS 0.09(或更低)版本升级到0.19(或更高)版本，必须先升级到BIOS版本号0.13和Ruyi系统版本号0.6，然后再升级到更高版本。

| BIOS 版本/日期 | Ruyi系统版本 | AMD驱动栈版本/日期
|-|-|-
| [0.20](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220020.zip) | 0.11 | 1.0.1.0 2018/5/2
| [0.19](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220019.zip) | 0.10 | 1.0.1.0 2018/4/17
| [0.13](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220013.zip) | 0.6 | 0.0.9.0 2018/2/2
| [0.11](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220011.zip) | 0.5 | 0.0.7.4 2018/1/5
| [0.10](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220010.zip) 2018/1/15 | 0.4 | 0.0.7.4 2018/1/5
| [0.09](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220009.zip) 2018/1/8 | 0.3 | 0.0.7.2 2017/12/15
| 0.08 2018/1/2 | 0.3 | 0.0.7.2 2017/12/15

因为Bios刷新过程有变更，请参考以下规则：  

| 安装的BIOS | 待刷新的BIOS | 规则
|-|-|-
| 0.09 (或之后) | 0.19 (或之后) | 首先更新到BIOS 0.13，系统更新到0.6。然后更新更高版本的BIOS/OS。

参考:

- 怎样查看[Ruyi系统版本](os.md#Version)
- [操作系统镜像下载](http://dev.playruyi.com/uservices)

## 刷新BIOS

可以在Windows系统下(推荐方法)，或使用装有EFI(Extensible Firmware Interface可扩展固件接口)内核的U盘刷新BIOS。

![](/docs/img/warning.png) 必须且仅能在[Ruyi系统](os.md)下更新[BIOS](bios.md)。从系统0.6版本开始，在更新之前请确保处于[主机模式]而非[PC模式](pc_mode.md)。

__在Windows下刷新BIOS__

BIOS v0.13或更高版本可参考以下步骤:

1. 在[拥有管理员(administrator)权限的命令行](https://technet.microsoft.com/en-us/library/cc947813(v=ws.10).aspx)下运行: `manage-bde.exe -protectors -disable c:`
    - 这条命令会暂时禁用Bitlocker。  __不执行这一步会导致操作系统无法启动__，这是由于TPM芯片里的加密数据丢失造成的。
1. 下载[最新版本BIOS的zip压缩文件](https://bitbucket.org/playruyi/support/src/master/files/bios/)
1. 解压文件，放到\Winflash\文件夹
1. 运行DA22XXXX.exe来刷新BIOS

刷新过程如下：

| 安装的BIOS版本 | 代刷新的BIOS版本 | 过程
|-|-|-
| 0.16以上 | | 机器会重启，出现BIOS安装界面，完成后机器重启。
| 0.15以下 | 0.16以上 | 机器会卡住几分钟，完成后可以正常响应。手动重启机器。
| 0.15以下 | 0.13到0.15 | 会出现一个图像界面

__使用EFI内核刷新__

_这种方法仅适合在没有任何已安装操作系统的情况下使用。我们推荐在Windows下刷新BIOS。_

首先，准备一个有刷新BIOS安装文件的USB安装盘：

1. 设置U盘文件格式为FAT32文件系统
1. 解压[EFI内核文件](https://bitbucket.org/playruyi/support/raw/master/files/bios/efi.zip)到U盘根目录
1. 解压[BIOS文件](https://bitbucket.org/playruyi/support/src/master/files/bios/)到U盘根目录

文件结构应该如下所示:
```
<USB root>
│
├───Shell
│       DA220010.rom
│       flash.nsh
│       H2OFFT-Sx64.efi
│       PLATFORM.INI
│
└───efi
    └───boot
            BOOTX64.efi
```

然后，在Ruyi主机上:

1. 如果已经安装Windows， 在[拥有管理员(administrator)权限的命令行](https://technet.microsoft.com/en-us/library/cc947813(v=ws.10).aspx)下运行: `manage-bde.exe -protectors -disable c:`
    - 这条命令会暂时禁用Bitlocker。  __不执行这一步会导致操作系统无法启动__，这是由于TPM芯片里的加密数据丢失造成的。
1. 把U盘插入Ruyi主机的任意U盘插口，重启主机
1. 等待EFI内核提示命令行界面:

       Shell>

1. U盘盘符名参考_设备映射表_
    - 盘符名应为`fs0`或`fs1`
    - 输入`fs0:`(或者`fs1:`)，按`Enter`，然后运行`dir`显示_Shell_文件夹在U盘上的位置
1. 修改U盘盘符名为`fs0:`(或者`fs1:`)，然后运行`cd shell`进入 _Shell_ 文件夹
1. 运行命令`flash.nsh`，开始刷新BIOS
    - 安装过程中会显示进度条
1. 安装过程应该在1分钟左右
1. 拔出U盘，重启机器

## 安装Ruyi系统

![](/docs/img/warning.png)安装Ruyi系统 __之前__ 请先确认与之匹配的BIOS版本。

参考[Ruyi系统安装说明](os.md#Installation).

## 资源文件

- [相关文件](https://bitbucket.org/playruyi/support/src/master/files/)