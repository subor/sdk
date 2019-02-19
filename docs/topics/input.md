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

To explicitly integrate Ruyi's input system register to receive input events published by input manager.  Create an [SDK instance](https://subor.github.io/api/cs/en-US/html/0c612cb2-48f2-a7bb-4726-7dbee95ea768.htm) and [subscribe](https://subor.github.io/api/cs/en-US/html/0b09fff9-d288-42c8-5470-2378590bb6d3.htm) to [`RuyiGamePadInput`](https://subor.github.io/api/cs/en-US/html/7232502d-e856-2b61-c19f-b0f8858c0f6b.htm) events:
```csharp
var sdk = RuyiSDK.CreateInstance(new RuyiSDKContext { endpoint = RuyiSDKContext.Endpoint.Console, EnabledFeatures = RuyiSDK.SDKFeatures.Basic });
sdk.Subscriber.Subscribe(Ruyi.Layer0.ServiceHelper.PubChannelID(ServiceIDs.INPUTMANAGER_INTERNAL));
sdk.Subscriber.AddMessageHandler<Ruyi.SDK.InputManager.RuyiGamePadInput>((topic, message) => {
    if ((message.ButtonFlags & (int)Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_A) != 0)
    {
        // "A" pressed!
    }
});
```

An alternative to explicit integration is to take advantage of input hooking feature of [overlay](overlay).

## Button Mapping

| Gamepad | Keyboard | Description
|-|-|-
| Home | F10 | Toggle overlay UI
|  | F11 | __Coming Soon__ Start/Stop video record
| `[+RB` | F12 | Screenshot
