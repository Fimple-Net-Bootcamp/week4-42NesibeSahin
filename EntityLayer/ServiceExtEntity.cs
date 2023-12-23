using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
	public static class ServiceExtEntity
	{
		public static void AddEntitySubService(this IServiceCollection service, IConfiguration configuration)
		{

			service.AddAutoMapper(Assembly.GetExecutingAssembly());
			//service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


		}
	}
}
