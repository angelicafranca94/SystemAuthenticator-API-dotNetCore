using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Exceptions;

namespace SystemAuthenticator.ExceptionMiddleware;

public class ExceptionMiddleware : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        HttpStatusCode statusCode = context.Exception switch
        {
            BadRequestException => HttpStatusCode.BadRequest,
            NotFoundException => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };

        NotificationResultDto<string> apiResponse = new NotificationResultDto<string>(false, context.Exception.Message, string.Empty, statusCode, null);


        context.Result = new JsonResult(apiResponse) { StatusCode = (int)statusCode };
    }
}
