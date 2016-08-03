using System;
using System.Web.Mvc;
using <%= basewebnamespace %>.Routing;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Controllers;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>
{
	public class <%= classname %>AreaRegistration : AreaRegistration 
	{
		public override string AreaName 
		{
			get 
			{
				return "<%= pluralname %>";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context) 
		{
			context.
				MapRoute(
					Routes.<%= classname %>.Home,
					this.AreaName,
					new { controller = typeof(<%= classname %>Controller).ControllerName(), action = "Index" }
				);

			context.
				MapRoute(
					Routes.<%= classname %>.Create,
					String.Format("{0}/Create", this.AreaName),
					new { controller = typeof(<%= classname %>Controller).ControllerName(), action = "Create" }
				);

			context.
				MapRoute(
					Routes.<%= classname %>.Edit,
					String.Format("{0}/Edit/{{id}}", this.AreaName),
					new { controller = typeof(<%= classname %>Controller).ControllerName(), action = "Edit", id = UrlParameter.Optional }
				);

			context.
				MapRoute(
					Routes.<%= classname %>.Details,
					String.Format("{0}/{{id}}", this.AreaName),
					new { controller = typeof(<%= classname %>Controller).ControllerName(), action = "Details", id = UrlParameter.Optional }
				);
				
			context.
				MapRoute(
					Routes.<%= classname %>.Delete,
					String.Format("{0}/Delete/{{id}}", this.AreaName),
					new { controller = typeof(<%= classname %>Controller).ControllerName(), action = "Delete", id = UrlParameter.Optional }
				);			
		}
	}
}