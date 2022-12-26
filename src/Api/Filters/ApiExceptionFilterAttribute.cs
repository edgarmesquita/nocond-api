using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NoCond.Application.Base.Exceptions;
using NoCond.Application.Extensions;

namespace NoCond.Api.Filters
{
    /// <summary>
    /// Api Exception Filter Attribute
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// On Exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            HandleException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NoDataFoundException _:
                    context.Result = new NoContentResult();
                    break;
                case ConflictException ex:
                    context.Result = new ObjectResult(ex.ToErrorResult())
                    {
                        StatusCode = StatusCodes.Status409Conflict
                    };
                    break;
                case AggregateException _:
                    ProcessAggregatedException(context);
                    break;

                default:
                    context.Result = new ObjectResult(context.Exception.ToErrorResult())
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                    break;
            }
        }
        
        private void ProcessAggregatedException(ExceptionContext context)
        {
            var innerEx = context.Exception.GetBaseException();
            if (innerEx is AggregateException aggregateException)
            {
                context.Exception = new Exception(aggregateException.Message);
                HandleException(context);
            }
            else
            {
                context.Exception = innerEx;
                HandleException(context);
            }
        }
    }
}