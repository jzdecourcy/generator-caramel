using System;
using Caramel.Entities;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace GPStrategies.AcademicAdvising.Entities.Mapping.Conventions
{
	public class NamedEntityCachingConvention : IClassConvention
	{
		public void Apply(IClassInstance instance)
		{
			if (typeof(NamedEntity<Guid?>).IsAssignableFrom(instance.EntityType))
			{
				instance.
					Cache.
					NonStrictReadWrite();
			}
		}
	}
}
