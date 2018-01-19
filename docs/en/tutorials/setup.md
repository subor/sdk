# Setup

These are instructions to setup and manage the Ruyi SDK on a developer's workstation or the Ruyi console.

If you received a devkit from us it should already come with the SDK pre-installed to `c:\ruyi`.  But, the following instructions can be used to update it.

## SDK Download and Installation

1. Download the following from the [Development](http://dev.playruyi.com/uservices) area of the website:
    - All SDKs
    - Devtools
    - Layer0
    - Main Client
1. Uncompress to local HDD as siblings

End result should be directory structure similar to the following:
```
|   
+---DevTools
|   |    
|   \   RuyiDev.exe
|         
+---Layer0
|   |    
|   \   Layer0.exe
|                               
+---MainClient
|   |   Client.exe
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
1. All assemblies above should keep in the same version, you can check that by right click on the exe/dll file, properties->details->file version
1. Delete the old version when upgrading, don't do a copy -> replacement, make sure files not needed don't exist.

### Dependencies
1. [vcredist_2013_x64.exe](https://www.microsoft.com/en-us/download/details.aspx?id=40784)
1. [vcredist_2017_x64.exe](https://go.microsoft.com/fwlink/?LinkId=746572)
1. [Vulkan Runtime](../../../files/VulkanRuntime.zip) install both 32 and 64bit version


## Launching Client, Registering, and Logging-in

__IMPORTANT__ A user _must be logged in via main client_ for most of the SDK API to work.  The retail version of the console will require a user to be logged in to launch apps.

1. Run `Layer0\Layer0.exe`
1. If installed to `c:\ruyi` the main client will start automatically.  Otherwise run `MainClient\Client.exe` to launch it
1. Register _guest_ user and login
    - Select __Guest Login__  
    ![](/docs/img/client_00.png)
    - Ok (or press `Enter`)  
    ![](/docs/img/client_01.png)
    - Ok (or press `Enter`)  
    ![](/docs/img/client_02.png)
    - Ok (or press `Enter`)  
    ![](/docs/img/client_03.png)

At this point you should be looking at placeholder UI for landing page of logged in user.

__Next step:__
- Try running [UE4](run_ue4_sample_pc.md) or [Unity](run_unity_sample_console.md) samples.

## Updating SDK

1. Close Main Client and layer0 (if running)
1. Delete old SDK folder
1. Follow [download & install steps](#SDK-Download-and-Installation) above