using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;


namespace WebApiExample.Controllers
{
    public class UserController : ApiController
    {

		[AllowAnonymous]
		[HttpGet]
		[Route("api/data/forall")]
		public IHttpActionResult Get()
		{
            var token = ActionContext.Request.Headers.Authorization.Parameter;

            return Ok("now server time is " + DateTime.Now.ToString());
		}

        [AllowAnonymous]
        [HttpPost]
        [Route("api/data/getToken")]
        public IHttpActionResult GetToken() {

            var identity = (ClaimsIdentity)User.Identity; 
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            identity.AddClaim(new Claim("username", "user"));
            identity.AddClaim(new Claim(ClaimTypes.Name, "Hello user"));



            return Ok("did it work? ");
            
        }

		[Authorize]
        [HttpGet] 
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate() { 
        
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }
    }
}