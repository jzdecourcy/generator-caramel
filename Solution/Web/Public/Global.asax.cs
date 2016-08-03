using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using FluentValidation;
using FluentValidation.Mvc;
using <%= basewebnamespace %>.Routing;
using <%= basewebnamespace %>.Controllers;

namespace <%= basewebnamespace %>
{
	public class <%= applicationName %>Application : HttpApplication
	{
		public static IWindsorContainer Container;

		protected void Application_Start()
		{
			Container = new WindsorContainer();
			ContainerConfig.RegisterComponents(Container);
			ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(Container));
			DependencyResolver.SetResolver(ServiceLocator.Current);

			RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			RouteTable.Routes.
				MapRoute(
					Routes.Home,
					"",
					new { controller = typeof(HomeController).ControllerName(), action = "Index" }
				);

			AreaRegistration.RegisterAllAreas();

			FluentValidationModelValidatorProvider.Configure(p => p.ValidatorFactory = Container.Resolve<IValidatorFactory>());

			ValidatorOptions.DisplayNameResolver =
				(t, m, e) =>
				{
					if (m != null)
					{
						var metadata =
							ModelMetadataProviders.
								Current.
								GetMetadataForProperty(() => null, m.DeclaringType, m.Name);

						return metadata.DisplayName;
					}

					return null;
				};

			//Humanizer.Inflections.Vocabularies.Default.AddPlural("Community", "Communities");
			//Humanizer.Inflections.Vocabularies.Default.AddPlural("Category", "Categories");

			ModelBinders.Binders.Add(typeof(System.Collections.Generic.IEnumerable<string>), new CheckBoxListModelBinder());
			ModelBinders.Binders.Add(typeof(System.Collections.Generic.IEnumerable<Guid>), new CheckBoxListModelBinder());
			ModelBinders.Binders.Add(typeof(System.Collections.Generic.IEnumerable<Guid?>), new CheckBoxListModelBinder());
		}
	}
}