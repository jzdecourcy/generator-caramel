using System;
//using System.Linq;
using FluentValidation;
//using FluentValidation.Results;
//using Caramel;
//using <%= basewebnamespace %>.Entities;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>.Validation
{
	public class Create<%= classname %>ViewModelValidator : AbstractValidator<Create<%= classname %>ViewModel>
	{
		public Create<%= classname %>ViewModelValidator()
		{
		}

		//public override ValidationResult Validate(ValidationContext<Create<%= classname %>ViewModel> context)
		//{
		//	using (UnitOfWork.BeginReadOnly())
		//	{
		//		return base.Validate(context);
		//	}
		//}	
	}
}