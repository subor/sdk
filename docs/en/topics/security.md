# Security

This document covers security aspects of the platform.

## Ruyi OS

[Ruyi OS](os.md) takes advantage of several Windows 10 security features, the most notable being:

- [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview) drive encryption; files on the hard drive cannot be copied or tampered with
- [Device Guard](https://docs.microsoft.com/en-us/windows/security/threat-protection/device-guard/device-guard-deployment-guide) code integrity; only signed applications can be executed

## PC mode

[PC mode](pc_mode.md) currently provides no security of any kind.  We are investigating potential solutions however there is currently no roadmap.