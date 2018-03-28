#pragma once

#include <list>
#include <string>

#include "boost/container/detail/json.hpp"

using nlohmann::json;

namespace Ruyi
{
	struct RuyiNetGetPartyInfoResponse
	{
		struct Data
		{
			struct Response
			{
				struct Group
				{
					std::string groupType;
					std::string groupId;
					bool isOpenGroup;
					int requestingPendingMemberCount;
					int invitedPendingMemberCount;
					std::string ownerId;
					std::string name;
					int memberCount;
				};
				
				std::list<Group> requested;
				std::list<Group> invited;
				std::list<Group> groups;
			};

			Response response;
			bool success;
		};
		
		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetGetPartyInfoResponse::Data::Response::Group & data);
	void from_json(const json & j, RuyiNetGetPartyInfoResponse::Data::Response::Group & data);
	void to_json(json & j, const RuyiNetGetPartyInfoResponse::Data::Response & data);
	void from_json(const json & j, RuyiNetGetPartyInfoResponse::Data::Response & data);
	void to_json(json & j, const RuyiNetGetPartyInfoResponse::Data & data);
	void from_json(const json & j, RuyiNetGetPartyInfoResponse::Data & data);
	void to_json(json & j, const RuyiNetGetPartyInfoResponse & data);
	void from_json(const json & j, RuyiNetGetPartyInfoResponse & data);
}
