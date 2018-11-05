Contents
========

[General](#general)

+ [Common Parameters](#common-parameters)

    + [Index](#index)

	+ [Callback](#callback)

    + [Player ID(s)](#player-id-s-)

    + [Game Id](#game-id)

+ [Common Structures](#common-structures)

    + [RuyiNet Response](#ruyinet-response)

[Services and Operations](#services-and-operations)

+ [Cloud Service](#cloud-service)

    + [Backup Data](#backup-data)

    + [Restore Data](#restore-data)

+ [Friend Service](#friend-service)

    + [Accept Friend Invitation](#accept-friend-invitation)

    + [Find User By Exact Name](#find-user-by-exact-name)

    + [Find Users By Substring Name](#find-users-by-substring-name)

    + [Get Users Online Status](#get-users-online-status)

    + [Get Summary Data For Player Id](#get-summary-data-for-player-id)

    + [List Friend Invitations Received](#list-friend-invitations-received)

    + [List Friend Invitations Sent](#list-friend-invitations-sent)

    + [List Friends](#list-friends)

    + [Read Friend Entity](#read-friend-entity)

    + [Read Friends' Entities](#read-friends-entities)

    + [Reject Friend Invitation](#reject-friend-invitation)

    + [Remove Friend](#remove-friend)

    + [Send Friend Invitation](#send-friend-invitation)

+ [Gamification Service](#gamification-service)

    + [Award Achievement](#award-achievement)

    + [Award Achievements](#award-achievements)

    + [Read Achieved Achievements](#read-achieved-achievements)

    + [Read Achievements](#read-achievements)

+ [Leaderboard Service](#leaderboard-service)

    + [Get Global Leaderboard Entry Count](#get-global-leaderboard-entry-count)

    + [Get Global Leaderboard Page](#get-global-leaderboard-page)

    + [Get Global Leaderboard Versions](#get-global-leaderboard-versions)

    + [Get Global Leaderboard View](#get-global-leaderboard-view)

    + [Get Group Social Leaderboard](#get-group-social-leaderboard)

    + [Get Player Score](#get-player-score)

    + [Get Player Scores from Leaderboards](#get-player-scores-from-leaderboards)

    + [Get Player's Social Leaderboard](#get-players-social-leaderboard)

    + [Get Social Leaderboard](#get-social-leaderboard)

    + [List All Leaderboards](#list-all-leaderboards)

    + [Post Score to Dynamic Leaderboard](#post-score-to-dynamic-leaderboard)

    + [Post Score to Leaderboard](#post-score-to-leaderboard)

    + [Remove Score](#remove-score)

+ [Lobby Service](#lobby-service)

    + [Close Lobby](#close-lobby)

    + [Create Lobby](#create-lobby)

    + [Destroy Lobby](#destroy-lobby)

    + [Find Friends Lobbies](#find-friends-lobbies)

    + [Find Lobbies](#find-lobbies)

    + [Get My Lobbies](#get-my-lobbies)

    + [Join Lobby](#join-lobby)

    + [Leave Lobby](#leave-lobby)

    + [Open Lobby](#open-lobby)

    + [Start Game](#start-game)

+ [Party Service](#party-service)

    + [Accept Party Invitation](#accept-party-invitation)

    + [Get Friends Parties](#get-friends-parties)

    + [Get My Party](#get-my-party)

    + [Get Party Info](#get-party-info)

    + [Join Party](#join-party)

    + [Leave Party](#leave-party)

    + [List Party Invitations](#list-party-invitations)

    + [Reject Party Invitation](#reject-party-invitation)

    + [Send Party Invitation](#send-party-invitation)

+ [Patch Service](#patch-service)

    + [Get game Manifest](#get-game-manifest)

+ [Profile Service](#profile-service)

    + [Update User Picture](#update-user-picture)

+ [Telemetry Service](#telemetry-service)

    + [End Telemetry Event](#end-telemetry-event)

    + [End Telemetry Session](#end-telemetry-session)

    + [Log Telemetry Event](#log-telemetry-event)

    + [Start Telemetry Event](#start-telemetry-event)

    + [Start Telemetry Session](#start-telemetry-session)

+ [User File Service](#user-file-service)

    + [Cancel Upload](#cancel-upload)

    + [Delete User File](#delete-user-file)

    + [Delete User Files](#delete-user-files)

    + [Get CDN URL](#get-cdn-url)

    + [Get Upload Bytes Transferred](#get-upload-bytes-transferred)

    + [Get Upload Progress](#get-upload-progress)

    + [Get Upload Total Bytes To Transfer](#get-upload-total-bytes-to-transfer)

    + [List User Files](#list-user-files)

    + [Upload File](#upload-file)

+ [Video Service](#video-service)

    + [Delete Video](#delete-video)

    + [Download Video](#download-video)

    + [Get Friends' Videos](#get-friends-videos)

    + [Get Video URL](#get-video-url)

    + [List Videos](#list-videos)

    + [Upload Video](#upload-video)

[Data Structures](#data-structures)

+ [Entity Service](#entity-service)

    + [RuyiNet Entity](#ruyinet-entity)

+ [Friend Service](#friend-service-1)

    + [RuyiNet Friend Invite](#ruyinet-friend-invite)

    + [RuyiNet Friend Online Status](#ruyinet-friend-online-status)

    + [RuyiNet Friend Summary Data](#ruyinet-friend-summary-data)

+ [Gamification Service](#gamification-service-1)

    + [RuyiNet Achievement](#ruyinet-achievement)

+ [Leaderboard Service](#leaderboard-service-1)

    + [RuyiNet Leaderboard Config](#ruyinet-leaderboard-config)

    + [RuyiNet Leaderboard Entry](#ruyinet-leaderboard-entry)

    + [RuyiNet Leaderboard Info](#ruyinet-leaderboard-info)

    + [RuyiNet Leaderboard Page](#ruyinet-leaderboard-page)

    + [RuyiNet Leaderboard Versions](#ruyinet-leaderboard-versions)

    + [RuyiNet Player Score](#ruyinet-player-score)

+ [Lobby Service](#lobby-service-1)

    + [RuyiNet Lobby](#ruyinet-lobby)

+ [Party Service](#party-service-1)

    + [RuyiNet Party](#ruyinet-party)

+ [Patch Service](#patch-service-1)

    + [RuyiNet Game Manifest](#ruyinet-game-manifest)

    + [RuyiNet Game Manifest -- Patch](#ruyinet-game-manifest-patch)

+ [Telemetry Service](#telemetry-service-1)

    + [RuyiNet Telemetry Session](#ruyinet-telemetry-session)

+ [User File Service](#user-file-service-1)

    + [RuyiNet Upload File Response](#ruyinet-upload-file-response)

    + [RuyiNet List User Files Response](#ruyinet-list-user-files-response)

General
=======

Common parameters
-----------------

Most operations will take at least the player's index and return a
response via a callback.

### Index

Many methods take an *index* which is the index of the logged in users
on the console. This will usually be zero unless there are multiple
users logged in.

### Callback

After every request has completed there will be a response. For most
operations this will either tell you the status of the request (whether
it succeeds/fails) or return the data requested from RuyiNet.

### Player ID(s)

This is the ID (or a list of IDs) of a player that an operation is to be
performed on. For example, it can be the ID of someone a player wishes
to send an invitation to.

### Game Id

This is the ID of the game we wish to perform an operation upon.

Common Structures
-----------------

### RuyiNet Response

Tells you the result of a response that returns no data.

#### Definition

    class RuyiNetResponse
    {
        public int status;
        public string message;
    }

#### Properties

  **Status**    
  
  The status of the response. This is based on standard HTTP codes.
  
  **Message**
  
  If there is an error of any kind this property will describe the error.

Services and Operations
=======================

RuyiNet is divided up into several services, each of which focus on a
different aspect of the online services available.

Cloud Service
-------------

This service provides operations for backing up the console data to the
cloud.

### Backup Data

This operation will take all the data stored on the hard drive for all
games and upload it to the RuyiNet Cloud.

#### Prototype

    void BackupData(int index, Action<RuyiNetResponse> callback)

### Restore Data

This will download the latest data from the cloud and overwrite the
current data on the hard drive.

#### Prototype

    void RestoreData(int index, Action<RuyiNetResponse> callback)
    

Friend Service
--------------

This service provides operations for players to manage their friends
lists.

### Accept Friend Invitation

Deletes the friend invitation and adds the players to each other's
friends lists.

#### Prototype

    void AcceptFriendInvitation(int index, string playerId, Action<RuyiNetResponse> callback)

### Find User By Exact Name

Will find a user by the exact name specified.

#### Prototype

    void FindUserByExactName(int index, string name, Action<RuyiNetFriendSummaryData[]> callback)

#### Parameters

  **Name**  
  
  The exact name to search for.

### Find Users By Substring Name

Returns a list of users with the specified substring within their
username.

#### Prototype

    void FindUsersBySubstrName(int index, string substring, int maxResults, Action<RuyiNetFriendSummaryData[]> callback)

#### Parameters

  **Substring**

  The substring to search for.

### Get Users Online Status

Returns the presence status for all the specified players.

#### Prototype

    void GetUsersOnlineStatus(int index, List<string> playerIds, Action<RuyiNetFriendOnlineStatus[]> callback)

### Get Summary Data For Player Id

Returns the summary data (profile) for the specified player.

#### Prototype

    void GetSummaryDataForPlayerId(int index, string playerId, Action<RuyiNetFriendSummaryData> callback)

### List Friend Invitations Received

Returns a list of invitations sent to the player.

#### Prototype

    void ListFriendInvitationsRecieved(int index, Action<RuyiNetFriendInvite[]> callback)

### List Friend Invitations Sent

Returns a list of invitations the player has sent.

#### Prototype

    void ListFriendInvitationsSent(int index, Action<RuyiNetFriendInvite[]> callback)

### List Friends

Returns a list of the player's friends' summary data.

#### Prototype

    void ListFriends(int index, Action<RuyiNetFriendSummaryData[]> callback)

### Read Friend Entity

Returns an entity belonging to the player.

#### Prototype

    void ReadFriendEntity(int index, string entityId, string friendPlayerId, Action<RuyiNetEntity> callback)

#### Parameters

  **Entity ID**

  The ID of the entity to get.

  **Friend Player ID**   
  
  The ID of the player the entity belongs to.

### Read Friends' Entities

Returns all friends' entities of a specific type.

#### Prototype

    void ReadFriendsEntities(int index, string entityType, Action<RuyiNetEntity[]> callback)

#### Parameters

  **Entity Type**   
  
  The custom type of entity to return.
  
### Reject Friend Invitation

Deletes a friend invitation from RuyiNet

#### Prototype

    void RejectFriendInvitation(int index, string playerId, Action<RuyiNetResponse> callback)

### Remove Friend

Removes two players from each other's friends lists (the current player
and the player specified by the operation call).

#### Prototype

    void RemoveFriend(int index, string playerId, Action<RuyiNetResponse> callback)

### Send Friend Invitation

Sends an invitation to another player to join each other's friends
lists.

#### Prototype

    void SendFriendInvitation(int index, string playerId, Action<RuyiNetResponse> callback)

Gamification Service
--------------------

Provides gamification features, such as achievements.

### Award Achievement

Awards an achievement to the player.

#### Prototype

    void AwardAchievement(int index, string achievementId, Action<RuyiNetAchievement> callback)

#### Parameters

  **Achievement ID**

  The ID of the achievement to award to the player.

### Award Achievements

Awards multiple achievements to a player.

#### Prototype

    void AwardAchievements(int index, List\<string\> achievementIds, Action<List<RuyiNetAchievement>> callback)

#### Parameters

  **Achievement IDs**  

  The IDs of the achievements to award to the player.

### Read Achieved Achievements

Returns a list of achievements earned by the player.

#### Prototype

    void ReadAchievedAchievements(int index, bool includeMetaData, Action<List<RuyiNetAchievement>> callback)

#### Parameters

  **Include Meta Data**   
  
  Whether or not to include the meta data. Just returns the achievement IDs if this is false.
  
### Read Achievements

Returns all achievement data for the current game.

#### Prototype

    void ReadAchievements(int index, bool includeMetaData, Action<List<RuyiNetAchievement>> callback)

#### Parameters

  **Include Meta Data**

  Whether or not to include the meta data. Just returns the achievement IDs if this is false.

Leaderboard Service
-------------------

The leaderboard service provides operations to submit scores and
retrieve leaderboard data.

### Get Global LEaderboard Entry Count

Returns the total number of entries in a leaderboard.

#### Prototypes

    void GetGlobalLeaderboardEntryCount(int index, string leaderboardId, Action<int> callback)

    void GetGlobalLeaderboardEntryCount(int index, string leaderboardId, int versionId, Action<int> callback)

#### Parameters

  **Leaderboard ID**   
  
  The ID of the leaderboard to fetch data for.
  
  **Version ID**       
  
  The version of the leaderboard to fetch.

### Get Global LEaderboard Page

Returns paginated data from a leaderboard.

#### Prototypes

    void GetGlobalLeaderboardPage(int index, string leaderboardId, SortOrder sort, int startIndex, int endIndex, Action<RuyiNetLeaderboardPage> callback)

    void GetGlobalLeaderboardPage(int index, string leaderboardId, SortOrder sort, int startIndex, int endIndex, int versionId, Action<RuyiNetLeaderboardPage> callback)

#### Parameters

  **Leaderboard ID**

  The ID of the leaderboard to fetch data for.

  **Version ID**       
  
  The version of the leaderboard to fetch.
  
  **Sort**             
  
  How to sort the leaderboard. Can be HIGH\_TO\_LOW or LOW\_TO\_HIGH, sorted by score.
  
  **Start Index**      
  
  The index of the leaderboard entry to start at (0-indexed).
  
  **End Index**        
  
  The index of the leaderboard entry to finish at.

### Get Global Leaderboard Versions

Get the versions that are available for a leaderboard.

#### Prototype

    void GetGlobalLeaderVersions(int index, string leaderboardId, Action<RuyiNetLeaderboardInfo> callback)

#### Parameters

  **Leaderboard ID**  

  The ID of the leaderboard to fetch data for.

### Get Global Leaderboard View

Returns a leaderboard page centered around the current player.

#### Prototype

    void GetGlobalLeaderboardView(int index, string leaderboardId, SortOrder sort, int beforeCount, int afterCount, Action<RuyiNetLeaderboardPage> callback)

    void GetGlobalLeaderboardView(int index, string leaderboardId, SortOrder sort, int beforeCount, int afterCount, int versionId, Action<RuyiNetLeaderboardPage> callback)

#### Parameters

  **Leaderboard ID** 

  The ID of the leaderboard to fetch data for.
  
  **Version ID** 

  The version of the leaderboard to fetch.
  
  **Sort**             
  
  How to sort the leaderboard. Can be HIGH\_TO\_LOW or LOW\_TO\_HIGH, sorted by score.
  
  **Before Count**   

  The maximum number of entries better than the player's entry to retrieve.
  
  **After Count**  

  The maximum number of entries worse than the player's entry to retrieve.

### Get Group Social Leaderboard

Returns a leaderboard for all players in a specific group.

#### Prototype

    void GetGroupSocialLeaderboard(int index, string leaderboardId, string groupId, Action<RuyiNetLeaderboardPage> callback)

#### Parameters

  **Leaderboard ID** 

  The ID of the leaderboard to fetch data for.
  
  **Group ID**       

  The ID of the group to get the player IDs from.

### Get Player Score

Retrieves the player's current score.

#### Prototype

    void GetPlayerScore(int index, string leaderboardId, Action<RuyiNetPlayerScore> callback)

    void GetPlayerScore(int index, string leaderboardId, int versionId, Action<RuyiNetPlayerScore> callback)

#### Parameters

  **Leaderboard ID** 

  The ID of the leaderboard to fetch data for.

  **Group ID**         
  
  The ID of the group to get the player IDs from.

### Get Player Scores from Leaderboards

Retrieves the player's current scores from multiple leaderboards.

#### Prototype

    void GetPlayerScoresFromLeaderboards(int index, List<string> leaderboardIds, Action<RuyiNetPlayerScore[]> callback)

#### Parameters

  **Leaderboard IDs**   
  
  The IDs of the leaderboards to fetch data for.
  
  
### Get Player's Social Leaderboard

Retrieves leaderboard scores for the specified players.

#### Prototype

    void GetPlayersSocialLeaderboard(int index, string leaderboardId, List<string> playerIds, Action<RuyiNetLeaderboardPage> callback)

#### Parameters

  **Leaderboard ID**   
  
  The ID of the leaderboard to fetch data for.
  
  **Player IDs**  

  The IDs of the players to fetch entries for.

### Get Social Leaderboard

Retrieves a leaderboard containing the player's friends' entries.

#### Prototype

    void GetSocialLeaderboard(int index, string leaderboardId, bool replaceName, Action<RuyiNetLeaderboardPage> callback)

#### Parameters

  **Leaderboard ID** 

  The ID of the leaderboard to fetch data for.
  
  **Replace Name**   

  If true, the player's name will be replaced with 'YOU'.

### List All Leaderboards

Returns a list of leaderboard configurations for the current game.

#### Prototype

    void ListAllLeaderboards(int index, Action<RuyiNetLeaderboardConfig[]> callback)

### Post Score to Dynamic Leaderboard

Posts a score to a leaderboard, creating a new one if it doesn't already
exist.

#### Prototypes

    void PostScoreToDynamicLeaderboard(int index, int score, string leaderboardId, RuyiNetLeaderboardType leaderboardType, RuyiNetRotationType rotationType, long rotationReset, int retainedCount, Action<bool> callback)

    void PostScoreToDynamicLeaderboard(int index, int score, string leaderboardId, RuyiNetLeaderboardType leaderboardType, RuyiNetRotationType rotationType, long rotationReset, int retainedCount, string data, Action<bool> callback)

#### Parameters

  **Score**       

  The score to post to the leaderboard.
  
  **Leaderboard ID**     
  
  The ID of the leaderboard to post the score to.
  
  **Leaderboard Type**  

  The type of leaderboard to create. Can be HIGH\_VALUE, CUMULATIVE, LAST\_VALUE, or LOW\_VALUE.
  
  **Rotation Type**     

  The rotation type to create the leaderboard with. Can be NEVER, DAILY, WEEKLY, MONTHLY, YEARLY, or a custom number of DAYS.
  
  **Rotation Reset**  

  The time the leaderboard will reset initially.
  
  **Retained Count**   

  The maximum number of versions to retain.
  
  **Data**          

  Custom data the game developer wishes to attach.

### Post Score to Leaderboard

Submits a score to the specified leaderboard. This will not create a new
leaderboard.

#### Prototypes

    void PostScoreToLeaderboard(int index, int score, string leaderboardId, Action<bool> callback)

    void PostScoreToLeaderboard(int index, int score, string leaderboardId, string data, Action<bool> callback)

#### Parameters

  **Score**            
  
  The score to submit to the leaderboard.
  
  **Leaderboard ID** 

  The ID of the leaderboard to submit the score to.

### Remove Score

Removes the player's score from the specified leaderboard.

#### Prototypes

    void RemoveScore(int index, string leaderboardId, Action<bool> callback)

    void RemoveScore(int index, string leaderboardId, int versionId, Action<bool> callback)

#### Parameters

  **Leaderboard ID**  
  
  The ID of the leaderboard to remove the score from.
  
  **Version ID**    

  The version of the leaderboard to remove the score from.

Lobby Service
-------------

The lobby service provides basic matchmaking features.

### Close Lobby

Closes a lobby so nobody can join it anymore. Can only be called by the
lobby owner.

#### Prototype

    void CloseLobby(int clientIndex, string lobbyId, Action callback)

#### Parameters

  **Lobby ID**  

  The ID of the lobby to close.

### Create Lobby

Creates a lobby and returns the newly created lobby.

#### Prototypes

    void CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, Action<RuyiNetLobby> callback)

    void CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, string jsonAttributes, Action<RuyiNetLobby> callback)

    void CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, bool isOpen, Action<RuyiNetLobby> callback)

    void CreateLobby(int clientIndex, int maxSlots, RuyiNetLobbyType lobbyType, bool isOpen, string jsonAttributes, Action<RuyiNetLobby> callback)

#### Parameters

  **Max Slots**   

  The maximum number of players that can join the lobby.
  
  **Lobby Type**        
  
  The type of lobby to create. Can be RANKED or PLAYER.
  
  **JSON Attributes**   
  
  Custom attributes to attach to the lobby.
  
  **Is Open**           
  
  If set to false, players won't be able to join the lobby until after an Open Lobby operation.

### Destroy Lobby

Kicks out all players and destroys a lobby completely. Can only be
called by the lobby owner.

#### Prototype

    void DestroyLobby(int clientIndex, string lobbyId, Action<RuyiNetLobby> callback)

#### Parameters

  **Lobby ID**  

  The ID of the lobby to destroy.

### Find Friends Lobbies

Returns a list of lobbies containing the player's friends.

#### Prototype

    void FindFriendsLobbies(int clientIndex, Action<RuyiNetLobby[]> callback)

### Find Lobbies

Returns a list of lobbies matching the specified parameters.

#### Prototype

    void FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType, Action<RuyiNetLobby[]> callback)

    void FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, Action<RuyiNetLobby[]> callback)

    void FindLobbies(int clientIndex, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, string jsonAttributes, Action<RuyiNetLobby[]> callback)

#### Parameters

  **Num Results**  

  The maximum number of lobbies to return.
  
  **Lobby Type**      

  The type of lobby to search for. Can be PLAYER or RANKED.
  
  **Free Slots**        
  
  The minimum number of free slots needed in the lobbies.
  
  **JSON Attributes**   
  
  The custom attributes to search for.

### Get My Lobbies

Returns a list of lobbies the current player is a member of.

#### Prototype

    void GetMyLobbies(int clientIndex, Action<RuyiNetLobby[]> callback)

### Join Lobby

Adds the player to the specified lobby.

#### Prototype

    void JoinLobby(int clientIndex, string lobbyId, Action<RuyiNetLobby> callback)

#### Parameters

  **Lobby ID**   
  
  The ID of the lobby to join.

### Leave Lobby

Removes a player from the specified lobby.

#### Prototype

    void LeaveLobby(int clientIndex, string lobbyId, Action callback)

#### Parameters

  **Lobby ID** 

  The ID of the lobby to leave.

### Open Lobby

Opens a lobby so that new players can join. Can only be called by the
lobby owner.

#### Prototype

    void OpenLobby(int clientIndex, string lobbyId, Action<RuyiNetLobby> callback)

#### Parameters

  **Lobby ID**  

  The ID of the lobby to open.

### Start Game

Starts a game for all players in the lobby. Can only be called by the
lobby owner.

#### Prototype

    void StartGame(int clientIndex, string lobbyId, string connectionString, Action<RuyiNetLobby> callback)

#### Parameters

  **Lobby ID**          

  The ID of the lobby to start a game for.
  
  **Connection String**

  A string that tells other players how to join the network game (e.g. an IP address).

Party Service
-------------

Provides the ability for players to join parties together and play
across multiple games.

### Accept Party Invitation

Deletes a party invitation and adds a player to the party.

#### Prototype

    void AcceptPartyInvitation(int index, string partyId, Action<RuyiNetParty> callback)

#### Parameters

  **Party ID**   
  
  The ID of the party to accept an invitation to.
  
### Get Friends Parties

Returns a list of parties that the player's friends are a member of.

#### Prototype

    void GetFriendsParties(int index, int maxResults, Action<RuyiNetParty[]> callback)

#### Parameters

  **Max Results**   
  
  The maximum number of results to return.
  
### Get My Party

Return the party the current player belongs to.

#### Prototype

    void GetMyParty(int index, Action<RuyiNetParty> callback)

### Get Party Info

Returns information on a specific party.

#### Prototype

    void GetPartyInfo(int index, string partyId, Action<RuyiNetParty> callback)

#### Parameters

  **Party ID**   
  
  The ID of the party to retrieve.
  
### Join Party

Joins a specific party and returns that party.

#### Prototype

    void JoinParty(int index, string partyId, Action<RuyiNetParty> callback)

#### Parameters

  **Party ID**   
  
  The ID of the party to join.
  
### Leave Party

Removes the current player from their party.

#### Prototype

    void LeaveParty(int index, string partyId, Action<RuyiNetParty> callback)

#### Parameters

  **Party ID**   
  
  The ID of the party to leave.
  
### List Party Invitations

List party invitations the player has received.

#### Prototype

    void ListPartyInvitations(int index, Action<RuyiNetPartyInvitation[]> callback)

### Reject Party Invitation

Deletes a party invitation.

#### Prototype

    void RejectPartyInvitation(int index, string partyId, Action<RuyiNetParty> callback)

#### Parameters

  **Party ID**   
  
  The ID of the party to reject an invitation to.

### Send Party Invitation

Creates a party and sends an invitation to another player.

#### Prototype

    void SendPartyInvitation(int index, string playerId, Action<RuyiNetParty> callback)

Patch Service
-------------

Provides operations for getting the current game manifest.

### Get game Manifest

Gets the current game manifest, including version and patch data.

#### Prototype

    void GetGameManifest(int clientIndex, string gameId, Action<RuyiNetGameManifest> callback)

Profile Service
---------------

Provides operations for player's profiles.

### Update User Picture

Updates the profile picture of the user.

#### Prototype

    void UpdateUserPicture(int index, string filename, Action<RuyiNetGetCDNResponse> callback)

#### Parameters

  **Filename**   
  
  The local path to the image to upload. Should be in .jpg or .png format.
  
Telemetry Service
-----------------

Provides operations for recording telemetry.

### End Telemetry Event

Marks the end of a timed telemetry event.

#### Prototypes

    void EndTelemetryEvent(int clientIndex, string sessionId, string eventType, Action<RuyiNetResponse> callback)

    void EndTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, Action<RuyiNetResponse> callback)

    void EndTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, string participantId, Action<RuyiNetResponse> callback)

    void EndTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void EndTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId, Action<RuyiNetResponse> callback)

    void EndTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void EndTelemetryEvent(int clientIndex, string sessionId, string eventType, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void EndTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, string participantId, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

#### Parameters

  **Session ID**   

  The ID of the telemetry session to log the event to.

  **Event Type**       
  
  The type of event to log.
  
  **Timestamp**        
  
  The time the event occurred. If not specified, the current timestamp will be used.
  
  **Participant ID**   
  
  The ID of the participant that caused the event. Can be a Player ID or any other way the game developer wishes to identify the player.
  
  **Custom Data**      
  
  Any custom data the game developer wishes to attach to the event.

### End Telemetry Session

Marks the end of a telemetry session.

#### Prototypes

    void EndTelemetrySession(int clientIndex, string sessionId, Action<RuyiNetResponse> callback)

    void EndTelemetrySession(int clientIndex, int timestamp, string sessionId, Action<RuyiNetResponse> callback)

#### Parameters

  **Session ID** 

  The ID of the telemetry session to end.

  **Timestamp**    
  
  The time the session ended. If this isn't specified, the current timestamp will be used.

### Log Telemetry Event

Logs a telemetry event to a session.

#### Prototypes

    void LogTelemetryEvent(int clientIndex, string sessionId, string eventType, Action<RuyiNetResponse> callback)

    void LogTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, Action<RuyiNetResponse> callback)

    void LogTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, string participantId, Action<RuyiNetResponse> callback)

    void LogTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void LogTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId, Action<RuyiNetResponse> callback)

    void LogTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void LogTelemetryEvent(int clientIndex, string sessionId, string eventType, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void LogTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, string participantId, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

#### Parameters

  **Session ID**     

  The ID of the telemetry session to log the event to.
  
  **Event Type**       
  
  The type of event to log.
  
  **Timestamp**        
  
  The time the event occurred. If not specified, the current timestamp will be used.

  **Participant ID**   
  
  The ID of the participant that caused the event. Can be a Player ID or any other way the game developer wishes to identify the player.
  
  **Custom Data**      
  
  Any custom data the game developer wishes to attach to the event.

### Start Telemetry Event

Starts a timed telemetry event.

#### Prototypes

    void StartTelemetryEvent(int clientIndex, string sessionId, string eventType, Action<RuyiNetResponse> callback)

    void StartTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, Action<RuyiNetResponse> callback)

    void StartTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, string participantId, Action<RuyiNetResponse> callback)

    void StartTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void StartTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId, Action<RuyiNetResponse> callback)

    void StartTelemetryEvent(int clientIndex, string sessionId, string eventType, string participantId, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void StartTelemetryEvent(int clientIndex, string sessionId, string eventType, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

    void StartTelemetryEvent(int clientIndex, int timestamp, string sessionId, string eventType, string participantId, Dictionary<string, string> customData, Action<RuyiNetResponse> callback)

#### Parameters

  **Session ID**     

  The ID of the telemetry session to log the event to.
  
  **Event Type**       
  
  The type of event to log.
  
  **Timestamp**        
  
  The time the event occurred. If not specified, the current timestamp will be used.

  **Participant ID**   
  
  The ID of the participant that caused the event. Can be a Player ID or any other way the game developer wishes to identify the player.
  
  **Custom Data**      
  
  Any custom data the game developer wishes to attach to the event.

### Start Telemetry Session

Starts a telemetry session, which is a group of telemetry events.

#### Prototypes

    void StartTelemetrySession(int clientIndex, Action<RuyiNetTelemetrySession> callback)

    void StartTelemetrySession(int clientIndex, int timestamp, Action<RuyiNetTelemetrySession> callback)

#### Parameters

  **Timestamp**   
  
  The timestamp when this session started. If this isn't specified, the current timestamp will be used.
  
User File Service
-----------------

Provides operations for storing and sharing user files.

### Cancel Upload

Cancels a user file upload in progress.

#### Prototype

    void CancelUpload(int index, string uploadId)

#### Parameters

  **Upload ID**   
  
  The ID of the upload to cancel.
  
### Delete User File

Removes a user file from the RuyiNet cloud.

#### Prototype

    void DeleteUserFile(int index, string cloudPath, string cloudFilename, Action<RuyiNetUploadFileResponse> callback)

#### Parameters

  **Cloud Path**       
  
  The path on the cloud to delete the file from.
  
  **Cloud Filename**   
  
  The name of the file to delete.

### Delete User Files

Delete multiple user files from the RuyiNet cloud.

#### Prototype

    void DeleteUserFiles(int index, string cloudPath, bool recursive, Action<RuyiNetListUserFilesResponse> callback)

#### Parameters

  **Cloud Path**   
  
  The path on the cloud to delete the files from.
  
  **Recursive**    
  
  If this is true files in subfolders will also be deleted.

### Get CDN URL

Returns the URL of a file stored in the RuyiNet cloud.

#### Prototype

    void GetCDNUrl(int index, string cloudPath, string cloudFilename, Action<RuyiNetGetCDNResponse> callback)

#### Parameters

  **Cloud Path**    

  The path on the cloud where the file is located.

  **Cloud Filename**   
  
  The name of the file to get the URL to.

### Get Upload Bytes Transferred

Returns the number of bytes transferred so far.

#### Prototype

    long GetUploadBytesTransferred(int index, string uploadId)

#### Parameters

  **Upload ID**   
  
  The ID of the upload to cancel.
  
### Get Upload Progress

Returns the progress of the upload, from 0.0 (not started) up to 1.0
(completed). Returns -1 if upload is not found.

#### Prototype

    double GetUploadProgress(int index, string uploadId)

#### Parameters

  **Upload ID**   
  
  The ID of the upload to cancel.
  
### Get Upload Total Bytes To Transfer

Returns the total number of bytes that will be uploaded.

#### Prototype

    long GetUploadTotalBytesToTransfer(int index, string uploadId)

#### Parameters

  **Upload ID**   
  
  The ID of the upload to cancel.
  
### List User Files

Lists all the files the user has uploaded in this game.

#### Prototypes

    void ListUserFiles(int index, Action<RuyiNetListUserFilesResponse> callback)

    void ListUserFiles(int index, string cloudPath, bool recursive, Action<RuyiNetListUserFilesResponse> callback)

#### Parameters

  **Cloud Path**   
  
  The cloud path to get the files from.
  
  **Recursive**    
  
  Whether or not to return subfolders within the cloud path.

### Upload File

Uploads a user file to RuyiNet's cloud.

#### Prototype

    void UploadFile(int index, string cloudPath, string cloudFilename, bool shareable, bool replaceIfExists, string localPath, Action<RuyiNetUploadFileResponse> callback)

#### Parameters

  **Cloud Path**          
  
  The path on the cloud to upload the file to.
  
  **Cloud Filename**      
  
  The name to give the file on the cloud.
  
  **Shareable**           
  
  If this is true, the file can be shared with other players.
  
  **Replace If Exists**   
  
  If this is true it will overwrite the file if it already exists.
  
  **Local Path**          
  
  The local path of the file to upload.
  
Video Service
-------------

Provides operations for players to share videos.

### Delete Video

Removes a video from the RuyiNet cloud.

#### Prototype

    void DeleteVideo(int index, string cloudFilename, Action<RuyiNetUploadFileResponse> callback)

#### Parameters

  **Cloud Filename**   
  
  The name of the video to delete.
  
### Download Video

Downloads a video from the RuyiNet cloud.

#### Prototype

    void DownloadVideo(int index, string cloudFilename, Action<RuyiNetResponse> callback)

#### Parameters

  **Cloud Filename**   
  
  The name of the video to download.
  
### Get Friends' Videos

Returns a list of videos that a friend has uploaded.

#### Prototype

    void GetFriendsVideos(int index, string playerId, Action<RuyiNetGetFriendsVideosResponse> callback)

### Get Video URL

Returns the URL of a particular video.

#### Prototype

    void GetVideoUrl(int index, string cloudFilename, Action<RuyiNetGetCDNResponse> callback)

#### Parameters

  **Cloud Filename**   
  
  The name of the video to get the URL for.
  
### List Videos

Returns a list of the users videos.

#### Prototype

    void ListVideos(int index, Action<RuyiNetListUserFilesResponse> callback)

### Upload Video

Uploads a video to the RuyiNet cloud.

#### Prototype

    void UploadVideo(int index, string cloudFilename, string localPath, Action<RuyiNetUploadFileResponse> callback)

#### Parameters

  **Cloud Filename**   
  
  The name of the video after it's uploaded.
  
  **Local Path**       
  
  The local path of the video to upload.

####  

Data Structures
===============

There are several data structures that can be returned by operations
containing information about the current state of the online service.

Entity Service
--------------

### RuyiNet Entity

Represents a custom entity stored on RuyiNet.

#### Definition

    class RuyiNetEntity
    {
        public string EntityId { get; private set; }
        public string EntityType { get; private set; }
        public int Version { get; private set; }
        public long CreatedAt { get; private set; }
        public long UpdatedAt { get; private set; }
        public Dictionary\<string, object\> Data { get; private set; }
    }

#### Properties

  **Entity ID**     
  
  The ID of the entity.
  
  **Entity Type**   
  
  The custom type of the entity.
  
  **Version**       
  
  The current version of the entity.
  
  **Created At**    
  
  When the entity was created.
  
  **Updated At**    
  
  When the entity was last updated.
  
  **Data**          
  
  Custom data stored on the entity.

Friend Service
--------------

### RuyiNet Friend Invite

Represents an invitation to become someone's friend.

#### Definition

    class RuyiNetFriendInvite
    {
        public string FromPlayerId { get; private set; }
        public string ToPlayerId { get; private set; }
    }

#### Properties

  **From Player ID**   
  
  The ID of the player that sent the invite.
  
  **To Player ID**     
  
  The ID of the player the invite was sent to.

### RuyiNet Friend Online Status

Represents the online presence of a player.

#### Definition

    class RuyiNetFriendOnlineStatus
    {
        public bool UserExists { get; private set; }
        public string PlayerId { get; private set; }
        public bool IsOnline { get; private set; }
    }

#### Properties

  **User Exists**   
  
  True if the user exists, false otherwise.
  
  **Player ID**     
  
  The ID of the player.
  
  **Is Online**     
  
  True if the player is currently logged into RuyiNet.

### RuyiNet Friend Summary Data

This structure represents a friend's profile.

#### Definition

    class RuyiNetFriendSummaryData
    {
        public string Name { get; private set; }
        public string PlayerId { get; private set; }
        public string PictureUrl { get; private set; }
        public Dictionary<string, object> Data { get; private set; }
        public string Email { get; private set; }
    }

#### Properties

  **Name**          
  
  The name of the player.
  
  **Player ID**     
  
  The ID of the player, used in operation calls.
  
  **Picture URL**   
  
  The resource location of the player's profile picture.
  
  **Email**         
  
  The email address of the player.

Gamification Service
--------------------

### RuyiNet Achievement

Represents an achievement.

#### Definition

    class RuyiNetAchievement
    {
        public string GameId { get; private set; }
        public string AchievementId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool InvisibleUntilEarned { get; private set; }
        public string ImageUrl { get; private set; }
        public string ExtraData { get; private set; }
        public int XpAwarded { get; private set; }
        public int CoinAwarded { get; private set; }
        public RuyiNetAchievementStatus Status { get; private set; }
    }

#### Properties

  **Game ID**                  
  
  The ID of the game this achievement is awarded by.
  
  **Achievement ID**           
  
  The ID of the achievement itself.
  
  **Title**                    
  
  The human-readable name of the achievement.
  
  **Description**          

  The human-readable description of how to get the achievement.
  
  **Invisible Until Earned**   
  
  If this is true the player can only see the achievement after it has been earned.
  
  **Image URL**                
  
  The resource location of the image associated with this achievement.
  
  **Extra Data**               
  
  Extra custom data set by the game developer.
  
  **XP Awarded**               
  
  The amount of experience the player's RuyiNet account will earn on completing this achievement.
  
  **Coin Award**               
  
  The amount of RuyiCoin the player will receive on completing this achievement.
  
  **Status**                   
  
  The status of this achievement. Can be AWARDED, NOT\_AWARDED, or UNKNOWN.

Leaderboard Service
-------------------

### RuyiNet Leaderboard Config

Represents a leaderboard configuration.

#### Definition

    class RuyiNetLeaderboardConfig
    {
        public string LeaderboardId { get; private set; }
        public RuyiNetLeaderboardType LeaderboardType { get; private set; }
        public long ResetAt { get; private set; }
        public RuyiNetRotationType RotationType { get; private set; }
        public int CurrentVersionId { get; private set; }
        public int MaxRetainedCount { get; private set; }
        public int RetainedVersionsCount { get; private set; }
        public string Data { get; private set; }
    }

#### Properties

  **Leaderboard ID**            
  
  The ID of the player that submitted this entry.
  
  **Leaderboard Type**          
  
  The type of leaderboard this is. Can be HIGH\_VALUE, CUMULATIVE, LAST\_VALUE, or LOW\_VALUE.
  
  **Rotation Type**             
  
  How often this leaderboard rotates. Can be NEVER, DAILY, WEEKLY, MONTHLY, YEARLY, or a custom number of DAYS.
  
  **Reset At**                  
  
  The time when this leaderboard will next be reset.
  
  **Current Version ID**        
  
  The ID of the latest version of the leaderboard.
  
  **Max Retained Count**        
  
  The maximum number of versions this leaderboard can retain.
  
  **Retained Versions Count**   
  
  The number of versions currently retained.
  
  **Data**                      
  
  Custom data specified by the game developer.

### RuyiNet Leaderboard Entry

Represents a single leaderboard entry.

#### Definition

    class RuyiNetLeaderboardEntry
    {
        public string PlayerId { get; private set; }
        public int Score { get; private set; }
        public string Data { get; private set; }
        public long CreatedAt { get; private set; }
        public long UpdatedAt { get; private set; }
        public int Index { get; private set; }
        public int Rank { get; private set; }
        public string Name { get; private set; }
        public string PictureUrl { get; private set; }
    }

#### Properties

  **Player ID**     
  
  The ID of the player that submitted this entry.
  
  **Score**         
  
  The actual score submitted.
  
  **Data**          
  
  Custom data specified by the game developer.
  
  **Created At**    
  
  When this entry was created.
  
  **Updated At**   

  When this entry was last updated.
  
  **Index**   

  The index of this leaderboard entry (0-indexed).
  
  **Rank**          
  
  The overall rank of this leaderboard entry (1-indexed).
  
  **Name**      

  The name of the player that submitted this entry.
  
  **Picture URL** 

  The resource location of the player's profile picture.
  

### RuyiNet Leaderboard Info

Represents information about a leaderboard.

#### Definition

    class RuyiNetLeaderboardInfo
    {
        public string LeaderboardId { get; private set; }
        public RuyiNetLeaderboardType LeaderboardType { get; private set; }
        public RuyiNetRotationType RotationType { get; private set; }
        public int RetainedCount { get; private set; }
        public List<RuyiNetLeaderboardVersionInfo> Versions { get; private set; }
    }

#### Properties

  **Leaderboard ID**     
  
  The ID of the player that submitted this entry.
  
  **Leaderboard Type**   
  
  The type of leaderboard this is. Can be HIGH\_VALUE, CUMULATIVE, LAST\_VALUE, or LOW\_VALUE.
  
  **Rotation Type**      
  
  How often this leaderboard rotates. Can be NEVER, DAILY, WEEKLY, MONTHLY, YEARLY, or a custom number of DAYS.
  
  **Retained Count**     
  
  The number of versions of this leaderboard being retained.
  
  **Versions**           
  
  A list of versions retained for this leaderboard.

### RuyiNet Leaderboard Page

Represents paginated data retrieved from a leaderboard

#### Definition

    class RuyiNetLeaderboardPage
    {
        public List\<RuyiNetLeaderboardEntry\> Entries { get; private set; }
        public bool MoreAfter { get; private set; }
        public bool MoreBefore { get; private set; }
        public int TimeBeforeReset { get; private set; }
        public long ServerTime { get; private set; }
    }

#### Properties

  **Entries**             
  
  A list of leaderboard entries.
  
  **More After**          
  
  True if there are more leaderboard entries after this page.
  
  **More Before**         
  
  True if there are more leaderboard entries before this page.
  
  **Time Before Reset**   
  
  How long until the next time this leaderboard is reset.
  
  **Server Time**         
  
  The server time when this page was retrieved.

### RuyiNet Leaderboard Versions

Represents a specific version of a leaderboard.

#### Definition

    class RuyiNetLeaderboardVersionInfo
    {
        public int VersionId { get; private set; }
        public long StartingAt { get; private set; }
        public long EndingAt { get; private set; }
    }

#### Properties

  **Version**       
  
  The ID of this version.
  
  **Starting At**   
  
  The time this version started accepting scores.
  
  **Ending At**     
  
  The time this version finishes accepting scores.

### RuyiNet Player Score

Represents a player's individual score.

#### Definition

    class RuyiNetPlayerScore
    {
        public int Score { get; private set; }
        public string Data { get; private set; }
        public long CreatedAt { get; private set; }
        public long UpdatedAt { get; private set; }
        public string LeaderboardId { get; private set; }
        public int VersionId { get; private set; }
    }

#### Properties

  **Score**     

  The actual score submitted.
  
  **Data**             
  
  Custom data specified by the game developer.
  
  **Created At**       
  
  When this entry was created.
  
  **Updated At**       
  
  When this entry was last updated.
  
  **Leaderboard ID**   
  
  The ID of the leaderboard this score was submitted to.
  
  **Version ID**       
  
  The version of the leaderboard this score was submitted to.

Lobby Service
-------------

### RuyiNet Lobby

Represents the current state of a lobby.

#### Definition

    class RuyiNetLobby
    {
        public string GameId { get; private set; }
        public string LobbyId { get; private set; }
        public Dictionary<string, object> JSONAttributes { get; private set; }
        public List<string> MemberPlayerIds { get; set; }
        public string ConnectionString { get; private set; }
        public RuyiNetLobbyState LobbyState { get; private set; }
        public RuyiNetLobbyType LobbyType { get; private set; }
        public long Created { get; private set; }
        public long Updated { get; private set; }
        public int MaxSlots { get; private set; }
        public bool IsOpen { get; private set; }
        public int FreeSlots { get; private set; }
        public string OwnerPlayerId { get; private set; }
    }

#### Properties

  **Game ID**             
  
  The ID of the game this lobby belongs to.
  
  **Lobby ID**            
  
  The unique ID of this lobby.
  
  **JSON Attributes**     
  
  Custom attributes set by the game developer.
  
  **Member Player IDs**   
  
  The IDs of the players in this lobby.
  
  **Connection String**   
  
  A custom string used to connect to a game.
  
  **Lobby State**         
  
  The current state of the lobby. Can be CREATED or STARTED.
  
  **Lobby Type**          
  
  The type of the lobby. Can be RANKED or PLAYER.
  
  **Created**             
  
  When this lobby was created
  
  **Updated**             
  
  When this lobby was last updated.
  
  **Max Slots**           
  
  The maximum number of players that can join this lobby.
  
  **Is Open**     

  If true then new players can join.

  **Free Slots**          
  
  The number of free slots in this lobby.
  
  **Owner Player ID**     
  
  The ID of the player that owns this lobby.

Party Service
-------------

### RuyiNet Party

Represents a party of players.

#### Definition

    class RuyiNetParty
    {
        public long Created { get; private set; }
        public string[] MemberPlayerIds { get; private set; }
        public long Updated { get; private set; }
        public string PartyId { get; private set; }
        public string OwnerPlayerId { get; private set; }
    }

#### Properties

  **Created**             
  
  The time the lobby was created.
  
  **Member Player IDs**   
  
  A list of the IDs of players belonging to the party.
  
  **Updated**             
  
  When the party was last updated.
  
  **Party ID**            
  
  The ID of the party.
  
  **Owner Player ID**     
  
  The ID of the owning player.

Patch Service
-------------

### RuyiNet Game Manifest

Represents information about a particular game.

#### Definition

    class RuyiNetGameManifest
    {
        public string GameId { get; private set; }
        public string LatestVersion { get; private set; }
        public Patch[] PatchInfo { get; private set; }
        public int Status { get; private set; }
    }

#### Properties

  **Game ID**         

  The ID of the game this manifest belongs to.

  **Latest Version**   
  
  The latest version of the game.
  
  **Patch Info**       
  
  A list of patches.
  
  **Status**           
  
  The HTTP status of the response (200 = OK).

### RuyiNet Game Manifest -- Patch

Represents an individual patch for a game.

#### Definition

    class RuyiNetGameManifest.Patch
    {
        public string FromVersion { get; set; }
        public string ToVersion { get; set; }
        public string ReleaseNotesLocation { get; set; }
        public string PatchLocation { get; set; }
        public string PatchMd5 { get; set; }
    }

#### Properties

  **From Version**     

  The version of the game this patch can be applied to.
  
  **To Version**               
  
  The version of the game after the patch is applied.
  
  **Release Notes Location**   
  
  The resource location for this patch's release notes.
  
  **Patch Location**           
  
  The resource location of the patch file.
  
  **Patch Md5**                
  
  The MD5 checksum of the patch file.

Telemetry Service
-----------------

### RuyiNet Telemetry Session

Represents a telemetry session.

#### Definition

    class RuyiNetTelemetrySession
    {
        public string Id { get; private set; }
        public int Timestamp { get; private set; }
    }

#### Properties

  **ID**      

  The ID of the telemetry session.
  
  **Timestamp**   
  
  The time the telemetry session started.

User File Service
-----------------

### RuyiNet Upload File Response

The response from an upload file operation.

#### Definition

    class RuyiNetUploadFileResponse
    {
        public class Data
        {
            public class FileDetails
            {
                public long updatedAt;
                public int fileSize;
                public string fileType;
                public long expiresAt;
                public bool shareable;
                public string uploadId;
                public long createdAt;
                public string profileId;
                public string gameId;
                public string path;
                public string filename;
                public bool replaceIfExists;
                public string cloudPath;
            }
            
            public FileDetails fileDetails;
        }

        public Data data;
        public int status;
    }

#### Properties

  **Updated At**  

  When the file was last updated.
  
  **File Size**           
  
  The size of the file.
  
  **File Type**           
  
  The type of the file.
  
  **Expires At**          
  
  When the upload attempt times out.
  
  **Shareable**           
  
  Whether or not the file can be shared with other players.
  
  **Upload ID**           
  
  The ID of the upload.
  
  **Created At**          
  
  When the file was created.
  
  **Profile ID**          
  
  The ID of the player that is uploading the file.
  
  **Game ID**             
  
  The ID of the game this file belongs to.
  
  **Path**                
  
  The local path of the file.
  
  **Filename**            
  
  The name of the file.
  
  **Replace If Exists**   
  
  Whether or not an already existing file will be overwritten.
  
  **Cloud Path**          
  
  The path of the file on the cloud.

### RuyiNet List User Files Response

The response from a list user files request.

#### Definition

    class RuyiNetListUserFilesResponse
    {
        public class Data
        {
            public class FileDetails
            {
                public long updatedAt;
                public long uploadedAt;
                public int fileSize;
                public bool shareable;
                public long createdAt;
                public string profileId;
                public string gameId;
                public string cloudPath;
                public string cloudFilename;
                public string downloadUrl;
                public string cloudLocation;
            }

            public FileDetails[] fileList;
        }

        public Data data;
        public int status;
    }

#### Properties

  **Updated At**   

  When the file was last updated.

  **Uploaded At**      
  
  When the file was uploaded
  
  **File Size**        
  
  The size of the file.
  
  **Shareable**        
  
  Whether or not the file can be shared with other players.
  
  **Created At**       
  
  When the file was created.
  
  **Profile ID**       
  
  The ID of the player that is uploading the file.
  
  **Game ID**          
  
  The ID of the game this file belongs to.
  
  **Download URL**     
  
  The URL to download the file.
  
  **Cloud Filename**   
  
  The name of the file.
  
  **Cloud Path**       
  
  The path of the file on the cloud.
  
  **Cloud Location**   
  
  ?

