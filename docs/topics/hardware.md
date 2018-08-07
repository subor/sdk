# 硬件功能

## 硬件

- AMD加速处理器(APU)
    - Zen 4核 w/ SMT (8线程) @ 3 GHz
    - Vega (GFX9/GCN第五代) 24组CU @ 1.3 GHz
        - 半精度浮点性能8TFLOPS, 单精度浮点性能4TFLOPS
- 8GB GDDR5共享内存
    - 带宽256GB/s
    - 其中2GB为显存(GPU使用)
- 存储设备
    - 128/256GB固态硬盘(SSD)
    - 1TB机械硬盘(HDD)
- 端口/外设
    - 4x USB 3.0(后), 2x USB 2.0 (前)
    - 2x HDMI 2.0
    - Wifi/802.11ac
    - 100Mbit以太网卡
    - 支持蓝牙
    - 2x 3.5mm 音频接口(输入/输出)
    - S/PDIF

### 修订

开发机硬件有几处修正:

| 硬件修正 | 硬件 | 已知问题
|-|-|-
| PVT (2018/5-) | 128或256GB固态硬盘(SSD)和1TB机械硬(HDD)<br/>1.3 GHz GPU
| DVT (2017/12-2018/4) | 东芝(Toshiba)机械硬盘(HDD)<br/>1.2 GHz GPU | 嘈杂<br/>硬盘表现

## 软件兼容性

__图形性能__

- Vulkan 1.0.1
- DirectX 9/10/11/__12__
- OpenGL 4.5
    - 部分支持4.6
    - 使用工具[GLview](http://realtech-vr.com/admin/glview)，查看显卡对OpenGL API支持的等级信息
- __不支持__HDR10输出
    - 硬件和驱动支持HDR10, 但[Windows 10 RS1](os.md)不支持.
    - 可以通过[AGS](amd_gpu_services.md)来添加HDR10支持。

__操作系统__

参见[操作系统](os.md).