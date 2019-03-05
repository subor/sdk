# Ruyi/Z+ OS

The operating system installed on the Ruyi console is a version of Windows 10 variably known as __Windows 10 IoT Enterprise__ or __Windows 10 Enterprise LTSB 2016__.  Note that this is __not__ the same as [Windows 10 IoT Core](https://developer.microsoft.com/en-us/windows/iot).   

Essentially, it is Windows 10:

* Fixed to RS1 update (aka Redstone 1, Anniversary Update, version 1607)
* With security features of Windows 10 Enterprise (i.e. [AppLocker](https://docs.microsoft.com/en-us/windows/security/threat-protection/applocker/applocker-overview), [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview), and [Device Guard](https://docs.microsoft.com/en-us/windows/security/threat-protection/device-guard/device-guard-deployment-guide))
* Without Microsoft Edge, Store, Cortana, and apps like Mail, Calendar, etc.

Together with [our configuration](security.md), [drivers](drivers.md), and desktop shell it is __Ruyi OS or Z+ OS__.

A standard Windows Desktop environment is available via [PC mode](pc_mode.md).

## Version

__Checking OS Version of Running Machine__

- In client open __Settings > System > System Information__:  
    ![](/docs/img/version.png)
- If version __0.7__ or later, check registry value of `HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Subor\MachineInfo`
- For versions before __0.7__, check the top of `c:\windows\ad.log`:

        Initial all Process on 02-05-2018 20:03:26
        RUYI OS v0.5_20180205B


__Checking OS Version of Install Media__

Check `<root>\sources\version.txt`:
```
v0.5_20180208
```

## Installation

![](/docs/img/warning.png) Flash the correct BIOS version __before__ installing the corresponding OS version (see [BIOS](bios.md)).

The OS is always installed to the [primary drive](harddrive.md).

Installation should take 20-40 minutes.

1. Prepare bootable USB drive with at least __6__ GB space and FAT32 format
1. Download [Ruyi OS image](http://dev.playruyi.com/uservices)
    - We only provide a link to the latest version.  If you need an older version, contact [support](support.md).
1. Unzip OS files to root of bootable USB drive.  It should be similar to the following:  

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

1. Once copying/unzipping is finished, eject/unmount the USB drive.  Then plug the USB drive into the machine it should be installed to, and reboot that machine.
1. A Command Prompt should appear, wait while the OS installs
1. When prompted, remove the USB drive and press `Enter` to reboot and continue
    - During the remainder of the installation process the machine may reboot, open PowerShell/Command Prompt windows, or display a black screen several times
1. Once a Windows desktop with no visible applications appears, installation is complete

## Console Additional Runtime Components

The following components are available on the console as part of the OS installation:

| Component | Link | Notes
|-|-|-
Microsoft Sync Framework | [link](https://www.microsoft.com/en-us/download/details.aspx?id=19502) | Used to transfer builds from devtool on PC to console
Visual C++ Redistributable for VS 2008 | [x86](https://www.microsoft.com/en-us/download/details.aspx?id=29) and [x64](https://www.microsoft.com/en-us/download/details.aspx?id=15336) | Needed by some apps/games
Visual C++ Redistributable for VS 2010 | [x86](https://www.microsoft.com/en-us/download/details.aspx?id=5555) and [x64](https://www.microsoft.com/en-us/download/details.aspx?id=14632) | Needed by some apps/games
Visual C++ Redistributable for VS 2012 | [x86/x64](https://www.microsoft.com/en-us/download/details.aspx?id=30679) | Needed by some apps/games
Visual C++ Redistributable for VS 2013 | [x86/x64](https://www.microsoft.com/en-us/download/details.aspx?id=40784) | Needed by main client some apps/games
Visual C++ Redistributable for VS 2017 | [x86/x64](https://go.microsoft.com/fwlink/?LinkId=746572) | Needed by layer0 and some apps/games.  Also covers VS 2015.
Vulkan Runtime v1.0.54.0 | [x86/x64](https://vulkan.lunarg.com/sdk/home) | Needed by some apps/games
DirectX 9.0c End-User Runtime | [link](https://www.microsoft.com/en-us/download/details.aspx?id=34429) | Needed by some apps/games
.NET Framework 3.5 | [link](https://www.microsoft.com/en-us/download/details.aspx?id=22) | Needed by some apps/games


## Resources

* [Wikipedia article about Windows 10 editions](https://en.wikipedia.org/wiki/Windows_10_editions)
* [Download Windows 10 IoT Enterprise ISO](https://www.microsoft.com/en-us/evalcenter/evaluate-windows-10-enterprise)
