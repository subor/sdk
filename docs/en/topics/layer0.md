# Platform Architecture

The Ruyi platform has the following architecture:

![](/docs/img/platform_arch.png)

Layer0 is the central entity exposing features of the Ruyi platform as a set of services.  It runs atop a host OS such as Windows 7 running on your local workstation, or [Ruyi OS](os.md) running on a Ruyi console.

Client applications interact with the platform (and eachother) via [Ruyi SDK API](http://dev.playruyi.com/api) implemented with [Apache Thrift](https://thrift.apache.org/).  This provides a consistent, versioned, well-documented, and mostly standardized way of interacting with the platform from a [wide variety of languages](https://thrift.apache.org/lib/).

Asynchronous messages are received by subscribing to topics published via [ZeroMQ](http://zeromq.org/).

Online services are provided by a customized instance of [brainCloud](http://getbraincloud.com/) running within China.