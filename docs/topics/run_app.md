# Summary
Start from 0.9.3, we no longer use *app packer* to pack the app before installing it into the kit, instead we use [Microsoft Sync Framework](https://www.microsoft.com/en-us/download/details.aspx?id=19502) to sync the build to the target kit(just during the development), so we don't have to like   
- Pack 100Gb file every time
- Send the whold package each time the build updated

So, we **Must** install [Microsoft Sync Framework](https://www.microsoft.com/en-us/download/details.aspx?id=19502) (choose <u>**Synchronization-v2.1-x64-ENU.msi**</u>) on devkits and anywhere you use devtools.   
- It already included in latest OS image ([v1.09]() or later), you'll need to update the OS if you want to test your app in console mode. [OS](os.md)   
- You can also install it on PC mode and test your app there, if you don't like to update the OS.   

# How to run the app
There are the basic steps for testing your app on the console.  
1. Integrate [Ruyi SDK](sdk.md) into your app. (optional)
1. Create the [App manifest file](app_metadata.md).
1. Sign the app if you want to test it in console mode. [Sign Tool](devtool.md#sign-tool)
1. Open [Dev Tools](devtool.md)
1. Choose _App Runner_, fill the proper IP address and choose your manifest file
1. Click _Install App_ 
1. Wait it to finish   

Done and have fun!!
 > IF error happens, make sure [Microsoft Sync Framework](https://www.microsoft.com/en-us/download/details.aspx?id=19502) has been installed on your PC and the target console, or the OS has been updated to the correct version ([v1.09]() or later) if you're in console mode.

# Limitations
- You'll be required to provide admin priviledge while doing first time installation via dev-tool(we need this to open a specific port for sync), just click yes, we'll fix this later by our dev-tool installer.
- We're using __net.tcp__ protocol to do the sync, currently it will only support install to the console located in the same LAN with from where your dev-tool running.