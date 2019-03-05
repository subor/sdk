# Security

This document covers security aspects of the platform.

## OS

The [OS](os.md) takes advantage of several Windows 10 Enterprise security features, the most notable being:

- [BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-overview) drive encryption; files on the hard drive cannot be copied or tampered with
- "Device Guard Code Integrity" (now called [Windows Defender Application Control](https://docs.microsoft.com/en-us/windows/security/threat-protection/windows-defender-application-control/windows-defender-application-control)); only signed applications can be executed

Additionally:
- `C:\` drive is encrypted, `D:\` is not (and accessible in PC mode)
- Numerous key combinations disabled via [Keyboard Filter](https://docs.microsoft.com/en-us/windows-hardware/customize/enterprise/keyboardfilter) (`Ctrl-Alt-Del`, `Alt-tab`, etc.)
- Windows desktop shell replaced with Ruyi client UI
- Limited [filesystem](#filesystem) and [registry](#registry) access
- Only Apps signed by Ruyi allowed to run in Ruyi OS, if you want to test your app, switch to dev mode from settings and sign your app via [Dev tool](devtool.md)
- Integrity check will happen when it trying to start an app, to prevent the corrupted/modifed apps from running

## Filesystem

In addition to BitLocker drive encryption, we're using a sandbox alike solution to protect app data, so each app will be limited to access data related to itself.

There're 3 kinds of priviledges we provide for the following path:

- __Writable__: installed apps have write access to several per-app systems paths obtained by passing a [`ConstantsSDKDataTypesConstants.*_TAG`](https://subor.github.io/api/cs/en-US/html/d775213e-161b-47f9-5805-e809ff3bfa33.htm) value to [`Storage.GetLocalPath()`](https://subor.github.io/api/cs/en-US/html/d963c51e-f3ba-12c4-29b4-4709cddb26ab.htm) or [`Storage.GetLocalPathAsync()`](https://subor.github.io/api/cs/en-US/html/60abf17d-fc4b-9b1a-445a-7315c0d0a296.htm) (see [example](https://subor.github.io/api/cs/en-US/html/3fb6018e-ad12-b81e-d435-ca30643ebe5b.htm)).
	> You can also visit directories under your current user name, like `C:\\Users\\{user name}` (in C#, use `Environment.UserName`), but we strongly recommend you only write to paths obtained from `GetLocalPath()`.

- __Read-Only__: the app's installation directory is read-only to the app; you __CANNOT__ write to the directory where it is installed or run from.  To get it:
	```C#
	// appid = the app id you get/created for your app, from Subor Team, or on the dev portal.
	var installPath = SDK.Storage.GetLocalPathAsync(ConstantsSDKDataTypesConstants.HDD0_DRIVER_TAG + appid, CancellationToken.None).Result;
	// read any content from installPath, but write to it is forbidden
	```

- __Fully denied__: access to any other app's install/writable/read-only paths or any system path will cause an Exception.


## Registry
During app installation, we create a path in the Windows Registry which is only visible to the current app.  It's safe to save data there and it can't be read/written by other apps:
```C#
// appid = the app id you get/created for your app, from Subor Team, or on the dev portal.
var exclusiveRegistryPath = @"SOFTWARE\Ruyi\Apps\" + appid;
```

## PC mode

[PC mode](pc_mode.md) provides security comparable to a standard Windows 10 desktop PC.  Namely:
- No constraints on which applications can be installed/run
- Users may freely copy/modify files
- Anti-piracy/anti-cheat is on the burden of the application