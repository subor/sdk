# Run Unity sample on devkit

In this tutorial we're going to install an example based on [Unity 3D](https://unity3d.com/) to a devkit and launch it.

## Prerequsites
- Unity 2017.1.1f1 (newer versions likely work)
- Ruyi console or PC running Windows 10 (demo has not been tested on mobile/Linux/OSX)

## Steps

1. On the devkit, [launch platform and login](layer0_devtools.md#Layer0)
1. Get IPv4 address of devkit.  On the devkit, in command prompt run `ipconfig` (here we will assume `192.168.1.1`).
1. [Download sample](https://bitbucket.org/playruyi/space_shooter) to local PC (here we will assume `d:\dev\unity_demo`).
1. Download and install the RUYI plugin
    - Get the DLLs from the [downloads list](http://dev.playruyi.com/udownloadslist/SDK) (use RuyiSDK/RuyiSDK.nf2.0.zip with Unity)
    - Place the DLLs in d:\dev\unity_demo\Assets\Plugins\x64
1. Launch Unity and open the project at `d:\dev\unity_demo`
1. File -> Build Settings  
![](/docs/img/unity_build.png)
    - Select PC, Mac & Linux Standalone
    - Target Platform is Windows
    - Build button
    - In the file dialog that opens, browse to `d:\dev\unity_demo\SpaceShooter\SpaceShooter\`, for "File name" enter SpaceShooter.exe and click Save button
    - Once it completes you should have a `d:\dev\unity_demo\SpaceShooter\SpaceShooter.exe`
1. Package the sample to create `d:\dev\unity_demo\SpaceShooter.zip`, read [Pack The App](how_to_pack.md) for more details, we will assume the organized folder would be `d:\dev\unity_demo\SpaceShooter`
    `ruyidev.exe apprunner --pack --apppath=d:\dev\unity_demo\SpaceShooter`
1. Install sample to devkit:
    `ruyidev.exe apprunner --hostaddress=192.168.1.1 --installapp --workingchannellist=dev --selectedinstallapp=d:\dev\unity_demo\SpaceShooter.zip`
1. Launch sample on devkit:
    `ruyidev.exe apprunner --hostaddress=192.168.1.1 --runapp --workingchannellist=dev --installedapplist=SpaceShooter`