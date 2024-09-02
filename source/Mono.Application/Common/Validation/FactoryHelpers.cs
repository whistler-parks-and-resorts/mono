// <copyright file="FactoryHelpers.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Mono.Application.Common.Validation
{
    /// <summary>
    /// Common factory functions.
    /// </summary>
    public static class FactoryHelpers
    {
        /// <summary>
        /// Attempts to instantiate an object and returns a validation result.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="creationFunc">The creation function to attempt.</param>
        /// <returns>A <see cref="ValidationEnvelope{TEntity}"/>.</returns>
        public static ValidationEnvelope<TEntity> TryValidate<TEntity>(Func<TEntity> creationFunc)
        {
            TEntity entity;

            try
            {
                entity = creationFunc.Invoke();
            }
            catch (ValidationException)
            {
                return ValidationEnvelope<TEntity>.Failure();
            }

            return ValidationEnvelope<TEntity>.Success(entity);
        }
    }
}
