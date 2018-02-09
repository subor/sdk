# Ruyi OS

The operating system installed on the Ruyi console is a version of Windows 10 variably known as __Windows 10 IoT Enterprise__ or __Windows 10 Enterprise LTSB 2016__.  Note that this is __not__ the same as [Windows 10 IoT Core](https://developer.microsoft.com/en-us/windows/iot).

Essentially, it is Windows 10:

* Fixed to RS1 update (aka Redstone 1, Anniversary Update, version 1607)
* With security features of Windows 10 Enterprise (i.e. [AppLocker](https://docs.microsoft.com/en-us/windows/security/threat-protection/applocker/applocker-overview), [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview), and [Device Guard](https://docs.microsoft.com/en-us/windows/security/threat-protection/device-guard/device-guard-deployment-guide))
* Without Microsoft Edge, Store, Cortana, and apps like Mail, Calendar, etc.

Together with our configuration and drivers it is __Ruyi OS__.

## Version

To determine the version of Ruyi OS currently installed, check the top of `c:\windows\ad.log`:
```
Initial all Process on 02-05-2018 20:03:26
RUYI OS v0.5_20180205B
```

To determine the version of Ruyi OS on install media, check `<root>\sources\version.txt`:
```
v0.5_20180208
```

## Installation

![](/docs/img/warning.png) Flash the correct BIOS version __before__ installing the corresponding OS version (see [BIOS](bios.md)).

1. Prepare USB drive with at least 6 GB space and FAT32 format
1. Download [Ruyi OS image](http://dev.playruyi.com/uservices)
1. Copy OS files to root of USB drive and unmount once finished
1. Plug USB drive into system and reboot it
1. A command prompt should appear, wait 20-40 minutes for OS to install
    - Once Windows desktop appears installation is complete

## Resources

* [Wikipedia article about Windows 10 editions](https://en.wikipedia.org/wiki/Windows_10_editions)
* [Download Windows 10 IoT Enterprise ISO](https://www.microsoft.com/en-us/evalcenter/evaluate-windows-10-enterprise)
