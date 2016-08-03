using System;
//using System.Linq;
using FluentValidation;
//using FluentValidation.Results;
//using Caramel;
//using <%= basewebnamespace %>.Entities;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>.Validation
{
	public class Edit<%= classname %>ViewModelValidator : AbstractValidator<Edit<%= classname %>ViewModel>
	{
		public Edit<%= classname %>ViewModelValidator()
		{
		}

		//public override ValidationResult Validate(ValidationContext<Edit<%= classname %>ViewModel> context)
		//{
		//	using (UnitOfWork.BeginReadOnly())
		//	{
		//		return base.Validate(context);
		//	}
		//}
	}
}