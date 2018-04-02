#pragma once

#include "../RuyiNetClient.h"
#include "RuyiNetResponse.h"

namespace Ruyi
{
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
				};

				/// <summary>
				/// The results.
				/// </summary>
				Results results;
			};

			/// <summary>
			/// The response.
			/// </summary>
			Response response;

			/// <summary>
			/// Whether or not the server-side script was successful.
			/// </summary>
			bool success;
		};

		/// <summary>
		/// The data.
		/// </summary>
		Data data;

		/// <summary>
		/// The response status.
		/// </summary>
		int status;
	};
}