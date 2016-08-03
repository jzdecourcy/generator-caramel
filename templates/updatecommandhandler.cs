using System;
using AutoMapper;
using Caramel;
using Caramel.ServiceBus;
using <%= basenamespace %>.Events;
using <%= basenamespace %>.Commands;
using <%= basenamespace %>.Entities;

namespace <%= basenamespace %>.CommandHandlers
{
	public class Update<%= classname %>CommandHandler : ICommandHandler<Update<%= classname %>Command>
	{
		public IMapper Mapper { get; set; }
	
		public void Handle(Update<%= classname %>Command command)
		{
			var <%= camelcaseclassname %> = Repository<<%= classname %>>.Get(command.<%= classname %>ID);
				
			this.
				Mapper.
					Map(
						command,
						<%= camelcaseclassname %>
					);

			// TODO: Update	other properties

			Repository<<%= classname %>>.Save(<%= camelcaseclassname %>);

			this.
				Bus().
					Publish(
						new <%= classname %>UpdatedEvent()
						{
							<%= classname %>ID = command.<%= classname %>ID
						}
					);
		}
	}
}
