# UE4 Packaging

Consult the latest [UE4 packaging documentation](https://docs.unrealengine.com/latest/INT/Engine/Basics/Projects/Packaging/index.html).

1. Open project in Visual Studio and build __Shipping__ configuration
1. From menu icon bar expand __Launch__ options and select __Project Launcher__  
    ![](/docs/img/ue4_launch_project_launcher.png)
1. Create a new Launch Profile  
    ![](/docs/img/ue4_add_custom_launch_profile.png)
1. Config the custom launch profile:  
    - __Project__: Select your UE4 `.uproject` file
    - __Build__: Leave unchanged
    - __Cook__: First select __By the book__
        - Cooked Platforms: select __WindowsNoEditor__
        - Cooked Cultures: select __en-US__
        - Cooked Maps: select __Show all__ then Select: __All__
        - Release/DLC/Patching Settings: Leave unchanged
        - Advanced Settings:
            - Enable: __Compress content__, __Save packages without versions__, and __Store all content in a single file (UnrealPak)__
            - For "Cooker build configuration" choose __Shipping__
    - __Package__:
        - Choose __Package & store locally__
        - Default output path is `<Project>/Saved/StagedBuilds`
        - Enable __Is this build for distribution to the public__
    - __Archive__: Leave unchanged
    - __Deploy__: Choose __Do not deploy__
1. Click __Back__ button to return to __Project Launcher__ and click the launch profile icon of the profile:  
    ![](/docs/img/ue4_launch_profile.png)
    - The cooking/packaging process will take around __5__ minutes and the build will be placed in package output path (default is `<Project>/Saved/StagedBuilds/<Platform>/`)
1. Copy Ruyi SDK runtime libraries (i.e. `lib/zmq/libzmq.dll` and `lib/boost/*.dll`) to `Binaries/Win64/` folder (e.g. `<Project>/Saved/StagedBuilds/WindowsNoEditor/PlatformerGame/Binaries/Win64/`)
1. Ensure [layer0](layer0) is running and double-click the output `.exe` (e.g. `PlatformerGame.exe`) to test the game build
1. Create [`res/` folder and `RuyiManifest.json` file](app_metadata.md) in platform output folder (i.e. `Saved/StagedBuilds/WindowsNoEditor/`)
    - See [UE4 sample](https://github.com/subor/sample_ue4_platformer/tree/master/Pack) for an example of these files
    - Final directory structure should be similar to:  

            |   
            |   PlatformerGame.exe
            |   RuyiManifest.json
            |   
            +---Engine
            |                   
            +---PlatformerGame
            |   +---Binaries
            |   |   \---Win64
            |   |           boost_chrono-vc141-mt-1_64.dll
            |   |           ...
            |   |           libzmq.dll
            |   |           PlatformerGame.exe
            |   |           PlatformerGame.pdb
            |   \---...
            |               
            \---res
                |   i18n.json
                |   
                +---hd
                |       
                \---ld

1. Use [devtool AppRunner](devtool.md) to pack, install, and run the application:  
    ![](/docs/img/devtool_ue4_runner.png)