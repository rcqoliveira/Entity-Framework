using Microsoft.EntityFrameworkCore;
using RC.EntityFramework.Api.Core;
using RC.EntityFramework.Api.Core.Domains.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RC.EntityFramework.Api.Infrastructure.Data.EntityFramework.Context
{
    public class DBContextApplication : DBContextBase
    {

        public virtual DbSet<Product> Products { get; set; }

        public DBContextApplication(ConfigurationApplication configurationApplication) : base(configurationApplication)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var type in GetTypesConfiguration())
            {
                dynamic configuration = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configuration);
            }
        }

        private IEnumerable<Type> GetTypesConfiguration()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
        }
    }
}