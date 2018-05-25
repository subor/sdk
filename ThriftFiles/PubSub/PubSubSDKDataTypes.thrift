/** The data defination of PublisherSubscriber */
namespace cpp Ruyi.SDK.PublisherSubscriber
namespace csharp Ruyi.SDK.PublisherSubscriber

/** The event type about service start/stop. */
enum ServiceLaunchEventType {
    /** All lower power services started. */
	LowPowerStartOver = 0,
    /** All high power services started. */
	HighPowerStartOver = 1,
    /** Back to low power from high power mode over. */
	BackToLowerPowerOver = 2,
}


/** The event will be fired when service state changed. */
struct ServiceLaunchEvent {
    /** The event type. */
	1: i32 EventType,
    /** The last service that cause the state change. */
	2: string LastServiceID,
}


/** The service channel of layer0 */
const string layer0_service_channel = "layer0/service"

/** The service input channel */
const string service_input_channel = "service/input"


