# PC Mode

Starting [OS](os.md) v0.6, the console can be booted to a regular PC desktop.  This is referred to as "PC mode".

PC mode is similar to the console OS- same version of Windows- but many of the security features have been turned off (Bitlocker, Device Guard Code Integrity, etc.).

![](/docs/img/warning.png) [BIOS](bios.md) updates cannot be done in [PC mode](pc_mode.md).  Make sure you are __not__ in PC mode before updating the BIOS.

## Switching

It is possible to switch back and forth between the console and PC mode.

__As Administrator__ run `sdk/SwitchOS.cmd` and restart.

Starting 0.8.1, in main client or [Z+ Assist](ruyi_assist.md) (only in [PC mode](pc_mode.md)).

## Changing Default Language

1. Open __Start Menu__ then __Settings__  
    ![](/docs/img/os_lang_settings.png)
1. Select __Time & Language__  
    ![](/docs/img/os_lang_time_lang.png)
1. Select __Region & Language__ and __Add a language__  
    ![](/docs/img/os_lang_region_add.png)
1. Select desired language  
    ![](/docs/img/os_lang_add.png)
1. Click __Set as default__  
    ![](/docs/img/os_lang_default.png)
1. Restart the machine

## Development

One reason for PC mode is to make development easier.  You can install Visual Studio and build/debug just like it was a regular PC.  CPU/GPU/disk capabilities and performance, memory configuration and bandwidth, OS environment, and so on will be almost identical.
