using System;
using Caramel.Web.Mvc.Metadata;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>.Metadata
{
	public class <%= classname %>ViewModelMetadata : ClassModelMetadata<<%= classname %>ViewModel>
	{
		public <%= classname %>ViewModelMetadata()
		{
			this.
				Apply(m => m.ID).
				Order(0).
				ShowForDisplay().
				ShortDisplayName("").
				DisplayName("");
		}
	}
}