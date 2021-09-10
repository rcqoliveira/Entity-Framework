using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RC.EntityFramework.Api.Core.Interface.Context;

namespace RC.EntityFramework.Api.Infrastructure.Data.EntityFramework.UoW
{
    public class UnitOfWork : IContext
    {
        private readonly DatabaseFacade database;

        public UnitOfWork(DbContext context)
        {
            this.database = context.Database;
        }

        public void Commit()
        {
            try
            {
                this.database.CommitTransaction();
            }
            catch
            {
                this.database.RollbackTransaction();
                throw;
            }
        }

        public void Rollback() => this.database.RollbackTransaction();
        public void BeginTransaction() => this.database.BeginTransaction();
    }
}