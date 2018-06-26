include "SDKValidatorSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.SDKValidator
namespace csharp Ruyi.SDK.SDKValidator
namespace java Ruyi.SDK.SDKValidator
namespace netcore Ruyi.SDK.SDKValidator
namespace rs Ruyi.SDK.SDKValidator


service ValidatorService {
	string ValidateSDK(1: string version),
}

