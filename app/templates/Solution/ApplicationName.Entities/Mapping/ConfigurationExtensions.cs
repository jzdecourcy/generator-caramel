using System;
using System.Linq;
using System.Reflection;
using NHibernate.Mapping.ByCode;

namespace <%= basenamespace %>.Entities.Mapping
{
	public static class ConfigurationExtensions
	{
		public static NHibernate.Cfg.Configuration ConfigureEntities(this NHibernate.Cfg.Configuration configuration)
		{
			var modelMapper = new ModelMapper();

			modelMapper.
				AddMappings(
					Assembly.
						GetExecutingAssembly().
						GetExportedTypes().
						Where(t => t.Name.EndsWith("Mapping"))
				);

			configuration.
				AddMapping(
					modelMapper.
						CompileMappingForAllExplicitlyAddedEntities()
				);

			return configuration;
		}
	}
}
