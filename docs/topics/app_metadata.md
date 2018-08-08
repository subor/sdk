Test222
# App Metadata

---
## ![](/docs/img/warning.png) NOTICE
Application meta-data is still being defined.
The following is meant to be exemplary and will be updated once specification is finalized.

---	

Application meta-data is comprised of:

- A manifest describing the application
- A resource folder containing assets

The [Unity sample](https://bitbucket.org/playruyi/space_shooter) contains an example of application meta-data used by Ruyi platform.  Running `D:\dev\unity_demo>tree /f pack` displays:
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

The `space_shooter` folder and `space_shooter.exe` should all match the appID value in the manifest file.

## Manifest

App manifest is similar to other platforms and is typically named `RuyiManifest.json`.

Example from the [SDK samples](https://bitbucket.org/playruyi/space_shooter/src/master/Pack/RuyiManifest.json):
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

## Overlay

See [overlay compatibility](overlay.md#Compatibility)

## Strings

Localized strings are stored in `res/i18n.json`.

Example from the [SDK Samples](https://bitbucket.org/playruyi/space_shooter/src/master/Pack/res/i18n.json):
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

## Images

Images are placed in `res/hd/` and `res/ld` for high-resolution and low-resolution assets, respectively.
