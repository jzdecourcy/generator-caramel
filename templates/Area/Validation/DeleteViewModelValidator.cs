using System;
//using System.Linq;
using FluentValidation;
//using FluentValidation.Results;
//using Caramel;
//using <%= basewebnamespace %>.Entities;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>.Validation
{
	public class Delete<%= classname %>ViewModelValidator : AbstractValidator<Delete<%= classname %>ViewModel>
	{
		public Delete<%= classname %>ViewModelValidator()
		{
		}

		//public override ValidationResult Validate(ValidationContext<Delete<%= classname %>ViewModel> context)
		//{
		//	using (UnitOfWork.BeginReadOnly())
		//	{
		//		return base.Validate(context);
		//	}
		//}
	}
}