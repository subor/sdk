include "InputManagerSDKDataTypes.thrift"
include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.InputManager
namespace csharp Ruyi.SDK.InputManager
namespace java Ruyi.SDK.InputManager
namespace netcore Ruyi.SDK.InputManager
namespace rs Ruyi.SDK.InputManager


service InputManagerService {
	/** Get the gamepads that are connected corrently */
	list<InputManagerSDKDataTypes.GamepadInfo> GetConnectedGamepads(),

	/** Activate the vibration of gamepad */
	bool SetGamepadVibration(
		/** The deviceid of the gamepad */
		1: string deviceId, 
		2: i8 motor1Value, 
		3: i8 motor1Time, 
		4: i8 motor2Value, 
		5: i8 motor2Time
	),

	/** SetGamepadLight_desc */
	bool SetGamepadLight(
		/** The device id of the gamepad */
		1: string deviceId, 
		2: i8 RValue, 
		3: i8 GValue, 
		4: i8 BValue
	),

	/** Obsolete. Temporary api the change the ruyi controller's state, will be removed later. */
	bool SetRuyiControllerStatus(1: i8 channel, 2: bool enableR, 3: bool enableG, 4: bool enableB, 5: bool enableMotor1, 6: bool enableMotor2, 7: bool shutdown, 8: i8 RValue, 9: i8 GValue, 10: i8 BValue, 11: i8 motor1Value, 12: i8 motor1Time, 13: i8 motor2Value, 14: i8 motor2Time),
}

