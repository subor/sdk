# BIOS

Similar to other devices, the console has BIOS firmware.

Recent versions of the devkit as well as the retail console are pre-installed with the latest BIOS/OS.  The latest BIOS is also available from [release downloads](https://github.com/subor/sdk/releases).  Older versions are available from the old dev portal and on request.

This document will be removed in the future.

## Version

__Checking BIOS version of Running Machine__

- In Ruyi client
    1. Go to __Settings > System > System Information__
    1. Check versions
    ![](/docs/img/version.png)

OR

- In Windows
    1. Run `msinfo32.exe`
    1. Inspect __System Summary -> BIOS Version/Date__ value  
    ![](/docs/img/msinfo32_bios.png)

__Checking BIOS version of Install Media__

If archive is named `DA220013.zip` then it is version __0.13__.

You can verify version number in `DA220REL.txt` file:
```
*   [Version]:
*   BIOS Version:  DA220013.rom (V0.13)
```

__Important__:  

![](/docs/img/warning.png) Because the BIOS must be paired with a compatible AMD driver, the BIOS version __must__ be paried with the correct version of [the OS](os.md).  This is summarized as follows:  

| BIOS Version | Ruyi OS Version | AMD Driver Stack Version/Date
|-|-|-
| [1.03](https://github.com/subor/sdk/releases/download/0.9.2.3270/DA220103.zip) | 1.07 | 1.0.5.0 2018/9/14
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

Because the BIOS flashing process was changed, please follow the steps below for how-to:

Skipping steps may cause failure

| Current BIOS | Target BIOS| Rule
|-|-|-
1.00 and forward | Latest | __Winflash__: Update to target version directly
|0.15-0.20 | Latest | __Winflash__: First update to __1.00__; and then update to the latest BIOS/OS.<br/>
| 0.09-0.13 | Latest |  __Winflash__: First update to __1.00__ (Machine will freeze for a few minutes, please wait.);  and then update to more recent BIOS/OS.


Also see:

- How to check the [OS verison](os.md#version)
- [OS Image download](http://dev.playruyi.com/uservices)

## Flashing the BIOS

Make sureyou backed up data you need before flash from Windows OS since RuyiOS will be unbootable and you have to restore OS afterwards.


1. Download the [latest BIOS zip file](https://github.com/subor/sdk/releases)
1. Extract the zip file and locate `Winflash/` folder
1. Run `DA22XXXX.exe` to flash BIOS



## Installing Ruyi OS

![](/docs/img/warning.png) Flash the correct BIOS version __before__ installing the corresponding OS version.

See [Ruyi OS installation instructions](os.md#Installation).

