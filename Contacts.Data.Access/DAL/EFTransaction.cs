using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data.Access.DAL
{
    public class EFTransaction :ITransaction
    {
        private DbContextTransaction _dbContextTranaction;

        public EFTransaction(DbContext dbContext)
        {

            if(dbContext.Database.CurrentTransaction == null)
                _dbContextTranaction = dbContext.Database.BeginTransaction();
        }
        public void Commit()
        {

            _dbContextTranaction.Commit();

        }

        public void Rollback()
        {
            _dbContextTranaction.Rollback();

        }

        public void Dispose()
        {
            _dbContextTranaction.Dispose();
        }
    }
}
