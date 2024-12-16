using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeetingApp.Models;

namespace MeetingApp.Controllers
{
   
    public class MeetingController : Controller
    {
       
      
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
          public IActionResult Apply(UserInfo model, IFormFile Image)
        {
            if(ModelState.IsValid){

            
              Repository.CreateUser(model);
              ViewBag.UserCount=Repository.Users.Where(i=>i.WillAttend==true).Count();
               if (Image != null && Image.Length > 0)
    {
        // wwwroot/images/ klasörüne kaydediyoruz
        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", Image.FileName);

        // Dosyayı kaydet
        using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            Image.CopyTo(stream);
        }

        // Modeldeki Image alanına dosya adını kaydediyoruz
        model.Image = Image.FileName;
    }
            return View("Thanks" ,model);
        }else{
            ViewBag.Error="Lütfen Bilgileri Eksiksiz Giriniz";
            return View(model);
        }
        }
        public IActionResult List()
        {
            var users=Repository.Users;
            return View(users);
        }
    public IActionResult Details(int id){
        return View(Repository.GetById(id));
    }
        
    }
}