# PC模式

从[Ruyi系统](os.md)v0.6开始, Ruyi主机可以开机启动进入Win10的桌面系统，这就是“PC模式”。

PC模式和Ruyi模式很接近。相同版本的Windows，只不过部分安全性相关的软件被禁用了(Bitlocker, Device Guard Code Integrity等等)。

![](/docs/img/warning.png) [BIOS](bios.md)升级只能在[Ruyi系统](os.md)下进行。确保在升级BIOS之前 __不在__ [PC模式](pc_mode.md)。

## 模式切换

可以在Ruyi模式和PC模式之前相互切换。

__使用 Administrator__账户 运行 `SwitchOS.cmd` (可以在桌面上找到)，然后重启。

## 设置默认语言

1. 打开 __开始菜单(Start Menu)__ 选择 __设置(Settings)__   
    ![](/docs/img/os_lang_settings.png)
1. 选择 __时间&语言(Time & Language)__  
    ![](/docs/img/os_lang_time_lang.png)
1. 选择 __区域&语言(Region & Language)__ 和 __添加语言(Add a language)__  
    ![](/docs/img/os_lang_region_add.png)
1. 选择需要的语言  
    ![](/docs/img/os_lang_add.png)
1. 点击 __设置为默认(Set as default)__  
    ![](/docs/img/os_lang_default.png)
1. 重启机器

## 开发

PC模式的存在使得在Ruyi主机上开发游戏更为方便。安装Visual Studio(注意[VS2017无法在LTSB上使用](https://docs.microsoft.com/en-us/visualstudio/productinfo/vs2017-system-requirements-vs))，编译/调试和在普通PC上使用很接近。CPU/GPU/硬盘性能，内存配置，带宽，系统环境等等都和主机环境完全一样。