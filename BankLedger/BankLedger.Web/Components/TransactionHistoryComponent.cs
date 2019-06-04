using Microsoft.AspNetCore.Mvc;

namespace BankLedger.Web.Components
{
    public class TransactionHistoryComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(@"~/Views/Shared/Components/TransactionComponent/TransactionHistory.cshtml");
        }
    }
}
