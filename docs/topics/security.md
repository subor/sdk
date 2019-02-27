# Security

This document covers security aspects of the platform.

## Ruyi OS

[Ruyi OS](os.md) takes advantage of several Windows 10 security features, the most notable being:

- [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview) drive encryption; files on the hard drive cannot be copied or tampered with
- [Device Guard](https://docs.microsoft.com/en-us/windows/security/threat-protection/device-guard/device-guard-deployment-guide) code integrity; only signed applications can be executed  

Along with above, 
- Sandbox, data access has been limited to your own app related paths, read [Storage](storage.md) for more info
- Only Apps signed by Ruyi allowed to run in Ruyi OS, if you want to test your app, switch to dev mode from settings and sign your app via [Dev tool](devtool.md)
- Integrity check will happen when it trying to start an app, to prevent the corrupted/modifed apps from running

## PC mode

[PC mode](pc_mode.md) provides no security of any kind.