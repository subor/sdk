# BIOS

Similar to other devices, the Ruyi box has BIOS firmware.

## Checking BIOS version

- When machine starts
    1. Press `F2` to enter BIOS setup
    1. Enter __Utility -> Main -> BIOS Version__

OR

- In Windows
    1. Run `msinfo32`
    1. Inspect __System Summary -> BIOS Version/Date__  
    ![](/docs/img/msinfo32_bios.png)

The BIOS version must match the [Ruyi OS](os.md) version because the BIOS must be paired with a compatible AMD driver.

| BIOS Version/Date | Ruyi OS Version | AMD Driver Stack Version/Date
|-|-|-
| 0.08 2018/1/2 | 0.3 | 23.20.785.0 2017/12/15
| [0.09](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220009.zip) 2018/1/8 | 0.3 | 23.20.785.0 2017/12/15
| [0.10](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220010.zip) 2018/1/15 | 0.4 | 23.20.785.0 2018/1/5
| [0.11](https://bitbucket.org/playruyi/support/raw/master/files/bios/DA220010.zip)

## Flashing the BIOS

__Create USB Flash Drive__

1. Format USB drive with FAT32 filesystem
1. Unzip [EFI shell files](https://bitbucket.org/playruyi/support/raw/master/files/bios/efi.zip) to root of USB drive
1. Unzip [BIOS binaries](https://bitbucket.org/playruyi/support/src/master/files/bios/) to root of USB drive

Resulting directory structure should be similar to the following:
```
<USB root>
│
├───Crisis
│       Fireflight.rom
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

__On the Ruyi Box__

1. In [Command Prompt with administrator rights](https://technet.microsoft.com/en-us/library/cc947813(v=ws.10).aspx) run: `manage-bde.exe -protectors -disable c:`
    - This temporarily disables Bitlocker.  __Failure to do this results in an unbootable OS__ due to lost encryption data in TPM chip.
1. Plug USB flash drive into any USB port on the box and reboot the box
1. Wait for EFI Shell prompt to appear:

       Shell>
1. Consult the _Device mapping table_ for the name of the USB drive
    - It should be `fs0` or `fs1`
    - Type `fs0:` (or `fs1:`) and press `Enter` then `dir` (and `Enter`) to locate the _Shell_ folder on the USB drive
1. Change to USB drive with `fs0:` (or `fs1:`), then enter _Shell_ folder with `cd shell`
1. Start flashing process by running `flash.nsh`
1. Wait around 1 minute for the flashing to complete

## Installing Ruyi OS

![](/docs/img/warning.png) Flash the correct BIOS version __before__ installing the corresponding OS version.

See [Ruyi OS installation instructions](os.md#Installation).

## Resources

- [Support files](https://bitbucket.org/playruyi/support/src/master/files/)