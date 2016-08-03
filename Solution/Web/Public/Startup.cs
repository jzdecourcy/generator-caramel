using System;
using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(<%= basewebnamespace %>.Startup))]

namespace <%= basewebnamespace %>
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
		}
	}
}
