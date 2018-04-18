namespace csharp Ruyi.SDK.Constants
namespace cpp Ruyi.SDK.Constants

struct BraincloudServerInfo {
    1: string name,
    2: string urlRoot,
    3: string dispatcher,
    4: string secretKey,
    5: string appId,
    6: string appVersion,
}


const i32 low_latency_socket_port = 11290

const i32 high_latency_socket_port = 11390

const string layer0_broker_address = "inproc://{addr}:5555"

const string layer0_publisher_in_uri = "tcp://{addr}:5567"

const string layer0_publisher_out_uri = "tcp://{addr}:5568"

const string setting_config_folder = "/ruyilocalroot/resources/configs/"

const string setting_system_config = "/ruyilocalroot/resources/configs/systemsetting"

const string setting_system_user_config = "/ruyilocalroot/resources/configs/usersetting"

const string system_setting_version = "1.0.0.1"

const string layer0_debugger_channel = "layer0_debugger_channel"

const string trc_test_channel = "trc_test_channel"

const string debugger_publisher_in_uri = "tcp://{addr}:8867"

const string debugger_publisher_out_uri = "tcp://{addr}:8868"

const string broker_playback_message = "mmi.developer.playback"

const string broker_power_message = "mmi.power.operation"

const list<BraincloudServerInfo> BraincloudServerList = [
	{
		"name": "external",
		"urlRoot": "",
		"dispatcher": "",
		"secretKey": "5f73bb67-2b82-444a-8801-e2bb8b09e917",
		"appId": "11498",
		"appVersion": "1.0.0",
	},
	{
		"name": "braincloudunittestuse",
		"urlRoot": "https://braincloud:4443/",
		"dispatcher": "dispatcherv2",
		"secretKey": "1b057efd-4ce5-4245-b076-caba21972e5c",
		"appId": "30002",
		"appVersion": "1.0.0",
	},
	{
		"name": "internalray",
		"urlRoot": "",
		"dispatcher": "",
		"secretKey": "f75514d5-10bf-4e10-8701-2b9e16356d3f",
		"appId": "11782",
		"appVersion": "1.0.0",
	},
	{
		"name": "localhost",
		"urlRoot": "https://localhost:8443/",
		"dispatcher": "dispatcherv2",
		"secretKey": "655a2914-be71-495b-868f-68f6b4f6dfb1",
		"appId": "30001",
		"appVersion": "1.0.0",
	},
]

