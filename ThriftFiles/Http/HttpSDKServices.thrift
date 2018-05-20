include "HttpSDKDataTypes.thrift"

namespace * Ruyi.SDK.Http


service HttpService {
	HttpSDKDataTypes.SubscribeReply Subscribe(1: HttpSDKDataTypes.SubscribeRequest message),
}

