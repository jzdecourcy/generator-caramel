using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Configuration;
using NHibernate.Cfg;
using NHibernate.Event;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using Caramel.Entities;
using Caramel.NHibernate.Configuration;
using Caramel.FluentNHibernate;
using Caramel.FluentNHibernate.Conventions;
//using <%= basenamespace %>.Entities.Event;
using <%= basenamespace %>.Entities.Mapping.Alterations;
//using <%= basenamespace %>.Entities.Mapping.Conventions;

namespace <%= basenamespace %>.Entities.Mapping
{
	public static class FluentConfigurationExtensions
	{
		public static FluentConfiguration ConfigureEntities(this FluentConfiguration configuration)
		{
			return
				configuration.
					ConfigureEntities(
						MsSqlConfiguration.
							MsSql2008.
							//AdoNetBatchSize(100).
							ConnectionString(
								cs =>
									cs.
										FromConnectionStringWithKey("<%= applicationName %>")
							)
					);
		}

		public static FluentConfiguration ConfigureEntities(this FluentConfiguration configuration, IPersistenceConfigurer persistenceConfigurer)
		{
			var model =
				AutoMap.
					AssemblyOf<SomeEntity>(new CaramelAutomappingConfiguration()).										
					Conventions.
					Add<PrimaryKeyConvention>().
					Conventions.
					Add(new DefaultStringLengthConvention(256)).
					Conventions.
					Add<NamedEntityUniqueNameConvention>().
					Conventions.
					Add<HasManyToManyTableNamingConvention>().
					Conventions.
					Add<ReferencesNotNullableConvention>().
					//Conventions.
					//Add<<%= basenamespace %>.Entities.Mapping.Conventions.ForeignKeyNamingConvention>().
					Conventions.
					AddFromAssemblyOf<SomeEntity>().
					UseOverridesFromAssemblyOf<SomeEntity>();

			configuration.
				Database(
					persistenceConfigurer
				).
				Mappings(
					m =>
					{
						m.
							AutoMappings.
								Add(
									model
								);
					}
				).
				CurrentSessionContext<NHibernate.Context.CallSessionContext>().
				ExposeConfiguration(
					c =>
					{
						c.
							SetProperty(NHibernate.Cfg.Environment.BatchSize, 64.ToString()).
							SetProperty(NHibernate.Cfg.Environment.DefaultBatchFetchSize, 128.ToString()).
							//SetProperty(NHibernate.Cfg.Environment.UseQueryCache, true.ToString()).
							SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, true.ToString()).
							SetProperty(NHibernate.Cfg.Environment.UseSecondLevelCache, true.ToString()).
							Cache(
								s =>
								{
									//s.Provider<NHibernate.Caches.SysCache.SysCacheProvider>();
									//s.UseQueryCache = true;
									//s.DefaultExpiration = 6000;
								}
							);
					}
				).
				BuildConfiguration();

				return configuration;
		}
	}
}
