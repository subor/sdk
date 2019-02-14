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

For example, the [Unity sample](https://github.com/subor/sample_unity_space_shooter) contains an example of application meta-data used by Ruyi platform.  Running `D:\dev\unity_demo>tree /f pack` displays:
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

## Strings

Localized strings are stored in `res/i18n.json`.

Example from the [Unity sample](https://github.com/subor/sample_unity_space_shooter/blob/master/Pack/res/i18n.json):
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

## Manifest

App manifest is similar to other platforms and is named `RuyiManifest.json`.

Example from the [Unity sample](https://github.com/subor/sample_unity_space_shooter/blob/master/Pack/RuyiManifest.json):
```json
{
  "appID": "18258",
  "version":"1.0.0.0",
  "use_sdk":{
    "minSdkVersion" : "1.0.0.0"
  },
  "application":	{
    "name":"@com.XXX.space_shooter",
    "icon":"SpaceShooter.png",
    "description":"@antestapp",
    "properties":[
      "SinglePlayer",
      "RuyiAchievements"
    ],
    "platform":[
      "RuyiConsole",
      "Windows"
    ],
    "size":12580,
    "languages":[
      {
        "languageCode":"en-US",
        "uiInterface":true,
        "fullAudio":true,
        "subtitles":true
      },
      {
        "languageCode":"ja-JP",
        "uiInterface":true,
        "fullAudio":false,
        "subtitles":true
      },
      {
        "languageCode":"de-DE",
        "uiInterface":true,
        "fullAudio":false,
        "subtitles":false
      }
    ],
    "activity":[
      {
        "name":"main",
        "exePath":"space_shooter/space_shooter.exe",
        "description":"@antestapp"
      }
    ]
  },
  "use_permissions":[
    {
      "name":"jade.permission.ACHIEVEMENT"
    }
  ]
}
```

- __appID__: the application ID (e.g. `"10112"`)
- __icon__: a filename that exists in both `res/ld/` and `res/hd/`
- __exePath__: path to application's main executable (e.g. `space_shooter/SpaceShooter.exe`)
  - Must be child relative to this file; cannot be `../bin/`, etc.
  - If app is placed in a sub-folder make sure the value of `exePath` reflects this.
- Strings starting with `@` are references to values in `i18n.json` file
    - For example, `@com.XXX.space_shooter` will be `Space Shooter` when the system language is English and `太空射手` when Simplified Chinese


## Overlay

See [overlay compatibility](overlay.md#compatibility)

## Images

Images are placed in `res/hd/` and `res/ld` for high-resolution and low-resolution assets, respectively.

## Devtool

Applications can be installed and run with [RuyiDev.exe "App Runner"](devtool.md#app-runner).
