using Microsoft.AspNetCore.Mvc;

namespace BookRent.AuthenticationService.Controllers
{

    [ApiController]
    [Route("/auth")]
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public async Task GetJWT([FromBody] string username, [FromBody] string Password)
        {
            
        }
    }
}
