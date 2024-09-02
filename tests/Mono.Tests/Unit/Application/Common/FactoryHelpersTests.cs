// <copyright file="FactoryHelpersTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using FluentValidation;
using Mono.Application.Common.Validation;

namespace Mono.Tests.Unit.Application.Common
{
    /// <summary>
    /// Tests for the <see cref="FactoryHelpers"/> class.
    /// </summary>
    [TestClass]
    public class FactoryHelpersTests
    {
        /// <summary>
        /// Validation exception returns the correct response.
        /// </summary>
        /// <exception cref="ValidationException">Expected to be thrown when validation fails.</exception>
        [TestMethod]
        public void EntityException_ReturnsCorrectResponse()
        {
            var result = FactoryHelpers.TryValidate<string>(() => throw new ValidationException(string.Empty));

            Assert.IsTrue(result.IsInvalid);
            Assert.IsNull(result.Entity);
        }

        /// <summary>
        /// Successful creation returns correct response.
        /// </summary>
        [TestMethod]
        public void EntitySuccess_ReturnsCorrectResponse()
        {
            const string expected = "result";

            var result = FactoryHelpers.TryValidate(() => expected);

            Assert.IsFalse(result.IsInvalid);
            Assert.AreEqual(expected, result.Entity);
        }
    }
}
