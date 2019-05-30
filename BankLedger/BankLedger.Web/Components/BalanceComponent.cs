using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Web.Components
{
    public class BalanceComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("BalanceComponent");
        }
    }
}
