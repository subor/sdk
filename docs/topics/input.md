# Input

## Supported Devices

__Gamepads__

- __Ruyi controller__
    - Includes controller shipped with devkits; which has a different exterior design, but similar circuitry and firmware
- Xbox One controller
- Xbox 360 controller
- DualShock 4 (Playstation 4) controller

__Other__

* Keyboard/mouse

## API

Create an [SDK instance](https://subor.github.io/api/cs/en-US/html/0c612cb2-48f2-a7bb-4726-7dbee95ea768.htm) and [subscribe](https://subor.github.io/api/cs/en-US/html/0b09fff9-d288-42c8-5470-2378590bb6d3.htm) to [`RuyiGamePadInput`](https://subor.github.io/api/cs/en-US/html/7232502d-e856-2b61-c19f-b0f8858c0f6b.htm) events:
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

## Hooking

As an alternative to implementing the API.