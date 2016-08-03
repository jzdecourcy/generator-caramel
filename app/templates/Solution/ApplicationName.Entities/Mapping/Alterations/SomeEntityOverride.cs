using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace <%= basenamespace %>.Entities.Mapping.Alterations
{
	public class SomeEntityOverride : IAutoMappingOverride<SomeEntity>
	{
		public void Override(AutoMapping<SomeEntity> mapping)
		{
		}
	}
}
