# Optimization

## Hardware

- AMD APU
    - Zen 4 core w/ SMT (8 hw threads) @ 3 GHz
    - Vega (GCN 5th generation) 24 CU @ 1.3 GHz
        - 8 TFLOPS half-precision, 4 TFLOPS single
- 8 GB GDDR5 shared memory
    - 256 GB/s bandwidth
    - 2 GB reserved for GPU

__Comments__

- Zen microarchitecture has 52% more IPC over previous generations ([source](https://www.anandtech.com/show/11143/amd-launch-ryzen-52-more-ipc-eight-cores-for-under-330-preorder-today-on-sale-march-2nd))

## Suggestions

- Profile first:
    - Use profiler included with your engine ([UE4](https://docs.unrealengine.com/latest/INT/Engine/Performance/Profiler/index.html), [Unity](https://docs.unity3d.com/Manual/Profiler.html), etc.)
    - [Radeon GPU Profiler](https://gpuopen.com/gaming-product/radeon-gpu-profiler-rgp/)
    - [PIX](https://blogs.msdn.microsoft.com/pix/download/)
- Performance vs. quality targets:
    - Exceeding either 6 GB of system or 2 GB graphics memory will result in performance penalty.  In general:
        - 30 FPS: 1080p to 2k on Ultra/Very High settings, or 2k to 4k on High
        - 60 FPS: 1080p on Ultra, 2k on High

## Optimizations

- Use [Vulkan API](https://www.khronos.org/vulkan/)
- Use FP16.  Vega's __Rapid Packed Math__ can _double_ throughput over single-precision float ([source](https://www.anandtech.com/show/11143/amd-launch-ryzen-52-more-ipc-eight-cores-for-under-330-preorder-today-on-sale-march-2nd))

## Resources

- [GPUOpen](https://gpuopen.com/)
    - [Vega ISA](https://developer.amd.com/wp-content/resources/Vega_Shader_ISA_28July2017.pdf)
- [Zen (family 17h) CPU Optimization Guide](http://support.amd.com/TechDocs/55723_SOG_Fam_17h_Processors_3.00.pdf) (from [AMD Developer Resources](https://developer.amd.com/resources/developer-guides-manuals/))
