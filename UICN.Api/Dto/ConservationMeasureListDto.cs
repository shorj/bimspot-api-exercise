using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UICN.Api.Dto {
	public class ConservationMeasureListDto : BaseDto {
		[JsonProperty("id")]
		public string Id { get; set; }			// returned as string

		[JsonProperty("region_identifier")]
		public string RegionIdentifier { get; set; }

		[JsonProperty("result")]
		public List<ConservationMeasureDto> Result { get; set; }
	}
}
