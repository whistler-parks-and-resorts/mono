// <copyright file="GlobalExceptionHandler.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mono.Infrastructure.ErrorHandling.GlobalException
{
    /// <inheritdoc />
    public class GlobalExceptionHandler : INotificationHandler<GlobalExceptionOccurred>
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
        {
            _logger.LogError(notification.Exception, "A global exception occurred at: {dateTime}", notification.DateTime);

            return Task.CompletedTask;
        }
    }
}
