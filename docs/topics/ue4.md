# Ruyi C++ SDK集成到虚幻4引擎

本来是关于如何将Ruyi C++ SDK集成到使用[虚幻4](https://www.unrealengine.com/en-US/)引擎的[示例项目](https://bitbucket.org/playruyi/unreal_demo)和[platformer](https://bitbucket.org/playruyi/platformer_game)游戏中.

## 前提条件

- 参考[集成C++ SDK]里的前提条件(cplusplus.md#Prerequsites)
- Unreal Engine 18 (4.18)，编译版

## 从开发者网站下载SDK的接入说明

1. 可以直接从开发者网站(http://dev.playruyi.com)下载Ruyi C++ SDK. 包括两个文件夹: __include__ 和 __lib__。 将它们放在你其中一个游戏模块的根目录文件夹下。比如，`source/ModuleName/include`和`source/ModuleName/lib`。也可以放在子文件夹下，保证这两个文件夹同级即可。
1. 打开文件 __ModuleName.Build.cs__，为变量`PublicIncludePaths`添加`ModuleName/xxx/include`。代码如下所示:

        PublicIncludePaths.AddRange(
            new string[] {
                "ModuleName/include",
            }
        );

1. 添加`using System.IO;`到文件头部。如下所示添加模块和库路径代码:

        private string ModulePath
        {
            get { return ModuleDirectory; }
        }

        private string LibPath
        {
            get { return Path.GetFullPath(Path.Combine(ModulePath, "xxx/lib/")); }
        }

1. 添加以下代码到主体函数中:

        PublicDelayLoadDLLs.Add(Path.Combine(LibPath, "zmq", "libzmq.dll"));

        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "RuyiSDK.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "zmq", "libzmq.lib"));

        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_chrono-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_chrono-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_date_time-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_date_time-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_system-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_system-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_thread-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_thread-vc141-mt-gd-1_64.lib"));

1. 复制`lib/zmq/libzmq.dll`到编译目标文件夹。比如`Binaries/Win64`。
1. 打开虚幻4编辑器。点击 __File -> Refresh Visual Studio Project__ (或者右击 __xxxxx.uproject__ 文件，点击 __Generate visual studio project file__)。等待完成，然后重新加载VS项目，项目工程里会显示 __include__ 和 __lib__ 文件夹。
1. 使用SDK时注意包含头文件`RuyiSDK.h`和对应命名空间(比如`Ruyi::RuyiSDK`)。可以参考[UE4示例](https://bitbucket.org/playruyi/unreal_demo)和[SDK文档](http://dev.playruyi.com/api)的具体API说明.
1. 编译项目。

## 从sdk_source GIT下载SDK的接入说明

也可以从[sdk_source](https://bitbucket.org/playruyi/sdk_source)GIT仓库上下载SDK。

1. 下载sdk_source仓库。

1. 从提供的链接里下载第三方库。解压缩，复制 __externals__ 文件夹到和 __sdk_source__ 同级的文件夹目录.
  
1. 编译"RuyiSDKCpp"项目。

1. 到"RuyiSDKCpp\bin\Release"路径下，复制 __include__ 和 __lib__ 文件夹到目标项目的主模块下。

1. 余下内容和从开发者网站下载SDK的接入过程一样。

## 可能会遇到的问题

- 由于Ruyi SDK使用[boost](http://www.boost.org/)库, 可能会遇到`error LNK2038: mismatch detected for 'boost__type_index__abi': value 'RTTI is used'`这样的错误。可以在模块编译配置文件 __xxxx.build.cs__ 里添加`bUseRTTI = true;`解决。

- 如果遇到: `Error C4577: 'noexcept' used with no exception handling mode specified`。可以在模块编译配置文件 __xxx.build.cs__ 里添加`bEnableExceptions = true;`解决。
