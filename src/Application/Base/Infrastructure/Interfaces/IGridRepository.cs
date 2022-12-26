using Unosquare.Tubular;

namespace NoCond.Application.Base.Infrastructure.Interfaces
{
    public interface IGridRepository
    {
        GridDataResponse GetPaged(GridDataRequest request);
    }
}