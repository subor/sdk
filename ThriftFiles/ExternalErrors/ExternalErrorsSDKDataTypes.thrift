namespace * Ruyi.SDK.ExternalErrors

enum ExternalErrorCode {
    Err_0 = 0,
    Err_1 = 1,
    Err_2 = 2,
    Err_3 = 3,
    Err_4 = 4,
    Err_5 = 5,
    Err_6 = 6,
    Err_7 = 7,
    Err_8 = 8,
    Err_9 = 9,
    Err_10 = 10,
    Err_11 = 11,
    Err_12 = 12,
    Err_13 = 13,
    Err_14 = 14,
    Err_15 = 15,
    Err_16 = 16,
    Err_17 = 17,
    Err_18 = 18,
}


struct ExternalErrorInfos {
    1: ExternalErrorCode errorCode,
    2: string description,
}


const list<ExternalErrorInfos> EXTERNALERRORLIST = [
	{
		"errorCode": ExternalErrorCode.Err_0,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_1,
		"description": "setting {0} is not found!",
	},
	{
		"errorCode": ExternalErrorCode.Err_2,
		"description": "[type error] trying to assign a {0} to setting item {1}, whose data type is {2}",
	},
	{
		"errorCode": ExternalErrorCode.Err_3,
		"description": "json string convert failed: {0}",
	},
	{
		"errorCode": ExternalErrorCode.Err_4,
		"description": "lambda expression error: {0}",
	},
	{
		"errorCode": ExternalErrorCode.Err_5,
		"description": "[type error] trying to assign a {0} to setting category {1} 's property {2}, whose data type is {3}",
	},
	{
		"errorCode": ExternalErrorCode.Err_6,
		"description": "currently no player logged in. please login a player first.",
	},
	{
		"errorCode": ExternalErrorCode.Err_7,
		"description": "can not find configuration file: {0}.",
	},
	{
		"errorCode": ExternalErrorCode.Err_8,
		"description": "specified user {0} is not playing app {1}",
	},
	{
		"errorCode": ExternalErrorCode.Err_9,
		"description": "user is not found by id {0}",
	},
	{
		"errorCode": ExternalErrorCode.Err_10,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_11,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_12,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_13,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_14,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_15,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_16,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_17,
		"description": "",
	},
	{
		"errorCode": ExternalErrorCode.Err_18,
		"description": "trigger action failed when changing setting {0}!",
	},
]


