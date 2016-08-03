using System;
using Caramel.Web.Mvc.Metadata;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>.Metadata
{
	public class Edit<%= classname %>ViewModelMetadata : ClassModelMetadata<Edit<%= classname %>ViewModel>
	{
		public Edit<%= classname %>ViewModelMetadata()
		{
		}
	}
}