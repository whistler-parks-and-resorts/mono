// <copyright file="GlobalExceptionHandler.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Serilog;

namespace Mono.Infrastructure.ErrorHandling.GlobalException
{
    /// <inheritdoc />
    public class GlobalExceptionHandler : INotificationHandler<GlobalExceptionOccurred>
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger"/> interface.</param>
        public GlobalExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
        {
            _logger.Error(notification.Exception, "A global exception occurred at: {dateTime}", notification.DateTime);

            return Task.CompletedTask;
        }
    }
}
