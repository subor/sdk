# Package File Preparation

1. Create the Manifest file, It must be named RuyiManifest.json, an typical content should looks like:
```
     {
        appID: "com.ruyi.jade.app_id",
        application:    {
                name:"@com.ruyi.app_id",
                label:"@antestapp",
                icon:"bluetooth.png",
                description:"an test app description",
                logo:"logo.png",
                activity:[
                        {
                                name:"main",
                                label:"main test activity",
                                description:"@antestapp",
                                icon:"logo.png"
                        }
                ]
        },
        use_permissions:[
                {
                        name:"jade.permission.ACHIEVEMENT"
                }
        ],
        use_sdk:{
                minSdkVersion : "1.0.0.0"
        }
    }
```
2. Create an sibling folder named "res" with your manifest file
3. create "ld" and "hd" folder in "res", put your images used in the manifest file into them according to the "high" or "low" dimension.
4. create the i18n.json file in "res", which should contain texts in all language you're gonna support. it should looks like this:
```
    {
        "i18n": {
            "en-US": {
                "trc.item.succeed": "pass",
                "antestapp": "achievement max number allowed for each title",
                "com.ruyi.TestApp": "against every game, we only allow specific number of achievement to be created"
            },
            "zh-CN": {
                "trc.item.succeed": "测试通过",
                "antestapp": "每款APP所允许的最大的成就数量"
            }
        }
    }
```
5. create a folder with the name of your app_id in "com.ruyi.jade.app_id" next to the manifest file, and put your app into it. the exe name must be "app_id".exe
6. create a zip file named "app_id" and contain all the content above directly in the root


# Developer Tool Operation:
1. open RuyiDev.exe -> select AppRunner -> file the "Host Address" blank with ip address of your console
2. Select Working Channel List, (Always "dev" for now)
3. Select the folde whick contains all the file we talk about above, then click "PackApp" button, wait for a second(it depends how big your file is). Until you see the pack output info
4. Selected the zip file in the "Select install App" blank
5. Press "install App" button, wait until the success installed info(the length of duration depends on how big of your zip file)
6. if install successfully, you should see your game option in "Installed App List" options, then you can choose it, press "Run App" button, you should see your game running on the console
7. you can stop your game by choose it's option in "Running App" Option and click "Stop App" button
8. you can uninstall your game app by select your game in "Installed App List" and then click "Uninstall App" button, note your game can't be running if your want to uninstall it
9. each time you reopen AppRunner plugin in develop tool( RuyiDev.exe), you need to press "ForceRefresh" button to refresh all the installed game state