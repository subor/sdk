# New Developers

## Registration

You need an app ID and secret from us.  If you have not received it, contact developer@playruyi.com.

## Development Environment

- Workstation running __64-bit Windows 10__ RS3+ (aka 1709, Fall Creator's Update)
- [Microsoft Sync Framework](https://www.microsoft.com/en-us/download/details.aspx?id=19502) (click __Download__ and select "Synchronization-v2.1-x64-ENU.msi")
- [Supported gamepad](input.md#supported-devices)

The following may also be necessary in some situations:

- [git](https://git-scm.com/)
- [Visual Studio 2017](https://www.visualstudio.com/vs/community/) 15.3+
- [Console additional runtime components](#console-additional-runtime-components)

Other variations _might_ work, but they aren't tested extensively; YMMV.

### Console Additional Runtime Components

The following components are available on the console as part of the OS installation:

| Component | Link | Notes
|-|-|-
Microsoft Sync Framework | [link](https://www.microsoft.com/en-us/download/details.aspx?id=19502) | Used to transfer builds from devtool on PC to console
Visual C++ Redistributable for VS 2008 | [x86](https://www.microsoft.com/en-us/download/details.aspx?id=29) and [x64](https://www.microsoft.com/en-us/download/details.aspx?id=15336) | Needed by some apps/games
Visual C++ Redistributable for VS 2010 | [x86](https://www.microsoft.com/en-us/download/details.aspx?id=5555) and [x64](https://www.microsoft.com/en-us/download/details.aspx?id=14632) | Needed by some apps/games
Visual C++ Redistributable for VS 2012 | [x86/x64](https://www.microsoft.com/en-us/download/details.aspx?id=30679) | Needed by some apps/games
Visual C++ Redistributable for VS 2013 | [x86/x64](https://www.microsoft.com/en-us/download/details.aspx?id=40784) | Needed by main client some apps/games
Visual C++ Redistributable for VS 2017 | [x86/x64](https://go.microsoft.com/fwlink/?LinkId=746572) | Needed by layer0 and some apps/games.  Also covers VS 2015.
Vulkan Runtime v1.0.54.0 | [x86/x64](https://vulkan.lunarg.com/sdk/home) | Needed by some apps/games
DirectX 9.0c End-User Runtime | [link](https://www.microsoft.com/en-us/download/details.aspx?id=34429) | Needed by some apps/games
.NET Framework 3.5 | [link](https://www.microsoft.com/en-us/download/details.aspx?id=22) | Needed by some apps/games
