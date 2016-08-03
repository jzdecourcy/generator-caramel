using System;

namespace <%= namespace %>
{
	[Migration(<%=  version %>)]
	public class <%= classname %>Migration : Controller
	{
		public override Up()
		{
		}
		
		public override Down()
		{
		}
	}
}