using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Access.Maps
{
    public interface IMap
    {
        void Visit(DbModelBuilder modelBuilder);
    }
}
