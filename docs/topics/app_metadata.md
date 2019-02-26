# App Metadata

---
## ![](/docs/img/warning.png) NOTICE
Application meta-data is still being defined.
The following is meant to be exemplary and will be updated once specification is finalized.

---	

Application meta-data is comprised of:

- `RuyiManifest.json` describing the application
- A resource folder containing assets

`RuyiManifest.json` must be placed in the same folder as a built app.  This includes all required data and dependencies.

The directory structure should be similar to:
```
│   RuyiManifest.json
│
├───res
│   ├───i18n.json
│   │
│   ├───hd/
│   │
│   └───ld/
│
└───<application>
```

For example, the [Unity sample](https://github.com/subor/sample_unity_space_shooter) contains an example of application meta-data used by Ruyi platform.  Running `D:\dev\unity_demo>tree /f pack` displays:
```
D:\DEV\UNITY_DEMO\PACK
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
└───space_shooter
    │   space_shooter.exe
    │
    └───space_shooter_Data
        ...
```

The `space_shooter` folder and `space_shooter.exe` should all match the `AppID` value in the manifest file.

## Strings

Localized strings are stored in `res/i18n.json`.

Example from the [Unity sample](https://github.com/subor/sample_unity_space_shooter/blob/master/Pack/res/i18n.json):
```json
{
  "i18n": {
    "en-US": {
      "com.playruyi.space_shooter": "Space Shooter",
      "description": "A description for this App",
    },
    "zh-CN": {
      "com.playruyi.space_shooter": "太空射手",
      "description": "这个游戏的描述",
    }
  }
}
```

## Manifest

App manifest is similar to other platforms and is named `RuyiManifest.json`.

It is JSON where all keys/attributes are [_PascalCase_](https://en.wikipedia.org/wiki/Camel_case).

Example from the [Unity sample](https://github.com/subor/sample_unity_space_shooter/blob/master/Pack/RuyiManifest.json):
```json
{
	"AppId": "18258",
	"Version":"1.0.0.0",
	"Sdk":{
		"MinSdkVersion" : "1.0.0.0"
	},
	"Application":	{
		"Name":"@com.playruyi.space_shooter",
		"Icon":"icon.png",
		"Description":"@description",
		"Properties":[
			"SinglePlayer",
			"RuyiAchievements"
		],
		"Platform":[
			"RuyiConsole",
			"Windows"
		],
		"Size":12580,
		"Languages":[
			{
				"LanguageCode":"en-US",
				"Ui":true,
				"FullAudio":true,
				"Subtitles":true
			},
			{
				"LanguageCode":"ja-JP",
				"Ui":true,
				"FullAudio":false,
				"Subtitles":true
			},
			{
				"LanguageCode":"de-DE",
				"Ui":true,
				"FullAudio":false,
				"Subtitles":false
			}
		],
		"Activity":[
			{
				"Name":"main",
				"ExePath":"space_shooter/SpaceShooter.exe",
				"Description":"@description"
			}
		]
	},
	"Permissions":[
		{
			"Name":"jade.permission.ACHIEVEMENT"
		}
	]
}
```

- __AppId__: the application ID (e.g. `"10112"`)
- __Icon__: a filename that exists in both `res/ld/` and `res/hd/`
- __ExePath__: path to application's main executable (e.g. `space_shooter/SpaceShooter.exe`)
  - Must be child relative to this file; cannot be `../bin/`, etc.
  - If app is placed in a sub-folder make sure the value of `ExePath` reflects this.
- Strings starting with `@` are references to values in `i18n.json` file
    - For example, `@com.playruyi.space_shooter` will be `Space Shooter` when the system language is English and `太空射手` when Simplified Chinese


## Overlay

See [overlay compatibility](overlay.md#compatibility)

## Images

Images are placed in `res/hd/` and `res/ld` for high-resolution and low-resolution assets, respectively.

## Devtool

Applications can be installed and run with [RuyiDev.exe "App Runner"](devtool.md#app-runner).
