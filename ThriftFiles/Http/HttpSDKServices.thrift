include "HttpSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.Http
namespace csharp Ruyi.SDK.Http
namespace java Ruyi.SDK.Http
namespace netcore Ruyi.SDK.Http
namespace rs Ruyi.SDK.Http


service HttpService {
	HttpSDKDataTypes.SubscribeReply Subscribe(1: HttpSDKDataTypes.SubscribeRequest message),
}

