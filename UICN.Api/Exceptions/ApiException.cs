using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UICN.Api.Exceptions {
	public class ApiException : Exception {
		#region Constructors

		public ApiException() { }

		public ApiException(string message) : base(message) { }

		public ApiException(string message, Exception innerException) : base(message, innerException) { }

		#endregion
	}
}
