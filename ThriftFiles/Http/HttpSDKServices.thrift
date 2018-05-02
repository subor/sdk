include "HttpSDKDataTypes.thrift"

namespace csharp Ruyi.SDK.Http
namespace cpp Ruyi.SDK.Http


service HttpService {
	HttpSDKDataTypes.SubscribeReply Subscribe(1: HttpSDKDataTypes.SubscribeRequest msg),
}

