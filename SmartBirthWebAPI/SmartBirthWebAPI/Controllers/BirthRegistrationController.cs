using System.Web.Http;
using SmartBirthWebAPI.DAL;
using SmartBirthWebAPI.Models;
using System.Collections.Generic;
using System;

namespace SmartBirthWebAPI.Controllers
{
    public class BirthRegistrationController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new BirthRegistrationDAL().List());
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                BirthRegistrationDAL dal = new BirthRegistrationDAL();
                BirthRegistration BirthRegistration = dal.Find(id);
                return Ok(BirthRegistration);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] BirthRegistration BirthRegistration)
        {
            try
            {
                BirthRegistrationDAL dal = new BirthRegistrationDAL();
                dal.Insert(BirthRegistration);

                string location =
                    Url.Link("DefaultApi",
                    new { controller = "birthRegistration", id = BirthRegistration.BirthRegistrationCode });

                return Created(new Uri(location), BirthRegistration);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                BirthRegistrationDAL dal = new BirthRegistrationDAL();
                dal.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put([FromBody] BirthRegistration birthRegistration)
        {
            try
            {
                BirthRegistrationDAL dal = new BirthRegistrationDAL();
                dal.Update(birthRegistration);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}