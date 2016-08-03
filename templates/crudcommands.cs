using System;
using Caramel.ServiceBus;

namespace <%= basenamespace %>.Commands
{
	public class Create<%= classname %>Command : ICommand
	{
	}
	
	public abstract class <%= classname %>Command : ICommand
	{
		public Guid <%= classname %>ID { get; set; }
	}

	public class Update<%= classname %>Command : <%= classname %>Command
	{
	}

	public class Delete<%= classname %>Command : <%= classname %>Command
	{
	}
	
	public class <%= classname %>CreatedMessage
	{
		public Guid <%= classname %>ID { get; set; }
	}
}