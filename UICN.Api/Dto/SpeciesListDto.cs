using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UICN.Api.Dto {
	public class SpeciesListDto : BaseDto {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("region_identifier")]
        public string RegionIdentifier { get; set; }

		// for some reason the api returns it as string, e.g. "0"
        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("result")]
        public List<SpeciesDto> Result { get; set; }
	}
}
