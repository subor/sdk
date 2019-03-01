# Security

This document covers security aspects of the platform.

## Ruyi OS

[Ruyi OS](os.md) takes advantage of several Windows 10 Enterprise security features, the most notable being:

- [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview) drive encryption; files on the hard drive cannot be copied or tampered with
- "Device Guard Code Integrity" (now called [Windows Defender Application Control](https://docs.microsoft.com/en-us/windows/security/threat-protection/windows-defender-application-control/windows-defender-application-control)); only signed applications can be executed

Additionally:
- `C:\` drive is encrypted, `D:\` is not (and accessible in PC mode)
- Numerous key combinations disabled (`Ctrl-Alt-Del`, `Alt-tab`, etc.)
- Windows desktop shell replaced with Ruyi client UI
- Sandbox, data access has been limited to your own app related paths, read [Storage](storage.md) for more info
- Only Apps signed by Ruyi allowed to run in Ruyi OS, if you want to test your app, switch to dev mode from settings and sign your app via [Dev tool](devtool.md)
- Integrity check will happen when it trying to start an app, to prevent the corrupted/modifed apps from running



## PC mode

[PC mode](pc_mode.md) provides security comparable to a standard Windows 10 desktop PC.  Namely:
- No constraints on which applications can be installed/run
- Users may freely copy/modify files
- Anti-piracy/anti-cheat is on the burden of the application