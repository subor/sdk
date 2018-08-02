# Simulation Systems

A _simulation system_ is a standard PC similar to the Ruyi console.

Below follows suggestions and instructions for building a simluation system.

## Recommended Hardware

- [RX470](http://www.amd.com/en-us/products/graphics/radeon-rx-series/radeon-rx-470)
- [Ryzen 1400](https://www.amd.com/en/products/cpu/amd-ryzen-5-1400)
- 6 to 8 GB DDR4 2400

### Differences from Ruyi Console

- Ruyi's APU will be clocked differently (CPU 3Gz, GPU 1.2GHz), but otherwise similar feature-wise
- Ruyi has 8 GB GDDR5 of shared system memory with 2GB reserved for the GPU

## Software

Ruyi platform can be installed to a PC.  By default it includes:

- [Windows 10 IoT Enterprise](os.md)
- [Client software](layer0.md)
- Device drivers for console hardware

### Instructions

1. Consult manufacturer documentation to configure system BIOS:
    - Enable TPM (either iTPM of dTPM)
    - Enable Intel VT-x / AMD-V (or SVM) virtualization
    - Enable UEFI boot
    - Enable Secure boot
    - Boot from USB before HDD
1. Follow Ruyi OS [installation instructions](os.md#Installation)
1. __Optional__  Install any needed device drivers or 3rd-party software

### Ruyi Client

Ruyi client-side software should be copied from [SDK](sdk.md) to `c:\ruyi`:

- Layer0
- MainClient
- OverlayClient

See [SDK setup tutorial](../tutorials/setup.md).

### Additional Components

| Component | Link | Notes
|-|-|-
Visual C++ Redistributable for VS 2008 | [x86](https://www.microsoft.com/en-us/download/details.aspx?id=29) and [x64](https://www.microsoft.com/en-us/download/details.aspx?id=15336) | Needed by some apps/games
Visual C++ Redistributable for VS 2010 | [x86](https://www.microsoft.com/en-us/download/details.aspx?id=5555) and [x64](https://www.microsoft.com/en-us/download/details.aspx?id=14632) | Needed by some apps/games
Visual C++ Redistributable for VS 2012 | [x86/x64](https://www.microsoft.com/en-us/download/details.aspx?id=30679) | Needed by some apps/games
Visual C++ Redistributable for VS 2013 | [x86/x64](https://www.microsoft.com/en-us/download/details.aspx?id=40784) | Needed by main client some apps/games
Visual C++ Redistributable for VS 2017 | [x86/x64](https://go.microsoft.com/fwlink/?LinkId=746572) | Needed by layer0 and some apps/games.  Also covers VS 2015.
Vulkan Runtime v1.0.54.0 | [x86/x64](https://vulkan.lunarg.com/sdk/home) | Needed by some apps/games
DirectX 9.0c End-User Runtime | [link](https://www.microsoft.com/en-us/download/details.aspx?id=34429) | Needed by some apps/games
.NET Framework 3.5 | [link](https://www.microsoft.com/en-us/download/details.aspx?id=22) | Needed by some apps/games