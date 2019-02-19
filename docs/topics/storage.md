# Summary
We're using a sandbox alike solution along with other [Windows Security Features](security.md) to protect app data, so each app will be limited to access data related to itself.

## HDD
To get the path that's your app can read from or write to, you need to create RuyiSDK instace first to do that. 
```C#
RuyiSDK sdk = RuyiSDK.CreateInstance(new RuyiSDKContext()
{
	endpoint = RuyiSDKContext.Endpoint.Console,
	EnabledFeatures = RuyiSDK.SDKFeatures.Storage,
});
```
There're 3 kinds of priviledges we provide for the following path:

- Writable, there're 4 writable path that an app have write access after installed, you can visit them vis RuyiSDK instance created above.
	```C#
	{
		ConstantsSDKDataTypesConstants.DOWNLOAD_DRIVER_TAG,
		ConstantsSDKDataTypesConstants.MEDIA_DRIVER_TAG,
		ConstantsSDKDataTypesConstants.HTTP_HDD_CACHE_DRIVER_TAG,
		ConstantsSDKDataTypesConstants.DATA_DRIVER_TAG,
	}
	// appid = the app id you get/created for your app, from Subor Team, or on the dev portal.
	var downloadPath = sdk.Storage.GetLocalPathAsync(ConstantsSDKDataTypesConstants.HDD0_DRIVER_TAG + appid, CancellationToken.None).Result;
	// write to your downloadPath here.
	``` 
	> you can also visit directories under your current user name, like C:\\Users\\{user name}, in C#, you can use _Environment.UserName_ to get the {user name}, but we strongly recommend you to write all the data created on the fly to the specific paths we provided above.

- Read only, the app's installation target path is read only to the app, you CANNOT write to the directory where it been installed (or run from, it's the same in our situation). To get it:
	```C#
	// appid = the app id you get/created for your app, from Subor Team, or on the dev portal.
	var installPath = SDK.Storage.GetLocalPathAsync(ConstantsSDKDataTypesConstants.HDD0_DRIVER_TAG + appid, CancellationToken.None).Result;
	// read any content from installPath, but write to it is forbidden
	```

- Fully denied, Access to any other app's installation/data path, or system path will cause an Exception.


## REGISTRY
During the installation of an app, we also created a path in the Windows Registry which only visible to the current app, it's safe to save some info there and they can't be read by other apps. the path is:
```C#
// appid = the app id you get/created for your app, from Subor Team, or on the dev portal.
var exclusiveRegistryPath = "SOFTWARE\Ruyi\Apps\" + appid;
```