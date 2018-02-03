# Optimization

## Hardware

- AMD APU
    - Zen 4 core w/ SMT (8 hw threads) @ 3 GHz
    - Vega (GCN 5th generation) 24 CU @ 1.3 GHz
        - 16 TFLOPS half-precision, 8 TFLOPS single, 4 TFLOPS double
- 8 GB GDDR5 shared memory
    - 256 GB/s bandwidth
    - 2 GB reserved for GPU

__Comments__
- Zen microarchitecture has 52% more IPC over previous generations ([source](https://www.anandtech.com/show/11143/amd-launch-ryzen-52-more-ipc-eight-cores-for-under-330-preorder-today-on-sale-march-2nd))

    
## Hardware

- AMD APU
    - Zen 4 core (8 hw threads) @ 3 GHz
    - Vega (GCN 5th generation) 24 CU @ 1.3 GHz
        - 16 TFLOPS half-precision, 8 TFLOPS single, 4 TFLOPS double
- 8 GB GDDR5 shared memory
    - 256 GB/s bandwidth
    - 2 GB reserved for GPU))

## General

- Profile first:
    - Use profiler included with your engine ([UE4](https://docs.unrealengine.com/latest/INT/Engine/Performance/Profiler/index.html), [Unity](https://docs.unity3d.com/Manual/Profiler.html))
    - [Radeon GPU Profiler](https://gpuopen.com/gaming-product/radeon-gpu-profiler-rgp/)
- GPU:
    - Use [Vulkan API](https://www.khronos.org/vulkan/)
    - Use FP16.  Vega's __Rapid Packed Math__ can _double_ throughput over single-precision float ([source](https://www.anandtech.com/show/11143/amd-launch-ryzen-52-more-ipc-eight-cores-for-under-330-preorder-today-on-sale-march-2nd))



## Resources

- [GPUOpen](https://gpuopen.com/)
    - [Vega ISA](https://developer.amd.com/wp-content/resources/Vega_Shader_ISA_28July2017.pdf)
- [Zen (17h) CPU Optimization Guide](http://support.amd.com/TechDocs/55723_SOG_Fam_17h_Processors_3.00.pdf) (from [AMD Developer Resources](https://developer.amd.com/resources/developer-guides-manuals/))
