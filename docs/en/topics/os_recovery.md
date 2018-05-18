#Prepare
1. Connect a keyboard to the RUYI device;
2. Connect network cable to Internet (Option);
3. One USB disk, more than 6GB, fat32 format.

##Step A: Make a Recovery USB drive (RUSB)  

###Method 1:  Manually Download source
1. Download RUYI OS image  
1. Unzip and copy OS files to root of bootable USB drive. (There is an EFI folder in the root path)  
1. Plug USB drive into system.   
1. Press power button to boot the system  
1. Follow the guide to finish the recovery

###Method 2: Use BIOS Internet Recovery
1. Press power button to boot the system  
1. Press F11(Keyboard) or “↑”+”Y”+”L1”+”R1” (gamepad) to Enter into Recovery UI;  
1. Plug USB drive into RUYI device, Connect network cable to Internet  
1. According to the guide to finish the recovery  

##Step B: According to the guide to finish the recovery  
1. Update BIOS (Option)  
Recovery Process will detect the BIOS and show this step if it need to update the BIOS.  
![](/docs/img/update_bios.png)  
1. Clean HDD Confirm  
![](/docs/img/clean_hdd.png)  
1. Develop mode choose (Option)  
![](/docs/img/dev_mode_choose.png)  
Only for developer  
1. Remove RUSB  
![](/docs/img/remove_usb.png)  
1. Finish  
During the remainder of the installation process the machine may reboot, open PowerShell/Command Prompt windows, or display a black screen several times. Until show the Finish message.  
![](/docs/img/finish_recovery.png)
