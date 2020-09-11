using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deploy.core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace deploy.core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeployController : ControllerBase
    {
        private readonly IDeployService _service;
        private readonly IConfiguration _config;

        public DeployController(IDeployService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string apiToken)
        {
            if (_config["ApiToken"] == apiToken)
                _service.RunUpdate();
            else
                return Unauthorized();

            return Ok();
        }
    }
}