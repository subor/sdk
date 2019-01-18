include "BrainCloudServiceSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.BrainCloudApi
namespace csharp Ruyi.SDK.BrainCloudApi
namespace java Ruyi.SDK.BrainCloudApi
namespace netcore Ruyi.SDK.BrainCloudApi
namespace rs Ruyi.SDK.BrainCloudApi


service BrainCloudService {
	/** Creates an instance of an asynchronous match. */
	string AsyncMatch_CreateMatch(
		/** JSON string identifying the opponent platform and id for this match.
            
             Platforms are identified as:
             BC - a brainCloud profile id
             FB - a Facebook id
            
             An exmaple of this string would be:
             [
                 {
                     "platform": "BC",
                     "id": "some-braincloud-profile"
                 },
                 {
                     "platform": "FB",
                     "id": "some-facebook-id"
                 }
             ] */
		1: string jsonOpponentIds, 
		
		/** Optional push notification message to send to the other party.
             Refer to the Push Notification functions for the syntax required. */
		2: string pushNotificationMessage, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Creates an instance of an asynchronous match with an initial turn. */
	string AsyncMatch_CreateMatchWithInitialTurn(
		/** JSON string identifying the opponent platform and id for this match.
            
             Platforms are identified as:
             BC - a brainCloud profile id
             FB - a Facebook id
            
             An exmaple of this string would be:
             [
                 {
                     "platform": "BC",
                     "id": "some-braincloud-profile"
                 },
                 {
                     "platform": "FB",
                     "id": "some-facebook-id"
                 }
             ] */
		1: string jsonOpponentIds, 
		
		/** JSON string blob provided by the caller */
		2: string jsonMatchState, 
		
		/** Optional push notification message to send to the other party.
             Refer to the Push Notification functions for the syntax required. */
		3: string pushNotificationMessage, 
		
		/** Optionally, force the next player player to be a specific player */
		4: string nextPlayer, 
		
		/** Optional JSON string defining what the other player will see as a summary of the game when listing their games */
		5: string jsonSummary, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Submits a turn for the given match. */
	string AsyncMatch_SubmitTurn(
		/** Match owner identfier */
		1: string ownerId, 
		
		/** Match identifier */
		2: string matchId, 
		
		/** Game state version to ensure turns are submitted once and in order */
		3: i64 version, 
		
		/** JSON string blob provided by the caller */
		4: string jsonMatchState, 
		
		/** Optional push notification message to send to the other party.
            Refer to the Push Notification functions for the syntax required. */
		5: string pushNotificationMessage, 
		
		/** Optionally, force the next player player to be a specific player */
		6: string nextPlayer, 
		
		/** Optional JSON string that other players will see as a summary of the game when listing their games */
		7: string jsonSummary, 
		
		/** Optional JSON string blob provided by the caller */
		8: string jsonStatistics, 
		
		/** @BrainCloud_clientIndex_desc */
		9: i32 clientIndex
	),

	/** Allows the current player (only) to update Summary data without having to submit a whole turn. */
	string AsyncMatch_UpdateMatchSummaryData(
		/** Match owner identfier */
		1: string ownerId, 
		
		/** Match identifier */
		2: string matchId, 
		
		/** Game state version to ensure turns are submitted once and in order */
		3: i64 version, 
		
		/** JSON string provided by the caller that other players will see as a summary of the game when listing their games */
		4: string jsonSummary, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Marks the given match as complete. */
	string AsyncMatch_CompleteMatch(
		/** Match owner identifier */
		1: string ownerId, 
		
		/** Match identifier */
		2: string matchId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Returns the current state of the given match. */
	string AsyncMatch_ReadMatch(
		/** Match owner identifier */
		1: string ownerId, 
		
		/** Match identifier */
		2: string matchId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Returns the match history of the given match. */
	string AsyncMatch_ReadMatchHistory(
		/** Match owner identifier */
		1: string ownerId, 
		
		/** Match identifier */
		2: string matchId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Returns all matches that are NOT in a COMPLETE state for which the player is involved. */
	string AsyncMatch_FindMatches(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Returns all matches that are in a COMPLETE state for which the player is involved. */
	string AsyncMatch_FindCompleteMatches(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Marks the given match as abandoned. */
	string AsyncMatch_AbandonMatch(
		/** Match owner identifier */
		1: string ownerId, 
		
		/** Match identifier */
		2: string matchId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Removes the match and match history from the server. DEBUG ONLY, in production it is recommended
            the user leave it as completed. */
	string AsyncMatch_DeleteMatch(
		/** Match owner identifier */
		1: string ownerId, 
		
		/** Match identifier */
		2: string matchId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Used to create the anonymous installation id for the brainCloud profile. */
	string Authentication_GenerateAnonymousId(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Initialize - initializes the identity service with a saved
            anonymous installation id and most recently used profile id */
	void Authentication_Initialize(
		/** The id of the profile id that was most recently used by the app (on this device) */
		1: string profileId, 
		
		/** The anonymous installation id that was generated for this device */
		2: string anonymousId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Used to clear the saved profile id - to use in cases when the user is
            attempting to switch to a different app profile. */
	void Authentication_ClearSavedProfileID(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Authenticate a user anonymously with brainCloud - used for apps that don't want to bother
            the user to login, or for users who are sensitive to their privacy */
	string Authentication_AuthenticateAnonymous(
		/** Should a new profile be created if it does not exist? */
		1: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Authenticate the user with a custom Email and Password.  Note that the client app
             is responsible for collecting (and storing) the e-mail and potentially password
             (for convenience) in the client data.  For the greatest security,
             force the user to re-enter their password at each login.
             (Or at least give them that option). */
	string Authentication_AuthenticateEmailPassword(
		/** The e-mail address of the user */
		1: string email, 
		
		/** The password of the user */
		2: string password, 
		
		/** Should a new profile be created for this user if the account does not exist? */
		3: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Authenticate the user using a userId and password (without any validation on the userId).
            Similar to AuthenticateEmailPassword - except that that method has additional features to
            allow for e-mail validation, password resets, etc. */
	string Authentication_AuthenticateUniversal(1: string userId, 
		/** The password of the user */
		2: string password, 
		
		/** Should a new profile be created for this user if the account does not exist? */
		3: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Authenticate the user via cloud code (which in turn validates the supplied credentials against an external system).
            This allows the developer to extend brainCloud authentication to support other backend authentication systems. */
	string Authentication_AuthenticateExternal(
		/** The user id */
		1: string userId, 
		
		/** The user token (password etc) */
		2: string token, 
		
		/** The name of the cloud script to call for external authentication */
		3: string externalAuthName, 
		
		/** Should a new profile be created for this user if the account does not exist? */
		4: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Authenticate the user via wechat */
	string Authentication_AuthenticatePhone(
		/** The phone number to authenticate with */
		1: string phoneNumber, 
		
		/** The code sent to the mobile phone */
		2: string authCode, 
		
		/** Should a new profile be created for this user if the account does not exist? */
		3: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Authenticate the user via wechat */
	string Authentication_AuthenticateWechat(
		/** The open id passed from wechat */
		1: string openId, 
		
		/** The access token passed from wechat */
		2: string token, 
		
		/** Should a new profile be created for this user if the account does not exist? */
		3: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Reset Email password - Sends a password reset email to the specified address */
	string Authentication_ResetEmailPassword(
		/** The email address to send the reset email to. */
		1: string externalId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Request an SMS code sent to a phone prior to authentication. */
	string Authentication_RequestSmsCode(
		/** The phone number to send the code to. */
		1: string phoneNumber, 
		
		/** Whether or not to create a new player if they don't exist. */
		2: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	string Authentication_CheckUsernameExists(1: string gameId, 2: string playerName, 
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Returns the sessionId or empty string if no session present. */
	string Client_GetSessionId(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Returns true if the user is currently authenticated.
            If a session time out or session invalidation is returned from executing a
            sever API call, this flag will reset back to false. */
	bool Client_IsAuthenticated(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Returns true if brainCloud has been initialized. */
	bool Client_IsInitialized(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Method initializes the BrainCloudClient. */
	void Client_Initialize_SSS(
		/** The secret key for your app */
		1: string secretKey, 
		2: string appId, 
		
		/** The app version */
		3: string appVersion, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method initializes the BrainCloudClient. */
	void Client_Initialize_SSSS(
		/** The URL to the brainCloud server */
		1: string serverURL, 
		
		/** The secret key for your app */
		2: string secretKey, 
		
		/** The app id */
		3: string appId, 
		
		/** The app version */
		4: string appVersion, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Initialize the identity aspects of brainCloud. */
	void Client_InitializeIdentity(
		/** The profile id */
		1: string profileId, 
		
		/** The anonymous id */
		2: string anonymousId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Update method needs to be called regularly in order
            to process incoming and outgoing messages. */
	void Client_Update(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Enable logging of brainCloud transactions (comms etc) */
	void Client_EnableLogging(
		/** True if logging is to be enabled */
		1: bool enable, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Resets all messages and calls to the server */
	void Client_ResetCommunication(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Sets the packet timeouts using a list of integers that
             represent timeout values for each packet retry. The
             first item in the list represents the timeout for the first packet
             attempt, the second for the second packet attempt, and so on.
            
             The number of entries in this array determines how many packet
             retries will occur.
            
             By default, the packet timeout array is {10, 10, 10}
            
             Note that this method does not change the timeout for authentication
             packets (use SetAuthenticationPacketTimeout method). */
	void Client_SetPacketTimeouts(
		/** An array of packet timeouts. */
		1: list<i32> timeouts, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Sets the packet timeouts back to default. */
	void Client_SetPacketTimeoutsToDefault(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Returns the list of packet timeouts. */
	list<i32> Client_GetPacketTimeouts(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Sets the authentication packet timeout which is tracked separately
            from all other packets. Note that authentication packets are never
            retried and so this value represents the total time a client would
            wait to receive a reply to an authentication API call. By default
            this timeout is set to 15 seconds. */
	void Client_SetAuthenticationPacketTimeout(1: i32 timeoutSecs, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Gets the authentication packet timeout which is tracked separately
            from all other packets. Note that authentication packets are never
            retried and so this value represents the total time a client would
            wait to receive a reply to an authentication API call. By default
            this timeout is set to 15 seconds. */
	i32 Client_GetAuthenticationPacketTimeout(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Returns the low transfer rate timeout in secs */
	i32 Client_GetUploadLowTransferRateTimeout(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Sets the timeout in seconds of a low speed upload
            (i.e. transfer rate which is underneath the low transfer rate threshold).
            By default this is set to 120 secs.Setting this value to 0 will
            turn off the timeout. Note that this timeout method
            does not work on Unity mobile platforms. */
	void Client_SetUploadLowTransferRateTimeout(1: i32 timeoutSecs, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns the low transfer rate threshold in bytes/sec */
	i32 Client_GetUploadLowTransferRateThreshold(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Sets the low transfer rate threshold of an upload in bytes/sec.
            If the transfer rate dips below the given threshold longer
            than the specified timeout, the transfer will fail.
            By default this is set to 50 bytes/sec. Note that this timeout method
            does not work on Unity mobile platforms. */
	void Client_SetUploadLowTransferRateThreshold(
		/** The low transfer rate threshold in bytes/sec */
		1: i32 bytesPerSec, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Enables the timeout message caching which is disabled by default.
             Once enabled, if a client side timeout is encountered
             (i.e. brainCloud server is unreachable presumably due to the client
             network being down) the SDK will do the following:
            
             1 - cache the currently queued messages to brainCloud
             2 - call the network error callback
             3 - then expect the app to call either:
                 a) RetryCachedMessages() to retry sending to brainCloud
                 b) FlushCachedMessages() to dump all messages in the queue.
            
             Between steps 2 and 3, the app can prompt the user to retry connecting
             to brainCloud to determine whether to follow path 3a or 3b.
            
             Note that if path 3a is followed, and another timeout is encountered,
             the process will begin all over again from step 1.
            
             WARNING - the brainCloud SDK will cache *all* API calls sent
             when a timeout is encountered if this mechanism is enabled.
             This effectively freezes all communication with brainCloud.
             Apps must call either RetryCachedMessages() or FlushCachedMessages()
             for the brainCloud SDK to resume sending messages.
             ResetCommunication() will also clear the message cache. */
	void Client_EnableNetworkErrorMessageCaching(
		/** True if message should be cached on timeout */
		1: bool enabled, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Attempts to resend any cached messages. If no messages are in the cache,
            this method does nothing. */
	void Client_RetryCachedMessages(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Flushes the cached messages to resume API call processing. This will dump
            all of the cached messages in the queue. */
	void Client_FlushCachedMessages(
		/** If set to true API error callbacks will
            be called for every cached message with statusCode CLIENT_NETWORK_ERROR and reasonCode CLIENT_NETWORK_ERROR_TIMEOUT. */
		1: bool sendApiErrorCallbacks, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Inserts a marker which will tell the brainCloud comms layer
             to close the message bundle off at this point. Any messages queued
             before this method was called will likely be bundled together in
             the next send to the server.
            
             To ensure that only a single message is sent to the server you would
             do something like this:
            
             InsertEndOfMessageBundleMarker()
             SomeApiCall()
             InsertEndOfMessageBundleMarker() */
	void Client_InsertEndOfMessageBundleMarker(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Sets the country code sent to brainCloud when a user authenticates.
            Will override any auto detected country. */
	void Client_OverrideCountryCode(
		/** ISO 3166-1 two-letter country code */
		1: string countryCode, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Sets the language code sent to brainCloud when a user authenticates.
            If the language is set to a non-ISO 639-1 standard value the game default will be used instead.
            Will override any auto detected language. */
	void Client_OverrideLanguageCode(
		/** ISO 639-1 two-letter language code */
		1: string languageCode, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Creates custom data stream page event */
	string DataStream_CustomPageEvent(
		/** The name of the event */
		1: string eventName, 
		
		/** The properties of the event */
		2: string jsonEventProperties, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Creates custom data stream screen event */
	string DataStream_CustomScreenEvent(
		/** The name of the event */
		1: string eventName, 
		
		/** The properties of the event */
		2: string jsonEventProperties, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Creates custom data stream track event */
	string DataStream_CustomTrackEvent(
		/** The name of the event */
		1: string eventName, 
		
		/** The properties of the event */
		2: string jsonEventProperties, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method creates a new entity on the server. */
	string Entity_CreateEntity(
		/** The entity type as defined by the user */
		1: string entityType, 
		
		/** The entity's data as a json string */
		2: string jsonEntityData, 
		
		/** The entity's access control list as json. A null acl implies default
            permissions which make the entity readable/writeable by only the user. */
		3: string jsonEntityAcl, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method returns all user entities that match the given type. */
	string Entity_GetEntitiesByType(
		/** The entity type to search for */
		1: string entityType, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method updates a new entity on the server. This operation results in the entity
            data being completely replaced by the passed in JSON string. */
	string Entity_UpdateEntity(
		/** The id of the entity to update */
		1: string entityId, 
		
		/** The entity type as defined by the user */
		2: string entityType, 
		
		/** The entity's data as a json string. */
		3: string jsonEntityData, 
		
		/** The entity's access control list as json. A null acl implies default
            permissions which make the entity readable/writeable by only the user. */
		4: string jsonEntityAcl, 
		
		/** Current version of the entity. If the version of the
            entity on the server does not match the version passed in, the
            server operation will fail. Use -1 to skip version checking. */
		5: i32 version, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Method updates a shared entity owned by another user. This operation results in the entity
            data being completely replaced by the passed in JSON string. */
	string Entity_UpdateSharedEntity(
		/** The id of the entity to update */
		1: string entityId, 
		
		/** The id of the entity's owner */
		2: string targetProfileId, 
		
		/** The entity type as defined by the user */
		3: string entityType, 
		
		/** The entity's data as a json string. */
		4: string jsonEntityData, 
		
		/** Current version of the entity. If the version of the
             entity on the server does not match the version passed in, the
             server operation will fail. Use -1 to skip version checking. */
		5: i32 version, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Method deletes the given entity on the server. */
	string Entity_DeleteEntity(
		/** The id of the entity to update */
		1: string entityId, 
		
		/** Current version of the entity. If the version of the
             entity on the server does not match the version passed in, the
             server operation will fail. Use -1 to skip version checking. */
		2: i32 version, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method updates a singleton entity on the server. This operation results in the entity
            data being completely replaced by the passed in JSON string. If the entity doesn't exist it is created. */
	string Entity_UpdateSingleton(
		/** The entity type as defined by the user */
		1: string entityType, 
		
		/** The entity's data as a json string. */
		2: string jsonEntityData, 
		
		/** The entity's access control list as json. A null acl implies default */
		3: string jsonEntityAcl, 
		
		/** Current version of the entity. If the version of the
             entity on the server does not match the version passed in, the
             server operation will fail. Use -1 to skip version checking. */
		4: i32 version, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Method deletes the given singleton on the server. */
	string Entity_DeleteSingleton(
		/** The entity type as defined by the user */
		1: string entityType, 
		
		/** Current version of the entity. If the version of the
             entity on the server does not match the version passed in, the
             server operation will fail. Use -1 to skip version checking. */
		2: i32 version, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method to get a specific entity. */
	string Entity_GetEntity(
		/** The id of the entity */
		1: string entityId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves a singleton entity on the server. If the entity doesn't exist, null is returned. */
	string Entity_GetSingleton(
		/** The entity type as defined by the user */
		1: string entityType, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns a shared entity for the given profile and entity ID.
            An entity is shared if its ACL allows for the currently logged
            in user to read the data. */
	string Entity_GetSharedEntityForProfileId(
		/** The the profile ID of the user who owns the entity */
		1: string profileId, 
		
		/** The ID of the entity that will be retrieved */
		2: string entityId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method returns all shared entities for the given profile id.
            An entity is shared if its ACL allows for the currently logged
            in user to read the data. */
	string Entity_GetSharedEntitiesForProfileId(
		/** The profile id to retrieve shared entities for */
		1: string profileId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method gets list of entities from the server base on type and/or where clause */
	string Entity_GetList(
		/** Mongo style query string */
		1: string whereJson, 
		
		/** Sort order */
		2: string orderByJson, 
		
		/** The maximum number of entities to return */
		3: i32 maxReturn, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method gets list of shared entities for the specified user based on type and/or where clause */
	string Entity_GetSharedEntitiesListForProfileId(
		/** The profile ID to retrieve shared entities for */
		1: string profileId, 
		
		/** Mongo style query string */
		2: string whereJson, 
		
		/** Sort order */
		3: string orderByJson, 
		
		/** The maximum number of entities to return */
		4: i32 maxReturn, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Method gets a count of entities based on the where clause */
	string Entity_GetListCount(
		/** Mongo style query string */
		1: string whereJson, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method uses a paging system to iterate through user entities.
            After retrieving a page of entities with this method,
            use GetPageOffset() to retrieve previous or next pages. */
	string Entity_GetPage(
		/** The json context for the page request.
            See the portal appendix documentation for format */
		1: string jsonContext, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method to retrieve previous or next pages after having called
            the GetPage method. */
	string Entity_GetPageOffset(
		/** The context string returned from the server from a previous call
            to GetPage() or GetPageOffset() */
		1: string context, 
		
		/** The positive or negative page offset to fetch. Uses the last page
            retrieved using the context string to determine a starting point. */
		2: i32 pageOffset, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Partial increment of entity data field items. Partial set of items incremented as specified. */
	string Entity_IncrementUserEntityData(
		/** The entity to increment */
		1: string entityId, 
		
		/** The subset of data to increment */
		2: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Partial increment of shared entity data field items. Partial set of items incremented as specified. */
	string Entity_IncrementSharedUserEntityData(
		/** The entity to increment */
		1: string entityId, 
		
		/** Profile ID of the entity owner */
		2: string targetProfileId, 
		
		/** The subset of data to increment */
		3: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Sends an event to the designated profile id with the attached json data.
            Any events that have been sent to a user will show up in their
            incoming event mailbox. If the recordLocally flag is set to true,
            a copy of this event (with the exact same event id) will be stored
            in the sending user's "sent" event mailbox. */
	string Event_SendEvent(
		/** The id of the user who is being sent the event */
		1: string toProfileId, 
		
		/** The user-defined type of the event. */
		2: string eventType, 
		
		/** The user-defined data for this event encoded in JSON. */
		3: string jsonEventData, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Updates an event in the user's incoming event mailbox. */
	string Event_UpdateIncomingEventData(
		/** The event id */
		1: string evId, 
		
		/** The user-defined data for this event encoded in JSON. */
		2: string jsonEventData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Delete an event out of the user's incoming mailbox. */
	string Event_DeleteIncomingEvent(
		/** The event id */
		1: string evId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Get the events currently queued for the user. */
	string Event_GetEvents(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Prepares a user file upload. On success the file will begin uploading
            to the brainCloud server.To be informed of success/failure of the upload
            register an IFileUploadCallback with the BrainCloudClient class. */
	string File_UploadFile(
		/** The desired cloud path of the file */
		1: string cloudPath, 
		
		/** The desired cloud fileName of the file */
		2: string cloudFilename, 
		
		/** True if the file is shareable */
		3: bool shareable, 
		
		/** Whether to replace file if it exists */
		4: bool replaceIfExists, 
		
		/** The path and fileName of the local file */
		5: string localPath, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Method cancels an upload. If an IFileUploadCallback has been registered with the BrainCloudClient class,
            the fileUploadFailed callback method will be called once the upload has been canceled.
            NOTE: The upload will still continue in the background on versions of Unity before 5.3
            and on Unity mobile platforms. */
	void File_CancelUpload(
		/** Upload ID of the file to cancel */
		1: string uploadId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns the progress of the given upload from 0.0 to 1.0 or -1 if upload not found.
            NOTE: This will always return 1 on Unity mobile platforms. */
	double File_GetUploadProgress(
		/** The id of the upload */
		1: string uploadId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns the number of bytes uploaded or -1 if upload not found.
            NOTE: This will always return the total bytes to transfer on Unity mobile platforms. */
	i64 File_GetUploadBytesTransferred(
		/** The id of the upload */
		1: string uploadId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns the total number of bytes that will be uploaded or -1 if upload not found. */
	i64 File_GetUploadTotalBytesToTransfer(
		/** The id of the upload */
		1: string uploadId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** List all user files */
	string File_ListUserFiles_SFO(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** List user files from the given cloud path */
	string File_ListUserFiles_SNSFO(
		/** File path */
		1: string cloudPath, 
		
		/** Whether to recurse down the path */
		2: bool recurse, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Deletes a single user file. */
	string File_DeleteUserFile(
		/** File path */
		1: string cloudPath, 
		2: string cloudFileName, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Delete multiple user files */
	string File_DeleteUserFiles(
		/** File path */
		1: string cloudPath, 
		
		/** Whether to recurse down the path */
		2: bool recurse, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Returns the CDN URL for a file object. */
	string File_GetCDNUrl(
		/** File path */
		1: string cloudPath, 
		
		/** Name of file */
		2: string cloudFilename, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Returns a particular entity of a particular friend. */
	string Friend_ReadFriendEntity(
		/** Id of entity to retrieve. */
		1: string entityId, 
		
		/** Profile Id of friend who owns entity. */
		2: string friendId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Returns entities of all friends based on type and/or subtype. */
	string Friend_ReadFriendsEntities(
		/** Types of entities to retrieve. */
		1: string entityType, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns user state of a particular friend. */
	string Friend_ReadFriendUserState(
		/** Profile Id of friend to retrieve user state for. */
		1: string friendId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns user state of a particular user. */
	string Friend_GetSummaryDataForProfileId(1: string playerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns user state of a set of users. */
	string Friend_GetSummaryDataForProfileIds(
		/** Player Ids of users to retrieve player state for. */
		1: list<string> playerIds, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns user state of the player's friends. */
	string Friend_GetSummaryDataForFriends(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Returns user state of player's recently met. */
	string Friend_GetSummaryDataForRecentlyMetPlayers(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Finds a list of users matching the search text by performing an exact
            search of all user names. */
	string Friend_FindUsersByExactName(
		/** The string to search for. */
		1: string searchText, 
		
		/** Maximum number of results to return. */
		2: i32 maxResults, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Finds a list of users matching the search text by performing a substring
            search of all user names. */
	string Friend_FindUsersBySubstrName(
		/** The substring to search for. Minimum length of 3 characters. */
		1: string searchText, 
		
		/** Maximum number of results to return. */
		2: i32 maxResults, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Retrieves a list of user and friend platform information for all friends of the current user. */
	string Friend_ListFriends(
		/** Friend platform to query. */
		1: BrainCloudServiceSDKDataTypes.FriendPlatform friendPlatform, 
		
		/** True if including summary data; false otherwise. */
		2: bool includeSummaryData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Links the current user and the specified users as brainCloud friends. */
	string Friend_AddFriends(
		/** Collection of profile IDs. */
		1: list<string> profileIds, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Unlinks the current user and the specified users as brainCloud friends. */
	string Friend_RemoveFriends(
		/** Collection of profile IDs. */
		1: list<string> profileIds, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Get users online status */
	string Friend_GetUsersOnlineStatus(
		/** Collection of profile IDs. */
		1: list<string> profileIds, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Friend_SendFriendInvitation(1: string toPlayerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Friend_ListFriendInvitationsReceived(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	string Friend_ListFriendInvitationsSent(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	string Friend_AcceptFriendInvitation(1: string fromPlayerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Friend_RejectFriendInvitation(1: string fromPlayerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Friend_RemoveFriend(1: string playerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves all gamification data for the player. */
	string Gamification_ReadAllGamification(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves all milestones defined for the game. */
	string Gamification_ReadMilestones(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Read all of the achievements defined for the game. */
	string Gamification_ReadAchievements(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns all defined xp levels and any rewards associated
            with those xp levels. */
	string Gamification_ReadXpLevelsMetaData(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Method retrives the list of achieved achievements. */
	string Gamification_ReadAchievedAchievements(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves the list of completed milestones. */
	string Gamification_ReadCompletedMilestones(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves the list of in progress milestones */
	string Gamification_ReadInProgressMilestones(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves milestones of the given category. */
	string Gamification_ReadMilestonesByCategory(
		/** The milestone category */
		1: string category, 
		2: bool includeMetaData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method will award the achievements specified. On success, this will
            call AwardThirdPartyAchievement to hook into the client-side Achievement
            service (ie GameCentre, Facebook etc). */
	string Gamification_AwardAchievements(
		/** A collection of achievement ids to award */
		1: list<string> achievementIds, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves all of the quests defined for the game. */
	string Gamification_ReadQuests(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns all completed quests. */
	string Gamification_ReadCompletedQuests(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns all in progress quests. */
	string Gamification_ReadInProgressQuests(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns all quests that haven't been started. */
	string Gamification_ReadNotStartedQuests(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns all quests with status. */
	string Gamification_ReadQuestsWithStatus(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns all quests with a basic percentage. */
	string Gamification_ReadQuestsWithBasicPercentage(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns all quests with a complex percentage. */
	string Gamification_ReadQuestsWithComplexPercentage(1: bool includeMetaData, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns all quests for the given category. */
	string Gamification_ReadQuestsByCategory(
		/** The quest category */
		1: string category, 
		2: bool includeMetaData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Sets the specified milestones' statuses to LOCKED. */
	string Gamification_ResetMilestones(
		/** List of milestones to reset */
		1: list<string> milestoneIds, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method reads all the global properties of the game */
	string GlobalApp_ReadProperties(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Method creates a new entity on the server. */
	string GlobalEntity_CreateEntity(
		/** The entity type as defined by the user */
		1: string entityType, 
		
		/** Sets expiry time for entity in milliseconds if > 0 */
		2: i64 timeToLive, 
		
		/** The entity's access control list as json. A null acl implies default */
		3: string jsonEntityAcl, 
		
		/** The entity's data as a json string */
		4: string jsonEntityData, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Method creates a new entity on the server with an indexed id. */
	string GlobalEntity_CreateEntityWithIndexedId(
		/** The entity type as defined by the user */
		1: string entityType, 
		
		/** A secondary ID that will be indexed */
		2: string indexedId, 
		
		/** Sets expiry time for entity in milliseconds if > 0 */
		3: i64 timeToLive, 
		
		/** The entity's access control list as json. A null acl implies default */
		4: string jsonEntityAcl, 
		
		/** The entity's data as a json string */
		5: string jsonEntityData, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Method updates an existing entity on the server. */
	string GlobalEntity_UpdateEntity(
		/** The entity ID */
		1: string entityId, 
		
		/** The version of the entity to update */
		2: i32 version, 
		
		/** The entity's data as a json string */
		3: string jsonEntityData, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method updates an existing entity's Acl on the server. */
	string GlobalEntity_UpdateEntityAcl(
		/** The entity ID */
		1: string entityId, 
		
		/** The version of the entity to update */
		2: i32 version, 
		
		/** The entity's access control list as json. */
		3: string jsonEntityAcl, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method updates an existing entity's time to live on the server. */
	string GlobalEntity_UpdateEntityTimeToLive(
		/** The entity ID */
		1: string entityId, 
		
		/** The version of the entity to update */
		2: i32 version, 
		
		/** Sets expiry time for entity in milliseconds if > 0 */
		3: i64 timeToLive, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method deletes an existing entity on the server. */
	string GlobalEntity_DeleteEntity(
		/** The entity ID */
		1: string entityId, 
		
		/** The version of the entity to delete */
		2: i32 version, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method reads an existing entity from the server. */
	string GlobalEntity_ReadEntity(
		/** The entity ID */
		1: string entityId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method gets list of entities from the server base on type and/or where clause */
	string GlobalEntity_GetList(
		/** Mongo style query string */
		1: string whereJson, 
		
		/** Sort order */
		2: string orderByJson, 
		
		/** The maximum number of entities to return */
		3: i32 maxReturn, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method gets list of entities from the server base on indexed id */
	string GlobalEntity_GetListByIndexedId(
		/** The entity indexed Id */
		1: string entityIndexedId, 
		
		/** The maximum number of entities to return */
		2: i32 maxReturn, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method gets a count of entities based on the where clause */
	string GlobalEntity_GetListCount(
		/** Mongo style query string */
		1: string whereJson, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method uses a paging system to iterate through Global Entities.
            After retrieving a page of Global Entities with this method,
            use GetPageOffset() to retrieve previous or next pages. */
	string GlobalEntity_GetPage(
		/** The json context for the page request.
            See the portal appendix documentation for format */
		1: string jsonContext, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method to retrieve previous or next pages after having called
            the GetPage method. */
	string GlobalEntity_GetPageOffset(
		/** The context string returned from the server from a previous call
            to GetPage() or GetPageOffset() */
		1: string context, 
		
		/** The positive or negative page offset to fetch. Uses the last page
            retrieved using the context string to determine a starting point. */
		2: i32 pageOffset, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Partial increment of global entity data field items. Partial set of items incremented as specified. */
	string GlobalEntity_IncrementGlobalEntityData(
		/** The entity to increment */
		1: string entityId, 
		
		/** The subset of data to increment */
		2: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Gets a list of up to randomCount randomly selected entities from the server based on the where condition and specified maximum return count. */
	string GlobalEntity_GetRandomEntitiesMatching(1: string whereJson, 
		/** The maximum number of entities to return */
		2: i32 maxReturn, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method updates an existing entity's Owner and Acl on the server. */
	string GlobalEntity_UpdateEntityOwnerAndAcl(
		/** The entity ID */
		1: string entityId, 
		
		/** The version of the entity */
		2: i64 version, 
		
		/** The owner ID */
		3: string ownerId, 
		
		/** The entity's access control list */
		4: BrainCloudServiceSDKDataTypes.JSON acl, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Method clears the owner id of an existing entity and sets the Acl on the server. */
	string GlobalEntity_MakeSystemEntity(
		/** The entity ID */
		1: string entityId, 
		
		/** The version of the entity */
		2: i64 version, 
		
		/** The entity's access control list */
		3: BrainCloudServiceSDKDataTypes.JSON acl, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method returns all of the global statistics. */
	string GlobalStatistics_ReadAllGlobalStats(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Reads a subset of global statistics as defined by the input JSON. */
	string GlobalStatistics_ReadGlobalStatsSubset(
		/** A list containing the statistics to read */
		1: list<string> globalStats, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves the global statistics for the given category. */
	string GlobalStatistics_ReadGlobalStatsForCategory(
		/** The global statistics category */
		1: string category, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Atomically increment (or decrement) global statistics.
            Global statistics are defined through the brainCloud portal. */
	string GlobalStatistics_IncrementGlobalStats(
		/** The JSON encoded data to be sent to the server as follows:
            {
              stat1: 10,
              stat2: -5.5,
            }
            would increment stat1 by 10 and decrement stat2 by 5.5.
            For the full statistics grammer see the api.braincloudservers.com site.
            There are many more complex operations supported such as:
            {
              stat1:INC_TO_LIMIT#9#30
            }
            which increments stat1 by 9 up to a limit of 30. */
		1: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Apply statistics grammar to a partial set of statistics. */
	string GlobalStatistics_ProcessStatistics(
		/** Example data to be passed to method:
            {
                "DEAD_CATS": "RESET",
                "LIVES_LEFT": "SET#9",
                "MICE_KILLED": "INC#2",
                "DOG_SCARE_BONUS_POINTS": "INC#10",
                "TREES_CLIMBED": 1
            } */
		1: map<string, BrainCloudServiceSDKDataTypes.JSON> statisticsData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Accept an outstanding invitation to join the group. */
	string Group_AcceptGroupInvitation(
		/** ID of the group. */
		1: string groupId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Add a member to the group. */
	string Group_AddGroupMember(
		/** ID of the group. */
		1: string groupId, 
		
		/** Profile ID of the member being added. */
		2: string profileId, 
		
		/** Role of the member being added. */
		3: BrainCloudServiceSDKDataTypes.Role role, 
		
		/** Attributes of the member being added. */
		4: string jsonAttributes, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Approve an outstanding request to join the group. */
	string Group_ApproveGroupJoinRequest(
		/** ID of the group. */
		1: string groupId, 
		
		/** Profile ID of the invitation being deleted. */
		2: string profileId, 
		
		/** Role of the member being invited. */
		3: BrainCloudServiceSDKDataTypes.Role role, 
		
		/** Attributes of the member being invited. */
		4: string jsonAttributes, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Automatically join an open group that matches the search criteria and has space available. */
	string Group_AutoJoinGroup(
		/** Name of the associated group type. */
		1: string groupType, 
		
		/** Selection strategy to employ when there are multiple matches */
		2: BrainCloudServiceSDKDataTypes.AutoJoinStrategy autoJoinStrategy, 
		
		/** Query parameters (optional) */
		3: string dataQueryJson, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Cancel an outstanding invitation to the group. */
	string Group_CancelGroupInvitation(
		/** ID of the group. */
		1: string groupId, 
		
		/** Profile ID of the invitation being deleted. */
		2: string profileId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Create a group. */
	string Group_CreateGroup(
		/** Name of the group. */
		1: string name, 
		
		/** Name of the type of group. */
		2: string groupType, 
		
		/** true if group is open; false if closed. */
		3: bool isOpenGroup, 
		
		/** The group's access control list. A null ACL implies default. */
		4: BrainCloudServiceSDKDataTypes.JSON acl, 
		
		/** Custom application data. */
		5: string jsonData, 
		
		/** Attributes for the group owner (current user). */
		6: string jsonOwnerAttributes, 
		
		/** Default attributes for group members. */
		7: string jsonDefaultMemberAttributes, 
		
		/** @BrainCloud_clientIndex_desc */
		8: i32 clientIndex
	),

	/** Create a group entity. */
	string Group_CreateGroupEntity(
		/** ID of the group. */
		1: string groupId, 
		2: string entityType, 
		
		/** true if entity is owned by a member; false if owned by the entire group. */
		3: bool isOwnedByGroupMember, 
		
		/** Access control list for the group entity. */
		4: BrainCloudServiceSDKDataTypes.JSON acl, 
		
		/** Custom application data. */
		5: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Delete a group. */
	string Group_DeleteGroup(
		/** ID of the group. */
		1: string groupId, 
		
		/** Current version of the group */
		2: i64 version, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Delete a group entity. */
	string Group_DeleteGroupEntity(
		/** ID of the group. */
		1: string groupId, 
		
		/** ID of the entity. */
		2: string entityId, 
		
		/** The current version of the group entity (for concurrency checking). */
		3: i64 version, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Read information on groups to which the current user belongs. */
	string Group_GetMyGroups(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Increment elements for the group's data field. */
	string Group_IncrementGroupData(
		/** ID of the group. */
		1: string groupId, 
		
		/** Partial data map with incremental values. */
		2: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Increment elements for the group entity's data field. */
	string Group_IncrementGroupEntityData(
		/** ID of the group. */
		1: string groupId, 
		
		/** ID of the entity. */
		2: string entityId, 
		
		/** Partial data map with incremental values. */
		3: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Invite a member to the group. */
	string Group_InviteGroupMember(
		/** ID of the group. */
		1: string groupId, 
		
		/** Profile ID of the member being invited. */
		2: string profileId, 
		
		/** Role of the member being invited. */
		3: BrainCloudServiceSDKDataTypes.Role role, 
		
		/** Attributes of the member being invited. */
		4: string jsonAttributes, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Join an open group or request to join a closed group. */
	string Group_JoinGroup(
		/** ID of the group. */
		1: string groupId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Leave a group in which the user is a member. */
	string Group_LeaveGroup(
		/** ID of the group. */
		1: string groupId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Retrieve a page of group summary information based on the specified context. */
	string Group_ListGroupsPage(
		/** Query context. */
		1: string jsonContext, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Retrieve a page of group summary information based on the encoded context 
            and specified page offset. */
	string Group_ListGroupsPageByOffset(
		/** Encoded reference query context. */
		1: string context, 
		
		/** Number of pages by which to offset the query. */
		2: i32 pageOffset, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Read information on groups to which the specified user belongs.  Access is subject to restrictions. */
	string Group_ListGroupsWithMember(
		/** User to read groups for */
		1: string profileId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Read the specified group. */
	string Group_ReadGroup(
		/** ID of the group. */
		1: string groupId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Read the data of the specified group. */
	string Group_ReadGroupData(
		/** ID of the group. */
		1: string groupId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Read a page of group entity information. */
	string Group_ReadGroupEntitiesPage(
		/** Query context. */
		1: string jsonContext, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Read a page of group entity information. */
	string Group_ReadGroupEntitiesPageByOffset(
		/** Encoded reference query context. */
		1: string encodedContext, 
		
		/** Number of pages by which to offset the query. */
		2: i32 pageOffset, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Read the specified group entity. */
	string Group_ReadGroupEntity(
		/** ID of the group. */
		1: string groupId, 
		
		/** ID of the entity. */
		2: string entityId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Read the members of the group. */
	string Group_ReadGroupMembers(
		/** ID of the group. */
		1: string groupId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Reject an outstanding invitation to join the group. */
	string Group_RejectGroupInvitation(
		/** ID of the group. */
		1: string groupId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Reject an outstanding request to join the group. */
	string Group_RejectGroupJoinRequest(
		/** ID of the group. */
		1: string groupId, 
		
		/** Profile ID of the invitation being deleted. */
		2: string profileId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Remove a member from the group. */
	string Group_RemoveGroupMember(
		/** ID of the group. */
		1: string groupId, 
		
		/** Profile ID of the member being deleted. */
		2: string profileId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Updates a group's data. */
	string Group_UpdateGroupData(
		/** ID of the group. */
		1: string groupId, 
		
		/** Version to verify. */
		2: i64 version, 
		
		/** Data to apply. */
		3: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Update a group entity. */
	string Group_UpdateGroupEntityData(
		/** ID of the group. */
		1: string groupId, 
		
		/** ID of the entity. */
		2: string entityId, 
		
		/** The current version of the group entity (for concurrency checking). */
		3: i64 version, 
		
		/** Custom application data. */
		4: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Update a member of the group. */
	string Group_UpdateGroupMember(
		/** ID of the group. */
		1: string groupId, 
		
		/** Profile ID of the member being updated. */
		2: string profileId, 
		
		/** Role of the member being updated (optional). */
		3: BrainCloudServiceSDKDataTypes.Role role, 
		
		/** Attributes of the member being updated (optional). */
		4: string jsonAttributes, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Updates a group's name. */
	string Group_UpdateGroupName(
		/** ID of the group. */
		1: string groupId, 
		
		/** Name to apply. */
		2: string name, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Attach a Email and Password identity to the current profile. */
	string Identity_AttachEmailIdentity(
		/** The user's e-mail address */
		1: string email, 
		
		/** The user's password */
		2: string password, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Merge the profile associated with the provided e=mail with the current profile. */
	string Identity_MergeEmailIdentity(
		/** The user's e-mail address */
		1: string email, 
		
		/** The user's password */
		2: string password, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Detach the e-mail identity from the current profile */
	string Identity_DetachEmailIdentity(
		/** The user's e-mail address */
		1: string email, 
		
		/** Proceed even if the profile will revert to anonymous? */
		2: bool continueAnon, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Attach a Universal (userId + password) identity to the current profile. */
	string Identity_AttachUniversalIdentity(
		/** The user's userId */
		1: string userId, 
		
		/** The user's password */
		2: string password, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Merge the profile associated with the provided e=mail with the current profile. */
	string Identity_MergeUniversalIdentity(
		/** The user's userId */
		1: string userId, 
		
		/** The user's password */
		2: string password, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Detach the universal identity from the current profile */
	string Identity_DetachUniversalIdentity(
		/** The user's userId */
		1: string userId, 
		
		/** Proceed even if the profile will revert to anonymous? */
		2: bool continueAnon, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Switch to a Child Profile */
	string Identity_SwitchToChildProfile(
		/** The profileId of the child profile to switch to
            If null and forceCreate is true a new profile will be created */
		1: string childProfileId, 
		
		/** The appId of the child game to switch to */
		2: string childAppId, 
		
		/** Should a new profile be created if it does not exist? */
		3: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Switches to the child profile of an app when only one profile exists
            If multiple profiles exist this returns an error */
	string Identity_SwitchToSingletonChildProfile(
		/** The App ID of the child game to switch to */
		1: string childAppId, 
		
		/** Should a new profile be created if one does not exist? */
		2: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Attach a new identity to a parent app */
	string Identity_AttachParentWithIdentity(
		/** User ID */
		1: string externalId, 
		
		/** Password or client side token */
		2: string authenticationToken, 
		
		/** Type of authentication */
		3: string authenticationType, 
		
		/** Optional - if using AuthenticationType of external */
		4: string externalAuthName, 
		
		/** If the profile does not exist, should it be created? */
		5: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Switch to a Parent Profile */
	string Identity_SwitchToParentProfile(
		/** The level of the parent to switch to */
		1: string parentLevelName, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Detaches parent from this user's profile */
	string Identity_DetachParent(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Returns a list of all child profiles in child Apps */
	string Identity_GetChildProfiles(
		/** Whether to return the summary friend data along with this call */
		1: bool includeSummaryData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Retrieve list of identities */
	string Identity_GetIdentities(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Retrieve list of expired identities */
	string Identity_GetExpiredIdentities(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Refreshes an identity for this user */
	string Identity_RefreshIdentity(
		/** User ID */
		1: string externalId, 
		
		/** Password or client side token */
		2: string authenticationToken, 
		
		/** Type of authentication */
		3: string authenticationType, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Allows email identity email address to be changed */
	string Identity_ChangeEmailIdentity(
		/** Old email address */
		1: string oldEmailAddress, 
		
		/** Password for identity */
		2: string password, 
		
		/** New email address */
		3: string newEmailAddress, 
		
		/** Whether to update contact email in profile */
		4: bool updateContactEmail, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Attaches a peer identity to this user's profile */
	string Identity_AttachPeerProfile(
		/** Name of the peer to connect to */
		1: string peer, 
		
		/** User ID */
		2: string externalId, 
		
		/** Password or client side token */
		3: string authenticationToken, 
		
		/** Type of authentication */
		4: string authenticationType, 
		
		/** Optional - if using AuthenticationType of external */
		5: string externalAuthName, 
		
		/** If the profile does not exist, should it be created? */
		6: bool forceCreate, 
		
		/** @BrainCloud_clientIndex_desc */
		7: i32 clientIndex
	),

	/** Detaches a peer identity from this user's profile */
	string Identity_DetachPeer(
		/** Name of the peer to connect to */
		1: string peer, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Retrieves a list of attached peer profiles */
	string Identity_GetPeerProfiles(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Sends a simple text email to the specified user */
	string Mail_SendBasicEmail(1: string profileId, 
		/** The email subject */
		2: string subject, 
		
		/** The email body */
		3: string body, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Sends an advanced email to the specified user */
	string Mail_SendAdvancedEmail(1: string profileId, 
		/** Parameters to send to the email service. See the documentation for
            a full list. http://getbraincloud.com/apidocs/apiref/#capi-mail */
		2: string jsonServiceParams, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Sends an advanced email to the specified email address */
	string Mail_SendAdvancedEmailByAddress(
		/** The address to send the email to */
		1: string emailAddress, 
		
		/** Parameters to send to the email service. See the documentation for
            a full list. http://getbraincloud.com/apidocs/apiref/#capi-mail */
		2: string jsonServiceParams, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Read match making record */
	string MatchMaking_Read(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Sets player rating */
	string MatchMaking_SetPlayerRating(
		/** The new player rating. */
		1: i64 playerRating, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Resets player rating */
	string MatchMaking_ResetPlayerRating(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Increments player rating */
	string MatchMaking_IncrementPlayerRating(
		/** The increment amount */
		1: i64 increment, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Decrements player rating */
	string MatchMaking_DecrementPlayerRating(
		/** The decrement amount */
		1: i64 decrement, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Turns shield on */
	string MatchMaking_TurnShieldOn(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Turns shield on for the specified number of minutes */
	string MatchMaking_TurnShieldOnFor(
		/** Number of minutes to turn the shield on for */
		1: i32 minutes, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Turns shield off */
	string MatchMaking_TurnShieldOff(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Increases the shield on time by specified number of minutes */
	string MatchMaking_IncrementShieldOnFor(
		/** Number of minutes to increase the shield time for */
		1: i32 minutes, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Gets the shield expiry for the given player id. Passing in a null player id
            will return the shield expiry for the current player. The value returned is
            the time in UTC millis when the shield will expire. */
	string MatchMaking_GetShieldExpiry(
		/** The player id or use null to retrieve for the current player */
		1: string playerId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Finds matchmaking enabled players */
	string MatchMaking_FindPlayers(
		/** The range delta */
		1: i64 rangeDelta, 
		
		/** The maximum number of matches to return */
		2: i64 numMatches, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Finds matchmaking enabled players with additional attributes */
	string MatchMaking_FindPlayersWithAttributes(
		/** The range delta */
		1: i64 rangeDelta, 
		
		/** The maximum number of matches to return */
		2: i64 numMatches, 
		
		/** Attributes match criteria */
		3: string jsonAttributes, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Finds matchmaking enabled players using a cloud code filter */
	string MatchMaking_FindPlayersUsingFilter(
		/** The range delta */
		1: i64 rangeDelta, 
		
		/** The maximum number of matches to return */
		2: i64 numMatches, 
		
		/** Parameters to pass to the CloudCode filter script */
		3: string jsonExtraParms, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Finds matchmaking enabled players using a cloud code filter 
            and additional attributes */
	string MatchMaking_FindPlayersWithAttributesUsingFilter(
		/** The range delta */
		1: i64 rangeDelta, 
		
		/** The maximum number of matches to return */
		2: i64 numMatches, 
		
		/** Attributes match criteria */
		3: string jsonAttributes, 
		
		/** Parameters to pass to the CloudCode filter script */
		4: string jsonExtraParms, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Enables Match Making for the Player */
	string MatchMaking_EnableMatchMaking(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Disables Match Making for the Player */
	string MatchMaking_DisableMatchMaking(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Starts a match */
	string OneWayMatch_StartMatch(
		/** The player to start a match with */
		1: string otherPlayerId, 
		
		/** The range delta used for the initial match search */
		2: i64 rangeDelta, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Cancels a match */
	string OneWayMatch_CancelMatch(
		/** The playback stream id returned in the start match */
		1: string playbackStreamId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Completes a match */
	string OneWayMatch_CompleteMatch(
		/** The playback stream id returned in the initial start match */
		1: string playbackStreamId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Starts a stream */
	string PlaybackStream_StartStream(
		/** The player to start a stream with */
		1: string targetPlayerId, 
		
		/** Whether to include shared data in the stream */
		2: bool includeSharedData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Reads a stream */
	string PlaybackStream_ReadStream(
		/** Identifies the stream to read */
		1: string playbackStreamId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Ends a stream */
	string PlaybackStream_EndStream(
		/** Identifies the stream to read */
		1: string playbackStreamId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Deletes a stream */
	string PlaybackStream_DeleteStream(
		/** Identifies the stream to read */
		1: string playbackStreamId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Adds a stream event */
	string PlaybackStream_AddEvent(
		/** Identifies the stream to read */
		1: string playbackStreamId, 
		
		/** Describes the event */
		2: string eventData, 
		
		/** Current summary data as of this event */
		3: string summary, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Gets recent streams for initiating player */
	string PlaybackStream_GetRecentStreamsForInitiatingPlayer(
		/** The player that started the stream */
		1: string initiatingPlayerId, 
		
		/** The player that started the stream */
		2: i32 maxNumStreams, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Gets recent streams for target player */
	string PlaybackStream_GetRecentStreamsForTargetPlayer(
		/** The player that started the stream */
		1: string targetPlayerId, 
		
		/** The player that started the stream */
		2: i32 maxNumStreams, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Read the state of the currently logged in user.
            This method returns a JSON object describing most of the
            player's data: entities, statistics, level, currency.
            Apps will typically call this method after authenticating to get an
            up-to-date view of the user's data. */
	string PlayerState_ReadUserState(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Completely deletes the user record and all data fully owned
            by the user. After calling this method, the user will need
            to re-authenticate and create a new profile.
            This is mostly used for debugging/qa. */
	string PlayerState_DeleteUser(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** This method will delete *most* data for the currently logged in user.
            Data which is not deleted includes: currency, credentials, and
            purchase transactions. ResetUser is different from DeleteUser in that
            the player record will continue to exist after the reset (so the user
            does not need to re-authenticate). */
	string PlayerState_ResetUser(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Logs user out of server. */
	string PlayerState_Logout(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Sets the user name. */
	string PlayerState_UpdateUserName(
		/** The name of the user */
		1: string userName, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Updates the "friend summary data" associated with the logged in user.
             Some operations will return this summary data. For instance the social
             leaderboards will return the player's score in the leaderboard along
             with the friend summary data. Generally this data is used to provide
             a quick overview of the player without requiring a separate API call
             to read their public stats or entity data. */
	string PlayerState_UpdateSummaryFriendData(
		/** A JSON string defining the summary data.
             For example:
             {
               "xp":123,
               "level":12,
               "highScore":45123
             } */
		1: string jsonSummaryData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Retrieve the user's attributes. */
	string PlayerState_GetAttributes(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Update user's attributes. */
	string PlayerState_UpdateAttributes(
		/** Single layer json string that is a set of key-value pairs */
		1: string jsonAttributes, 
		
		/** Whether to wipe existing attributes prior to update. */
		2: bool wipeExisting, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Remove user's attributes. */
	string PlayerState_RemoveAttributes(
		/** List of attribute names. */
		1: list<string> attributeNames, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Updates player's picture URL. */
	string PlayerState_UpdateUserPictureUrl(
		/** URL to apply. */
		1: string pictureUrl, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Update the user's contact email. 
            Note this is unrelated to email authentication. */
	string PlayerState_UpdateContactEmail(
		/** Updated email */
		1: string contactEmail, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Read all available user statistics. */
	string PlayerStatistics_ReadAllUserStats(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Reads a subset of user statistics as defined by the input JSON. */
	string PlayerStatistics_ReadUserStatsSubset(1: list<string> playerStats, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method retrieves the user statistics for the given category. */
	string PlayerStatistics_ReadUserStatsForCategory(
		/** The user statistics category */
		1: string category, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Reset all of the statistics for this user back to their initial value. */
	string PlayerStatistics_ResetAllUserStats(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Atomically increment (or decrement) user statistics.
            Any rewards that are triggered from user statistic increments
            will be considered. User statistics are defined through the brainCloud portal.
            Note also that the "xpCapped" property is returned (true/false depending on whether
            the xp cap is turned on and whether the user has hit it). */
	string PlayerStatistics_IncrementUserStats_SSFO(
		/** The JSON encoded data to be sent to the server as follows:
            {
              stat1: 10,
              stat2: -5.5,
            }
            would increment stat1 by 10 and decrement stat2 by 5.5.
            For the full statistics grammer see the api.braincloudservers.com site.
            There are many more complex operations supported such as:
            {
              stat1:INC_TO_LIMIT#9#30
            }
            which increments stat1 by 9 up to a limit of 30. */
		1: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Atomically increment (or decrement) user statistics.
             Any rewards that are triggered from user statistic increments
             will be considered. User statistics are defined through the brainCloud portal.
             Note also that the "xpCapped" property is returned (true/false depending on whether
             the xp cap is turned on and whether the user has hit it). */
	string PlayerStatistics_IncrementUserStats_DSFO(
		/** Stats name and their increments:
             {
              {"stat1", 10},
              {"stat1", -5}
             }
            
             would increment stat1 by 10 and decrement stat2 by 5.
             For the full statistics grammer see the api.braincloudservers.com site.
             There are many more complex operations supported such as:
             {
               stat1:INC_TO_LIMIT#9#30
             }
             which increments stat1 by 9 up to a limit of 30. */
		1: map<string, BrainCloudServiceSDKDataTypes.JSON> dictData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Apply statistics grammar to a partial set of statistics. */
	string PlayerStatistics_ProcessStatistics(
		/** Example data to be passed to method:
            {
                "DEAD_CATS": "RESET",
                "LIVES_LEFT": "SET#9",
                "MICE_KILLED": "INC#2",
                "DOG_SCARE_BONUS_POINTS": "INC#10",
                "TREES_CLIMBED": 1
            } */
		1: map<string, BrainCloudServiceSDKDataTypes.JSON> statisticsData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns JSON representing the next experience level for the user. */
	string PlayerStatistics_GetNextExperienceLevel(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Increments the user's experience. If the user goes up a level,
            the new level details will be returned along with a list of rewards. */
	string PlayerStatistics_IncrementExperiencePoints(
		/** The amount to increase the user's experience by */
		1: i32 xpValue, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Sets the user's experience to an absolute value. Note that this
            is simply a set and will not reward the user if their level changes
            as a result. */
	string PlayerStatistics_SetExperiencePoints(
		/** The amount to set the the player's experience to */
		1: i32 xpValue, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Trigger an event server side that will increase the user statistics.
             This may cause one or more awards to be sent back to the user -
             could be achievements, experience, etc. Achievements will be sent by this
             client library to the appropriate awards service (Apple Game Center, etc).
            
             This mechanism supercedes the PlayerStatisticsService API methods, since
             PlayerStatisticsService API method only update the raw statistics without
             triggering the rewards. */
	string PlayerStatisticsEvent_TriggerStatsEvent(1: string eventName, 2: i32 eventMultiplier, 
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** See documentation for TriggerStatsEvent for more
            documentation. */
	string PlayerStatisticsEvent_TriggerStatsEvents(
		/** jsonData
              [
                {
                  "eventName": "event1",
                  "eventMultiplier": 1
                },
                {
                  "eventName": "event2",
                  "eventMultiplier": 1
                }
              ] */
		1: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Gets the player's currency for the given currency type
            or all currency types if null passed in. */
	string Product_GetCurrency(
		/** The currency type to retrieve or null
            if all currency types are being requested. */
		1: string currencyType, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method gets the active sales inventory for the passed-in
            currency type. */
	string Product_GetSalesInventory(
		/** The store platform. Valid stores are:
            - itunes
            - facebook
            - appworld
            - steam
            - windows
            - windowsPhone
            - googlePlay */
		1: string platform, 
		
		/** The currency to retrieve the sales
            inventory for. This is only used for Steam and Facebook stores. */
		2: string userCurrency, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Method gets the active sales inventory for the passed-in
            currency type and category. */
	string Product_GetSalesInventoryByCategory(
		/** The store platform. Valid stores are:
            - itunes
            - facebook
            - appworld
            - steam
            - windows
            - windowsPhone
            - googlePlay */
		1: string platform, 
		
		/** The currency to retrieve the sales
            inventory for. This is only used for Steam and Facebook stores. */
		2: string userCurrency, 
		
		/** The product category */
		3: string category, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Verify Microsoft Receipt. On success, the player will be awarded the 
            associated currencies. */
	string Product_VerifyMicrosoftReceipt(
		/** Receipt XML */
		1: string receipt, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns the eligible promotions for the player. */
	string Product_GetEligiblePromotions(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Verify ITunes Receipt. On success, the player will be awarded the 
            associated currencies. */
	string Product_VerifyItunesReceipt(
		/** Base64 encoded receipt data */
		1: string base64EncReceiptData, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Checks supplied text for profanity. */
	string Profanity_ProfanityCheck(
		/** The text to check */
		1: string text, 
		
		/** Optional comma delimited list of two character language codes */
		2: string languages, 
		
		/** Optional processing of email addresses */
		3: bool flagEmail, 
		
		/** Optional processing of phone numbers */
		4: bool flagPhone, 
		
		/** Optional processing of urls */
		5: bool flagUrls, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Replaces the characters of profanity text with a passed character(s). */
	string Profanity_ProfanityReplaceText(
		/** The text to check */
		1: string text, 
		
		/** The text to replace individual characters of profanity text with */
		2: string replaceSymbol, 
		
		/** Optional comma delimited list of two character language codes */
		3: string languages, 
		
		/** Optional processing of email addresses */
		4: bool flagEmail, 
		
		/** Optional processing of phone numbers */
		5: bool flagPhone, 
		
		/** Optional processing of urls */
		6: bool flagUrls, 
		
		/** @BrainCloud_clientIndex_desc */
		7: i32 clientIndex
	),

	/** Checks supplied text for profanity and returns a list of bad wors. */
	string Profanity_ProfanityIdentifyBadWords(
		/** The text to check */
		1: string text, 
		
		/** Optional comma delimited list of two character language codes */
		2: string languages, 
		
		/** Optional processing of email addresses */
		3: bool flagEmail, 
		
		/** Optional processing of phone numbers */
		4: bool flagPhone, 
		
		/** Optional processing of urls */
		5: bool flagUrls, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Deregisters all device tokens currently registered to the user. */
	string PushNotification_DeregisterAllPushNotificationDeviceTokens(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Deregisters the given device token from the server to disable this device
            from receiving push notifications. */
	string PushNotification_DeregisterPushNotificationDeviceToken(
		/** The device platform being registered. */
		1: string platform, 
		
		/** The platform-dependant device token needed for push notifications. */
		2: string token, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Registers the given device token with the server to enable this device
            to receive push notifications. */
	string PushNotification_RegisterPushNotificationDeviceToken(1: string platform, 
		/** The platform-dependant device token needed for push notifications. */
		2: string token, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Sends a simple push notification based on the passed in message.
            NOTE: It is possible to send a push notification to oneself. */
	string PushNotification_SendSimplePushNotification(
		/** The braincloud profileId of the user to receive the notification */
		1: string toProfileId, 
		
		/** Text of the push notification */
		2: string message, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Sends a notification to a user based on a brainCloud portal configured notification template.
            NOTE: It is possible to send a push notification to oneself. */
	string PushNotification_SendRichPushNotification(
		/** The braincloud profileId of the user to receive the notification */
		1: string toProfileId, 
		
		/** Id of the notification template */
		2: i32 notificationTemplateId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Sends a notification to a user based on a brainCloud portal configured notification template.
            Includes JSON defining the substitution params to use with the template.
            See the Portal documentation for more info.
            NOTE: It is possible to send a push notification to oneself. */
	string PushNotification_SendRichPushNotificationWithParams(
		/** The braincloud profileId of the user to receive the notification */
		1: string toProfileId, 
		
		/** Id of the notification template */
		2: i32 notificationTemplateId, 
		
		/** JSON defining the substitution params to use with the template */
		3: string substitutionJson, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Sends a notification to a "group" of user based on a brainCloud portal configured notification template.
            Includes JSON defining the substitution params to use with the template.
            See the Portal documentation for more info. */
	string PushNotification_SendTemplatedPushNotificationToGroup(
		/** Target group */
		1: string groupId, 
		
		/** Id of the notification template */
		2: i32 notificationTemplateId, 
		
		/** JSON defining the substitution params to use with the template */
		3: string substitutionsJson, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Sends a notification to a "group" of user based on a brainCloud portal configured notification template.
            Includes JSON defining the substitution params to use with the template.
            See the Portal documentation for more info. */
	string PushNotification_SendNormalizedPushNotificationToGroup(
		/** Target group */
		1: string groupId, 
		
		/** Body and title of alert */
		2: string alertContentJson, 
		
		/** Optional custom data */
		3: string customDataJson, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Schedules raw notifications based on user local time. */
	string PushNotification_ScheduleRawPushNotificationUTC(
		/** The profileId of the user to receive the notification */
		1: string profileId, 
		
		/** Valid Fcm data content */
		2: string fcmContent, 
		
		/** Valid ios data content */
		3: string iosContent, 
		
		/** Facebook template string */
		4: string facebookContent, 
		
		/** Start time of sending the push notification */
		5: i32 startTime, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Schedules raw notifications based on user local time. */
	string PushNotification_ScheduleRawPushNotificationMinutes(
		/** The profileId of the user to receive the notification */
		1: string profileId, 
		
		/** Valid Fcm data content */
		2: string fcmContent, 
		
		/** Valid ios data content */
		3: string iosContent, 
		
		/** Facebook template string */
		4: string facebookContent, 
		
		/** Minutes from now to send the push notification */
		5: i32 minutesFromNow, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Sends a raw push notification to a target user. */
	string PushNotification_SendRawPushNotification(
		/** The profileId of the user to receive the notification */
		1: string toProfileId, 
		
		/** Valid Fcm data content */
		2: string fcmContent, 
		
		/** Valid ios data content */
		3: string iosContent, 
		
		/** Facebook template string */
		4: string facebookContent, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Sends a raw push notification to a target list of users. */
	string PushNotification_SendRawPushNotificationBatch(
		/** Collection of profile IDs to send the notification to */
		1: list<string> profileIds, 
		
		/** Valid Fcm data content */
		2: string fcmContent, 
		
		/** Valid ios data content */
		3: string iosContent, 
		
		/** Facebook template string */
		4: string facebookContent, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Sends a raw push notification to a target group. */
	string PushNotification_SendRawPushNotificationToGroup(
		/** Target group */
		1: string groupId, 
		
		/** Valid Fcm data content */
		2: string fcmContent, 
		
		/** Valid ios data content */
		3: string iosContent, 
		
		/** Facebook template string */
		4: string facebookContent, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Schedules a normalized push notification to a user */
	string PushNotification_ScheduleNormalizedPushNotificationUTC(
		/** The profileId of the user to receive the notification */
		1: string profileId, 
		
		/** Body and title of alert */
		2: string alertContentJson, 
		
		/** Optional custom data */
		3: string customDataJson, 
		
		/** Start time of sending the push notification */
		4: i32 startTime, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Schedules a normalized push notification to a user */
	string PushNotification_ScheduleNormalizedPushNotificationMinutes(
		/** The profileId of the user to receive the notification */
		1: string profileId, 
		
		/** Body and title of alert */
		2: string alertContentJson, 
		
		/** Optional custom data */
		3: string customDataJson, 
		
		/** Minutes from now to send the push notification */
		4: i32 minutesFromNow, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Schedules a rich push notification to a user */
	string PushNotification_ScheduleRichPushNotificationUTC(
		/** The profileId of the user to receive the notification */
		1: string profileId, 
		
		/** Body and title of alert */
		2: i32 notificationTemplateId, 
		
		/** Optional custom data */
		3: string substitutionsJson, 
		
		/** Start time of sending the push notification */
		4: i32 startTime, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Schedules a rich push notification to a user */
	string PushNotification_ScheduleRichPushNotificationMinutes(
		/** The profileId of the user to receive the notification */
		1: string profileId, 
		
		/** Body and title of alert */
		2: i32 notificationTemplateId, 
		
		/** Optional custom data */
		3: string substitutionsJson, 
		
		/** Minutes from now to send the push notification */
		4: i32 minutesFromNow, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Sends a notification to a user consisting of alert content and custom data. */
	string PushNotification_SendNormalizedPushNotification(
		/** The profileId of the user to receive the notification */
		1: string toProfileId, 
		
		/** Body and title of alert */
		2: string alertContentJson, 
		
		/** Optional custom data */
		3: string customDataJson, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Sends a notification to multiple users consisting of alert content and custom data. */
	string PushNotification_SendNormalizedPushNotificationBatch(
		/** Collection of profile IDs to send the notification to */
		1: list<string> profileIds, 
		
		/** Body and title of alert */
		2: string alertContentJson, 
		
		/** Optional custom data */
		3: string customDataJson, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Executes a script on the server. */
	string Script_RunScript(
		/** The name of the script to be run */
		1: string scriptName, 
		
		/** Data to be sent to the script in json format */
		2: string jsonScriptData, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Allows cloud script executions to be scheduled */
	string Script_ScheduleRunScriptUTC(
		/** Name of script */
		1: string scriptName, 
		
		/** JSON bundle to pass to script */
		2: string jsonScriptData, 
		
		/** The start date as a DateTime object */
		3: BrainCloudServiceSDKDataTypes.date startDateInUTC, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Allows cloud script executions to be scheduled */
	string Script_ScheduleRunScriptMinutes(
		/** Name of script */
		1: string scriptName, 
		
		/** JSON bundle to pass to script */
		2: string jsonScriptData, 
		
		/** Number of minutes from now to run script */
		3: i64 minutesFromNow, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Run a cloud script in a parent app */
	string Script_RunParentScript(
		/** Name of script */
		1: string scriptName, 
		
		/** JSON bundle to pass to script */
		2: string jsonScriptData, 
		
		/** The level name of the parent to run the script from */
		3: string parentLevel, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Cancels a scheduled cloud code script */
	string Script_CancelScheduledScript(
		/** ID of script job to cancel */
		1: string jobId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Runs a script from the context of a peer */
	string Script_RunPeerScript(
		/** The name of the script to run */
		1: string scriptName, 
		
		/** JSON data to pass into the script */
		2: string jsonScriptData, 
		
		/** Identifies the peer */
		3: string peer, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Runs a script asynchronously from the context of a peer
            This operation does not wait for the script to complete before returning */
	string Script_RunPeerScriptAsynch(
		/** The name of the script to run */
		1: string scriptName, 
		
		/** JSON data to pass into the script */
		2: string jsonScriptData, 
		
		/** Identifies the peer */
		3: string peer, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method returns the social leaderboard. A player's social leaderboard is
             comprised of players who are recognized as being your friend.
             For now, this applies solely to Facebook connected players who are
             friends with the logged in player (who also must be Facebook connected).
             In the future this will expand to other identification means (such as
             Game Centre, Google circles etc).
            
             Leaderboards entries contain the player's score and optionally, some user-defined
             data associated with the score. The currently logged in player will also
             be returned in the social leaderboard.
            
             Note: If no friends have played the game, the bestScore, createdAt, updatedAt
             will contain NULL. */
	string SocialLeaderboard_GetSocialLeaderboard(
		/** The id of the leaderboard to retrieve */
		1: string leaderboardId, 
		
		/** If true, the currently logged in player's name will be replaced
             by the string "You". */
		2: bool replaceName, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Reads multiple social leaderboards. */
	string SocialLeaderboard_GetMultiSocialLeaderboard(
		/** Array of leaderboard id strings */
		1: list<string> leaderboardIds, 
		
		/** Maximum count of entries to return for each leaderboard. */
		2: i32 leaderboardResultCount, 
		
		/** If true, the currently logged in player's name will be replaced
            by the string "You". */
		3: bool replaceName, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Method returns a page of global leaderboard results.
            
             Leaderboards entries contain the player's score and optionally, some user-defined
             data associated with the score.
            
             Note: This method allows the client to retrieve pages from within the global leaderboard list */
	string SocialLeaderboard_GetGlobalLeaderboardPage(
		/** The id of the leaderboard to retrieve. */
		1: string leaderboardId, 
		
		/** Sort key Sort order of page. */
		2: BrainCloudServiceSDKDataTypes.SortOrder sort, 
		
		/** The index at which to start the page. */
		3: i32 startIndex, 
		
		/** The index at which to end the page. */
		4: i32 endIndex, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Method returns a page of global leaderboard results. By using a non-current version id, 
            the user can retrieve a historical leaderboard. See GetGlobalLeaderboardVersions method
            to retrieve the version id. */
	string SocialLeaderboard_GetGlobalLeaderboardPageByVersion(
		/** The id of the leaderboard to retrieve. */
		1: string leaderboardId, 
		
		/** Sort key Sort order of page. */
		2: BrainCloudServiceSDKDataTypes.SortOrder sort, 
		
		/** The index at which to start the page. */
		3: i32 startIndex, 
		
		/** The index at which to end the page. */
		4: i32 endIndex, 
		
		/** The historical version to retrieve. */
		5: i32 versionId, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Method returns a view of global leaderboard results that centers on the current player.
            
             Leaderboards entries contain the player's score and optionally, some user-defined
             data associated with the score. */
	string SocialLeaderboard_GetGlobalLeaderboardView(
		/** The id of the leaderboard to retrieve. */
		1: string leaderboardId, 
		
		/** Sort key Sort order of page. */
		2: BrainCloudServiceSDKDataTypes.SortOrder sort, 
		
		/** The count of number of players before the current player to include. */
		3: i32 beforeCount, 
		
		/** The count of number of players after the current player to include. */
		4: i32 afterCount, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Method returns a view of global leaderboard results that centers on the current player.
            By using a non-current version id, the user can retrieve a historical leaderboard.
            See GetGlobalLeaderboardVersions method to retrieve the version id. */
	string SocialLeaderboard_GetGlobalLeaderboardViewByVersion(
		/** The id of the leaderboard to retrieve. */
		1: string leaderboardId, 
		
		/** Sort key Sort order of page. */
		2: BrainCloudServiceSDKDataTypes.SortOrder sort, 
		
		/** The count of number of players before the current player to include. */
		3: i32 beforeCount, 
		
		/** The count of number of players after the current player to include. */
		4: i32 afterCount, 
		
		/** The historial version to retrieve. Use -1 for current leaderboard. */
		5: i32 versionId, 
		
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** Gets the global leaderboard versions. */
	string SocialLeaderboard_GetGlobalLeaderboardVersions(
		/** In_leaderboard identifier. */
		1: string leaderboardId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Retrieve the social leaderboard for a group. */
	string SocialLeaderboard_GetGroupSocialLeaderboard(
		/** The leaderboard to read */
		1: string leaderboardId, 
		
		/** The group ID */
		2: string groupId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Post the players score to the given social leaderboard.
             You can optionally send a user-defined json string of data
             with the posted score. This string could include information
             relevant to the posted score.
            
             Note that the behaviour of posting a score can be modified in
             the brainCloud portal. By default, the server will only keep
             the player's best score. */
	string SocialLeaderboard_PostScoreToLeaderboard(
		/** The leaderboard to post to */
		1: string leaderboardId, 
		
		/** The score to post */
		2: i64 score, 
		3: string jsonData, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Removes a player's score from the leaderboard */
	string SocialLeaderboard_RemovePlayerScore(
		/** The ID of the leaderboard */
		1: string leaderboardId, 
		
		/** The version of the leaderboard */
		2: i32 versionId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Post the players score to the given social leaderboard.
            Pass leaderboard config data to dynamically create if necessary.
            You can optionally send a user-defined json string of data
            with the posted score. This string could include information
            relevant to the posted score. */
	string SocialLeaderboard_PostScoreToDynamicLeaderboard(
		/** The leaderboard to post to */
		1: string leaderboardId, 
		
		/** The score to post */
		2: i64 score, 
		3: string jsonData, 
		
		/** leaderboard type */
		4: BrainCloudServiceSDKDataTypes.SocialLeaderboardType leaderboardType, 
		
		/** Type of rotation */
		5: BrainCloudServiceSDKDataTypes.RotationType rotationType, 
		
		/** Date to reset the leaderboard UTC */
		6: BrainCloudServiceSDKDataTypes.date rotationReset, 
		
		/** How many rotations to keep */
		7: i32 retainedCount, 
		
		/** @BrainCloud_clientIndex_desc */
		8: i32 clientIndex
	),

	/** Post the players score to the given social leaderboard with a rotation type of DAYS.
            Pass leaderboard config data to dynamically create if necessary.
            You can optionally send a user-defined json string of data
            with the posted score. This string could include information
            relevant to the posted score. */
	string SocialLeaderboard_PostScoreToDynamicLeaderboardDays(
		/** The leaderboard to post to */
		1: string leaderboardId, 
		
		/** The score to post */
		2: i64 score, 
		3: string jsonData, 
		
		/** leaderboard type */
		4: BrainCloudServiceSDKDataTypes.SocialLeaderboardType leaderboardType, 
		
		/** Date to reset the leaderboard UTC */
		5: BrainCloudServiceSDKDataTypes.date rotationReset, 
		
		/** How many rotations to keep */
		6: i32 retainedCount, 
		
		/** How many days between each rotation */
		7: i32 numDaysToRotate, 
		
		/** @BrainCloud_clientIndex_desc */
		8: i32 clientIndex
	),

	/** Retrieve the social leaderboard for a list of players. */
	string SocialLeaderboard_GetPlayersSocialLeaderboard(
		/** The ID of the leaderboard */
		1: string leaderboardId, 
		
		/** The IDs of the players */
		2: list<string> profileIds, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Retrieve a list of all leaderboards */
	string SocialLeaderboard_ListLeaderboards(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Gets the number of entries in a global leaderboard */
	string SocialLeaderboard_GetGlobalLeaderboardEntryCount(
		/** The ID of the leaderboard */
		1: string leaderboardId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Gets the number of entries in a global leaderboard */
	string SocialLeaderboard_GetGlobalLeaderboardEntryCountByVersion(
		/** The ID of the leaderboard */
		1: string leaderboardId, 
		
		/** The version of the leaderboard */
		2: i32 versionId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Gets a player's score from a leaderboard */
	string SocialLeaderboard_GetPlayerScore(
		/** The ID of the leaderboard */
		1: string leaderboardId, 
		
		/** The version of the leaderboard. Use -1 for current. */
		2: i32 versionId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Gets a player's score from multiple leaderboards */
	string SocialLeaderboard_GetPlayerScoresFromLeaderboards(
		/** A collection of leaderboardIds to retrieve scores from */
		1: list<string> leaderboardIds, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Method returns the server time in UTC. This is in UNIX millis time format.
            For instance 1396378241893 represents 2014-04-01 2:50:41.893 in GMT-4. */
	string Time_ReadServerTime(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Processes any outstanding rewards for the given player */
	string Tournament_ClaimTournamentReward(
		/** The leaderboard for the tournament */
		1: string leaderboardId, 
		
		/** Version of the tournament to claim rewards for.
            Use -1 for the latest version. */
		2: i32 versionId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Get tournament status associated with a leaderboard */
	string Tournament_GetTournamentStatus(
		/** The leaderboard for the tournament */
		1: string leaderboardId, 
		
		/** Version of the tournament. Use -1 for the latest version. */
		2: i32 versionId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Join the specified tournament.
            Any entry fees will be automatically collected. */
	string Tournament_JoinTournament(
		/** The leaderboard for the tournament */
		1: string leaderboardId, 
		
		/** Tournament to join */
		2: string tournamentCode, 
		
		/** The initial score for players first joining a tournament
            Usually 0, unless leaderboard is LOW_VALUE */
		3: i64 initialScore, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Removes player's score from tournament leaderboard */
	string Tournament_LeaveTournament(
		/** The leaderboard for the tournament */
		1: string leaderboardId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Post the users score to the leaderboard */
	string Tournament_PostTournamentScore(
		/** The leaderboard for the tournament */
		1: string leaderboardId, 
		
		/** The score to post */
		2: i64 score, 
		
		/** Optional data attached to the leaderboard entry */
		3: string jsonData, 
		
		/** Time the user started the match resulting in the score
            being posted. */
		4: BrainCloudServiceSDKDataTypes.date roundStartedTime, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Post the users score to the leaderboard and returns the results */
	string Tournament_PostTournamentScoreWithResults(
		/** The leaderboard for the tournament */
		1: string leaderboardId, 
		
		/** The score to post */
		2: i64 score, 
		
		/** Optional data attached to the leaderboard entry */
		3: string jsonData, 
		
		/** Time the user started the match resulting in the score
            being posted. */
		4: BrainCloudServiceSDKDataTypes.date roundStartedTime, 
		
		/** Sort key Sort order of page. */
		5: BrainCloudServiceSDKDataTypes.SortOrder sort, 
		
		/** The count of number of players before the current player to include. */
		6: i32 beforeCount, 
		
		/** The count of number of players after the current player to include. */
		7: i32 afterCount, 
		
		/** The initial score for players first joining a tournament
            Usually 0, unless leaderboard is LOW_VALUE */
		8: i64 initialScore, 
		
		/** @BrainCloud_clientIndex_desc */
		9: i32 clientIndex
	),

	/** Returns the user's expected reward based on the current scores */
	string Tournament_ViewCurrentReward(
		/** The leaderboard for the tournament */
		1: string leaderboardId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns the user's reward from a finished tournament */
	string Tournament_ViewReward(
		/** The leaderboard for the tournament */
		1: string leaderboardId, 
		
		/** Version of the tournament. Use -1 for the latest version. */
		2: i32 versionId, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Create a new lobby. */
	string Lobby_CreateLobby(
		/** The type of lobby to create, either "PLAYER" or "RANKED". */
		1: BrainCloudServiceSDKDataTypes.LobbyType lobbyType, 
		
		/** The maximum number of players that can join the lobby. */
		2: i32 maxSlots, 
		
		/** Whether or not the lobby is open by default. */
		3: bool isOpen, 
		
		/** A json string containing any custom attributes to attach to the lobby. */
		4: string jsonAttributes, 
		
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	/** Open a lobby so players can join. */
	string Lobby_OpenLobby(
		/** The ID of the lobby to open. */
		1: string lobbyId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Close a lobby so players can't join. */
	string Lobby_CloseLobby(
		/** The ID of the lobby to close. */
		1: string lobbyId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Find lobbies the player can join. */
	string Lobby_FindLobbies(1: i32 freeSlots, 2: i32 maxResults, 
		/** A json string containing any custom attributes to search for. */
		3: string jsonAttributes, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Find lobbies with the player's friends in them. */
	string Lobby_FindFriendsLobbies(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Join a lobby. */
	string Lobby_JoinLobby(
		/** The ID of the lobby to join. */
		1: string lobbyId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Leave a lobby. */
	string Lobby_LeaveLobby(
		/** The ID of the lobby to leave. */
		1: string lobbyId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Destroy a lobby. */
	string Lobby_DestroyLobby(
		/** The ID of the lobby to destroy. */
		1: string lobbyId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Start a lobby game. */
	string Lobby_StartGame(
		/** The ID of the lobby to destroy. */
		1: string lobbyId, 
		
		/** A string that can be used to connect to a real game (e.g an IP Address/port). */
		2: string connectionString, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Get a list of lobbies the player is a member of. */
	string Lobby_GetMyLobbies(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	string Party_AcceptPartyInvitation(1: string partyId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Party_GetPartyInfo(1: string partyId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Party_JoinParty(1: string partyId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Party_LeaveParty(1: string partyId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Party_RejectPartyInvitation(1: string partyId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Party_SendPartyInvitation(1: string playerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Party_ListPartyInvitations(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	string Party_GetFriendsParties(1: i32 maxResults, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Party_GetMyParty(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	string Patch_GetGameManifest(1: string gameId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Add a product to the player's shopping cart. */
	string Shopping_AddToCart_SISFO(
		/** The ID of the product to add to the cart (usually a Game ID). */
		1: string productId, 
		
		/** The amount of this product to add. */
		2: i32 quantity, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Add a product to the player's shopping cart. */
	string Shopping_AddToCart_ISFO(1: list<string> productIds, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Empty the player's shopping cart. */
	string Shopping_EmptyCart(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Retrieve the player's current shopping cart. */
	string Shopping_GetCart(1: bool includeDetails, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Remove an item from the player's shopping cart. */
	string Shopping_RemoveFromCart(
		/** The ID of the product to remove. */
		1: string productId, 
		2: i32 quantity, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Add an item to the player's wishlist. */
	string Shopping_AddToWishlist(
		/** The ID of the product to add. */
		1: string productId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Remove all items from the player's wishlist. */
	string Shopping_EmptyWishlist(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** Returns the current player's wishlist. */
	string Shopping_GetMyWishlist(1: bool includeDetails, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Returns the specified player's wishlist. */
	string Shopping_GetWishlist(
		/** The ID of the player to get the wishlist for. */
		1: string playerId, 
		2: bool includeDetails, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Remove an item from the player's wishlist. */
	string Shopping_RemoveFromWishlist_SSFO(
		/** The ID of the product to remove. */
		1: string productId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Remove multiple items from the player's wishlist. */
	string Shopping_RemoveFromWishlist_ISFO(1: list<string> productIds, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Get a list of user reviews for a product. */
	string Shopping_GetUserReviews(
		/** The ID of the product to get reviews for. */
		1: string productId, 
		
		/** The 1-indexed page of the review list to fetch. */
		2: i32 page, 
		
		/** The size of each page. */
		3: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Submit a user review of a product. */
	string Shopping_SubmitUserReview(
		/** The ID of the product being reviewed. */
		1: string productId, 
		
		/** The text of the review. */
		2: string reviewText, 
		
		/** The rating given to the product. */
		3: i32 rating, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** Return a list of recently created products. */
	string Shopping_GetRecentlyCreatedProducts(
		/** The 1-indexed page of the review list to fetch. */
		1: i32 page, 
		
		/** The size of each page. */
		2: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Return a list of recently updated products. */
	string Shopping_GetRecentlyUpdatedProducts(
		/** The 1-indexed page of the review list to fetch. */
		1: i32 page, 
		
		/** The size of each page. */
		2: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Return a list of featured products. */
	string Shopping_GetFeaturedProducts(
		/** If true will also return full descriptions of games in the list. */
		1: bool includeDetails, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** Return a list of the mos tpopular products. */
	string Shopping_GetPopularProducts(
		/** The 1-indexed page of the review list to fetch. */
		1: i32 page, 
		
		/** The size of each page. */
		2: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** Return a list of special offers. */
	string Shopping_GetSpecialOffers(
		/** The 1-indexed page of the review list to fetch. */
		1: i32 page, 
		
		/** The size of each page. */
		2: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** @2304250631 */
	string Shopping_GetMyLibrary(1: bool includeDetails, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** @1350446922 */
	string Shopping_GetPopularTags(
		/** @1144882702 */
		1: i32 page, 
		
		/** The size of each page. */
		2: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** @3387279661 */
	string Shopping_GetProductsByTag(1: string tag, 
		/** @1144882702 */
		2: i32 page, 
		
		/** The size of each page. */
		3: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** @2681224790 */
	string Shopping_GetProductsByTags(1: list<string> tags, 
		/** @1144882702 */
		2: i32 page, 
		
		/** The size of each page. */
		3: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** @2681224790 */
	string Shopping_GetRecommendedProducts(1: i32 count, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** @919332756 */
	string Shopping_GetMyOrders(
		/** @1616325051 */
		1: bool includeCompleted, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** @2681224790 */
	string Shopping_GetProduct(1: string productId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** @1777617418 */
	string Shopping_GetUserTags(
		/** @3110420339 */
		1: string productId, 
		
		/** @1144882702 */
		2: i32 page, 
		
		/** The size of each page. */
		3: i32 pageSize, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** @274383141 */
	string Shopping_GetMyUserTags(
		/** @3110420339 */
		1: string productId, 
		
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	/** @3717774610 */
	string Shopping_SubmitUserTag(
		/** @3110420339 */
		1: string productId, 
		
		/** @605655784 */
		2: string tag, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** @2944656417 */
	string Shopping_RemoveUserTag(
		/** @3110420339 */
		1: string productId, 
		
		/** @3017888560 */
		2: string tag, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	string SocialFeed_ShareVideo(1: i32 timestamp, 2: string resource, 3: list<string> tagged, 4: list<string> show, 5: list<string> block, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string SocialFeed_ShareScreenshot(1: i32 timestamp, 2: string resource, 3: list<string> tagged, 4: list<string> show, 5: list<string> block, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string SocialFeed_ShareAchievement(1: i32 timestamp, 2: string resource, 3: list<string> tagged, 4: list<string> show, 5: list<string> block, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string SocialFeed_ShareApp(1: i32 timestamp, 2: string resource, 3: list<string> tagged, 4: list<string> show, 5: list<string> block, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string SocialFeed_ShareChannel(1: i32 timestamp, 2: string resource, 3: list<string> tagged, 4: list<string> show, 5: list<string> block, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string SocialFeed_ShareLink(1: i32 timestamp, 2: string resource, 3: list<string> tagged, 4: list<string> show, 5: list<string> block, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string SocialFeed_ShareGameGuide(1: i32 timestamp, 2: string resource, 3: list<string> tagged, 4: list<string> show, 5: list<string> block, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string SocialFeed_ReadSocialFeed(1: i32 skip, 2: i32 limit, 
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	string SocialFeed_ReadFilteredSocialFeed(1: i32 skip, 2: i32 limit, 3: list<string> playerIds, 
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	string SocialFeed_ReadFriendsSocialFeed(1: i32 skip, 2: i32 limit, 
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	string SocialFeed_PostComment(1: i32 timestamp, 2: string parentId, 3: string content, 
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	string SocialFeed_PostCommentReply(1: i32 timestamp, 2: string parentId, 3: string content, 
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	string SocialFeed_ReadComments(1: i32 skip, 2: i32 limit, 3: string parentId, 
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	string SocialFeed_ReadCommentReplies(1: i32 skip, 2: i32 limit, 3: string parentId, 
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	string SocialFeed_LikeComment(1: string socialFeedId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_LikeActivity(1: string socialFeedId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_UnlikeComment(1: string socialFeedId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_UnlikeActivity(1: string socialFeedId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_SetFeedVisibility(1: string visibility, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_BlockPlayer(1: string playerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_HidePlayer(1: string playerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_UnblockPlayer(1: string playerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_UnhidePlayer(1: string playerId, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string SocialFeed_GetActivity(1: string socialFeedId, 2: i32 depth, 3: i32 skip, 4: i32 limit, 
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	string SocialFeed_GetComment(1: string socialFeedId, 2: i32 depth, 3: i32 skip, 4: i32 limit, 
		/** @BrainCloud_clientIndex_desc */
		5: i32 clientIndex
	),

	string Telemetry_StartTelemetrySession(1: i32 timestamp, 
		/** @BrainCloud_clientIndex_desc */
		2: i32 clientIndex
	),

	string Telemetry_EndTelemetrySession(1: string telemetrySessionId, 2: i32 timestamp, 
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	string Telemetry_LogTelemetryEvent(1: string telemetrySessionId, 2: i32 timestamp, 3: string eventType, 4: string participantId, 5: map<string, BrainCloudServiceSDKDataTypes.JSON> customData, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string Telemetry_StartTelemetryEvent(1: string telemetrySessionId, 2: i32 timestamp, 3: string eventType, 4: string participantId, 5: map<string, BrainCloudServiceSDKDataTypes.JSON> customData, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	string Telemetry_EndTelemetryEvent(1: string telemetrySessionId, 2: i32 timestamp, 3: string eventType, 4: string participantId, 5: map<string, BrainCloudServiceSDKDataTypes.JSON> customData, 
		/** @BrainCloud_clientIndex_desc */
		6: i32 clientIndex
	),

	/** @Authentication_GetWeChatQRPageURL_desc */
	string Authentication_GetWeChatQRPageURL(
		/** @BrainCloud_clientIndex_desc */
		1: i32 clientIndex
	),

	/** @BrainCloud_DownloadFile_desc */
	string File_DownloadFile(
		/** @BrainCloudFile_cloudPath */
		1: string cloudPath, 
		
		/** @BrainCloudFile_cloudFilename */
		2: string cloudFilename, 
		
		/** @BrainCloudFile_replaceIfExists */
		3: bool replaceIfExists, 
		
		/** @BrainCloud_clientIndex_desc */
		4: i32 clientIndex
	),

	/** @BrainCloud_GetDownloadInfo_desc */
	string File_GetDownloadInfo(
		/** @BrainCloudFile_cloudPath */
		1: string cloudPath, 
		
		/** @BrainCloudFile_cloudFileName */
		2: string cloudFilename, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),

	/** @BrainCloud_CancelDownload_desc */
	string File_CancelDownload(
		/** @BrainCloudFile_cloudPath */
		1: string cloudPath, 
		
		/** @BrainCloudFile_cloudFileName */
		2: string cloudFilename, 
		
		/** @BrainCloud_clientIndex_desc */
		3: i32 clientIndex
	),
}

