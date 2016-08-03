using System;
using AutoMapper;
using Caramel;
using Caramel.ServiceBus;
using <%= basenamespace %>.Events;
using <%= basenamespace %>.Commands;
using <%= basenamespace %>.Entities;

namespace <%= basenamespace %>.CommandHandlers
{
	public class Delete<%= classname %>CommandHandler : ICommandHandler<Delete<%= classname %>Command>
	{
		public IMappingEngine Mapper { get; set; }
	
		public void Handle(Delete<%= classname %>Command command)
		{
			Repository<<%= classname %>>.Delete(command.<%= classname %>ID);

			this.
				Bus().
					Publish(
						new <%= classname %>DeletedEvent()
						{
							<%= classname %>ID = command.<%= classname %>ID
						}
					);
		}
	}
}
