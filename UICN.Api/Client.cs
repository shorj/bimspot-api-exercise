using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serialization.Json;
using UICN.Api.Dto;
using UICN.Api.Exceptions;
using UICN.Api.Serializers;

namespace UICN.Api {
	public class Client {
		#region Constants

		private const string BaseUrl = "http://apiv3.iucnredlist.org/api/v3";

		#endregion

		#region Fields

		private readonly string _token;
		private readonly IRestClient _client;

		#endregion

		#region Constructors

		public Client(string token) {
			_token = token;
			_client = new RestClient(BaseUrl);
			_client.UseSerializer(new JsonNetSerializer());
		}

		#endregion

		#region Methods

		private T Execute<T>(RestRequest request, bool withToken = true) where T : new() {
			if(withToken) {
				request.AddParameter("token", _token, ParameterType.QueryStringWithoutEncode);
			}

			IRestResponse<T> response = _client.Execute<T>(request);
			if(response.ErrorException != null) {
				throw new ApiException("Error while calling UICN API", response.ErrorException);
			}

			return response.Data;
		}

		public string GetApiVersion() {
			RestRequest request = new RestRequest("version");

			return Execute<VersionDto>(request, false).Version;
		}

		public RegionListDto GetRegionList() {
			RestRequest request = new RestRequest("region/list");

			return Execute<RegionListDto>(request);
		}

		#endregion
	}
}
