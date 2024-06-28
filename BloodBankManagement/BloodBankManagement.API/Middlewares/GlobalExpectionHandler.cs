using BloodBankManagement.Application.Features.Common.Result;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace BloodBankManagement.API.Middlewares
{
    public class GlobalExpectionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExpectionHandler> _logger;
        public GlobalExpectionHandler(ILogger<GlobalExpectionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Exception occured: \n{Message}", exception.Message);

            var errorModel = new ErrorModel(
                    ErrorEnum.InternalServerError,
                    ErrorEnum.InternalServerError.ToString(),
                    "Unexpected behavior, call admin."
                    //exception.Message
                    );

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(errorModel, cancellationToken);

            return true;
        }
    }
}
