using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using APIModels.General;
using MalcoCorporateAPIBusinessRules.General;
using MalcoCorporateFramawork.Generics;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MalcoCorporateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        // POST api/<LoginController>/Login
        [HttpPost("Login")]
        public ActionResult Login([FromBody] JsonElement body)
        {
            try
            {
                string json = GenericFunctions.ConvertToJson(body);
                Profile NewEntity = GenericFunctions.ConvertJsonToObject<Profile>(json);

                Login BRLogin = new Login();
                if (BRLogin.UserCanDoLogin(NewEntity.Email, NewEntity.Password))
                {
                    return Ok(NewEntity.Email);
                }
                else
                {
                    return BadRequest(BRLogin.GetErrors());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
