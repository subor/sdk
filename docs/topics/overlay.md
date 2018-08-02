# Overlay

Ruyi's overlay is based off technology licensed from [Evolve](www.evolvehq.com) and provides the following functionality:  

* "Overlay" UI displayed on top of apps (including pop-up notifications for achievements, etc.)
* Recording video (see [DVR](dvr.md))
* Taking screenshots
* __Coming soon:__ [Input](input.md) from devices (as an alternative to implementing input portion of SDK)

![](/docs/img/warning.png) The following are not (yet) supported:  

* DirectX 12 (__Coming soon__)
* Vulkan (coming less soon)
* HDR10 (not coming soon; see [hardware](hardware.md))

It is implemented via dll hooking (also called dll injection) so it works without requiring any modifications in compatible applications.  It already supports over 5000 games.

## Compatibility

A compatibility string may be placed in the [application manifest](app_metadata.md):

```
meta_data:[
    {
    name:"gamedb_string",
    value:"
    
        <game>
            <id>6002</id>
            <name>UE4Game</name>
            <conditions>
                <cond name='is-UE4Game.exe-present' type='exe-present' exe='UE4Game.exe'/>
            </conditions>
            <detection>
                <variant order='1' name='default'>
                    <if cond='is-UE4Game.exe-present'/>
                </variant>
            </detection>
        </game>

    "
    }
	]
```

Here the value in gamedb_string is a "game block" which copy from gamedb.xml.  Here you need to pay attention to use `' '` instead of `" "` in `<game></game>`, in order to correctly include XML in JSON file.

## Gamesdb.xml

Compatible apps are listed in `RuyiOverlay/Resources/DeployRes/gamesdb.xml`.

Currently, making a game compatible requires adding an entry to gamesdb.xml.  Later we will make this part of the [application manifest](app_metadata.md).

1. Shutdown Layer0 and Overlay client
1. Open `OverlayClient/DeployRes/gamesdb.xml` in a text/XML editor
1. Inside `<games version="2">` add a new `<game>` block similar to:

        <game>
            <id>9999</id> 
            <name>Your Game Name</name>
            <conditions>
                <cond name="is-YourGameName.exe-present" type="exe-present" exe="YourGameName.exe"/>
            </conditions>
            <detection>
                <variant order="1" name="default">
                    <if cond="is-YourGameName.exe-present"/>
                </variant>
            </detection>
        </game>

    Where `id` is [app id assigned to you by Subor](dev_onboarding.md).

1. Save `gamesdb.xml`
1. Restart layer0

__In most cases__, a simple entry like above will suffice.  For more advanced uses, consult [gamesdb.xml format](gamesdb_format.md).

## Debugging

Some registry values in `HKLM/Software/Subor/Ruyi` can be set (or created):

| Name | Type | Description
|-|-|-
| `EnableDisplayDriverLogging` | DWORD | If __1__, additional logging is done
| `DisplayDriverLogFilePath` | string/REG_SZ | Path of file for log output
