// <copyright file="ValidationEnvelope.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

namespace Mono.Application.Common.Validation
{
    /// <summary>
    /// A wrapper for an entity and the validation result.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class ValidationEnvelope<TEntity>
    {
        private ValidationEnvelope(bool failure, TEntity entity)
        {
            IsInvalid = failure;
            Entity = entity;
        }

        /// <summary>
        /// Gets get the entity.
        /// </summary>
        public TEntity Entity { get; }

        /// <summary>
        /// Gets a value indicating whether the validation result failed.
        /// </summary>
        public bool IsInvalid { get; }

        /// <summary>
        /// Instantiates a success response.
        /// </summary>
        /// <param name="entity">The entity for the validation result.</param>
        /// <returns>An envelope object.</returns>
        public static ValidationEnvelope<TEntity> Success(TEntity entity)
        {
            return new ValidationEnvelope<TEntity>(false, entity);
        }

        /// <summary>
        /// Instantiates a failed response. We suppress the nullability here because it will never be used.
        /// </summary>
        /// <returns>An envelope object.</returns>
        public static ValidationEnvelope<TEntity> Failure()
        {
            return new ValidationEnvelope<TEntity>(true, default!);
        }
    }
}
