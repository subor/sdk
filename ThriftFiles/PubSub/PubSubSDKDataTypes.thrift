/** The data defination of PublisherSubscriber */
namespace csharp Ruyi.SDK.PublisherSubscriber
namespace cpp Ruyi.SDK.PublisherSubscriber

/** The event type about service start/stop. */
enum ServiceLaunchEventType {
    /** All lower power services started. */
	LowPowerStartOver = 0,
    /** All high power services started. */
	HighPowerStartOver = 1,
    /** Back to low power from high power mode over. */
	BackToLowerPowerOver = 2,
}

enum UserShellEventType {
    Login = 0,
    Logout = 1,
}


/** The event will be fired when service state changed. */
struct ServiceLaunchEvent {
    /** The event type. */
	1: i32 EventType,
    /** The last service that cause the state change. */
	2: string LastServiceID,
}

struct UserShellEvent {
    1: UserShellEventType EventType,
}


/** The service channel of layer0 */
const string layer0_service_channel = "layer0/service"

/** The service input channel */
const string service_input_channel = "service/input"


