using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Collections.Generic;

namespace <%= basewebnamespace %>.Html
{
	public static class HtmlHelperExtensions
	{
		public static MvcHtmlString RouteAction(this HtmlHelper htmlHelper, string routeName)
		{
			return htmlHelper.RouteAction(routeName, (object)null);
		}

		public static MvcHtmlString RouteAction(this HtmlHelper htmlHelper, string routeName, object routeValues)
		{
			return htmlHelper.RouteAction(routeName, new RouteValueDictionary(routeValues));
		}

		public static MvcHtmlString RouteAction(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues)
		{
			var route = htmlHelper.RouteCollection[routeName] as Route;

			var routeNameValues = route.Defaults;
			var routeNameTokens = route.DataTokens;
			var additionalRouteValues = routeValues;
			routeValues = MergeDictionaries(additionalRouteValues, routeNameTokens, routeNameValues, htmlHelper.ViewContext.RouteData.Values);

			return htmlHelper.Action(routeValues["action"] as string, routeValues["controller"] as string, routeValues);
		}

		public static string CurrentViewName(this HtmlHelper html)
		{
			return Path.GetFileNameWithoutExtension(((RazorView)html.ViewContext.View).ViewPath);
		}

		public static bool PartialViewExists(this HtmlHelper htmlHelper, string viewName)
		{
			var viewResult = ViewEngines.Engines.FindPartialView(htmlHelper.ViewContext.Controller.ControllerContext, viewName);

			return (viewResult.View != null);
		}

		private static RouteValueDictionary MergeDictionaries(params RouteValueDictionary[] dictionaries)
		{
			// Merge existing route values with the user provided values
			var result = new RouteValueDictionary();

			foreach (RouteValueDictionary dictionary in dictionaries.Where(d => d != null))
			{
				foreach (KeyValuePair<string, object> kvp in dictionary.Where(kvp => !result.ContainsKey(kvp.Key)))
				{
					result.Add(kvp.Key, kvp.Value);
				}
			}

			return result;
		}
	}
}