#include "RuyiNetGetPartyInfoResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetGetPartyInfoResponse::Data::Response::Group & data)
	{
		j = json
		{
			{ "groupType", data.groupType },
			{ "groupId", data.groupId },
			{ "isOpenGroup", data.isOpenGroup },
			{ "requestingPendingMemberCount", data.requestingPendingMemberCount },
			{ "invitedPendingMemberCount", data.invitedPendingMemberCount },
			{ "ownerId", data.ownerId },
			{ "name", data.name },
			{ "memberCount", data.memberCount }
		};
	}

	void from_json(const json & j, RuyiNetGetPartyInfoResponse::Data::Response::Group & data)
	{
		data.groupType = j.at("groupType").get<std::string>();
		data.groupId = j.at("groupId").get<std::string>();
		data.isOpenGroup = j.at("isOpenGroup").get<bool>();
		data.requestingPendingMemberCount = j.at("requestingPendingMemberCount").get<int>();
		data.invitedPendingMemberCount = j.at("invitedPendingMemberCount").get<int>();
		data.ownerId = j.at("ownerId").get<std::string>();
		data.name = j.at("name").get<std::string>();
		data.memberCount = j.at("memberCount").get<int>();
	}

	void to_json(json & j, const RuyiNetGetPartyInfoResponse::Data::Response & data)
	{
		j = json
		{
			{ "requested", data.requested },
			{ "invited", data.invited },
			{ "groups", data.groups }
		};
	}

	void from_json(const json & j, RuyiNetGetPartyInfoResponse::Data::Response & data)
	{
		data.requested = j.at("requested").get<std::list<RuyiNetGetPartyInfoResponse::Data::Response::Group>>();
		data.invited = j.at("invited").get<std::list<RuyiNetGetPartyInfoResponse::Data::Response::Group>>();
		data.groups = j.at("groups").get<std::list<RuyiNetGetPartyInfoResponse::Data::Response::Group>>();
	}

	void to_json(json & j, const RuyiNetGetPartyInfoResponse::Data & data)
	{
		j = json
		{
			{ "response", data.response },
			{ "success", data.success }
		};
	}

	void from_json(const json & j, RuyiNetGetPartyInfoResponse::Data & data)
	{
		data.response = j.at("response").get<RuyiNetGetPartyInfoResponse::Data::Response>();
		data.success = j.at("success").get<bool>();
	}

	void to_json(json & j, const RuyiNetGetPartyInfoResponse & data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void from_json(const json & j, RuyiNetGetPartyInfoResponse & data)
	{
		data.data = j.at("data").get<RuyiNetGetPartyInfoResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}