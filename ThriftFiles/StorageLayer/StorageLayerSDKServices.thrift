include "StorageLayerSDKDataTypes.thrift"

namespace * Ruyi.SDK.StorageLayer


service StorageLayerService {
	StorageLayerSDKDataTypes.GetLocalPathResult GetLocalPath(1: string message),
}

