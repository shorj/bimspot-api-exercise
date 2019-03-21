using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UICN.Api;
using UICN.Api.Dto;
using UICN.Api.Exceptions;
using UICN.Exercise.Models;

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
				RegionListDto regionListDto = client.GetRegionList();
				int regionCount = regionListDto.Results.Count;
				Console.WriteLine($"Region list contains {regionCount} items");

				// 2. Take a random region from the list
				if(regionCount < 1) {
					Console.WriteLine("Region list is empty, the application will be ended");
					return;
				}
				
				// debug:
				//int regionIndex = 3; // europe
				//int regionIndex = 8; // global
				int regionIndex = new Random().Next(0, regionCount);
				RegionDto regionDto = regionListDto.Results[regionIndex];
				Console.WriteLine($"Selected region: {regionDto}");

				// 3. Load the list of all species in the selected region — the first page of the results would suffice, no need for pagination
				// why not to implement pagination?
				// 4. Create a model for “Species” and map the results to an array of Species.
				// i would prefer List<Species> instead of array because of performance reasons, but array is also possible (we can use Array.Resize for changing its size)
				// another option: convert the list ToArray() in the end
				List<Species> listSpecies = new List<Species>(10000); // todo 2think: can we predict the initial capacity better? could it be better to request "Species Count" first?
				for(int page = 0;; page++) {
					SpeciesListDto speciesListDto = client.GetSpeciesListForRegion(regionDto.Identifier, page);
					int speciesCount = speciesListDto.Result.Count;
					if(speciesCount == 0) {
						break;
					}
					listSpecies.AddRange(from x in speciesListDto.Result select new Species(x));
				}
				Console.WriteLine($"Found {listSpecies.Count} species");

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
