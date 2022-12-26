using System.Threading.Tasks;
using Unosquare.Tubular;

namespace NoCond.Application.Base.Services.Interfaces
{
    /// <summary>
    /// Grid crud service.
    /// </summary>
    /// <seealso cref="ICrudService{TRequestDto, TDto, TKey, TReferenceKey}" />
    public interface IGridCrudService<in TRequestDto, TDto, TKey, TReferenceKey> : ICrudService<TRequestDto, TDto, TKey, TReferenceKey>
    {

        /// <summary>
        /// Gets grid data response.
        /// </summary>
        Task<GridDataResponse> GetAsync (TReferenceKey referenceId, GridDataRequest dto);

    }
    /// <summary>
    /// Grid crud service.
    /// </summary>
    /// <seealso cref="ICrudService{TRequestDto, TDto, TKey}" />
    public interface IGridCrudService<in TRequestDto, TDto, TKey> : ICrudService<TRequestDto, TDto, TKey>
    {

        /// <summary>
        /// Gets grid data response.
        /// </summary>
        Task<GridDataResponse> GetAsync (GridDataRequest dto);

    }
}