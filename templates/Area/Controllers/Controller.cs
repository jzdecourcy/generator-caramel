using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Caramel;
using Caramel.ServiceBus;
using <%= basenamespace %>.Commands;
using <%= basenamespace %>.Entities;
using <%= basewebnamespace %>.Routing;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= basewebnamespace %>.Areas.<%= pluralname %>.Controllers
{
	public class <%= classname %>Controller : Controller
	{
		public IServiceBus Bus { get; set; }

		public IMapper Mapper { get; set; }

		public ActionResult Index(PagedListSearchViewModel<<%= classname %>ViewModel, <%= classname %>SearchCriteriaViewModel> model)
		{
			model.Criteria = model.Criteria ?? new <%= classname %>SearchCriteriaViewModel();

			using (UnitOfWork.BeginReadOnly())
			{
				var results = Repository<<%= classname %>>.All;

				if (!String.IsNullOrWhiteSpace(model.Criteria.Term))
				{
					//results =
					//	results.
					//		Where(
					//			u =>
					//			u.Name.Contains(model.Criteria.Term)
					//		);
				}

				return
					this.
						View(
							new PagedListSearchViewModel<<%= classname %>ViewModel, <%= classname %>SearchCriteriaViewModel>()
							{
								Items =
									results.
										//OrderBy(e => e.Name).
										Skip(model.PageIndex * model.PageSize).
										Take(model.PageSize).
										Select(e => this.Mapper.Map<<%= classname %>ViewModel>(e)).
										ToList(),
								Criteria = model.Criteria,
								PageIndex = model.PageIndex,
								PageSize = model.PageSize,
								TotalRecords = results.Count()
							}
						);
			}
		}
		
		public ActionResult Create()
		{
			var model = new Create<%= classname %>ViewModel();
			
			using (UnitOfWork.BeginReadOnly())
			{
				this.OnCreate(model);
			}
			
			return this.View(model);
		}

		[HttpPost()]
		public ActionResult Create(Create<%= classname %>ViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				using (UnitOfWork.BeginReadOnly())
				{
					this.OnCreate(model);
				}
			
				return this.View(model);
			}

			var id =
				this.
					Bus.
						Send(
							this.
								Mapper.
									Map<Create<%= classname %>Command>(
										model
									)
						).
						Register(
							r =>
							r.Messages.OfType<<%= classname %>CreatedMessage>().First().<%= classname %>ID
						);

			return this.RedirectToRoute(Routes.<%= classname %>.Home);
		}

		private void OnCreate(Create<%= classname %>ViewModel model)
		{
		}
		
		public ActionResult Edit(Guid id)
		{
			using (UnitOfWork.BeginReadOnly())
			{
				var model =
					this.
						Mapper.
							Map<Edit<%= classname %>ViewModel>(
								Repository<<%= classname %>>.Get(id)
							);				
				
				this.OnEdit(model);
				
				return this.View(model);
			}
		}

		[HttpPost()]
		public ActionResult Edit(Edit<%= classname %>ViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				using (UnitOfWork.BeginReadOnly())
				{
					this.OnEdit(model);
				}
				
				return this.View(model);
			}

			this.
				Bus.
					Send(
						this.
							Mapper.
								Map<Update<%= classname %>Command>(
									model
								)
					);

			return this.RedirectToRoute(Routes.<%= classname %>.Home);
		}

		private void OnEdit(Edit<%= classname %>ViewModel model)
		{
		}
		
		public ActionResult Details(Guid id)
		{
			using (UnitOfWork.BeginReadOnly())
			{
				return
					this.
						View(
							this.
								Mapper.
									Map<<%= classname %>DetailsViewModel>(
										Repository<<%= classname %>>.Get(id)
									)
						);
			}
		}
		
		public ActionResult Delete(Delete<%= classname %>ViewModel model)
		{
			this.
				Bus.
					Send(
						this.
							Mapper.
								Map<Delete<%= classname %>Command>(
									model
								)
					);
					
			return this.RedirectToRoute(Routes.<%= classname %>.Home);
		}
	}
}