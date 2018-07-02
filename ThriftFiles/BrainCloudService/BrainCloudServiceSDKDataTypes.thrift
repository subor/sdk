namespace csharp Ruyi.SDK.BrainCloudApi
namespace cpp Ruyi.SDK.BrainCloudApi

typedef string JSON
typedef i64 date

enum FriendPlatform {
    All = 0,
    brainCloud = 1,
    Facebook = 2,
}

enum Role {
    OWNER = 0,
    ADMIN = 1,
    MEMBER = 2,
    OTHER = 3,
}

enum AutoJoinStrategy {
    JoinFirstGroup = 0,
    JoinRandomGroup = 1,
}

enum SortOrder {
    HIGH_TO_LOW = 0,
    LOW_TO_HIGH = 1,
}

enum SocialLeaderboardType {
    HIGH_VALUE = 0,
    CUMULATIVE = 1,
    LAST_VALUE = 2,
    LOW_VALUE = 3,
}

enum RotationType {
    NEVER = 0,
    DAILY = 1,
    WEEKLY = 2,
    MONTHLY = 3,
    YEARLY = 4,
}


struct BCServiceStartedNotification {
}

struct FileUploadSuccessResult {
    1: string fileUploadId,
    2: string jsonResponse,
}

struct FileUploadFailedResult {
    1: string fileUploadId,
    2: i32 statusCode,
    3: i32 reasonCode,
    4: string jsonResponse,
}


