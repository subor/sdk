# 游戏呼出界面

Ruyi的游戏内呼出界面基于[Evolve](www.evolvehq.com)提供的技术实现，提供以下功能:  

* 游戏内呼出界面位于应用上层(包括弹出的成就通知信息等等)
* 录制游戏视屏(参考[DVR](dvr.md))
* 游戏截图
* __之后会提供:__ 从外部设备[输入](input.md)功能

![](/docs/img/warning.png) 以下尚未支持:  

* Vulkan和DirectX 12 (__之后会支持__)
* HDR10 (不会支持，参考[硬件](hardware.md))

使用dll注入技术实现，不需要更改应用程序即可兼容大部分(应用)。适用程序列表在`RuyiOverlay/Resources/DeployRes/gamesdb.xml`中查看。
