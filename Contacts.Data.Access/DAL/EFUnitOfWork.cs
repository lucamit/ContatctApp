using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Access.DAL
{
    public class EFUnitOfWork :IUnitOfWork
    {
        private readonly Func<DbContext> _dbContext;
        private ITransaction transaction;
        
        public EFUnitOfWork(Func<DbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public EFUnitOfWork()
        {
            var appContext = new AppDbContext();
            _dbContext = () => appContext;
           
        }

        public ITransaction BeginTransaction()
        {
            transaction = new EFTransaction(_dbContext());
            return transaction;
        }

        public void Add<T>(T objectToAdd) where T : class
        {
            var set = _dbContext().Set<T>();
            set.Add(objectToAdd);
            _dbContext().SaveChanges();
            
        }

        public void Update<T>(T objectToUpdate) where T : class
        {
            var set = _dbContext().Set<T>();
            set.Attach(objectToUpdate);
            _dbContext().Entry(objectToUpdate).State = EntityState.Modified;
            _dbContext().SaveChanges();
        }

        public void Remove<T>(T objectToRemove) where T : class
        {
            var set = _dbContext().Set<T>();
            set.Remove(objectToRemove);
            _dbContext().SaveChanges();
        }

        public void Attach<T>(T objectToAttach) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext().SaveChanges();
            _dbContext().Dispose();
        }


        public IQueryable<T> Query<T>() where T : class
        {
            return _dbContext().Set<T>();
        }

        private void Commit()
        {
            transaction.Commit();
            
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
    }
}
