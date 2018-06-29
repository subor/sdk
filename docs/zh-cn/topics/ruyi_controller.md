# Ruyi手柄适配说明

  本文档旨在说明同过代码实现Ruyi手柄适合，由于目前RuyiSDK仍处于开发中，所以说明中使用的代码相关API可能会和实际SDK有出入，最新
代码可以在这里[C#](https://bitbucket.org/playruyi/space_shooter/src),[C++](https://bitbucket.org/playruyi/unreal_demo/src/master)
查看

## 具体代码说明（以C#版为例）

1. 注册手柄事件和监听消息
m_RuyiNet.Subscribe.Subscribe("service/inputmgr_int");
m_RuyiNet.Subscribe.AddMessageHandler<Ruyi.SDK.InputManager.RuyiGamePadInput>(RuyiGamePadInputListener);

2. 在监听事件监听按键和遥感输入：
       	void RuyiGamePadInputListener(string topic, Ruyi.SDK.InputManager.RuyiGamePadInput msg)
	   
		其中Ruyi.SDK.InputManager.RuyiGamePadInput即为返回的手柄输入数据
	   	
		主要变量	 public int ButtonFlags { get; set; }      		
				   public sbyte LeftTrigger { get; set; }
        		   public sbyte RightTrigger { get; set; }
        		   public short LeftThumbX { get; set; }
        		   public short LeftThumbY { get; set; }
        		   public short RightThumbX { get; set; }
        		   public short RightThumbY { get; set; }
		
		ButtonFlags表示手柄按键输入，比如：
	if ((int)Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_X == msg.ButtonFlags) {Debug.Log(“Button X”);}
	
	表示手柄“X”键输入事件，注意该判定是在按键“按下”时判定成功。“松开”时ButtonFlags的值为0.
	
	也可以 判定按键组合，比如按下“X”键同时按键“A”键 (先按“X”然后再按“A“或反之结果一样)
   	
	if (((int)Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_X | (int)Ruyi.SDK.CommonType.RuyiGamePadButtonFlags.GamePad_A) == msg.ButtonFlags)
        {
            Debug.Log("X&B");
        }
	
	遥感判定左摇杆LeftThumbX水平LeftThumbY垂直
	
	将LeftThumbX或LeftThumbY的值除以Mathf.Pow(2f, 15)（2的15次方），结果映射为（-1，1），即为遥感移动范围(-1,1)(左，右)（下，上），右摇杆一样

3. 手柄震动API说明
	bool SetRuyiControllerStatus(sbyte channel, bool enableR, bool enableG, bool enableB, bool enableMotor1, bool enableMotor2, bool shutdown, sbyte RValue, sbyte GValue, sbyte BValue, sbyte motor1Value, sbyte motor1Time, sbyte motor2Value, sbyte motor2Time);
	
	channel：由连接方式决定（有线无线），目前有线情况下第一个手柄就固定填4，之后会再对该API做调整。
	
	enableR,enable,enable指定手柄等是否亮
	
	enableMotor1,enableMoter2指是否开启震动（左右两边）,shutdown一般false
	
	RValue,GValue,BValue指灯亮的参数
	
	motor1Value,motor1Time,motor2Value,motor2Time指手柄的震动长度和持续时间
	
	比较重要的参数就是震动强度和时间。可以像以下这样传
	
	byte viberatePower = 255 (范围0~255强度从小到大), viberateTime = 255（范围0~255时间从短到长） ，否则直接传sbyte（-128~127）不够直观
	
	m_RuyiNet.mSDK.InputMgr.SetRuyiControllerStatus(4, false, false, false,
                true, true, false,
                (sbyte)0, (sbyte)0, (sbyte)0,
                (sbyte)viberatePower, (sbyte)viberateTime,
                (sbyte)viberatePower, (sbyte)viberateTime);
C++版本API同样

## 手柄震动建议
	    马达1 （大马达）	                                  	  马达2（小马达）

强度	   建议70开始，80，90，a0， b0，c0，d0，e0，f0，ff	 		建议70开始，80，90，a0， b0，c0，d0，e0，f0，ff

时间	   建议>04	                                          建议>04
		
	
	另外建议，震动时间特别短的时候尽量震动强度相对大一点，比如 强度ff，时间04，可以感觉到明显的短促震动一下，但是强度70时间04就几乎没有震感，但是强度70，时间20也是能够感觉到持续的轻微震动的	
    
## 帮助支持

    如果在实际使用过程中有问题或者API有变更，可以随时和这边联系，技术支持邮箱 dev-support@playruyi.com。论坛https://dev.playruyi.com/forum

