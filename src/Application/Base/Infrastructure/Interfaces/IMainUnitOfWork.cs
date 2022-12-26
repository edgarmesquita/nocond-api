using eQuantic.Core.Data.Repository;

namespace NoCond.Application.Base.Infrastructure.Interfaces
{
    public interface IMainUnitOfWork : IQueryableUnitOfWork
    {
        IAsyncRelationalRepository<IMainUnitOfWork, TEntity, TKey> GetAsyncRelationalRepository<TEntity, TKey> () where TEntity : class, IEntity, new ();

        IAsyncRepository<IMainUnitOfWork, TEntity, TKey> GetAsyncRepository<TEntity, TKey> () where TEntity : class, IEntity, new ();

        IRelationalRepository<IMainUnitOfWork, TEntity, TKey> GetRelationalRepository<TEntity, TKey> () where TEntity : class, IEntity, new ();

        IRepository<IMainUnitOfWork, TEntity, TKey> GetRepository<TEntity, TKey> () where TEntity : class, IEntity, new ();
    }
}