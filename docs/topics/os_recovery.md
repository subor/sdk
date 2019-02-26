# Prepare
1. Connect a keyboard to the RUYI device
1. Connect network cable to Internet (optional)
1. One USB disk, more than 6GB, fat32 format.

## Step 1: Make a Recovery USB drive (USB)  

There are two ways to create a recovery USB:
1. Manually download image
1. Use BIOS Internet Recovery

### Method A:  Manually Download Image
1. Download RUYI OS image  
1. Unzip and copy OS files to root of bootable USB drive. (There is an EFI folder in the root path)  
1. Plug USB drive into system.
1. Turn on or reboot the system

### Method B: Use BIOS Internet Recovery
1. Press power button to boot the system  
1. Press `F11` (keyboard) or `↑+Y+L1+R1` (gamepad) to enter recovery mode
1. Plug USB drive into console, connect network cable to Internet
1. Follow onscreen directions

## Step 2: Follow Onscreen Guide to Finish Recovery  
1. If the BIOS needs to be updated this screen will appear.  Otherwise skip to the next step.  
![](/docs/img/update_bios.png)  
1. Clean HDD Confirm  
![](/docs/img/clean_hdd.png)  
1. Choose developer mode (Optional)  
![](/docs/img/dev_mode_choose.png)  
Only for developer  
1. Remove USB  
![](/docs/img/remove_usb.png)  
1. Finish  
During the remainder of the installation process the machine may reboot, open PowerShell/Command Prompt windows, or display a black screen several times.  
![](/docs/img/finish_recovery.png)
