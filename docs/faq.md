# 常见问题

## 硬件

1. 主机的芯片/显卡/内存?

    [硬件说明](topics/hardware.md)

1. 主机搭载蓝光还是DVD光驱?有HDD吗?

    都不支持。主机之后会尝试搭载128GB的固态硬盘(SSD)和1TB的机械硬盘(HDD)。[详细](topics/hardware.md)

1. 我收到的主机只有一个东芝(Toshiba)机械硬盘，性能糟糕，这个是最终版吗?

    不是，机械硬盘的性能问题是第一批开发机的问题。之后生产的机器已修正该问题。[详细](topics/hardware.md#Revisions)

1. 输入设备(游戏手柄/键盘/鼠标)?

    早期会搭配一个类似XBox主机的手柄。键盘/鼠标是支持的。[详细](topics/input.md)

1. 具体的外部设备，比如视频/音频插口等等?

    USB, HDMI, 以太网口, wifi, 蓝牙, S/PDIF.  [详细](topics/hardware.md)

1. 主机运行时会比较声音比较嘈杂吗?

    不会。早期生产的主机(由于设计和PSU问题)，可能有这个问题。(参考[硬件审核](topics/hardware.md#Revisions)).
    如果你拿到的是最新硬件，确保你升级了最新版[BIOS](topics/bios.md)(对风扇控制等做了调整)。

## 软件/SDK

1. 主机运行的操作系统?

    __Windows 10 IoT 企业版__。也称为Windows 10 企业版 LTSB 2016。[详细](topics/os.md)

1. 支持的图像API接口?

    Vulkan, OpenGL, and DirectX (9-12)。基本上在Windows10上使用的都支持。[详细](topics/hardware.md)

1. 支持的编程语言?

    很多。基本[Apache Thrift](https://thrift.apache.org/docs/features)所支持的都能使用。

1. 具体的C++编译器?支持Visual Studio吗?

    可以使用Visual Studio。你可以使用任何能在Windows10上使用的编译器。

1. 支持API/SDK/各类中间件吗?

    如果可以在AMD硬件和Windows 10 RS1正常使用,应该就可以在Ruyi主机上使用。

1. 支持虚幻/U3d引擎吗?各种自研引擎呢?

    支持。如果能在AMD硬件和Windows 10 RS1上使用,应该就可以在Ruyi主机上使用。

1. 怎么开始?

    - 参考这里[指引](https://bitbucket.org/playruyi/docs/src/master/docs/en/tutorials/)
    - 尝试在主机上[调试观察](https://bitbucket.org/playruyi/docs/src/master/docs/en/topics/optimization.md)你的游戏

1. 我的问题在这里找不到答案，怎么办?

    [更多文档](README.md), [论坛](http://dev.playruyi.com/forum/), 和[开发支持](https://bitbucket.org/playruyi/support) (包括[问题解决](https://bitbucket.org/playruyi/support/issues?status=new&status=open)).

## 平台/发布

1. 支持的功能?

    我们最终会提供一系列和XBox Live，PSN，Steam，GoG等近似的功能服务。

1. 能具体点吗?

    成就，好友，聊天，分数版，比赛匹配，竞赛，云存档，截屏/视频分享，直播，IAP等等。

1. 游戏怎样发售?

    主要是数字版下载。我们也考虑支持通过USB线下安装。

1. 安全性问题?

    [Ruyi系统](topics/os.md)提供了和其他平台相似的安全保护措施。重要内容不会被非授权方复制。作弊行为会被机器人阻止，不允许内容篡改等等。[详细](topics/security.md)

1. [PC模式](topics/pc_mode.md)有DRM或者类似Steam的反拷贝技术吗?其他方面的安全问题，比如反外挂等等?

    PC模式类似普通的PC桌面系统;没有DRM，反拷贝，反外挂等功能。我们会考虑提供部分解决方案，但目前还没有计划表。

1. 有TRC/TCR吗?

    有。我们了解开发者非常讨厌TRC，尽管它们有利于玩家[详细](topics/trc.md)

1. 审核具体过程?需要多长时间?

    更多细节会在2018第三季度公布。

1. 目前中国大陆的政府审查规范是怎样的?

    早期审核是由我们的内容发布团队线下手动处理。


## Layer0

1. 在开发机上使用从[dev portal](http://dev.playruyi.com/)下载的Layer0会崩溃 (参考[问题](https://bitbucket.org/playruyi/support/issues/3))
    
    > 由于IE浏览器的安全性问题，不被信任的文件会被 __阻止__ 。右击可执行文件(比如Layer0.exe)，勾选 __Unblock file__, 然后点 __Apply__.  
    也可以使用PowerShell命令`Get-ChildItem c:\\ruyi\\*.* -Recurse | Unblock-File`来解锁所有文件。