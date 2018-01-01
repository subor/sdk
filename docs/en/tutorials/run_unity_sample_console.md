# Run Unity sample on devkit

In this tutorial we're going to install an example based on [Unity](https://unity3d.com/) to a devkit and launch it.

1. On the devkit, [launch platform and login](layer0_devtools.md#Layer0)
1. Get ipv4 address of devkit.  In command prompt run `ifconfig`
1. [Download sample](https://bitbucket.org/playruyi/space_shooter) to local PC
1. Package the sample:
    `ruyidev.exe apprunner --pack --apppath=PATH-OF-SAMPLE`
1. Install sample to devkit:
    `ruyidev.exe apprunner --installapp --workingchannellist=dev --installedapplist=com.playruyi.space_shooter`
1. Launch sample on devkit:
    `ruyidev.exe apprunner --runapp --workingchannellist=dev --installedapplist=com.playruyi.space_shooter`