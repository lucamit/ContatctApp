using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Data.Access.Maps;
using Contacts.Data.Model;

namespace Contacts.Data.Access.DAL
{
    public class AppDbContext: DbContext
    {
       // public DbSet<Contact> Contacts { get; set; }


        public AppDbContext()
            : base("AppDbContext")
        {
             Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<DbContext>());
             //Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var assembly = typeof(ContactMap).Assembly.DefinedTypes;
            //var imaptypes = assembly.Where(x => x.IsAssignableFrom(typeof(IMap)));
            //var modelsToMap = imaptypes.Where(x=>x.IsClass)
            //    .Select(x=>(IMap) Activator.CreateInstance(x));

            var configurators = typeof(IMap);

            var types = typeof(IMap).Assembly.GetTypes()
                .Where(p => configurators.IsAssignableFrom(p) && !p.IsInterface)
                    .Select(x => (IMap)Activator.CreateInstance(x)).ToList();
            foreach (var model in types)
            {
                model.Visit(modelBuilder);
            }
        }
    }
}
