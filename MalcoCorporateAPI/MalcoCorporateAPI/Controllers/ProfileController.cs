using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using APIBusinessRules.General;
using APIModels;
using APIModels.General;
using MalcoCorporateFramawork.Generics;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MalcoCorporateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        DBConnection Context;

        public ProfileController():base()
        {
            this.Context = new DBConnection();
        }

        // GET: api/<ProfileController>
        [HttpGet]
        public ActionResult Get()
        {
            //Debug.WriteLine("ProfileController - Get()");

            List<string> Profiles = new List<string>();

            foreach (Profile item in this.Context.Profiles.ToList())
            {
                Profiles.Add(GenericFunctions.ConvertToJson(item));
            }

            return Ok(Profiles);
        }

        // GET api/<ProfileController>Email=email@gmail.com
        [HttpGet("ByEmail")]
        public ActionResult Get(string Email)
        {
            try
            {
                //Debug.WriteLine("ProfileController - Get(string Email) - El email es " + Email);

                Profile Element = this.Context.Profiles.Where(i => i.Email.Equals(Email)).FirstOrDefault();

                if (Element != null)
                    return Ok(GenericFunctions.ConvertToJson(Element));
                else
                    return NotFound(Email);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST api/<ProfileController>/Registro
        [HttpPost("Registro")]
        public ActionResult Registro([FromBody] JsonElement body)
        {
            try
            {
                string json = GenericFunctions.ConvertToJson(body);
                Profile NewEntity = GenericFunctions.ConvertJsonToObject<Profile>(json);

                Registration BRRegistration = new Registration(NewEntity);
                if (BRRegistration.IsValid())
                {
                    BRRegistration.Save();
                    return Ok(BRRegistration.GetUserProfileAnalized());
                }
                else
                {
                    return BadRequest(BRRegistration.GetErrors());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProfileController>/email@gmail.com
        [HttpPut("Update")]
        public ActionResult Update(string Email, [FromBody] JsonElement body)
        {
            try
            {
                string json = GenericFunctions.ConvertToJson(body);
                Profile NewEntity = GenericFunctions.ConvertJsonToObject<Profile>(json);
                NewEntity.Email = Email;

                Registration BRRegistration = new Registration(NewEntity);
                if (BRRegistration.IsValid())
                {
                    BRRegistration.Update();
                    return Ok(BRRegistration.GetUserProfileAnalized());
                }
                else
                {
                    return BadRequest(BRRegistration.GetErrors());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProfileController>/email@gmail.com
        [HttpDelete("Delete")]
        public ActionResult Delete(string Email)
        {
            try
            {
                Profile NewEntity = new Profile
                {
                    Email = Email
                };

                Registration BRRegistration = new Registration(NewEntity);
                BRRegistration.DisableProfile();
 
                return Ok(Email);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
