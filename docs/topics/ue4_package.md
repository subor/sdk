# UE4 Packaging

Consult the latest [UE4 packaging documentation](https://docs.unrealengine.com/latest/INT/Engine/Basics/Projects/Packaging/index.html).

1. Build project in VS with "Shipping" and "Development" config
1. Launch "ProjectLauncher" on menu icon bar. 
1. Create a new Launch Profile
1. Config the custom launch profile
    1. Project part: Set the "Project" to your Unreal project file
    1. Build part: hook nothing
    1. Cook part: "Cooked Platforms:" hook "WindowsNoEditor"
               "Cooked Cultures": hook "en-US"
               "Cooked Maps": hook nothing
               "Release/DLC/Patching Settings": hook and fill nothing
               "Advanced Settings": hook "Compress content", "Save packages without versions", "Store all content in a single file(UnrealPak)"
                                    choose "Shipping" in "Cooker build configuration"
    1. Package part: "How would you like to package the build?" choose "Package & store locally"
                  the path you can just use default one, which the built files will be store in "ProjectFolder/Saved/StagedBuilds"
                  hook "Is this build for distribution to the public"
    1. Archive part: hook nothing
    1. Deploy part: chose "Do not deploy"
1. Go back to Custom Launch Profile interface and click the launch profile icon of the profile, wait for several minutes.
if everything goes well, you can find all built files in "ProjectFolder/Saved/StageBuild/WindowsNoEditor"
1. Copy all those files and runtime libraries (e.g. `lib/zmq/libzmq.dll` and `lib/boost/*.dll` from our SDK) to the Project folder (i.e. `PlatformerGame/`)
1. Create ["res" folder and `RuyiManifest.json` file](app_metadata.md) and use [devtool AppRunner](devtool.md) to pack and run the application
