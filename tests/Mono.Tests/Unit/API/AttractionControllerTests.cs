// <copyright file="AttractionControllerTests.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Mono.API.Controllers;

namespace Mono.Tests.Unit.API
{
    /// <summary>
    /// Tests for the <see cref="AttractionController"/> class.
    /// </summary>
    [TestClass]
    public class AttractionControllerTests
    {
        /// <summary>
        /// Action returns the correct type.
        /// </summary>
        [TestMethod]
        public void Get_HasCorrectReturnType()
        {
            var controller = new AttractionController();

            var result = controller.GetStatus(Guid.NewGuid());

            Assert.IsInstanceOfType<OkObjectResult>(result);
        }
    }
}
