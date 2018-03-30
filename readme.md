#This is the open source project for RuyiSDK.

##Dependencies:  
* Visual studio 2017, later than 15.3   
* Windows 10 SDK (10.0.15063.0)

###C# Version:  
* [thrift](https://thrift.apache.org/), version 0.10.0 [Download](http://archive.apache.org/dist/thrift/0.10.0/)
* [netmq](https://netmq.readthedocs.io/en/latest/), version 4.0.0.1 managed by nuget package

###Cpp Version:  
* [thrift](https://thrift.apache.org/), version 0.10.0 [Download](http://archive.apache.org/dist/thrift/0.10.0/)   
** [boost](http://www.boost.org/), used by thrift, version 1.64.0   
** [openssl](https://www.openssl.org/), used by thrift, version 1.1.1-dev  
* [jsoncpp](https://github.com/open-source-parsers/jsoncpp), used by cpp unit test, version 1.8.3    
* [zeromq](http://zeromq.org/), version 4.2

If you don't want to build the libs above, you can use [the one we provide](https://bitbucket.org/playruyi/sdk_source/downloads/externals.zip)

##Build Guide
1. Clone the repo, or download it, put them under the folder named ___sdk___
1. Build the libs mentioned above, each one should have their own folder, put them in ___externals___, beside ___sdk___
1. Open ___sdk/SDK.sln___, we get two c# version sdks targeting on .net framework 3.5 & .net standard 2.0. build it.
1. For cpp version, remove the post build event script, it will actually only copy files(.h;.lib) around, build it.