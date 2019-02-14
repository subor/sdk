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
1. [Download sample](https://github.com/subor/sample_unity_space_shooter) to local PC (here we will assume `d:\dev\unity_demo`).
1. Setup the SDK
    - Download the [latest version of the SDK](https://github.com/subor/sdk/releases)
    - Place the DLLs from `RuyiSDK.nf2.0/` in d:\dev\unity_demo\Assets\Plugins\x64
1. Launch Unity and open the project at `d:\dev\unity_demo`
1. __File -> Build Settings__  
![](/docs/img/unity_build.png)
    - Select __PC, Mac & Linux Standalone__
    - _Target Platform_ is `Windows`
    - _Architecture_ is `x86_64`
    - Click __Build__ button
    - In the file dialog that opens, browse to `d:\dev\unity_demo\SpaceShooter\SpaceShooter\`, for "File name" enter SpaceShooter.exe and click __Save__ button
    - Once it completes you should have a `d:\dev\unity_demo\SpaceShooter\SpaceShooter.exe`
1. Package the sample to create `d:\dev\unity_demo\SpaceShooter.zip`, read [Pack The App](how_to_pack.md) for more details, we will assume the organized folder would be `d:\dev\unity_demo\SpaceShooter`
    `ruyidev.exe apprunner --pack --apppath=d:\dev\unity_demo\SpaceShooter`
1. Install sample to devkit:
    `ruyidev.exe apprunner --hostaddress=192.168.1.1 --installapp --workingchannellist=dev --selectedinstallapp=d:\dev\unity_demo\SpaceShooter.zip`
1. Launch sample on devkit:
    `ruyidev.exe apprunner --hostaddress=192.168.1.1 --runapp --workingchannellist=dev --installedapplist=SpaceShooter`