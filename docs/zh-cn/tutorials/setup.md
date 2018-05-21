# SDK安装

这里是关于开发者在自己的工作机器或者Ruyi主机上安装管理RuyiSDK的指南.

如果你有收到我们发出的开发套件，其中应该已经预装有SDK(`c:\ruyi`). 当然，以下说明仍可以用来升级SDK。

## 前提条件

- [注册成为Ruyi开发者及安装开发环境](../topics/dev_onboarding.md)

## SDK下载及安装

1. 在[开发者网站](http://dev.playruyi.com/uservices)下载以下内容:
    - 所有SDK
    - 开发工具（Devtools）
    - Layer0
    - 主机客户端（Main Client）
1. 解压到本地硬盘
1. 如果有需要(参照[遇到问题](https://bitbucket.org/playruyi/support/issues/3)), __解除锁定__文件:
    - __右击exe文件__, 选择属性（__Properties__）, 勾选__解除锁定__（__Unblock__）  
    ![](/docs/img/exe_unblock.png)

    或者
    - 用__administrator__账户运行__Windows PowerShell__， 执行`Get-ChildItem c:\RUYI\*.* -Recurse | Unblock-File`

最终文件目录结构应该如下所示:
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

更多关于SDK说明请看[这里](../topics/sdk.md).

### 注意
1. 以上所有组件必须保持版本匹配, 你可以通过右击exe/dll文件，属性->详细->文件版本，来查看版本信息。
1. 升级时请删除旧版本文件，不要复制->取代，保证所有不需要的文件已被清除.


## 启动客户端，注册，登陆

在进入Ruyi平台前请保证在主机上先运行[Layer0](../topics/layer0.md)。

__重要__ 在使用SDK的API前请保证用户已通过客户端（main client）登陆. 正式发售的主机需要用户登陆之后才能启动游戏.

1. 运行`Layer0\Layer0.exe`  
![](/docs/img/layer0.png)
1. 如果Layer0安装到`c:\RUYI`下，客户端（main client）会自动启动。否则需要手动运行`MainClient\Client.exe`来启动客户端。
1. 注册成为__访客__用户及登陆
    - 选择__Guest Login__  
    ![](/docs/img/client_00.png)
    - Ok (或者按`Enter`)  
    ![](/docs/img/client_01.png)
    - Ok (或者按`Enter`)  
    ![](/docs/img/client_02.png)
    - Ok (或者按`Enter`)  
    ![](/docs/img/client_03.png)

这是你应该可以看到用户的登陆页面UI。

__下一步:__

- 尝试运行[虚幻4](run_ue4_sample_pc.md)或者[Unity3D](run_unity_sample_console.md)示例程序.

## 升级SDK

1. 关闭客户端（Main Client）和layer0(如果有运行)
1. 删除旧版本的SDK文件夹
1. 参照之前的[SDK下载及安装]步骤升级SDK(#SDK-Download-and-Installation)