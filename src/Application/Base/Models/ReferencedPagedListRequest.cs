namespace NoCond.Application.Base.Models
{
    public class ReferencedPagedListRequest<TReferenceKey> : PagedListRequest, IReferencedRequestBase<TReferenceKey>
    {
        private TReferenceKey referenceId;

        public TReferenceKey GetReferenceId ()
        {
            return referenceId;
        }

        public void SetReferenceId (TReferenceKey referenceKey)
        {
            referenceId = referenceKey;
        }
    }
}