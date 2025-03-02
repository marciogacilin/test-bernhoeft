using Microsoft.AspNetCore.Mvc.Filters;

namespace Bernhoeft.GRT.Teste.Api.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FluentValidation.ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

            var result = new ObjectResult(new { Errors = errors })
            {
                StatusCode = 400, // Bad Request
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
