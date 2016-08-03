using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace GPStrategies.AcademicAdvising.Entities.Mapping.Conventions
{
	public class ForeignKeyNamingConvention : ForeignKeyConvention
	{
		protected override string GetKeyName(Member property, System.Type type)
		{
			//if (property != null)
			//{
			//	return property.Name + "ID";
			//}
			//else
			//{
				return type.Name + "ID";
			//}
		}
	}
}
