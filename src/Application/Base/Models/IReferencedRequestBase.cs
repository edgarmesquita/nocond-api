namespace NoCond.Application.Base.Models
{
    public interface IReferencedRequestBase<TReferenceKey>
    {
        void SetReferenceId (TReferenceKey referenceKey);
        TReferenceKey GetReferenceId ();
    }
}