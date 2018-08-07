# 应用元数据

---
## ![](/docs/img/warning.png) 注意
应用程序元数据的具体格式仍在定义中。
以下内容为具体数据格式的说明，元数据格式定义完成后会更新这些说明

---	

应用程序的元数据包括:

- 一个描述应用程序的配置文件
- 一个包含资源组件的文件夹

[Unity示例](https://bitbucket.org/playruyi/space_shooter)中有一个支持Ruyi主机平台的程序元数据列子。在命令行运行`D:\dev\unity_demo>tree /f pack`会显示:
```
D:\DEV\UNITY_DEMO\PACK
│   RuyiManifest.json
│
├───res
│   │   i18n.json
│   │
│   ├───hd
│   │       bluetooth.png
│   │
│   └───ld
│           bluetooth.png
│
└───space_shooter
    │   space_shooter.exe
    │
    └───space_shooter_Data
        ...
```

`space_shooter`文件夹和`space_shooter.exe`文件都必须匹配配置文件中的appID字段的值。

## 配置文件

应用配置文件和其他平台的配置文件类似，这里命名为`RuyiManifest.json`.

[SDK示例](https://bitbucket.org/playruyi/space_shooter/src/master/Pack/RuyiManifest.json)中的配置文件内容:
```json
{
	"appID": "com.playruyi.space_shooter",
	"application":	{
		"name":"@com.playruyi.space_shooter",
		"label":"@antestapp",
		"icon":"bluetooth.png",
		"description":"an test app description",
		"logo":"logo.png",
		"activity":[
			{
				"name":"main",
				"exePath":"space_shooter/space_shooter.exe",
				"label":"main test activity",
				"description":"@antestapp",
				"icon":"logo.png"
			}
		]
	},
	"use_permissions":[
		{
			"name":"jade.permission.ACHIEVEMENT"
		}
	],
	"use_sdk":{
		"minSdkVersion" : "1.0.0.0"
	}
}
```

## 多语言字符

本地化文字位于`res/i18n.json`文件.

[SDK示例](https://bitbucket.org/playruyi/space_shooter/src/master/Pack/res/i18n.json)中的本地化配置文件内容
```json
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

## 图片资源

图片资源位于`res/hd/`和`res/ld`文件夹下，分为高分辨率和低分辨率。