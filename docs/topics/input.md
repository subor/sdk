# Input

## Supported Devices

__Gamepads__

- __Ruyi controller__
    - Includes controller shipped with devkits; which has a different exterior design, but similar circuitry and firmware
- Xbox One controller
- Xbox 360(-compatible) controllers
- __Coming Soon__ DualShock 4 (Playstation 4) controller
- __Coming Soon__ Nintendo Switch Pro controller

__Other__

* Keyboard/mouse

## Integration

To explicitly integrate Ruyi's input system, register to receive input events published by input manager:  
1. Create an [SDK instance](https://subor.github.io/api/cs/en-US/html/0c612cb2-48f2-a7bb-4726-7dbee95ea768.htm)
1. [Subscribe](https://subor.github.io/api/cs/en-US/html/23dc7650-c5f6-5e03-1d3a-45b67cb55819.htm) to [`RuyiGamePadInput`](https://subor.github.io/api/cs/en-US/html/7232502d-e856-2b61-c19f-b0f8858c0f6b.htm) events.

See [API docs](https://subor.github.io/) and [integration samples](https://github.com/subor/) for detailed examples.

An alternative to explicit integration is to take advantage of [input hooking feature of overlay](overlay.md#input).

## Button Mapping

| Gamepad | Keyboard | Description
|-|-|-
| Home | F10 | Toggle overlay UI
|  | F11 | __Coming Soon__ Start/Stop video record
| `[+RB` | F12 | Screenshot
