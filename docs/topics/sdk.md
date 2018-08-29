# SDK

---
# ![](/docs/img/warning.png) NOTE

- __IMPORTANT__ A user _must be logged in via main client_ for most of the SDK to work
- Many functions in `Ruyi.SDK.BrainCloudApi` namespace don't yet work
	- Generally speaking, only those in `RuyiNet` work
    - This is not the fault of [brainCloud](http://getbraincloud.com/), it is intentionally and temporarily done by us

---

SDK has following directory structure (see [SDK Setup](../tutorials/setup.md)):
```
+---DevTools
|   |   ...
|   |   RuyiDev.exe
|   |   ...
|   +---Resources
|   \---Ruyi
|       \---Presentation
|           +   ...
|           \---Web
|               |   index.html
|               \   ...
|                       
+---Layer0
|   |   ...
|   |   Layer0.exe
|   \   ...
|                               
+---MainClient
|   |   ...
|   |   WpfClient.exe
|   \   ...
|
+---OverlayClient
|   |   ...
|   |   RuyiOverlayClient.exe
|   \   ...
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
```

Folder | Path | Description
-|-|-
DevTools/ | RuyiDev.exe | [Developer tools](devtool.md)
| Ruyi/Presentation/Web/index.html | SDK API documentation (same as [online docs](http://dev.playruyi.com/api))
Layer0/ | Layer0.exe | Daemon portion of client (see [architecture](layer0.md))
MainClient/ | WpfClient.exe | End-user facing UI (requires layer0 already running)
MiniPower | MiniPower.exe | [Z+ Assist](ruyi_assist.md); power control and hardware information for [PC mode](pc_mode.md)
OverlayClient/ | RuyiOverlayClient.exe | [In-game UI overlay](overlay.md) (managed by layer0)
RuyiSDK/ | | .Net/C# SDK (.Net Standard 2.0)
RuyiSDK.nf2.0/ | | .Net/C# SDK targeting .Net Framework 3.5 (for Unity)
RuyiSDKCpp/ | lib/RuyiSDK.lib | C++ SDK linked with /MD
| lib/RuyiSDK_mt.lib | C++ SDK linked with /MT
RuyiSDKUnity/ | RuyiSDKUnity.unitypackage | SDK package for Unity 3D

## Links

* [SDK Downloads](https://github.com/subor/sdk/releases)
* SDK documentation: [C#](http://subor.github.io/api/cs/en-US/), [C++](https://subor.github.io/api/cpp/en-US/), [offline](https://github.com/subor/subor.github.io)
* [Unity specifics](unity.md)
* [UE4 specifics](ue4.md)
