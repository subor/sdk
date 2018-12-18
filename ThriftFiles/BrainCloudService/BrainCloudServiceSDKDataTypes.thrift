namespace cpp Ruyi.SDK.BrainCloudApi
namespace csharp Ruyi.SDK.BrainCloudApi
namespace java Ruyi.SDK.BrainCloudApi
namespace netcore Ruyi.SDK.BrainCloudApi
namespace rs Ruyi.SDK.BrainCloudApi

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

enum LobbyType {
    PLAYER = 0,
    RANKED = 1,
}


/** @BCServiceStartedNotification_desc */
struct BCServiceStartedNotification {
}

/** @FileUploadSuccessResult_desc */
struct FileUploadSuccessResult {
    /** @FileUploadSuccessResult_fileUploadId_desc */
	1: string fileUploadId,
    /** @FileUploadSuccessResult_jsonResponse_desc */
	2: string jsonResponse,
}

/** @FileUploadFailedResult_desc */
struct FileUploadFailedResult {
    /** @FileUploadFailedResult_fileUploadId_desc */
	1: string fileUploadId,
    /** @FileUploadFailedResult_statusCode_desc */
	2: i32 statusCode,
    /** @FileUploadFailedResult_reasonCode_desc */
	3: i32 reasonCode,
    /** @FileUploadFailedResult_jsonResponse_desc */
	4: string jsonResponse,
}


