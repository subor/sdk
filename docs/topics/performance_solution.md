# Performance Solution

This document is about solution to performance issues developers reported. We list them here so if anyone encoutered similar problems, they can find a solution quickly.

- When using Unity3d's particles system, when you use mesh in Render tag, you can click "Enable Mesh GPU instancing" option and use "Particles/Standard Surface" with your material to improve the performance, this is only availalbe in 2018 later version. This will improve a lot when you using large-vertex-number mesh and high particles numbers. In 2017 older version, we suggest split one particle object into multiple ones with lower params which will have similar effect, or you can refine your artistic resource or with lower-cost shader etc.
![](/docs/img/unity_ruyinet.png)
