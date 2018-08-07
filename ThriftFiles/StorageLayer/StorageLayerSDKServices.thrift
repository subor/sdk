include "StorageLayerSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.StorageLayer
namespace csharp Ruyi.SDK.StorageLayer
namespace java Ruyi.SDK.StorageLayer
namespace netcore Ruyi.SDK.StorageLayer
namespace rs Ruyi.SDK.StorageLayer


service StorageLayerService {
	StorageLayerSDKDataTypes.GetLocalPathResult GetLocalPath(1: string message),
}

