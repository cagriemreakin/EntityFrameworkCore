using System;
using Microsoft.Extensions.Configuration;

namespace CodeFirst
{
	public class Initializer
	{
		public static IConfiguration Configuration;

		public static void Build()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			Configuration =builder.Build();
		}
	}
}

