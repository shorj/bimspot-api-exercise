using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UICN.Api.Dto {
	public class RegionListDto : BaseDto {
        [JsonProperty("count")]
        public int Count { get; set; }
		[JsonProperty("results")]
        public List<RegionDto> Results { get; set; }
	}
}
