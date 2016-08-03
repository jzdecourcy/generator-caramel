using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Caramel.ServiceBus;

namespace <%= basenamespace %>.EventHandlers.Castle
{
	public class EventHandlersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.
				Register(
					Classes.
						FromThisAssembly().
						BasedOn(typeof(IEventHandler<>)).
						WithServiceAllInterfaces().
						Configure(r => r.LifestyleTransient())
				);
		}
	}
}