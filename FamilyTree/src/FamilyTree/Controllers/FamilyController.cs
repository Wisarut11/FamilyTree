using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FamilyTree.Models;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyTree.Controllers
{
    [Authorize]
    public class FamilyController : Controller
    {
        private ftContext _db;
        public FamilyController(ftContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View(_db.FamilyMembers.Where(q => q.UserId == User.GetUserId()).ToList());
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Remove()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
