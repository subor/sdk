# FAQ

## Hardware

1. What CPU/GPU/memory?

    [Hardware specs](topics/hardware.md)

1. Does it have Blueray or DVD drive?  HDD?

    No, neither optical drive.  It will tentatively ship with a 128 GB SSD and 1 TB HDD.  [Details](topics/hardware.md)

1. The devkit I received has a single Toshiba HDD with wretched performance, is that final?

    No, HDD performance problems with first batch of devkits was fixed in later hardware revisions.  [Details](topics/hardware.md#Revisions)

1. Input device (gamepad/keyboard/mouse)?

    It will include a gamepad eerily similar to Xbox.  Keyboard/mouse are also supported.  [Details](topics/input.md)

1. What about peripherals, display/audio ports, etc.?

    USB, HDMI, ethernet, wifi, bluetooth, S/PDIF.  [Details](topics/hardware.md)

1. Is it supposed to be so loud?

    No.  This was a problem with earlier hardware revisions as a result of incomplete thermal design and PSU issues (see [hardware revisions](topics/hardware.md#Revisions)).
    If you have the latest hardware, make sure you've installed the latest [BIOS](topics/bios.md) as it tweaks fan speed control.

## Software/SDK

1. What operating system?

    __Windows 10 IoT Enterprise__.  Also known as Windows 10 Enterprise LTSB 2016.  [Details](topics/os.md)

1. What graphics APIs are supported?

    Vulkan, OpenGL, and DirectX (9-12).  Basically, anything you can use on Windows 10.  [Details](topics/hardware.md)

1. What programming languages are supported?

    Lots; everything supported by [Apache Thrift](https://thrift.apache.org/docs/features).

1. Which (C++) compiler toolchain?  Is Visual Studio supported?

    Yes, you can use Visual Studio.  You can use any toolchain with which you can create programs for Windows 10.

1. Is API/SDK/middle-ware XYZ supported?

    If it works on AMD hardware and Windows 10 RS1, it probably works on Ruyi.

1. Is Unreal Engine (UE4)/Unity3D supported?  What about engine XYZ?

    Yes.  If it works on AMD hardware and Windows 10 RS1, it probably works on Ruyi.

1. How do I get started?

    - Take a look at the [tutorials](tutorials/)
    - Try [profiling](topics/optimization.md) your game on the hardware

1. My question isn't answered here, I need help, what do I do?

    - Try [searching for it](https://github.com/subor/sdk/search) ([see Repository Search](topics/support.md#repository-search))
    - Check [online documentation](README.md)
    - Try [support resources](topics/support.md) like [forums](http://dev.playruyi.com/forum/) and [tickets](https://github.com/subor/sdk/issues)

## Platform/Publishing

1. What features will be available?

    We plan to eventually have a feature list similar to Xbox Live, PSN, Steam, GoG, etc.

1. Can you be more specific?

    Achievments, friends, chat, leaderboards, match making, tournaments, cloud saves, screenshot/video sharing, live-streaming, IAP, etc.

1. How are games distributed?

    Primarily digital download.  We're also considering ways to do offline install via USB storage.

1. What about security?

    [Ruyi OS](topics/os.md) provides security measures comparable to other consoles.  Premium content is protected against un-authorized copying.  Cheating is prevented by blocking bots, disallowing content tampering, etc..  [Details](topics/security.md)

1. Does [PC mode](topics/pc_mode.md) have DRM or anti-copy technology similar to Steam?  What about other security, anti-cheat, etc.?

    PC mode is similar to a regular desktop PC environment; there is no DRM, anti-copy, anti-cheat, etc.  We are investigating providing some solution, but there is currently no roadmap.

1. Will there be TRC/TCR?

    Yes.  We are well aware how much developers hate them despite them being for the benefit of consumers.  [Details](topics/trc.md)

1. What is the submission process and how long will it take?

    We will have more details by summer/fall 2018.

1. What about government censorship for China?

    For early titles that will be handled offline/manually by our content/publishing team.



## Layer0

1. layer0 crashes on devkit when using version downloaded from [dev portal](http://dev.playruyi.com/) (see [issue](https://bitbucket.org/playruyi/support/issues/3))
    
    > Due to IE security, untrusted files downloaded from the Internet will be in __Blocked__ state.  Right-click the executable (such as Layer0.exe), enable __Unblock file__, then __Apply__.  
    Alternatively, you can use PowerShell command `Get-ChildItem c:\\ruyi\\*.* -Recurse | Unblock-File` to unblock all files.