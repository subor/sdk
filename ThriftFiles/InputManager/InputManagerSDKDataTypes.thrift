namespace csharp Ruyi.SDK.InputManager
namespace cpp Ruyi.SDK.InputManager

struct InputDeviceEventHeader {
    1: i32 headerType,
    2: string deviceId,
    3: i32 deviceType,
}

struct InputDeviceConnectionChanged {
    1: InputDeviceEventHeader header,
    2: bool isConnected,
}

struct RuyiInputStateChanged {
    1: list<RuyiInputEvent> keyPressEvent,
    2: list<RuyiInputEvent> analogEvent,
}

struct InputDeviceStateChangedX360 {
    1: i64 PacketNumber,
    2: string DeviceId,
    3: i16 LeftThumbDeadZone,
    4: i16 RightThumbDeadZone,
    5: i32 Buttons,
    6: i8 LeftTrigger,
    7: i8 RightTrigger,
    8: i16 LeftThumbX,
    9: i16 LeftThumbY,
    10: i16 RightThumbX,
    11: i16 RightThumbY,
    12: RuyiInputStateChanged Changed,
}

struct InputDeviceStateChangedGamepad {
    1: i32 RawOffset,
    2: i32 Value,
    3: i32 Timestamp,
    4: i32 Sequence,
    5: i16 Offset,
}

struct InputDeviceStateChangedJoystick {
    1: i32 RawOffset,
    2: i32 Value,
    3: i32 Timestamp,
    4: i32 Sequence,
    5: i16 Offset,
}

struct InputDeviceStateChangedKeyboard {
    1: string DeviceId,
    2: i32 RawOffset,
    3: i32 Value,
    4: i32 Timestamp,
    5: i32 Sequence,
    6: i8 Key,
    7: bool IsPressed,
    8: bool IsReleased,
}

struct InputDeviceStateChangedMouse {
    1: i32 RawOffset,
    2: i32 Value,
    3: i32 Timestamp,
    4: i32 Sequence,
    5: i8 Offset,
    6: bool IsButton,
}

struct InputActionTriggered {
    1: string deviceId,
    2: string name,
    3: i64 timestamp,
    4: list<RuyiInputEvent> events,
}

struct RuyiInputEvent {
    1: i64 EventId,
    /** refer to GlobalInputDefine.enum.RuyiInputDeviceType */
	2: byte DeviceType,
    /** refer to GlobalInputDefine.enum.RuyiControllerKey. Todo: refer to other enums in GlobalInputDefine depends on DeviceType */
	3: i32 Key,
    4: byte NewValue,
    5: byte LastValue,
}

struct InputDeviceStateChangedRuyiController {
    1: i64 PacketId,
    2: i32 ChannelId,
    3: string DeviceId,
    4: i32 KeyPress,
    5: i8 AnalogL2,
    6: i8 AnalogR2,
    7: i8 AnalogLeftJoyX,
    8: i8 AnalogLeftJoyY,
    9: i8 AnalogRightJoyX,
    10: i8 AnalogRightJoyY,
    11: RuyiInputStateChanged Changed,
}

struct InputDeviceStateChanged {
    1: InputDeviceEventHeader header,
    2: InputDeviceStateChangedX360 x360,
    3: InputDeviceStateChangedGamepad dgamepad,
    4: InputDeviceStateChangedJoystick djoystick,
    5: InputDeviceStateChangedKeyboard dkeyboard,
    6: InputDeviceStateChangedMouse dmouse,
    7: InputDeviceStateChangedRuyiController ruyicontroller,
}

