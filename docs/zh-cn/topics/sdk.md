# SDK

---
# ![](/docs/img/warning.png) 注意

- __重要__ 用户必须通过客户端(main client)登陆后才能使用大部分SDK的API功能
- 目前`Ruyi.SDK.BrainCloudApi`命名空间的许多方法还无法工作
	- 总体来说，只有在`RuyiNet`命名空间的API可以正常使用
    - 这不是[brainCloud](http://getbraincloud.com/)造成的, 目前由于种种原因我们暂时这样设计。

---

SDK包括以下目录结构(参考[SDK安装](../tutorials/setup.md)):
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

文件夹 | 路径 | 描述
-|-|-
DevTools/ | RuyiDev.exe | [开发者工具](devtool.md)
| Ruyi/Presentation/Web/index.html | SDK API文档 (即[线上文档](http://dev.playruyi.com/api))
Layer0/ | Layer0.exe | 客户端的保护进程(参考[平台架构](layer0.md))
MainClient/ | WpfClient.exe | 面向用户端界面(需要先layer0运行)
MiniPower | MiniPower.exe | "Ruyi助手"; [PC模式](pc_mode.md)的电量控制和硬件信息
OverlayClient/ | RuyiOverlayClient.exe | [游戏内界面](overlay.md) (由layer0管理)
RuyiSDK/ | | .Net/C# SDK (.Net标准2.0)
RuyiSDK.nf2.0/ | | .Net/C#支持.Net Framework 3.5 (Unity使用)
RuyiSDKCpp/ | lib/RuyiSDK.lib | C++ SDK使用‘/MD’链接
| lib/RuyiSDK_mt.lib | C++ SDK使用‘/MT’链接
RuyiSDKUnity/ | RuyiSDKUnity.unitypackage | Unity3D示例程序的Asset包

## API:

## 链接:

* [下载SDK](http://dev.playruyi.com/uservices)
* [Unity接入说明](unity.md)
* [UE4接入说明](ue4.md)
