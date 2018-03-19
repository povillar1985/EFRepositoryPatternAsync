using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using XYZCorp.Core.Repositories;
using XYZCorp.Repository.Repositories;
using XYZCorp.WebApi.Models;

/// <summary>
/// Developer: Peter Gil O. Villar
/// </summary>
namespace XYZCorp.WebApi.Controllers
{
    /// <summary>
    /// Swagger is installed, please run the application and enter the following url
    /// http://localhost:[port]/swagger
    /// </summary>

    //i can simply rename this class to "UsersController" for automatic routing. and no need to explicitly decorate from some actions
    public class ValuesController : ApiController
    {

        static List<User> _users = new List<User>
                    {
                        new User { Id=1, Name="Peter", Points=0 },
                        new User { Id=2, Name="Jonh", Points=1 }
                    };


        private readonly IUserRepository _userRepository;

        public ValuesController()
        {
            _userRepository = new UserRepository();
        }

        // GET api/users
        [HttpGet]
        [Route("api/users")]
        public async Task<IHttpActionResult> Get()
        {
            var users = await _userRepository.GetAllAsync();

            return Ok(users);
        }

        // GET api/users/5
        [HttpGet]
        [Route("api/users/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        [Route("api/users")]
        public IHttpActionResult Post(User user)
        {
            if (user == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            //save here
            _users.Add(user);

            return Ok(user.Id);
        }

        // PUT api/setPoints
        [HttpPut]
        [Route("api/setPoints")]
        public IHttpActionResult Put(User user)
        {
            if (user == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            //update here
            var userFound = _users.Find(x => x.Id == user.Id);

            if (userFound == null)
                return NotFound();

            userFound.Points = user.Points;

            return Ok("Success");
        }

        //////// DELETE api/values/5
        //////public void Delete(int id)
        //////{
        //////}
    }
}
