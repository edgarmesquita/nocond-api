using System.Collections.Generic;

namespace NoCond.Application.Base.Models
{
    /// <summary>
    /// Error Result
    /// </summary>
    public class ErrorResult
    {
        public string Message { get; set; }
        public List<string> Errors { get; } = new List<string>(); 
    }
}