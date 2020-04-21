using System.Web.Http;
using SmartBirthWebAPI.DAL;
using SmartBirthWebAPI.Models;
using System.Collections.Generic;
using System;

namespace SmartBirthWebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok( new UserDAL().List());
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                UserDAL dal = new UserDAL();
                User User = dal.Find(id);
                return Ok(User);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] User User)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dal.Insert(User);

                string location =
                    Url.Link("DefaultApi",
                    new { controller = "user", id = User.UserCode });

                return Created(new Uri(location), User);
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
                UserDAL dal = new UserDAL();
                dal.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put([FromBody] User user)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dal.Update(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}