# Run UE4 sample on local PC

In this tutorial we're going to install an example based on [UE4](https://www.unrealengine.com/) to your local PC and launch it.

All the following steps should be done on your local PC.

1. [Launch platform and login](layer0_devtools.md#Layer0)
1. [Download sample](https://bitbucket.org/playruyi/unreal_demo).  We will assume `c:\ue4_demo\`.
1. Build sample?
1. Package the sample:
    `ruyidev.exe apprunner --pack --apppath=c:\ue4_demo\`
1. Install sample:
    `ruyidev.exe apprunner --installapp --workingchannellist=dev --installedapplist=com.playruyi.unreal_demo`
1. Launch sample:
    `ruyidev.exe apprunner --runapp --workingchannellist=dev --installedapplist=com.playruyi.unreal_demo`
