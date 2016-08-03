using System;
using Caramel.ServiceBus;

namespace <%= basenamespace %>.Events
{
	public abstract class <%= classname %>Event : IEvent
	{
		public Guid <%= classname %>ID { get; set; }
	}

	public class <%= classname %>CreatedEvent : <%= classname %>Event
	{
	}
	
	public class <%= classname %>UpdatedEvent : <%= classname %>Event
	{
	}
	
	public class <%= classname %>DeletedEvent : <%= classname %>Event
	{
	}
}