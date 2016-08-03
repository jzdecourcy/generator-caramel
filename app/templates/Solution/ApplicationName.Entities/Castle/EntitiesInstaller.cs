using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Caramel.FluentNHibernate;
using Caramel.NHibernate.Castle;
using <%= basenamespace %>.Entities.Mapping;

namespace <%= basenamespace %>.Entities.Castle
{
	public class EntitiesInstaller : IWindsorInstaller
	{
		public EntitiesInstaller()
			: this(
				MsSqlConfiguration.
					MsSql2008.
					ConnectionString(c => c.FromConnectionStringWithKey("<%= applicationName %>"))
			)
		{
		}

		public EntitiesInstaller(IPersistenceConfigurer persistenceConfigurer)
		{
			this.PersistenceConfigurer = persistenceConfigurer;
		}

		public IPersistenceConfigurer PersistenceConfigurer { get; private set; }

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			var configuration =
				Fluently.
					Configure().
					ConfigureEntities(
						this.PersistenceConfigurer
					).
					ConfigureListeners().
					//ExposeConfiguration(
					//	c =>
					//	{
					//		c.EventListeners.PreInsertEventListeners = new NHibernate.Event.IPreInsertEventListener[] { new PreInsertEntityEventListener() };
					//		//c.EventListeners.PreUpdateEventListeners = new NHibernate.Event.IPreUpdateEventListener[] { new PreUpdateEntityEventListener() };
					//	}
					//).
					BuildConfiguration();

			container.
				Install(
					new NHibernateInstaller(
						configuration
					)
				);
		}

		//public class PreInsertEntityEventListener : NHibernate.Event.IPreInsertEventListener
		//{
		//	#region IPreInsertEventListener Members

		//	public virtual bool OnPreInsert(NHibernate.Event.PreInsertEvent @event)
		//	{
		//		var immutable = @event.Entity as Caramel.Entities.IImmutable;

		//		if (immutable == null)
		//		{
		//			return false;
		//		}

		//		var created = Caramel.SystemTime.Now;
		//		var createdBy = Caramel.CurrentUser.Name;

		//		if (@event.Persister.PropertyNames.Contains("Created"))
		//		{
		//			@event.State[Array.IndexOf(@event.Persister.PropertyNames, "Created")] = created;
		//		}

		//		if (@event.Persister.PropertyNames.Contains("CreatedBy"))
		//		{
		//			@event.State[Array.IndexOf(@event.Persister.PropertyNames, "CreatedBy")] = createdBy;
		//		}

		//		immutable.Created = created;
		//		immutable.CreatedBy = createdBy;

		//		return false;
		//	}

		//	#endregion
		//}
	}
}
