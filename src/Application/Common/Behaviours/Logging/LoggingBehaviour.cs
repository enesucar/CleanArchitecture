using Application.Interfaces.Services;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours.Logging
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        private readonly ILogger _logger;
        private readonly IDateTimeService _dateTimeService;

        public LoggingBehaviour(ILogger<TRequest> logger, IDateTimeService dateTimeService)
        {
            _logger = logger;
            _dateTimeService = dateTimeService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("{DateTime} CleanArchitecture Request: {Name}", _dateTimeService.Now, requestName);
            return await next();
        }
    }
}
