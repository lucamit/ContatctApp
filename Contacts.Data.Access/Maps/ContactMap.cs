using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Data.Model;

namespace Contacts.Data.Access.Maps
{
    public class ContactMap :IMap
    {

        public void Visit(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contacts").HasKey(x => x.Id);
        }
    }
}
