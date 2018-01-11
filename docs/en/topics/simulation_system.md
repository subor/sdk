# Simulation Systems

A _simulation system_ is a standard PC similar to the Ruyi console.

Below follows suggestions and instructions for building a simluation system or converting a regular PC.

## Recommended Hardware

- [RX470](http://www.amd.com/en-us/products/graphics/radeon-rx-series/radeon-rx-480)
- [Ryzen 1400](https://www.amd.com/en/products/cpu/amd-ryzen-5-1400)
- 6 to 8 GB DDR4 2400

### Differences from Ruyi Console

- Ruyi's APU will be clocked differently (CPU 3Gz- GPU final clock tbd), but otherwise similar
- Ruyi has 8GB GDDR5 of shared system memory with 2GB reserved for the GPU

## Software

Ruyi platform can be installed to a PC.  By default it includes:

- [Windows 10 IoT Enterprise](os.md)
- [Client software](layer0.md)
- Device drivers for console hardware

### Instructions

1. Consult manfucturer documentation to configure system BIOS:
    - Enable TPM (either iTPM of dTPM)
    - Enable Intel VT-x / AMD-V (or SVM) virtualization
    - Enable UEFI boot
    - Enable Secure boot
1. Prepare USB drive with at least 6GB space and FAT32 format
1. Copy Ruyi OS files to root of USB drive and unmount once finished
1. Plug USB drive into simulation system and boot from it
    - May need to configure BIOS to boot from USB before HDD
1. A command prompt should appear, wait 20-40 minutes for OS to install
    - Once Windows desktop appears installation is complete
1. __Optional__  Install any needed device drivers or 3rd-party software

## Ruyi Platform

Ruyi platform (e.g. [layer0](layer0.md)) should be installed to `c:\ruyi`:

![](/docs/img/layer0_path.png)