using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UICN.Api.Dto {
	public class RegionDto : BaseDto {
		#region Properties

        [JsonProperty("name")]
        public string Name { get; set; }

		[JsonProperty("identifier")]
        public string Identifier { get; set; }

		#endregion

		#region Methods

		public override string ToString() {
			return $"Id = '{Identifier}', Name = '{Name}'";
		}

		#endregion
	}
}
