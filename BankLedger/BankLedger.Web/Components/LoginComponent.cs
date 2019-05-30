using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Web.Components
{
    public class LoginComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("LoginComponent");
        }
    }
}
