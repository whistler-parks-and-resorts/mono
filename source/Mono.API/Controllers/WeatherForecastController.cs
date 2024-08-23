// <copyright file="WeatherForecastController.cs" company="Whistler Parks &amp; Resorts LLC">
// Copyright (c) Whistler Parks &amp; Resorts LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace Mono.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        /// <summary>
        /// Gets a weather forecast.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/>.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok(Summaries[new Random().Next(0, Summaries.Length - 1)]);
        }
    }
}
