# BIOS

Similar to other devices, Ruyi has BIOS firmware.

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

__Important__

The BIOS version __must__ match the [Ruyi OS](os.md) version because the BIOS must be paired with a compatible AMD driver.

| BIOS Version/Date | Ruyi OS Version | AMD Driver Stack Version/Date
|-|-|-
| [0.13](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220013.zip) | 0.6 | 0.0.9.0 2018/2/2
| [0.11](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220011.zip) | 0.5 | 0.0.7.4 2018/1/5
| [0.10](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220010.zip) 2018/1/15 | 0.4 | 0.0.7.4 2018/1/5
| [0.09](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220009.zip) 2018/1/8 | 0.3 | 0.0.7.2 2017/12/15
| 0.08 2018/1/2 | 0.3 | 0.0.7.2 2017/12/15

Also see:

- How to check the [Ruyi OS verison](os.md#Version)
- [OS Image download](http://dev.playruyi.com/uservices)

## Flashing the BIOS

The BIOS can be flashed from Windows (the preferred method) or via EFI shell with thumb drive.

![](/docs/img/warning.png) [BIOS](bios.md) updates should only be done from [Ruyi OS](os.md).  Make sure you are __not__ in [PC mode](pc_mode.md) before updating the BIOS.

__Flash under Windows__

Available BIOS v0.13 and later:

1. In [Command Prompt with administrator rights](https://technet.microsoft.com/en-us/library/cc947813(v=ws.10).aspx) run: `manage-bde.exe -protectors -disable c:`
    - This temporarily disables Bitlocker.  __Failure to do this results in an unbootable OS__ due to lost encryption data in TPM chip.
1. Download the [latest BIOS zip file](https://bitbucket.org/playruyi/support/src/master/files/bios/)
1. Extract the zip file and locate \Winflash\ folder
1. Run DA22XXXX.exe to flash BIOS
    - BIOS 0.16 and later: machine will freeze for a few minutes and become responsive when ready.  Restart machine if it doesn't automatically.
    - BIOS 0.13 to 0.15: a GUI window will appear

__Flash with EFI shell__

_We recommend flashing the BIOS under Windows instead of via EFI Shell_

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
1. Plug USB flash drive into any Ruyi's USB ports and reboot it
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