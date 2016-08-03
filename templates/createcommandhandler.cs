using System;
using AutoMapper;
using Caramel;
using Caramel.ServiceBus;
using <%= basenamespace %>.Events;
using <%= basenamespace %>.Commands;
using <%= basenamespace %>.Entities;

namespace <%= basenamespace %>.CommandHandlers
{
	public class Create<%= classname %>CommandHandler : ICommandHandler<Create<%= classname %>Command>
	{
		public IMapper Mapper { get; set; }

		public void Handle(Create<%= classname %>Command command)
		{
			var <%= camelcaseclassname %> =
				this.
					Mapper.
						Map<<%= classname %>>(
							command
						);

			Repository<<%= classname %>>.Save(<%= camelcaseclassname %>);

			this.
				Bus().
					Publish(
						new <%= classname %>CreatedEvent()
						{
							<%= classname %>ID = <%= camelcaseclassname %>.ID.Value
						}
					);

			this.
				Bus().
					Reply(
						new <%= classname %>CreatedMessage()
						{
							<%= classname %>ID = <%= camelcaseclassname %>.ID.Value
						}
					);
		}
	}
}
