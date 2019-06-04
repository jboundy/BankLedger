using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Web.Components
{
    public class ErrorModalComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(@"~/Views/Shared/Components/LoginComponent/ErrorModal.cshtml");
        }
    }
}
