# Setup

These are instructions to setup and manage the SDK on a developer's workstation or the console.

If you received a devkit from us it should already come with the SDK pre-installed to `c:\ruyi`.  But, the following instructions can be used to update it.

## Prerequisites

- [Register as a developer and setup a development environment](../topics/dev_onboarding.md)

## SDK Download and Installation

1. Download the most recent [SDK and runtime](https://github.com/subor/sdk/releases)
1. Uncompress to local HDD as siblings
1. If necessary, __unblock__ executable files:
    - __Right-click executable, select Properties__, enable the __Unblock__ checkbox  
    ![](/docs/img/exe_unblock.png)

    OR
    - Run __Windows PowerShell__ as _administrator_ and execute `Get-ChildItem c:\RUYI\*.* -Recurse | Unblock-File`

End result should be directory structure similar to the following:
```
|   
+---DevTools
|   |    
|   \   RuyiDev.exe
|         
+---Layer0
|   |    
|   \   zpLayer0.exe
|                               
+---MainClient
|   |   zpMainClient.exe
|   |
|   \---WebResource
|                   
+---OverlayClient
|   |   
|   +---DeployRes
|   |       
|   \---Drivers
|           
\---SDK
    |   
    +---RuyiSDK
    |   |   RuyiSDK.xml
    |   |   
    |   \---netstandard2.0
    |               
    +---RuyiSDK.nf2.0
    |       
    \---RuyiSDKCpp
        +---include
        |               
        \---lib
            |   RuyiSDK.lib
            |   
            +---boost
            |       
            \---zmq
```

Details regarding the SDK can be found [here](../topics/sdk.md).

### Notes
1. All assemblies above should be the same version, you can check by right-clicking a exe/dll, and select __properties->details->file version__
1. When upgrading, delete the old version first.  That is, don't overwrite the old version with a new one.  This is to ensure files unneeded are removed.


## Login

[Layer0](../topics/layer0.md) must be running on a host machine before you can access most of the platform features.

__IMPORTANT__ A user _must be logged in via main client_ for most of the SDK to work.  The retail version of the console will require a user to be logged in to launch apps.

1. [Run Layer0](../topics/layer0.md)
1. If installed to `c:\RUYI` the main client will start automatically.  Otherwise run `MainClient\zpMainClient.exe` to launch it
1. Register a user and login

At this point you should be looking at placeholder UI for landing page of logged in user.

__Next step:__

- Try running [UE4](run_ue4_sample_pc.md) or [Unity](run_unity_sample_console.md) samples.

## Updating SDK

1. Close Main Client and layer0 (if running)
1. Delete old SDK folder
1. Follow [download & install steps](#SDK-Download-and-Installation) above