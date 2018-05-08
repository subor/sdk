include "StorageLayerSDKDataTypes.thrift"

namespace csharp Ruyi.SDK.StorageLayer
namespace cpp Ruyi.SDK.StorageLayer


service StorageLayerService {
	StorageLayerSDKDataTypes.GetLocalPathResult GetLocalPath(1: string msg),
}

