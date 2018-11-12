# BIOS

Similar to other devices, the console has BIOS firmware.

Recent versions of the devkit as well as the retail console are pre-installed with the latest BIOS/OS.  The latest BIOS is also available from [release downloads](https://github.com/subor/sdk/releases).  Older versions are available from the old dev portal and on request.

This document will be removed in the future.

## Version

__Checking BIOS version of Running Machine__

- When machine starts
    1. Press `F2` to enter BIOS setup
    1. Enter __Setup Utility -> Main -> BIOS Version__

OR

- In Windows
    1. Run `msinfo32.exe`
    1. Inspect __System Summary -> BIOS Version/Date__ value  
    ![](/docs/img/msinfo32_bios.png)

__Checking BIOS version of Install Media__

If archive is named `DA220013.zip` then it is version __0.13__.

Check the top of the `DA220REL.txt` file:
```
*   [Version]:
*   BIOS Version:  DA220013.rom (V0.13)
```

__Important__:  

![](/docs/img/warning.png) Because the BIOS must be paired with a compatible AMD driver, the BIOS version __must__ be paried with the correct version of [the OS](os.md).  This is summarized as follows:  

| BIOS Version | Ruyi OS Version | AMD Driver Stack Version/Date
|-|-|-
| [1.02](https://github.com/subor/sdk/releases/download/v0.9.0.2440/BIOS_DA220102.zip) | 1.04/1.05 | 1.0.4.0 2018/7/10
| [1.01](https://github.com/subor/sdk/releases/download/v0.9.0.2440/BIOS_DA220101.zip) | 1.02 | 1.0.1.0 2018/5/31
| [1.00](https://github.com/subor/sdk/releases/download/legacy/DA220100.zip) | 1.02 | 1.0.1.0 2018/5/31
| 0.20 | 0.11 | 1.0.1.0 2018/5/2
| 0.19 | 0.10 | 1.0.1.0 2018/4/17
| [0.15](https://github.com/subor/sdk/releases/download/legacy/DA220015.zip) | 0.6 | 0.0.9.0 2018/3/12
| 0.13 | 0.6 | 0.0.9.0 2018/2/2
| 0.11 | 0.5 | 0.0.7.4 2018/1/5     
| 0.10 | 0.4 | 0.0.7.4 2018/1/5
| 0.09 | 0.3 | 0.0.7.2 2017/12/15
| 0.08 | 0.3 | 0.0.7.2 2017/12/15

Because the BIOS flashing process was changed, please observe the following rules:  

| Installed BIOS | BIOS to Flash | Rule
|-|-|-
0.15-0.20 | 1.01(or later) | __Winflash__: First update to __1.00__; and then update to more recent BIOS/OS.<br/>  __EFI flash__: 1. Disable Secure boot (F2->Secure Boot Option->Erase all Secure Boot Settings); and then update to __1.00__; At last, update to more recent BIOS/OS.
| 0.09-0.13 | 1.01 (or later) | __EFI flash__: First update to BIOS __0.15__, and then update to __1.00__; at last, update to more recent BIOS/OS.<br/>  __Winflash__: First update to __1.00__ (Machine will freeze for a few minutes, please wait.);  and then update to more recent BIOS/OS.


Also see:

- How to check the [OS verison](os.md#version)
- [OS Image download](http://dev.playruyi.com/uservices)

## Flashing the BIOS

The BIOS can be flashed from Windows (the preferred method) or via EFI shell with thumb drive.

![](/docs/img/warning.png) [BIOS](bios.md) updates cannot be done in [PC mode](pc_mode.md).  Starting with OS 0.6, make sure you are __not__ in PC mode before updating the BIOS.

__Flash under Windows__

Available BIOS v0.13 and later:

1. In [Command Prompt with administrator rights](https://technet.microsoft.com/en-us/library/cc947813(v=ws.10).aspx) run: `manage-bde.exe -protectors -disable c:`
    - This temporarily disables Bitlocker.  __Failure to do this results in an unbootable OS__ due to lost encryption data in TPM chip.
1. Download the [latest BIOS zip file](https://github.com/subor/sdk/releases)
1. Extract the zip file and locate `Winflash/` folder
1. Run `DA22XXXX.exe` to flash BIOS

Flashing will progress as follows:

| Installed BIOS | BIOS to Flash | Process
|-|-|-
| 0.16 and up | | Machine will reboot, BIOS install screen will appear, machine will reboot when finished.
| 0.15 or lower | 0.16 or higher | Machine will freeze for a few minutes and become responsive when finished.  Manually restart the machine.
| 0.15 or lower | 0.13 to 0.15 | A GUI window will appear

__Flash with EFI shell__

_This approach is only needed in situations where no OS is installed.  We recommend flashing the BIOS under Windows._

First, create USB flash drive:

1. Create bootable USB drive formatted with FAT32 filesystem
1. Unzip [EFI shell files](https://bitbucket.org/playruyi/support/raw/master/files/bios/efi.zip) to root of USB drive
1. Unzip [BIOS binaries](https://bitbucket.org/playruyi/support/src/master/files/bios/) to root of USB drive

Resulting directory structure should be similar to the following:
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

Next, on the Ruyi:

1. If Windows is already installed, in [Command Prompt with administrator rights](https://technet.microsoft.com/en-us/library/cc947813(v=ws.10).aspx) run: `manage-bde.exe -protectors -disable c:`
    - This temporarily disables Bitlocker.  __Failure to do this results in an unbootable OS__ due to lost encryption data in TPM chip.
1. Plug USB drive into any of Ruyi's USB ports and reboot it
1. Wait for EFI Shell prompt to appear:

       Shell>

1. Consult the _Device mapping table_ for the name of the USB drive
    - It should be `fs0` or `fs1`
    - Type `fs0:` (or `fs1:`) and press `Enter` then run `dir` to locate the _Shell_ folder on the USB drive
1. Change to USB drive with `fs0:` (or `fs1:`), then enter _Shell_ folder with `cd shell`
1. Start flashing the BIOS by running `flash.nsh`
    - A progress bar should be displayed during the flashing process
1. Wait around 1 minute for the flashing to complete
1. Remove the USB stick and reboot machine

## Installing Ruyi OS

![](/docs/img/warning.png) Flash the correct BIOS version __before__ installing the corresponding OS version.

See [Ruyi OS installation instructions](os.md#Installation).

## Resources

- [Support files](https://bitbucket.org/playruyi/support/src/master/files/)