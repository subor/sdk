# 打包所需的配置文件

1. 创建Manifest配置文件,注意必须命名为RuyiManifest.json。文件内容格式如下所示：
```
     {
        appID: "app_id",
        application:    {
                name:"@app_id",
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
2. 创建一个和Manifest.json同级目录的文件夹“res”。
3. 在“res”文件夹下创建“ld”和“hd”文件夹，里面的图片名称和Manifest文件中对应值保持一致.
4. 在“res”文件夹下新建i18n.json，用来支持多语言，内容如下格式：
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
5. 新建和Manifest同级文件夹，名称和Manifest文件中appID项的值"com.ruyi.jade.app_id"中的“app_id”一致,将生成的应用执行文件全部放在该文件夹下。运行应用的exe文件注意名称和“app_id”保持一直。
6. 将上面所有文件使用zip压缩打包，名称和之前的“app_id”一致


# 开发者工具打包操作:
1. 打开RuyiDev.exe -> 选择AppRunner -> file "Host Address"栏填写目标主机的ip地址
2. Working Channel List选“dev”
3. Select the folde whick contains all the file we talk about above, then click "PackApp" button, wait for a second(it depends how big your file is). Until you see the pack output info
4. Selected the zip file in the "Select install App" blank
5. Press "install App" button, wait until the success installed info(the length of duration depends on how big of your zip file)
6. if install successfully, you should see your game option in "Installed App List" options, then you can choose it, press "Run App" button, you should see your game running on the console
7. you can stop your game by choose it's option in "Running App" Option and click "Stop App" button
8. you can uninstall your game app by select your game in "Installed App List" and then click "Uninstall App" button, note your game can't be running if your want to uninstall it
9. each time you reopen AppRunner plugin in develop tool( RuyiDev.exe), you need to press "ForceRefresh" button to refresh all the installed game state