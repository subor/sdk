# Hardware Features

## Hardware

- AMD APU
    - Zen 4 core w/ SMT (8 hw threads) @ 3 GHz
    - Vega (GFX9/GCN 5th generation) 24 CU @ 1.3 GHz
        - 8 TFLOPS half-precision, 4 TFLOPS single-precision
- 8 GB GDDR5 shared memory
    - 256 GB/s bandwidth
    - 2 GB reserved for GPU
- Ports/peripherals
    - 4x USB 3.0 (back), 2x USB 2.0 (front)
    - 2x HDMI 2.0
    - Wifi/802.11ac
    - 100Mbit ethernet
    - Bluetooth
    - 2x 3.5mm audio (input/output)
    - S/PDIF

## Software Compatibility

__Graphics__

- Vulkan 1.0.1
- DirectX 9/10/11/__12__
- OpenGL 4.5
    - 4.6 support is partial
    - Use a tool like [GLview](http://realtech-vr.com/admin/glview) for list of supported extensions
- HDR10 output is __not__ supported
    - The hardware and driver support HDR10, but [Windows 10 RS1](os.md) does not.
    - It is possible to add HDR10 support on a per-title basis via [AGS](amd_gpu_services.md).

__Operating System__

See [Operating System](os.md).