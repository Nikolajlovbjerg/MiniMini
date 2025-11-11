using Core;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repo;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/bruger")]
    public class CreateUserController : ControllerBase
    {
        private ICreateUserRepo cUser;

        public CreateUserController(ICreateUserRepo cUser)
        {
            this.cUser = cUser;
        }

        [HttpPost]
        public void Add(User user) 
        {
            cUser.Add(user);
        }

        [HttpGet]
        public IEnumerable<User> GetAll() 
        { 
            return cUser.GetAll();
        }
    }
}
