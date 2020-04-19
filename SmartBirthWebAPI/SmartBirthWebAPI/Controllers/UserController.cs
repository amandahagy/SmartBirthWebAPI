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
    }
}