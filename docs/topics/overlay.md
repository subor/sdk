# 游戏呼出界面

Ruyi的游戏内呼出界面基于[Evolve](www.evolvehq.com)提供的技术实现，提供以下功能:  

* 游戏内呼出界面位于应用上层(包括弹出的成就通知信息等等)
* 录制游戏视屏(参考[DVR](dvr.md))
* 游戏截图
* __即将到来:__ 从外部设备[输入](input.md)(也可以选择从SDK接收输入信息)

![](/docs/img/warning.png) 以下尚未支持:  

* DirectX 12 (__即将到来__)
* Vulkan (稍晚到来)
* HDR10 (短时间内不会支持，参考[硬件](hardware.md))

使用dll注入技术实现，不需要更改应用程序即可兼容大部分游戏(应用)，数量在5000以上。

## 游戏适配

适用程序列表在`RuyiOverlay/Resources/DeployRes/gamesdb.xml`中查看。

目前，适合游戏需要在gamesdb.xml中添加对应配置信息。之后我们把把这部分内容加到[应用配置文件](app_metadata.md)中.

1. 关闭Layer0和弹出界面(Overlay)客户端
1. 使用text/XML编辑器打开`OverlayClient/DeployRes/gamesdb.xml`
1. 在`<games version="2">`块中添加`<game>`标签，具体格式如下:

        <game>
            <id>9999</id> 
            <name>Your Game Name</name>
            <conditions>
                <cond name="is-YourGameName.exe-present" type="exe-present" exe="YourGameName.exe"/>
            </conditions>
            <detection>
                <variant order="1" name="default">
                    <if cond="is-YourGameName.exe-present"/>
                </variant>
            </detection>
        </game>

    `id`就是[小霸王分配的app id](dev_onboarding.md).

1. 保存`gamesdb.xml`
1. 重启layer0

__在多数情况下__, 如上的配置信息已经可以适用了。如果需要添加更多配置应用，可以参考[gamesdb.xml format](gamesdb_format.md).

## 调试

在注册表路径`HKLM/Software/Subor/Ruyi`下的部分值可以设置(或者创建):

| 名字 | 类型 | 说明
|-|-|-
| `EnableDisplayDriverLogging` | DWORD | 如果为 __1__, 会有额外的日志记录
| `DisplayDriverLogFilePath` | string/REG_SZ | 日志路径
