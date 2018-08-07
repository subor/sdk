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
2. 创建一个和RuyiManifest.json同级目录的文件夹“res”。
3. 在“res”文件夹下创建“ld”和“hd”文件夹，里面的图片名称和RuyiManifest.json文件中对应值保持一致.
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
5. 新建和RuyiManifest.json同级文件夹，名称和RuyiManifest.json文件中appID项的值"com.ruyi.jade.app_id"中的“app_id”一致,将生成的应用执行文件全部放在该文件夹下。注意启动应用的exe文件名需要和“app_id”保持一致。
6. 将上面所有文件使用zip压缩打包，文件名和之前的“app_id”一致


# 开发者工具打包操作:
1. 打开RuyiDev.exe->选择AppRunner插件。"Host Address"栏填写目标主机的ip地址
2. Working Channel List栏选“dev”。
3. “AppRootFolder”栏选之前存放所有配置文件和游戏运行文件的文件夹，点击“PackApp”，等待打包完成。
4. "Select install App"栏选上一步中打包好的zip文件。
5. 点击"install App"按钮，等待安装完成。
6. 如果安装成功，应该可以在"Installed App List"栏看到所安装游戏的选项，选中然后点击"Run App"按钮，可以看到游戏在主机上运行。
7. 可以通过在"Running App"栏选中已运行的游戏，点击"Stop App"使其停止。
8. 可以通过在"Installed App List"栏选中已安装的游戏，点击"Uninstall App"按钮来卸载已安装游戏。注意正在运行的游戏无法卸载。
9. 每次打开AppRunner插件，可以通过点击"ForceRefresh"按钮来刷新已安装游戏列表。