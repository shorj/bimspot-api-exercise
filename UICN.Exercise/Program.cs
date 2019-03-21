using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UICN.Api;

namespace UICN.Exercise {
	internal static class Program {
		static void Main(string[] args) {
			DateTime startTime = DateTime.Now;
			Console.WriteLine($"------------------------ UICN.Exercise Start ({startTime:yyyy-MM-dd HH:mm:ss}) ------------------------");
			
			Client client = new Client("9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee");
			Console.WriteLine($"Api version: {client.GetApiVersion()}");

			DateTime endTime = DateTime.Now;
			Console.WriteLine($"------------------------ UICN.Exercise End ({endTime:yyyy-MM-dd HH:mm:ss}) ------------------------");
			Console.WriteLine();
		}
	}
}
