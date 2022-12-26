using System;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Unit.Models
{
    public class UnitRequest : IReferencedRequestBase<Guid>
    {
        private Guid unitGroupId;
        
        public int Floor { get; set; }
        public FloorType FloorType { get; set; }
        public string Block { get; set; }
        public string BlockDescription { get; set; }
        public string Side { get; set; }
        public string Code { get; set; }
        public string CodePrefix { get; set; }
        public string CodeSuffix { get; set; }
        
        public Guid UnitTypeId { get; set; }
        
        public void SetReferenceId(Guid referenceKey)
        {
            unitGroupId = referenceKey;
        }

        public Guid GetReferenceId()
        {
            return unitGroupId;
        }
    }
}