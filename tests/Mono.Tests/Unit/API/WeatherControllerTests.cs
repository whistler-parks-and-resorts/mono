// <copyright file="WeatherControllerTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Mono.API.Controllers;

namespace Mono.Tests.Unit.API
{
    /// <summary>
    /// Tests for the <see cref="WeatherForecastController"/> class.
    /// </summary>
    [TestClass]
    public class WeatherControllerTests
    {
        /// <summary>
        /// Action returns the correct type.
        /// </summary>
        [TestMethod]
        public void Get_HasCorrectReturnType()
        {
            var controller = new WeatherForecastController();

            var result = controller.Get();

            Assert.IsInstanceOfType<OkObjectResult>(result);
        }
    }
}
