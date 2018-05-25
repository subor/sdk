# 硬盘驱动

Ruyi主机拥有两个支持SATA硬盘(2.5")的插槽(最大9.5mm宽):

* 位置设备中央的 _主_ 驱动，Ruyi主机始终从该驱动启动。
* 另一个为可选驱动。

早期的Ruyi主机搭载东芝(Toshiba)机械硬盘。

之后版本的Ruyi主机搭载128GB固态硬盘和1TB机械硬盘。

[Ruyi系统](os.md)和[PC模式](pc_mode.md)的分区方案:

| Ruyi系统版本 | 主分区 | 次分区
|-|-|-
| v0.5之前版本 | 100% Ruyi系统 | 不支持
| v0.6之后版本 | 50/50 Ruyi系统/PC模式 | 30/70 Ruyi系统/PC模式

## 维护

1. 确保已关闭Ruyi主机电源，翻转主机机身。
1. 向 __Open__ 字样方向 滑动开关。
1. 将开关按住在Open位置，朝Ruyi主机前端轻拉硬盘遮挡槽:  
![](/docs/img/harddrive_cover_open.jpg)
1. 安装硬盘时注意硬盘安装的方向位置如下图所示:  
![](/docs/img/harddrive_rail.jpg)
1. 安装完成后, 将硬盘遮挡槽轻推会原处。