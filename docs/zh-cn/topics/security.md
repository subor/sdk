# 安全保护

本文是关于Ruyi平台安全方面的说明

## Ruyi系统

[Ruyi系统](os.md)利用Windows10的安全机制功能，最主要包括:

- [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview)驱动加密;硬件驱动上的文件无法被复制或篡改
- [Device Guard](https://docs.microsoft.com/en-us/windows/security/threat-protection/device-guard/device-guard-deployment-guide)签名完整性;只有Windows信任的程序才能运行

## PC模式

[PC模式](pc_mode.md) 目前不提供安全保护机制。我们正在研究潜在方案，不过目前还没有详细规划。