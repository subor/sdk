# Running Apps

This document covers how developers can run applications on a devkit/console.

Starting with 0.9.3.3995, *App Runner* in no longer needed to pack apps before installation.  Instead, the [Microsoft Sync Framework](https://msdn.microsoft.com/en-us/library/mt763482.aspx?f=255&MSPPError=-2147217396) (see [dev environment](dev_onboarding.md) pre-requisites) is used to sync builds to a target machine.  This avoids unnecessary work like:  
- Creating large compressed archives
- Re-transferring an entire build when many files are unchanged

The [Microsoft Sync Framework](dev_onboarding.md) __must be installed on devkits and anywhere you use devtools__.  It is pre-installed in the latest [OS](os.md) image ([v1.09]() or later) for both console and [PC mode](pc_mode.md).

## How to run the app
There are the basic steps for testing your app on the console.  
1. Integrate [Ruyi SDK](sdk.md) into your app
1. Create a [RuyiManifest.json](app_metadata.md) at the root of a build
1. If using console mode (i.e. not in [PC mode](pc_mode.md)), you __must__ enable developer mode in _Settings_ and [sign the app](devtool.md#sign-tool)
1. Open [Dev Tools](devtool.md)
1. Choose _App Runner_, fill the proper IP address and choose your manifest file
1. Click _Install App_ 
1. Wait for it to finish

Done and have fun!!
 > IF error happens, make sure the Microsoft Sync Framework has been installed on your PC and the target console has been updated to the latest version of the [OS](os.md).

## Limitations
- You may be asked for admin priviledges the first time you install an app with devtool (we need to open a specific port for sync).  Click __Yes__.
- The sync is done over _TCP_ protocol.  Currently it only supports machines located in the same LAN as where devtool is running.
