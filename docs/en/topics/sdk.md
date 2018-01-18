# SDK

---
# ![](/docs/img/warning.png) NOTE

- __IMPORTANT__ A user _must be logged in via main client_ for most of the SDK API to work
- Many functions in `Ruyi.SDK.BrainCloudApi` namespace don't yet work
	- Generally speaking, only those in `RuyiNet` work
    - This is not the fault of [brainCloud](http://getbraincloud.com/), it is intentionally and temporarily done by us

---

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
|   |   Client.exe
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

Links:

* [SDK Download](http://dev.playruyi.com/udownloadslist/SDK)
* [Unity specifics](unity.md)
* [UE4 specifics](ue4.md)
