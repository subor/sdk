# Ruyi OS

The operating system installed on the Ruyi console is a version of Windows 10 variably known as __Windows 10 IoT Enterprise__ or __Windows 10 Enterprise LTSB 2016__.  Note that this is __not__ the same as [Windows 10 IoT Core](https://developer.microsoft.com/en-us/windows/iot).   

Essentially, it is Windows 10:

* Fixed to RS1 update (aka Redstone 1, Anniversary Update, version 1607)
* With security features of Windows 10 Enterprise (i.e. [AppLocker](https://docs.microsoft.com/en-us/windows/security/threat-protection/applocker/applocker-overview), [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview), and [Device Guard](https://docs.microsoft.com/en-us/windows/security/threat-protection/device-guard/device-guard-deployment-guide))
* Without Microsoft Edge, Store, Cortana, and apps like Mail, Calendar, etc.

Together with our configuration, drivers, and shell it is __Ruyi OS__.

Some key changes we make relative to a normal Windows 10 environment:

* Drives (including `c:\`) encrypted with Bitlocker
* Numerous key combinations disabled (Ctrl-Alt-Del, Alt-tab, etc.)
* _UPCOMING_ Windows desktop shell replaced with Ruyi client UI
* _UPCOMING_ Device Guard Code Integrity enabled (now called Application Control)

A standard Windows Desktop environment is available via [PC mode](pc_mode.md).

## Version

__Checking Ruyi OS Version of Running Machine__

If version __0.7__ or later, check registry value of `HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Subor\MachineInfo`

For versions before __0.7__, check the top of `c:\windows\ad.log`:
```
Initial all Process on 02-05-2018 20:03:26
RUYI OS v0.5_20180205B
```

__Checking Ruyi OS Version of Install Media__

Check `<root>\sources\version.txt`:
```
v0.5_20180208
```

## Installation

![](/docs/img/warning.png) Flash the correct BIOS version __before__ installing the corresponding OS version (see [BIOS](bios.md)).

The OS is always installed to the [primary drive](harddrive.md).

Installation should take 20-40 minutes.

1. Prepare USB drive with at least 6 GB space and FAT32 format
1. Download [Ruyi OS image](http://dev.playruyi.com/uservices)
    - We only provide a link to the latest version.  If you need an older version, contact [support](support.md).
1. Copy OS files to root of bootable USB drive and eject/unmount once finished
1. Plug USB drive into system and reboot it
1. A Command Prompt should appear, wait while the OS installs
1. When prompted, remove the USB drive and press `Enter` to reboot and continue
    - During the remainder of the installation process the machine may reboot, open PowerShell/Command Prompt windows, or display a black screen several times
1. Once a Windows desktop with no visible applications appears, installation is complete

## Resources

* [Wikipedia article about Windows 10 editions](https://en.wikipedia.org/wiki/Windows_10_editions)
* [Download Windows 10 IoT Enterprise ISO](https://www.microsoft.com/en-us/evalcenter/evaluate-windows-10-enterprise)
