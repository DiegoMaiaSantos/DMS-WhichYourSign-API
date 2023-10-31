using DMS_WhichYourSign_API.Src.Infra.Data.Contexts.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace DMS_WhichYourSign_API.Src.Infra.Data.Contexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WhichYourSignDBContext _whichYourSignDBContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(WhichYourSignDBContext whichYourSignDBContext)
        {
            _whichYourSignDBContext = whichYourSignDBContext;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _whichYourSignDBContext.Database.BeginTransactionAsync();
        }
        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }
        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }
        public void Dispose()
        {
            _transaction?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
