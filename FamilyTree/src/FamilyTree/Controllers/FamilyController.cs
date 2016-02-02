using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FamilyTree.Models;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using FamilyTree.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyTree.Controllers
{
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
            List<FamilyMember> fm = _db.FamilyMembers.Where(q => q.UserId == User.GetUserId()).ToList();
            return View(fm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateFamilyMemberViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                FamilyMember fm = new FamilyMember
                {
                    UserId = User.GetUserId(),
                    Relation = viewModel.Relation,
                    Name = viewModel.Name
                };
                _db.FamilyMembers.Add(fm);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //something went wrong go back to Add action
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
