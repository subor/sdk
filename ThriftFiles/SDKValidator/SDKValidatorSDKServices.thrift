include "SDKValidatorSDKDataTypes.thrift"

namespace csharp Ruyi.SDK.SDKValidator
namespace cpp Ruyi.SDK.SDKValidator

service ValidatorService {
	string ValidateSDK(1: string version),
}

