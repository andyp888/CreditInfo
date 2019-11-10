using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditInfoWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CreditInfoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndividualController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<IndividualController> _logger;

        public IndividualController(ILogger<IndividualController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Individual Search(string nationalId)
        {
            //Poll DB for individual with provided nationalId
            bool individualExists = false;

            if (individualExists)
            {
                return new Individual();
            }

            else
            {
                return null;
            }
        }

        [HttpGet]
        public Individual Detail(string nationalId)
        {
            //Poll DB for individual with provided nationalId
            return new Individual();
        }
    }
}
