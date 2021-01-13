using BT.Helpers;
using BT.Models;
using BT.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExternalConnector.ExternalConnector _externalConnector;

        public HomeController(ILogger<HomeController> logger, ExternalConnector.ExternalConnector externalConnector)
        {
            _logger = logger;
            _externalConnector = externalConnector ?? throw new Exception(nameof(externalConnector));
        }

        public async  Task<IActionResult> Index()
        {
            var accounts = await _externalConnector.GetAccountsAsync<AccountViewModel>();

            for (var index = 0; index < accounts.Count; index++)
            {
                var account = accounts[index];

                account.AccountTypeCss = AccountTypeCSS.AccountWithFullInfo;

                if (account.ContactInfo.Count == 0)
                    account.AccountTypeCss = AccountTypeCSS.AccountWithOutContacts;

                if (account.ContactInfo.Count > 0 && account.ContactInfo.Any(x => x.Information == null))
                    account.AccountTypeCss = AccountTypeCSS.AccountWithMissingContactInformation;
            }

            return View(accounts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
