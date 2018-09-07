# Overlay

The overlay is based off technology licensed from [Evolve](www.evolvehq.com) and provides the following functionality:  

* "Overlay" UI displayed on top of apps (including pop-up notifications for achievements, etc.)
* Recording video (see [DVR](dvr.md))
* Taking screenshots
* [Input](#input) from devices (as an alternative to implementing input portion of SDK)

![](/docs/img/warning.png) The following are not (yet) supported:  

* DirectX 12 (__Coming soon__)
* Vulkan (coming less soon)
* HDR10 (not coming soon; see [hardware](hardware.md))

It is implemented via [dll injection](https://en.wikipedia.org/wiki/DLL_injection) (also called dll hooking) so it works without requiring any modifications in compatible applications.  However, this might cause problems if your game uses anti-cheat middleware.

It already supports over 5000 games.  Your game can be made compatible with any of the following methods:
- Creating a [manifest entry](#manifest)
- Editing [Gamesdb.xml](#gamesdb.xml)

## API

Compatible apps don't __have__ to do anything with the SDK.

However, there are some functions related to the overlay in the SDK.  For example, apps can trigger a screenshot.  [See SDK documentation](https://subor.github.io/api/cs/en-US/html/609b22ad-556e-51d2-22a5-112ae52e4d9c.htm) for details.

## Manifest

A compatibility string may be placed in the [application manifest](app_metadata.md):

```json
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

Here the value in gamedb_string is a `<game></game>` block copied from [gamesdb.xml](#gamesdb.xml).  Pay attention to use `' '` instead of `" "`, in order to correctly embed JSON in XML.

## Gamesdb.xml

Compatible apps may be listed in `RuyiOverlay/Resources/DeployRes/gamesdb.xml`.

1. [Shutdown Layer0](layer0.md)
1. Open `OverlayClient/DeployRes/gamesdb.xml` in a text/XML editor
1. Inside `<games version="2">` add a new `<game>` block similar to:

    ```xml
    <game>
        <!-- Your app id -->
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
    ```

1. Save `gamesdb.xml`
1. Restart layer0

__In most cases__, a simple entry like above will suffice.  For more advanced uses, consult [gamesdb.xml format](gamesdb_format.md).

## Input

Instead of integrating the input portion of the SDK, you may be able to leverage dll hooking of input APIs.  This _might_ work if your app uses any of the following:

- Engines: UE4
- Middleware: [SDL](http://libsdl.org/)
- APIs: [XInput or DirectInput](https://docs.microsoft.com/en-us/windows/desktop/xinput/xinput-and-directinput)

This currently does __NOT__ work if your app uses:
- [HID API](https://docs.microsoft.com/en-us/windows-hardware/drivers/hid/introduction-to-hid-concepts) (support will be added in the future)
- [Unity Input](https://docs.unity3d.com/ScriptReference/Input.html) (which uses HID)


```xml
<runtime>
    <ruyifeatures>
        <ruyi_xinput enabled="true" />
    </ruyifeatures>
</runtime>
```

## Debugging

Some registry values in `HKLM/Software/Subor/Ruyi` can be set (or created):

| Name | Type | Description
|-|-|-
| `EnableDisplayDriverLogging` | DWORD | If __1__, additional logging is done
| `DisplayDriverLogFilePath` | string/REG_SZ | Path of file for log output
