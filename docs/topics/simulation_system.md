# 虚拟主机系统

__虚拟主机系统__指在普通PC上安装和Ruyi主机近似的操作系统环境。

按照以下建议说明搭建一个虚拟主机系统。

## 硬件推荐配置

- [RX470](http://www.amd.com/en-us/products/graphics/radeon-rx-series/radeon-rx-470)
- [Ryzen 1400](https://www.amd.com/en/products/cpu/amd-ryzen-5-1400)
- 6到8GB DDR4 2400

### 和Ruyi主机的区别

- Ruyi主机的APU时钟频率不同(CPU 3Gz, GPU 1.2GHz), 其他功能相近
- Ruyi主机拥有8GB的GDDR5系统共享内存，2GB显存

## 软件

可以在普通PC上安装Ruyi平台，默认内容包括:

- [Windows 10 IoT企业版](os.md)
- [客户端软件](layer0.md)
- 驱动设备

### 说明

1. 查看厂商说明书来配置系统BIOS：
    - 开启TPM (either iTPM of dTPM)
    - 开启Intel VT-x / AMD-V (或SVM)虚拟化
    - 开启UEFI boot
    - 开启Secure boot
    - 设置USB启动优先于HDD
1. 参看Ruyi系统[安装说明](os.md#Installation)
1. __选择性__地安装需要的设备驱动或者第三方软件。

### Ruyi客户端

Ruyi客户端所需软件参照[SDK](sdk.md)，将SDK文件复制到`c:\ruyi`下：

- Layer0
- 主客户端（MainClient）
- 游戏界面客户端（OverlayClient）

具体参照[SDK安装指引](../tutorials/setup.md).

### 附加组件

| 组件 | 链接 | 备注
|-|-|-
Visual C++ Redistributable for VS 2008 | [x86](https://www.microsoft.com/en-us/download/details.aspx?id=29) 和 [x64](https://www.microsoft.com/en-us/download/details.aspx?id=15336) | 部分应用/现有需要
Visual C++ Redistributable for VS 2010 | [x86](https://www.microsoft.com/en-us/download/details.aspx?id=5555) 和 [x64](https://www.microsoft.com/en-us/download/details.aspx?id=14632) | 部分应用/现有需要
Visual C++ Redistributable for VS 2012 | [x86/x64](https://www.microsoft.com/en-us/download/details.aspx?id=30679) | 部分应用/现有需要
Visual C++ Redistributable for VS 2013 | [x86/x64](https://www.microsoft.com/en-us/download/details.aspx?id=40784) | 主客户端及部分应用/现有需要
Visual C++ Redistributable for VS 2017 | [x86/x64](https://go.microsoft.com/fwlink/?LinkId=746572) | Layer0及部分应用/现有需要。VS 2015亦可
Vulkan Runtime v1.0.54.0 | [x86/x64](https://vulkan.lunarg.com/sdk/home) | 部分应用/现有需要
DirectX 9.0c End-User Runtime | [link](https://www.microsoft.com/en-us/download/details.aspx?id=34429) | 部分应用/现有需要
.NET Framework 3.5 | [link](https://www.microsoft.com/en-us/download/details.aspx?id=22) | 部分应用/现有需要