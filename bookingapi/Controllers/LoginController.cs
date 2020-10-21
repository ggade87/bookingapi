using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookingapi.Classes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
namespace bookingapi.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
            
        }

        [HttpGet("GetUserValidate")]
        public async Task<ActionResult<string>> GetUserValidate(string username,string password)
        {
            string token = "";
            if (Security.Login(username, password))
            {
                token = Security.generateAuthToken(username, password);
            }
            return token;
        }
    }
}
