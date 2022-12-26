using eQuantic.Core.Data.Repository;

namespace NoCond.Application.Base.Models
{
    public interface IEntityBase<TKey> : IEntity
    {
        TKey Id { get; set; }
    }
}