using Microsoft.AspNetCore.Mvc;

namespace TakeAway.SignalR.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }
    }
}
