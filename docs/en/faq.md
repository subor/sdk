# FAQ

## Hardware

1. What CPU/GPU/memory?

    [Hardware specs](topics/hardware.md)

1. Does it have Blueray or DVD drive?  HDD?

    No, neither optical drive.  It will tentatively ship with a 128 GB SSD and 1 TB HDD.

1. The devkit I received has a single Toshiba HDD with wretched performance, is that final?

    No, HDD performance problems with first batch of devkits are a known issue which later hardware revisions will correct.

1. Input device (gamepad/keyboard/mouse)?

    It will include a gamepad eerily similar to Xbox.  Keyboard/mouse are also supported.

1. What about peripherals, display/audio ports, etc.?

    USB, HDMI, ethernet, wifi, bluetooth, S/PDIF.  [Details](topics/hardware.md)

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

    - Take a look at the [tutorials](https://bitbucket.org/playruyi/docs/src/master/docs/en/tutorials/)
    - Try [profiling](https://bitbucket.org/playruyi/docs/src/master/docs/en/topics/optimization.md) your game on the hardware

1. My question isn't answered here, I need help, what do I do?

    There's [more documentation](README.md), [forums](http://dev.playruyi.com/forum/), and [dev support](https://bitbucket.org/playruyi/support) (including [tickets](https://bitbucket.org/playruyi/support/issues?status=new&status=open)).

## Platform/Publishing

1. What features will be available?

    We plan to eventually have a feature list similar to Xbox Live, PSN, Steam, GoG, etc.

1. Can you be more specific?

    Achievments, friends, chat, leaderboards, match making, tournaments, cloud saves, screenshot/video sharing, live-streaming, IAP, etc.

1. How are games distributed?

    Primarily digital download.  We're also considering ways to do offline install via USB storage.

1. What about security?

    Ruyi provides security measures comparable to other consoles.  Premium content is protected against un-authorized copying.  Cheating is prevented by blocking bots, disallowing content tampering, etc..  [Details](topics/security.md)

1. Will there be TRC/TCR?

    Yes.  We are well aware how much developers hate them despite them being for the benefit of consumers.

1. What is the submission process and how long will it take?

    We will have more details by summer/fall 2018.

1. What about government censorship for China?

    For early titles that will be handled offline/manually by our content/publishing team.



## Layer0

1. layer0 crashes on devkit when using version downloaded from [dev portal](http://dev.playruyi.com/) (see [issue](https://bitbucket.org/playruyi/support/issues/3))
    
    > Due to IE security, untrusted files downloaded from the Internet will be in __Blocked__ state.  Right-click the executable (such as Layer0.exe), enable __Unblock file__, then __Apply__.  
    Alternatively, you can use PowerShell command `Get-ChildItem c:\\ruyi\\*.* -Recurse | Unblock-File` to unblock all files.