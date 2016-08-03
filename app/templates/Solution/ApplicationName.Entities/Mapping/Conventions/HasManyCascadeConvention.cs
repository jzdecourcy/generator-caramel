using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace GPStrategies.AcademicAdvising.Entities.Mapping.Conventions
{
	public class HasManyCascadeConvention : IHasManyConvention
	{
		public void Apply(IOneToManyCollectionInstance instance)
		{
			instance.
				Cascade.
				AllDeleteOrphan();
		}
	}
}
