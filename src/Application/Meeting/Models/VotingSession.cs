using System;

namespace NoCond.Application.Meeting.Models
{
    public class VotingSession
    {
        public Guid Id { get; set; }
        
        public string Description { get; set; }
        
        public int Order { get; set; }
        
        public DateTime StartsOn { get; set; }

        public DateTime EndsOn { get; set; }
    }
}