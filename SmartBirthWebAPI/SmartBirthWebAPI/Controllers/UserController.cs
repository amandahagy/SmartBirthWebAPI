using System.Web.Http;
using SmartBirthWebAPI.Models;
using SmartBirthWebAPI.DAL;
using System.Collections.Generic;

namespace SmartBirthWebAPI.Controllers
{
    public class UserController : ApiController
    {
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