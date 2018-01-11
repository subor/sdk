# App Metadata

---
# ![](/docs/img/warning.png) NOTICE
Application meta-data is still being defined.
The following is meant to be exemplary and will be updated once specification is finalized.

---	

## Manifest

App manifest similar to that found on other platforms.

Example from the [SDK samples](https://bitbucket.org/playruyi/space_shooter/src/47b6da28637020946bc3e50b6fa76668e3c43971/Pack/RuyiManifest.json?at=master&fileviewer=file-view-default):
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

## Strings

Example from the [SDK Samples](https://bitbucket.org/playruyi/space_shooter/src/47b6da28637020946bc3e50b6fa76668e3c43971/Pack/res/i18n.json?at=master&fileviewer=file-view-default):
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

