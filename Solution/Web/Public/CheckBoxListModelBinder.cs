using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace <%= basewebnamespace %>
{
	public class CheckBoxListModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (bindingContext.ModelMetadata.TemplateHint != "CheckBoxList")
			{
				return null;
			}

			var values =
				controllerContext.
					HttpContext.
					Request.
					Form.
					AllKeys.
					Where(k => k.StartsWith(bindingContext.ModelName + "[")).
					Select(
						k =>
						controllerContext.
							HttpContext.
							Request.
							Form[k]
					).
					Aggregate((c, n) => c + n).
					Split(',').
					Where(v => !String.IsNullOrWhiteSpace(v)).
					ToList();

			if (bindingContext.ModelType == typeof(IEnumerable<Guid>))
			{
				return
					values.
						Select(v => new Guid(v)).
						ToList();
			}

			if (bindingContext.ModelType == typeof(IEnumerable<Guid?>))
			{
				return
					values.
						Select(v => new Nullable<Guid>(new Guid(v))).
						ToList();
			}

			return values;
		}
	}
}
