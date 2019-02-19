# C++ SDK Integration

This documentation is about how to intergrate C++ SDK to a common VS C++ project.

## Prerequisites

- [Visual Studio 2017](https://www.visualstudio.com/vs/community/) version 15.3 or later with the following individual components:
    - Windows 10 SDK (10.0.15063.0) (under __SDKs, libraries, and frameworks__)

## Integration

1. Download [C++ SDK](https://github.com/subor/sdk/releases) to your project or where you keep 3rd-party libraries

1. Right click your solution, click __Properties__

1. In __Configuration Selection__, choose `Release` and `x64`

1. Choose __Configuration Properties > C/C++ > General__ in Property Page, in __Additional Include Directories__ add:
    - `<Path to RuyiSDKCpp>\include`
    - `<Path to RuyiSDKCpp>\include\Generated\CommonType`

1. Choose __Configuration Properties > Linker > General__ in Property Page, in __Additional Library Directiories__ add:
    - `<Path to RuyiSDKCpp>\lib`
    - `<Path to RuyiSDKCpp>\lib\boost`
    - `<Path to RuyiSDKCpp>\lib\zmq`

1. Choose __Configuration Properties > Linker > Input__ in Property page, to __Additional Dependencies__ add `RuyiSDK.lib` and `libzmq.lib`

1. And `#include "RuyiSDK.h"` to your code and initialize the SDK:

        auto context = Ruyi::RuyiSDKContext(Ruyi::RuyiSDKContext::Endpoint::Console, "localhost");
        Ruyi::RuyiSDK* ruyiSDK = Ruyi::RuyiSDK::CreateSDKInstance(context);

        if (nullptr != ruyiSDK)
        {
            // Do something
        }

1. Build everything
1. Copy SDK runtime dependencies (`<Path to RuyiSDKCpp>\lib\boost\*.dll`, and `<Path to RuyiSDKCpp>\lib\zmq\*.dll`) where they will be found at runtime (i.e. your exe output folder)
