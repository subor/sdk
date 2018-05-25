include "HttpSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.Http
namespace csharp Ruyi.SDK.Http


service HttpService {
	HttpSDKDataTypes.SubscribeReply Subscribe(1: HttpSDKDataTypes.SubscribeRequest message),
}

