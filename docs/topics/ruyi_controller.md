# Ruyi Controller API Insturction

  This document is about how to use Ruyi Controller through SDK API。Download the latest Layer0（[dev portal](https://dev.playruyi.com/)），launch it before running your game。
(Since RuyiSDK is still in development, the code here may be a little different from the download SDK). You can refer the sample code from here [C#](https://github.com/subor/sample_unity_space_shooter),
[C++](https://github.com/subor/sample_ue4_platformer)

## Code Instruction（C#）

1. Subcribe the input event and message
m_RuyiNet.Subscribe.Subscribe("service/inputmgr_int");
m_RuyiNet.Subscribe.AddMessageHandler<Ruyi.SDK.InputManager.RuyiGamePadInput>(RuyiGamePadInputListener);

2. Implement receiving button and stick input in mesage event：
       	void RuyiGamePadInputListener(string topic, Ruyi.SDK.InputManager.RuyiGamePadInput msg)
	   
		Ruyi.SDK.InputManager.RuyiGamePadInput is the data struct of ruyi controller input
	   	
		variable   public int ButtonFlags { get; set; }      		
				   public sbyte LeftTrigger { get; set; }
        		   public sbyte RightTrigger { get; set; }
        		   public short LeftThumbX { get; set; }
        		   public short LeftThumbY { get; set; }
        		   public short RightThumbX { get; set; }
        		   public short RightThumbY { get; set; }
		
		ButtonFlags is the button input variable，ep：
		
	if ((int)Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_X == msg.ButtonFlags) {Debug.Log(“Button X”);}
	
	represent button “X” input，note the if condition is true when you press down the "X" button。The ButtonFlags will be zero when Releasing it.
	
	You can also judge multiple button press like press "X" and "A" button at same time(or press "X" then "A" or the other way around)
   	
	if (((int)Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_X | (int)Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_A) == msg.ButtonFlags)
        {
            Debug.Log("X&B");
        }
	
	stck：left one refer the value LeftThumbX which is horizontal value, LeftThumbY vertical value.
	      right one RightThumbX horizontal RightThumbY vertical 
	
	divide LeftThumbX or LeftThumbY by Mathf.Pow(2f, 15)，mapping result in （-1，1）(left，right)（down，up)

3. Viberation API
	bool SetRuyiControllerStatus(sbyte channel, bool enableR, bool enableG, bool enableB, bool enableMotor1, bool enableMotor2, bool shutdown, sbyte RValue, sbyte GValue, sbyte BValue, sbyte motor1Value, sbyte motor1Time, sbyte motor2Value, sbyte motor2Time);
	
	channel：controller connection channel（wire/wireless），use 4 for now。
	
	enableR,enable,enable whether the light is on or not
	
	enableMotor1,enableMoter2 viberation is on or not (left and right), shutdown use false
	
	RValue,GValue,BValue the color of light
	
	motor1Value,motor1Time,motor2Value,motor2Time reprents the power and duration of viberation
	
	you can use it as below:
	
	byte viberatePower = 255 (0~255 from power min to max), viberateTime = 255（duration from min to max）
	
	m_RuyiNet.mSDK.InputMgr.SetRuyiControllerStatus(4, false, false, false,
                true, true, false,
                (sbyte)0, (sbyte)0, (sbyte)0,
                (sbyte)viberatePower, (sbyte)viberateTime,
                (sbyte)viberatePower, (sbyte)viberateTime);
				
same with c++ version

