using GamerLibrary.Common.Domain;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace GamerLibrary.Common.API.Extensions
{
    public static class ProblemDetailsOptionsExtensions
    {
        public static void ConfigureProblemDetails(this ProblemDetailsOptions options, IWebHostEnvironment webHostEnvironment)
        {
            // Exception details only for development an environment
            options.IncludeExceptionDetails = (ctx, ex) => webHostEnvironment.IsDevelopment();

            options.MapException<NotFoundException>(StatusCodes.Status404NotFound);

            options.MapException<Exception>(StatusCodes.Status500InternalServerError);
        }

        public static void MapException<TException>(this ProblemDetailsOptions options, int statusCode) 
            where TException : Exception
        {
            options.Map<TException>(exception =>
            {
                var error = StatusCodeProblemDetails.Create(statusCode);
                error.Type = exception.GetType().Name;
                error.Detail = exception.Message;
                return error;
            });
        }
    }
}
