namespace Oisys.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}