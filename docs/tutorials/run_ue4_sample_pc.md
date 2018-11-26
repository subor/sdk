# Run UE4 sample on local PC

In this tutorial we're going to install an example based on [UE4](https://www.unrealengine.com/) to your local PC and launch it.

All the following steps should be done on your local PC.

1. [Launch platform and login](setup.md)
2. [Download UE4 sample](https://github.com/subor/sample_ue4_platformer).  We will assume `c:\ue4_demo\`.
3. Build sample?
4. Package the sample, read [Pack The App](how_to_pack.md) for more details, we will assume the organized folder would be `c:\ue4_pack\`
    ```
    ruyidev.exe apprunner --pack --apppath=c:\ue4_pack\
    ```
5. Install sample:
    ```
    ruyidev.exe apprunner --installapp --workingchannellist=dev --installedapplist=com.playruyi.unreal_demo
    ```
6. Launch sample:
    ```
    ruyidev.exe apprunner --runapp --workingchannellist=dev --installedapplist=com.playruyi.unreal_demo
    ```
