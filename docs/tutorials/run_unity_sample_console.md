# Run Unity sample on Console

In this tutorial we're going to install an example based on [Unity 3D](https://unity3d.com/) to a console and launch it.

## Prerequsites
- Unity 2017.1.1f1 (newer versions likely work)
- Ruyi console

## Steps

1. On the console, [launch platform and login](setup.md)
1. Get IPv4 address of console (here we will assume `192.168.1.1`).  On the devkit:
    - In main client: __Settings > Network > Check Network Status > IP Address__
    - In [PC mode](../topics/pc_mode), open a command prompt and run `ipconfig`
1. [Download sample](https://github.com/subor/sample_unity_space_shooter) to local PC (here we will assume `d:\dev\sample_unity_space_shooter`).
1. Setup the SDK
    - Download the [latest version of the SDK](https://github.com/subor/sdk/releases)
    - Place the DLLs from `RuyiSDK.nf2.0/` in d:\dev\sample_unity_space_shooter\Assets\Plugins\x64
1. Launch Unity and open the project at `d:\dev\sample_unity_space_shooter`
1. __File -> Build Settings__  
![](/docs/img/unity_build.png)
    - Select __PC, Mac & Linux Standalone__
    - _Target Platform_ is `Windows`
    - _Architecture_ is `x86_64`
    - Click __Build__ button
    - In the file dialog that opens, browse to `d:\dev\sample_unity_space_shooter\Pack\space_shooter\`, for "File name" enter `SpaceShooter.exe` and click __Save__ button
    - Once it completes you should have a `d:\dev\sample_unity_space_shooter\Pack\space_shooter\SpaceShooter.exe`
1. Sign the build
    - Launch [devtool](../topics/devtool) and select __Sign Tool__
    - For __App's RuyiManifest__ browse to `d:\dev\sample_unity_space_shooter\Pack\RuyiManifest.json` 
    - Click __Sign App__
1. Install sample to devkit:
    - In devtool select __App Runner__
    - For __App's RuyiManifest__ browse to `d:\dev\sample_unity_space_shooter\Pack\RuyiManifest.json` - Click __Install App__
1. Launch sample on devkit:
    - Make sure the app is selected in __Installed Apps__
    - Click __Run App__

## Additional Information

- [Running Apps](../topics/run_app.md)
- [RuyiManifest](../topics/app_metadata)
- [Sign Tool](../topics/devtool#sign-tool)
- [App Runner](../topics/devtool#app-runner)