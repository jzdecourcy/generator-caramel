using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace GPStrategies.AcademicAdvising.Entities.Mapping.Conventions
{
	public class BinaryPropertyTypeConvention : IPropertyConvention
	{
		public void Apply(IPropertyInstance instance)
		{
			if (instance.Property.PropertyType == typeof(byte[]))
			{
				instance.
					CustomSqlType("varbinary(max)");

				instance.
					Length(Int32.MaxValue);

				instance.
					LazyLoad();
			}
		}
	}
}
