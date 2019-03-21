using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;

namespace UICN.Api.Serializers {
	public class JsonNetSerializer : IRestSerializer {
		public string Serialize(object obj) {
			return JsonConvert.SerializeObject(obj);
		}

		public string ContentType { get; set; } = "application/json";

		public T Deserialize<T>(IRestResponse response) {
			return JsonConvert.DeserializeObject<T>(response.Content);
		}

		public string Serialize(Parameter parameter) {
			return JsonConvert.SerializeObject(parameter.Value);
		}

		public string[] SupportedContentTypes { get; } = {
			"application/json", "text/json", "text/x-json", "text/javascript", "*+json"
		};

		public DataFormat DataFormat { get; } = DataFormat.Json;
	}
}
