using System;
using System.Linq;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Extensions
{
    public static class ExceptionExtensions
    {
        public static ErrorResult ToErrorResult(this Exception exception)
        {
            var result = new ErrorResult();
            switch (exception)
            {
                case AggregateException aggregateException :
                    ProcessAggregatedException(result, aggregateException);
                    break;
                default:
                    result.Errors.Add(exception.Message);
                    break;
            }

            result.Message = result.Errors.LastOrDefault();
            return result;
        }
        
        private static void ProcessAggregatedException(ErrorResult result, AggregateException aggregateException)
        {
            var innerEx = aggregateException.GetBaseException();
            result.Errors.Add(innerEx.Message);
            if (innerEx is AggregateException aggregateEx)
            {
                ProcessAggregatedException(result, aggregateEx);
            }
        }
    }
}
