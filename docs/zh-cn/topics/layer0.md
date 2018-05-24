# 平台架构

Ruyi平台的架构如下图所示:

![](/docs/img/platform_arch.png)

Layer0是一种在系统后台运行的[守护进程](https://en.wikipedia.org/wiki/Daemon_(computing))(daemon)，Ruyi平台所有的“服务”功能都是通过Layer0来交互的。它运行于主机系统最上层。类似于Win10运行于工作机器，或[Ruyi系统](os.md)运行于Ruyi主机上。

客户端程序通过[Ruyi SDK API](http://dev.playruyi.com/api)与平台（或相互之间）交互。RuyiSDK使用[Apache Thrift](https://thrift.apache.org/)实现。通过Apache Thrift来提供稳定的，版本可控的，可文档化的，最为标准化的[跨多语言](https://thrift.apache.org/lib/)的平台服务开发。

数据交互（异步）通过订阅[ZeroMQ](http://zeromq.org/)的消息模型来实现。 

网络服务由定制化[brainCloud](http://getbraincloud.com/)提供。