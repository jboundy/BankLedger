using BankLedger.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Web.Components
{
    public class BalanceComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ActiveAccount account)
        {
            return View("BalanceComponent", account);
        }
    }
}
