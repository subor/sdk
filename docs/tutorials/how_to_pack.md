# Package File Preparation

To package an application create a directory structure similar to:
```
│   RuyiManifest.json
│
├───res
│   │   i18n.json
│   │
│   ├───hd
│   │       icon.png
│   │
│   └───ld
│           icon.png
│
└───<application>
```

## Manifest

Create `res/l18n.json` similar to the following:
```json
{
  "i18n": {
    "en-US": {
      "com.XXX.space_shooter": "Space Shooter",
      "description": "A description for this App",
    },
    "zh-CN": {
      "com.XXX.space_shooter": "太空射手",
      "description": "这个游戏的描述",
    }
  }
}
```

Create `RuyiManifest.json` similar to:
```json
{
	appID: "60030",
	version:"1.0.0.0",
	use_sdk:{
		minSdkVersion : "1.0.0.0"
	},
	application:	{
		name:"@com.XXX.space_shooter",
		icon:"icon.png",
		description:"@description",
		properties:[
			"SinglePlayer",
			"RuyiAchievements"
		],
		platform:[
			"RuyiConsole",
			"Windows",
		],
		size:12580,
		languages:[
			{
				languageCode:"en-US",
				uiInterface:true,
				fullAudio:true,
				subtitles:true,
			},
		],
		
		activity:[
			{
				name:"main",
				exePath:"space_shooter/SpaceShooter.exe",
				description:"@description",
			}
		],
	},
	use_permissions:[
		{
			name:"jade.permission.ACHIEVEMENT"
		}
	],
}
```
- __appID__: the application ID (e.g. `"10112"`)
- __icon__: a filename that exists in both `res/ld/` and `res/hd/`
- __exePath__: path to application's main executable (e.g. `space_shooter/SpaceShooter.exe`)
    - Must be child relative to this file; cannot be `../bin/`, etc.
- Strings starting with `@` are references to values in `i18n.json` file
    - For example, `@com.XXX.space_shooter` will be `Space Shooter` when the system language is English and `太空射手` when Simplified Chinese


## Application

The application must be a sibling or child of the folder containing `RuyiManifest.json`.  This must include all data and dependencies required by your application.

If placed in a sub-folder make sure the value of `exePath` reflects this.


## Developer Tool Operation

Applications can be packed, deployed, and run with [RuyiDev.exe "App Runner"](../topics/devtool.md#app-runner).
