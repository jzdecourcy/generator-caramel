using System;
using Caramel.Web.Mvc.Metadata;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>.Metadata
{
	public class <%= classname %>DetailsViewModelMetadata : ClassModelMetadata<<%= classname %>DetailsViewModel>
	{
		public <%= classname %>DetailsViewModelMetadata()
		{
		}
	}
}