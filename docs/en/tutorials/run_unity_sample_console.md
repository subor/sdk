# Run Unity sample on devkit

In this tutorial we're going to install an example based on [Unity 3D](https://unity3d.com/) to a devkit and launch it.

## Prerequsites
- Unity 2017.1.1f1 (newer versions likely work)
- Ruyi console or PC running Windows 10 (demo has not been tested on mobile/Linux/OSX)

## Steps

1. On the devkit, [launch platform and login](layer0_devtools.md#Layer0)
1. Get IPv4 address of devkit.  On the devkit, in command prompt run `ipconfig` (here we will assume `192.168.1.1`).
1. [Download sample](https://bitbucket.org/playruyi/space_shooter) to local PC (here we will assume `d:\dev\unity_demo`).
1. Launch Unity and open the project at `d:\dev\unity_demo`
1. File -> Build Settings  
![](/img/unity_build.png)
    - Select PC, Mac & Linux Standalone
    - Target Platform is Windows
    - Build button
    - In the file dialog that opens, browse to `d:\dev\unity_demo\Pack\space_shooter\`, for "File name" enter space_shooter.exe and click Save button
    - Once it completes you should have a `d:\dev\unity_demo\Pack\space_shooter\space_shooter.exe`
1. Package the sample to create `d:\dev\unity_demo\Pack.zip`:
    `ruyidev.exe apprunner --pack --apppath=d:\dev\unity_demo\Pack`
1. Install sample to devkit:
    `ruyidev.exe apprunner --hostaddress=192.168.1.1 --installapp --workingchannellist=dev --selectedinstallapp=d:\dev\unity_demo\Pack.zip`
1. Launch sample on devkit:
    `ruyidev.exe apprunner --hostaddress=192.168.1.1 --runapp --workingchannellist=dev --installedapplist=com.playruyi.space_shooter`