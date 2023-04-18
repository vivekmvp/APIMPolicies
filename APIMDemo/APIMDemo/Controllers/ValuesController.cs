using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIMDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetValues")]
        public ActionResult GetValues()
        {
            //Make a random failure
            Random rnd = new Random();
            int num = rnd.Next(1, 3);

            if (num % 2 == 0)
            {
                try
                {                    
                    throw new Exception("An error has occurred.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error {ex}");
                    return BadRequest($"Error {ex.Message}");
                }
            }                
            else
            {
                var result = new List<string>
                {
                    "One", "Two", "Three", "Four", "Five",
                    "Six", "Seven", "Eight", "Nine", "Ten"
                };

                _logger.LogInformation($"Info {result}");
                return Ok(result);
            }            
        }


        [HttpPost(Name = "PostValues")]
        public ActionResult PostValues(List<string> lstValues)
        {
            //Make a random failure
            Random rnd = new Random();
            int num = rnd.Next(1, 3);

            if (num % 2 == 0)
            {
                try
                {
                    throw new Exception("An error has occurred.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error {ex}");
                    return BadRequest($"Error {ex.Message}");
                }
            }
            else
            {
                //Do Post Operation work here
                _logger.LogInformation($"Info: Post Operation successful");
                return Ok("Info: Post Operation successful");
            }
        }
    }
}
