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
