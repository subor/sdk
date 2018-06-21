#pragma once

#include "../RuyiNetClient.h"
#include "../Enum.h"

#include "RuyiNetResponse.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	enum RuyiNetLobbyType
	{
		RANKED,
		PLAYER,
	};

	/// <summary>
	/// Response received after creating a lobby.
	/// </summary>
	struct RuyiNetLobbyFindResponse
	{
		/// <summary>
		/// The data
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The response
			/// </summary>
			struct Response
			{
				/// <summary>
				/// 
				/// </summary>
				std::string context;

				/// <summary>
				/// The results from the response.
				/// </summary>
				struct Results
				{
					/// <summary>
					/// The number of groups found.
					/// </summary>
					int count;

					/// <summary>
					/// The page this list represents.
					/// </summary>
					int page;

					/// <summary>
					/// The array of groups found.
					/// </summary>
					std::list<RuyiNetResponseGroup> items;

					/// <summary>
					/// Whether or not there are more groups in later pages.
					/// </summary>
					bool moreAfter;

					/// <summary>
					/// Whether or not there are more groups in earlier pages.
					/// </summary>
					bool moreBefore;

					void parseJson(nlohmann::json& j)
					{
						if (!j["count"].is_null())
						{
							count = j["count"];
						}
						if (!j["page"].is_null())
						{
							page = j["page"];
						}
						if (!j["moreAfter"].is_null())
						{
							moreAfter = j["moreAfter"];
						}
						if (!j["moreBefore"].is_null())
						{
							moreBefore = j["moreBefore"];
						}
						if (!j["items"].is_null())
						{
							nlohmann::json itemsJson = j["items"];

							if (itemsJson.is_array())
							{
								for (auto itemJson : itemsJson)
								{
									RuyiNetResponseGroup group;
									
									group.parseJson(itemJson);

									items.push_back(group);
								}
							}
						}
					}
				};

				/// <summary>
				/// The results.
				/// </summary>
				Results results;

				void parseJson(nlohmann::json& j)
				{
					if (!j["context"].is_null())
					{
						context = j["context"];
					}
					if (!j["results"].is_null())
					{
						nlohmann::json resultsJson = j["results"];
						results.parseJson(resultsJson);
					}
				}
			};

			/// <summary>
			/// The response.
			/// </summary>
			Response response;

			/// <summary>
			/// Whether or not the server-side script was successful.
			/// </summary>
			bool success;

			void parseJson(nlohmann::json& j)
			{
				if (!j["success"].is_null())
				{
					success = j["success"];
				}
				if (!j["response"].is_null())
				{
					nlohmann::json responseJson = j["response"];
					
					if (!responseJson.is_object()) return;

					response.parseJson(responseJson);
				}
			}
		};

		/// <summary>
		/// The data.
		/// </summary>
		Data data;

		/// <summary>
		/// The response status.
		/// </summary>
		int status;
		
		void parseJson(nlohmann::json& j) 
		{
			if (!j["status"].is_null())
			{
				status = j["status"];
			}
			if (!j["data"].is_null())
			{
				nlohmann::json dataJson = j["data"];

				data.parseJson(dataJson);
			}
		}
	};

	/// <summary>
	/// Response received after creating a lobby.
	/// </summary>
	struct RuyiNetLobbyResponse
	{
		/// <summary>
		/// Data class.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The response.
			/// </summary>
			RuyiNetResponseGroup response;

			/// <summary>
			/// Whether or not the server-side script was successful.
			/// </summary>
			bool success;

			void parseJson(nlohmann::json& j)
			{
				if (!j["response"].is_null())
				{
					nlohmann::json responseJson = j["response"];
					response.parseJson(responseJson);
				}
				if (!j["success"].is_null())
				{
					success = j["success"];
				}
			}
		};

		/// <summary>
		/// The data.
		/// </summary>
		Data data;

		/// <summary>
		/// The response status.
		/// </summary>
		int status;

		void parseJson(nlohmann::json& j)
		{
			if (!j["data"].is_null())
			{
				nlohmann::json dataJson = j["data"];
				data.parseJson(dataJson);
			}
			if (!j["status"].is_null())
			{
				status = j["status"];
			}
		}
	};
//}
}}} //namespace