using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contacts.Data.Access.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        ITransaction BeginTransaction();
        void Rollback();
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T objectToAdd) where T:class;
        void Update<T>(T objectToUpdate) where T : class;
        void Remove<T>(T objectToRemove) where T : class;
        void Attach<T>(T objectToAttach) where T : class;
    }
}
