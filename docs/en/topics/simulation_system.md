# Simulation Systems

A _simulation system_ is a standard PC similar to the Ruyi console.

Below follows suggestions and instructions for building a simluation system.

## Recommended Hardware

- [RX470](http://www.amd.com/en-us/products/graphics/radeon-rx-series/radeon-rx-470)
- [Ryzen 1400](https://www.amd.com/en/products/cpu/amd-ryzen-5-1400)
- 6 to 8 GB DDR4 2400

### Differences from Ruyi Console

- Ruyi's APU will be clocked differently (CPU 3Gz- GPU final clock tbd), but otherwise similar feature-wise
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
1. Prepare USB drive with at least 6 GB space and FAT32 format
1. Download [Ruyi OS image](http://dev.playruyi.com/uservices)
1. Copy OS files to root of USB drive and unmount once finished
1. Plug USB drive into simulation system and reboot it
1. A command prompt should appear, wait 20-40 minutes for OS to install
    - Once Windows desktop appears installation is complete
1. __Optional__  Install any needed device drivers or 3rd-party software

### Ruyi Client

Ruyi client-side software should be copied from [SDK](sdk.md) to `c:\ruyi`:
- Layer0
- MainClient
- OverlayClient

See [SDK setup tutorial](../tutorials/setup.md).

### Additional Components

- Visual C++ Redistributable for [Visual Studio 2013 (x64)](https://www.microsoft.com/en-us/download/details.aspx?id=40784) and 
- [Visual Studio 2017 (x64)](https://go.microsoft.com/fwlink/?LinkId=746572)
- Vulkan Runtime 
- [DirectX 9.0c End-User Runtime](https://www.microsoft.com/en-us/download/details.aspx?id=34429)