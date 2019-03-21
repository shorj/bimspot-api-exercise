using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UICN.Api;
using UICN.Api.Dto;
using UICN.Api.Exceptions;

namespace UICN.Exercise {
	internal static class Program {
		private static void Main(string[] args) {
			AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
			DateTime startTime = DateTime.Now;
			Console.WriteLine(
				$"------------------------ UICN.Exercise Start ({startTime:yyyy-MM-dd HH:mm:ss}) ------------------------");

			try {
				Client client = new Client("9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee");
				Console.WriteLine($"Api version: {client.GetApiVersion()}");

				// 1. Load the list of the available regions for species
				RegionListDto regionList = client.GetRegionList();

			} catch(ApiException apiException) {
				// in case we need special handling for api exceptions
				Console.WriteLine($"ApiException in the Main function:\r\n{apiException}");
			} catch(Exception ex) {
				Console.WriteLine($"Exception in the Main function:\r\n{ex}");
			} finally {
				DateTime endTime = DateTime.Now;
				Console.WriteLine(
					$"------------------------ UICN.Exercise End   ({endTime:yyyy-MM-dd HH:mm:ss}) ------------------------");
				Console.WriteLine();
			}
		}

		private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
			Console.WriteLine($"Domain.UnhandledException:\r\n{e.ExceptionObject}");
		}
	}
}
