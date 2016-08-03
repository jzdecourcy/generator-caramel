using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Caramel.ServiceBus;

namespace <%= basenamespace %>.CommandHandlers.Castle
{
	public class CommandHandlersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.
				Register(
					Classes.
						FromThisAssembly().
						BasedOn(typeof(ICommandHandler<>)).
						WithServiceAllInterfaces().
						Configure(r => r.LifestyleTransient())
				);
		}
	}
}