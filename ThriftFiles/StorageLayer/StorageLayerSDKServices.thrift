include "StorageLayerSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.StorageLayer
namespace csharp Ruyi.SDK.StorageLayer


service StorageLayerService {
	StorageLayerSDKDataTypes.GetLocalPathResult GetLocalPath(1: string message),
}

