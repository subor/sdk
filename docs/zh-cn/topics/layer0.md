# 平台架构

Ruyi平台的架构如下图所示:

![](/docs/img/platform_arch.png)

Layer0是一种在系统后台运行的[守护进程](https://en.wikipedia.org/wiki/Daemon_(computing))(daemon)，Ruyi平台所有的“服务”功能都是通过Layer0来交互的。它运行于主机系统最上层。类似于Win10运行于工作机器，或[Ruyi系统](os.md)运行于Ruyi主机上。

客户端程序通过[Ruyi SDK API](http://dev.playruyi.com/api)与平台（或相互之间）交互。RuyiSDK使用[Apache Thrift](https://thrift.apache.org/)实现。通过这种方式来提供稳定的，版本可控的，可文档化的，最为标准化的[跨多语言](https://thrift.apache.org/lib/)的平台服务开发。

数据交互（异步）通过订阅[ZeroMQ](http://zeromq.org/)的消息模型来实现。 

网络服务由定制化[brainCloud](http://getbraincloud.com/)提供。


## 启动

Layer0的设计是作为一个Windows服务运行的。

1. 以 __（管理员）Administrator__ 账户权限运行`cmd.exe` 
1. 运行`layer0.exe --install --start`安装、启动layer0

安装完成后，layer0可以在`services.msc`中开启/关闭:  
![](/docs/img/services.png)

1. 启动 __开始(Start) / Windows管理员工具(Windows Administrative Tools) / 服务（Services）__ (或者运行`services.msc`)
1. 右击名为 __Ruyi Layer0__ 服务，选择 __Start__/__Stop__

或者，从命令行关闭layer0:

1. 以 __（管理员）Administrator__ 账户权限运行`cmd.exe` 
1. 运行`layer0.exe --stop`

或者，layer0也可以作为一个终端程序来运行:

1. 如果layer0已作为服务（service）运行，直接关闭
1. 双击`layer0.exe`启动
