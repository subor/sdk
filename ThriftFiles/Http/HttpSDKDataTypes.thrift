namespace csharp Ruyi.SDK.Http
namespace cpp Ruyi.SDK.Http

struct SubscribeRequest {
    1: string topic,
    2: string appid,
    3: string msgname,
}

struct SubscribeReply {
    1: bool success,
    2: string topic,
    3: string appid,
    4: string msgname,
}


