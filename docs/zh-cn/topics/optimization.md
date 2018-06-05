# 优化

## 针对硬件

参考[硬件](hardware.md).

__说明__

- Zen微架构比前几代多52%的IPC。([source](https://www.anandtech.com/show/11143/amd-launch-ryzen-52-more-ipc-eight-cores-for-under-330-preorder-today-on-sale-march-2nd))

## 建议

- 优先使用性能分析器:
    - 使用引擎自带的性能分析器([虚幻4](https://docs.unrealengine.com/latest/INT/Engine/Performance/Profiler/index.html), [Unity](https://docs.unity3d.com/Manual/Profiler.html)等等。)
    - [Radeon GPU性能分析器](https://gpuopen.com/gaming-product/radeon-gpu-profiler-rgp/)
    - [GPUView](https://docs.microsoft.com/en-us/windows-hardware/drivers/display/using-gpuview)
    - [PIX](https://blogs.msdn.microsoft.com/pix/download/)
- 实际表现对比目标性能:
    - 使用超过6GB系统内存或2GB显存可能会导致性能瓶颈。:
        - 达到30帧: 极高/高(Ultra/High)画质下分辨率1080p到2k，或者高(High)画质下2k到4k
        - 达到60帧: 极高(Ultra)画质下分辨率1080p，高(High)画质下2k
        
## Benchmarks(性能测试软件)

以下是使用benchmarks测试的游戏性能表现,这些游戏对内存需求相对较高。

名称 | 画质 | 分辨率 | FPS
-|-|-|-
Rise of the Tomb Raider | 高(High) | 4k | 27
Rise of the Tomb Raider | 非常高(Very High) | 1080p | 24
Shadow of Mordor | 高(High) | 4k | 38
Shadow of Morder | 极高(Ultra) | 1080p | 78
Shadow of Morder | 极高(Ultra) | 1440p | 44

## 优化手段

- 使用[Vulkan API](https://www.khronos.org/vulkan/)
- 使用FP16.  Vega的 __Rapid Packed Math__ 可以通过使用单精度浮点数提高性能([source](https://www.anandtech.com/show/11143/amd-launch-ryzen-52-more-ipc-eight-cores-for-under-330-preorder-today-on-sale-march-2nd))
- 咨询[AMD图形处理器服务(AMD GPU Services)](amd_gpu_services.md)

## 相关资源

- [GPUOpen](https://gpuopen.com/)
    - [Vega ISA](https://developer.amd.com/wp-content/resources/Vega_Shader_ISA_28July2017.pdf)
- [Zen (family 17h) CPU优化指南](http://support.amd.com/TechDocs/55723_SOG_Fam_17h_Processors_3.00.pdf) (from [AMD Developer Resources](https://developer.amd.com/resources/developer-guides-manuals/))
