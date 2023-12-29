using Beltek.HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beltek.HelloMVC.Controllers
{
    public class OgretmenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ViewResult AddTeacher()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(Ogretmen ogrt)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogretmenler.Add(ogrt);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListTeacher");
            //return View();
        }


        public IActionResult ListTeacher()
        {

            List<Ogretmen> lst1;

            using (var ctx = new OkulDbContext())
            {
                lst1 = ctx.Ogretmenler.ToList();
            }
            return View(lst1);
        }


        public IActionResult DeleteTeacher(string id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogrt = ctx.Ogretmenler.FirstOrDefault(o => o.Tckimlik == id);

                if (ogrt != null)
                {
                    ctx.Ogretmenler.Remove(ogrt);
                    ctx.SaveChanges();
                    return RedirectToAction("ListTeacher");
                }

                return NotFound("Silinecek öğretmen bulunamadı");
            }
        }



        public IActionResult UpdateTeacher(string id)
        {
            Ogretmen ogrt;
            using (var ctx = new OkulDbContext())
            {
                ogrt = ctx.Ogretmenler.FirstOrDefault(o => o.Tckimlik == id);
            }

            if (ogrt == null)
            {
                return NotFound("Öğretmen bulunamadı");
            }

            return View(ogrt);
        }

            [HttpPost]

            public IActionResult UpdateTeacher(Ogretmen ogrt)
            {
                using (var ctx = new OkulDbContext())

                {
                    ctx.Entry(ogrt).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                return RedirectToAction("listTeacher");
            }

        
    }
}