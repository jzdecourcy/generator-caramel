using System;
using Caramel.Web.Mvc.Metadata;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>.Metadata
{
	public class Create<%= classname %>ViewModelMetadata : ClassModelMetadata<Create<%= classname %>ViewModel>
	{
		public Create<%= classname %>ViewModelMetadata()
		{
		}
	}
}