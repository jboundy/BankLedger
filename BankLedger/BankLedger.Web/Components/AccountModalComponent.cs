using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Web.Components
{
    public class AccountModalComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(@"~/Views/Shared/Components/LoginComponent/AccountModal.cshtml");
        }
    }
}
