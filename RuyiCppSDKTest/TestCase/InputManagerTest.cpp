#include "InputManagerTest.h"
#include "PubSub\SubscribeClient.h"

enum WaitingTasks 
{
	STATE_CHANGED = 0,
//	CONNECTION_CHANGED,
	MAX_NUM,
};
string getWaitingTaskName(WaitingTasks task) 
{
	if (STATE_CHANGED == task) return "STATE_CHANGED";
//	else if (CONNECTION_CHANGED == task) return "CONNECTION_CHANGED";
	else return "";
}
HANDLE ResetHandles[MAX_NUM];

unsigned int InputManagerTest::SubscriberMessage() 
{
	const string* pChar = &Ruyi::SDK::Constants::g_ConstantsSDKDataTypes_constants.layer0_publisher_out_uri;
	string* modifier = const_cast<string*>(pChar);
	replace_all(*modifier, "{addr}", "localhost");

	ruyiSDK->Subscriber->Subscribe("service/inputmgr_int");
	//ruyiSDK->Subscriber->Subscribe("service/user_service_external");
	ruyiSDK->Subscriber->AddMessageHandler(this, &InputManagerTest::SubStateChangeHandler2);

	return 0;
}

void InputManagerTest::SubStateChangeHandler2(std::string topic, apache::thrift::TBase* msg)
{
	//auto idsc = dynamic_cast<InputManager::InputDeviceStateChanged*>(msg);
	//auto idcc = dynamic_cast<InputManager::InputDeviceConnectionChanged*>(msg);
	//if (idsc == NULL && idcc == NULL)
	//	return;
	auto rgpi = dynamic_cast<InputManager::RuyiGamePadInput*>(msg);
	if (rgpi == NULL)
		return;

	std::string output = "SubStateChangeHandler ";
	output += rgpi->DeviceId + "\n";
	Logger::WriteMessage(output.c_str());
	SetEvent(ResetHandles[STATE_CHANGED]);
}

#define SCREEN_WIDTH 1024
#define SCREEN_HEIGHT 800

void MouseSetup(INPUT *buffer)
{
	buffer->type = INPUT_MOUSE;
	buffer->mi.dx = (0 * (0xFFFF / SCREEN_WIDTH));
	buffer->mi.dy = (0 * (0xFFFF / SCREEN_HEIGHT));
	buffer->mi.mouseData = 0;
	buffer->mi.dwFlags = MOUSEEVENTF_ABSOLUTE;
	buffer->mi.time = 0;
	buffer->mi.dwExtraInfo = 0;
}


void MouseMoveAbsolute(INPUT *buffer, int x, int y)
{
	buffer->mi.dx = (x * (0xFFFF / SCREEN_WIDTH));
	buffer->mi.dy = (y * (0xFFFF / SCREEN_HEIGHT));
	buffer->mi.dwFlags = (MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE);

	SendInput(1, buffer, sizeof(INPUT));
}


void MouseClick(INPUT *buffer)
{
	buffer->mi.dwFlags = (MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN);
	SendInput(1, buffer, sizeof(INPUT));

	Sleep(10);

	buffer->mi.dwFlags = (MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP);
	SendInput(1, buffer, sizeof(INPUT));
}

void simulateInput()
{
	Sleep(2000);
	INPUT buffer[1];
	MouseSetup(buffer);
	MouseMoveAbsolute(buffer, 123, 123);
	MouseClick(buffer);
	MouseMoveAbsolute(buffer, 234, 234);
	MouseClick(buffer);
}

// it will always fail unless someone moved the mouse/keyboard/controller
void InputManagerTest::InputManagerReceiveInputMessage()
{
	SubscriberMessage();
	for (int i = 0; i < MAX_NUM; i++)
	{
		ResetHandles[i] = CreateEvent(NULL, FALSE, FALSE, NULL);
	}

	std::thread th(simulateInput);
	DWORD wait = WaitForMultipleObjects(MAX_NUM, ResetHandles, TRUE, 6000);
	th.join();

	if (wait == WAIT_TIMEOUT || wait == WAIT_FAILED)
	{
		for (int i = 0; i < MAX_NUM; ++i)
		{
			if (!ResetEvent(ResetHandles[i]))
			{
				std::cout << "Time Out:" << getWaitingTaskName((WaitingTasks)i) << std::endl;
			}
		}
		Assert::Fail(L"waiting time out or wait function failed.");
	}
	else
	{
		Assert::IsTrue(true);
	}
}

InputManagerTest::InputManagerTest(RuyiSDKContext::Endpoint endpoint, string remoteAddress)
	:BaseUnitTest(endpoint, remoteAddress)
{
}




