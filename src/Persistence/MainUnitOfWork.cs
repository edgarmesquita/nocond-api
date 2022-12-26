using eQuantic.Core.Data.EntityFramework.Repository;
using eQuantic.Core.Data.Repository;
using Lamar;
using NoCond.Application.Base.Infrastructure;
using NoCond.Application.Base.Infrastructure.Interfaces;

namespace NoCond.Persistence
{
    public class MainUnitOfWork : UnitOfWork, IMainUnitOfWork
    {
        private readonly IContainer container;
        private readonly MainContext dbContext;

        public MainUnitOfWork (MainContext dbContext, IContainer container) : base (dbContext)
        {
            this.dbContext = dbContext;
            this.container = container;
        }

        public override TRepository GetRepository<TRepository> ()
        {
            return container.GetInstance<TRepository> ();
        }

        public override TRepository GetRepository<TRepository> (string name)
        {
            return container.GetInstance<TRepository> (name);
        }

        IAsyncRelationalRepository<IMainUnitOfWork, TEntity, TKey> IMainUnitOfWork.GetAsyncRelationalRepository<TEntity, TKey> ()
        {
            return new AsyncRelationalRepository<IMainUnitOfWork, TEntity, TKey> (this);
        }

        IAsyncRepository<IMainUnitOfWork, TEntity, TKey> IMainUnitOfWork.GetAsyncRepository<TEntity, TKey> ()
        {
            return new AsyncRepository<IMainUnitOfWork, TEntity, TKey> (this);
        }

        IRelationalRepository<IMainUnitOfWork, TEntity, TKey> IMainUnitOfWork.GetRelationalRepository<TEntity, TKey> ()
        {
            return new RelationalRepository<IMainUnitOfWork, TEntity, TKey> (this);
        }

        IRepository<IMainUnitOfWork, TEntity, TKey> IMainUnitOfWork.GetRepository<TEntity, TKey> ()
        {
            return new Repository<IMainUnitOfWork, TEntity, TKey> (this);
        }
    }
}