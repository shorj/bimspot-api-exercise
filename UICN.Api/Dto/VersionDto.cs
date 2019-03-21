using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UICN.Api.Dto {
	internal class VersionDto : BaseDto {
		[JsonProperty("version")]
		public string Version { get; set; }
	}
}
