include "InputManagerSDKDataTypes.thrift"

namespace csharp Ruyi.SDK.InputManager
namespace cpp Ruyi.SDK.InputManager


service InputManagerService {
	bool SetRuyiControllerStatus(1: i8 channel, 2: bool enableR, 3: bool enableG, 4: bool enableB, 5: bool enableMotor1, 6: bool enableMotor2, 7: bool shutdown, 8: i8 RValue, 9: i8 GValue, 10: i8 BValue, 11: i8 motor1Value, 12: i8 motor1Time, 13: i8 motor2Value, 14: i8 motor2Time),
}

