# Unity 3D

[Unity 3D](https://unity3d.com/) is a first-class development environment for Ruyi.

## Prerequisites

- Unity 2017.1.1f1 (newer versions likely work)

## Quick Start

RuyiNet is provided as high-level wrapper around the Ruyi C# API.

1. [Download the UnityPackage version of the SDK](https://github.com/subor/sdk/releases) and import the package into your project (__Assets->Import Package->Custom Package...__). 
1. Create an instance of RuyiNet script and add your app id/secret:  
![](/docs/img/unity_ruyinet.png)
1. In __Edit/Project Settings/Player__, expand _Other Settings_, set __Api Compatibility Level__ to `.NET 2.0`

## Advanced Usage

__Coming Soon__

## Common Problems

```
ArgumentException: The Assembly System.Web is referenced by log4net ('Assets/plugins/x64/log4net.dll'). But the dll is not allowed to be included or could not be found.
```

- In __Edit->Project Settings->Player__, expand _Other Settings_, set __Api Compatibility Level__ to `.NET 2.0` (instead of `.Net 2.0 Subset`)


## Links

- [Unity sample](https://github.com/subor/example_unity_space_shooter)
- [Unity tutorial](../tutorials/run_unity_sample_console.md)