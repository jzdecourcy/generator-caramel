using System;

namespace <%= basewebnamespace %>.Routing
{
	public static partial class Routes
	{
		public static class <%= classname %>
		{
			public const string PREFIX = "<%= classname %>";

			public const string Home = PREFIX + "Home";

			public const string Create = PREFIX + "Create";

			public const string Edit = PREFIX + "Edit";

			public const string Details = PREFIX + "Details";
			
			public const string Delete = PREFIX + "Delete";
		}
	}
}