include "SDKValidatorSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.SDKValidator
namespace csharp Ruyi.SDK.SDKValidator


service ValidatorService {
	string ValidateSDK(1: string version),
}

