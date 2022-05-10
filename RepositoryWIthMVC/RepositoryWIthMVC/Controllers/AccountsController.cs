#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositoryWIthMVC.Data;
using RepositoryWIthMVC.Data.BLL;
using RepositoryWIthMVC.Models;

namespace RepositoryWIthMVC.Controllers
{
    public class AccountsController : Controller
    {
        
        private AccountBusinessLogic accountBL;
        public AccountsController(RepositoryWIthMVCContext context)
        {
            
            accountBL = new AccountBusinessLogic(new AccountRepository(context));
        }

        public IActionResult Index()
        {
            return View(accountBL.GetAll());
        }
    }
}
