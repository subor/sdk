include "SDKValidatorSDKDataTypes.thrift"

namespace * Ruyi.SDK.SDKValidator


service ValidatorService {
	string ValidateSDK(1: string version),
}

