using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Data.Model;


namespace Contacts.Queries
{
    public interface IContactQueryProcessor
    {
        IQueryable<Contact> Get();
        Contact Get(long id);
        Contact Create(Contact contactModel);
        Contact Update(Contact contactModel);
        void Delete(long id);

    }
}
