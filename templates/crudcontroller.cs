using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Caramel;
using Caramel.ServiceBus;
using <%= basenamespace %>.Commands;
using <%= basenamespace %>.Entities;

namespace <%= namespace %>
{
	public class <%= classname %>Controller : Controller
	{
		public IServiceBus Bus { get; set; }

		public IMappingEngine Mapper { get; set; }

		public ActionResult Index()
		{
			using (UnitOfWork.BeginReadOnly())
			{
				return
					this.
						View(
							Repository<<%= classname %>>.All.
								//OrderBy().
								ToList().
								Select(c => this.Mapper.Map<<%= classname %>ViewModel>(c)).
								ToList()
						);
			}
		}

		public ActionResult Create()
		{
			return this.View(new Create<%= classname %>ViewModel());
		}

		[HttpPost()]
		public ActionResult Create(Create<%= classname %>ViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			this.
				Bus.
					Send(
						this.
							Mapper.
								Map<Create<%= classname %>Command>(
									model
								)
					);

			return this.RedirectToRoute(Routes.<%= classname %>.Home);
		}

		public ActionResult Edit(Guid id)
		{
			using (UnitOfWork.BeginReadOnly())
			{
				return
					this.
						View(
							this.
								Mapper.
									Map<Edit<%= classname %>ViewModel>(
										Repository<<%= classname %>>.Get(id)
									)
						);
			}
		}

		[HttpPost()]
		public ActionResult Edit(Edit<%= classname %>ViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
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

		public ActionResult Delete(Guid id)
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
	}
}