# Overlay

Ruyi's overlay is based off technology licensed from [Evolve](www.evolvehq.com) and provides the following functionality:  

* "Overlay" UI displayed on top of apps (including pop-up notifications for achievements, etc.)
* Recording video (see [DVR](dvr.md))
* Taking screenshots
* __Coming soon:__ [Input](input.md) from devices

![](/docs/img/warning.png) The following are not (yet) supported:  

* Vulkan and DirectX 12 (__Coming soon__)
* HDR10 (not coming soon; see [hardware](hardware.md))

It is implemented by dll hooking (also called dll injection) so it can work without any modifications to compatible applications.  Compatible apps are listed in `RuyiOverlay/Resources/DeployRes/gamesdb.xml`.

## Gamedb.xml

1. Shutdown Layer0 and Overlay client
1. Open `OverlayClient/DeployRes/gamesdb.xml`
1. Add new `<game>` block to `<games version="2">` similar to:

        <game>
            <id>9999</id> 
            <name>YourGameName</name>
            <conditions>
                <cond name="is-YourGameName.exe-present" type="exe-present" exe="YourGameName.exe"/>
            </conditions>
            <detection>
                <variant order="1" name="default">
                    <if cond="is-YourGameName.exe-present"/>
                </variant>
            </detection>
        </game>

    * `id` is unique number
    * Replace `YourGameName.exe` with the name of your game's executable in `<conditions>` and `<detection>`
    
1. Save `gamesdb.xml`
1. Restart layer0