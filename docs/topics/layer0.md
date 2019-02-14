# Layer0

## Platform Architecture

The platform has the following architecture:

![](/docs/img/platform_arch.png)

Layer0 is a background [daemon](https://en.wikipedia.org/wiki/Daemon_(computing)) that exposes features of the Ruyi platform as a set of "services".  It runs atop a host OS such as Windows 10 running on your local workstation, or [Z+ OS](os.md) running on the console.

Client applications interact with the platform (and indirectly with eachother) via [the SDK](https://github.com/subor/sdk) implemented with [Apache Thrift](https://thrift.apache.org/).  This provides a consistent, versioned, well-documented, and mostly standardized way of interacting with the platform from a [wide variety of languages](https://thrift.apache.org/lib/).

Asynchronous push messages are received by subscribing to topics published via [ZeroMQ](http://zeromq.org/).

Online services are provided by a customized instance of [brainCloud](http://getbraincloud.com/) running within China.

## Starting and Stopping

Layer0 is designed to run as a Windows service.

1. Run `cmd.exe` as __Administrator__
1. `layer0.exe --install --start` to install and start layer0

Once installed, layer0 can be started/stopped via `services.msc`:  
![](/docs/img/services.png)

1. Launch __Start / Windows Administrative Tools / Services__ (or run `services.msc`)
1. Right-click service named __Ruyi Layer0__ and select __Start__/__Stop__

Or, to stop it from the command-line:

1. Run `cmd.exe` as __Administrator__
1. `layer0.exe --stop`
