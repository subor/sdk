# Setup

These are instructions to setup and manage the Ruyi SDK on a developer's workstation.

If you received a devkit from us it should already come with the SDK pre-installed to `c:\ruyi`.  But, the following instructions can be used to update it.

## SDK Download and Installation

1. Download the following from the [Development](http://dev.playruyi.com/uservices) area of the website:
    - All SDKs
    - Devtools
    - Layer0
    - Main Client
1. Uncompress to local HDD as siblings

End result should be following directory structure:
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


## Launching Client, Registering, and Logging-in

__IMPORTANT__ A user _must be logged in_ for most of the SDK API to work.  The retail version of the console will require a user to be logged in to launch apps.

1. Run `Layer0\Layer0.exe`
1. If installed to `c:\ruyi` the main client will start automatically.  Otherwise run `MainClient\Client.exe` to launch it
1. Register _guest_ user and login
    - Select __Guest Login__  
    ![](/docs/img/client_00.png)
    - Ok  
    ![](/docs/img/client_01.png)
    - Ok  
    ![](/docs/img/client_02.png)
    - Ok  
    ![](/docs/img/client_03.png)

## Replacing/Updating SDK

1. Close [Main Client and layer0](layer0.md)
1. Delete old folder
1. Follow [Download & Install steps](#SDK Download and Installation)