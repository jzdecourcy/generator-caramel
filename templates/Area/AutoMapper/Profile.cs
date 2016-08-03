using System;
using AutoMapper;
using <%= basenamespace %>.Commands;
using <%= basenamespace %>.Entities;
using <%= basewebnamespace %>.Areas.<%= pluralname %>.Models;

namespace <%= namespace %>
{
	public class <%= classname %>Profile : Profile
	{
		protected override void Configure()
		{
			this.
				CreateMap<Create<%= classname %>ViewModel, Create<%= classname %>Command>();

			this.
				CreateMap<<%= classname %>, Edit<%= classname %>ViewModel>();

			this.
				CreateMap<Edit<%= classname %>ViewModel, Update<%= classname %>Command>().
					ForMember(d => d.<%= classname %>ID, o => o.MapFrom(s => s.ID));

			this.
				CreateMap<<%= classname %>, <%= classname %>ViewModel>();

			this.
				CreateMap<<%= classname %>, <%= classname %>DetailsViewModel>();
				
			this.
				CreateMap<Delete<%= classname %>ViewModel, Delete<%= classname %>Command>().
					ForMember(d => d.<%= classname %>ID, o => o.MapFrom(s => s.ID));				
		}
	}
}