using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Hosting;
using System.IO;
using Microsoft.AspNet.Http;
using Microsoft.Net.Http.Headers;
using FamilyTree.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyTree.Controllers
{
    public class ImageController : Controller
    {
        private IHostingEnvironment _environment;
        private ftContext _context;
        public ImageController(IHostingEnvironment environment, ftContext context)
        {
            _environment = environment;
            _context = context;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Add(int fmId)
        {
            FamilyMember fm = _context.FamilyMembers.FirstOrDefault(q => q.Id == fmId);
            fm.Images = _context.Images.Where(q => q.FamilyMemberId == fm.Id).ToList();
            return View(fm);
        }

        [HttpPost]
        public IActionResult Add(ICollection<IFormFile> files, int fmId)
        {
            FamilyMember fm = _context.FamilyMembers.FirstOrDefault(q => q.Id == fmId);
            fm.Images = _context.Images.Where(q => q.FamilyMemberId == fm.Id).ToList();
            var uploads = Path.Combine(_environment.WebRootPath, "IMG\\Uploads");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    file.SaveAs(Path.Combine(uploads, fileName));
                    Image newimage = new Image();
                    newimage.URI = fileName;
                    newimage.Text = "image text";
                    fm.Images.Add(newimage);
                    _context.SaveChanges(); 
                }
            }
            return RedirectToAction("Index", "Account", null);
        }
        public IActionResult ViewImages(int fmId)
        {
            List<Image> images = _context.Images.Where(q => q.FamilyMemberId == fmId).ToList();
            return PartialView(images);
        }
    }
}
