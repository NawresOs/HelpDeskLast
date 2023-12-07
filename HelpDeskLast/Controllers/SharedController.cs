using HelpDeskIdentity.Models.HelpDeskModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HelpDeskLast.Controllers
{
    public class SharedController : Controller
    {
        public DeskDbContext db { get; private set; }
        const string SessionCurrentUser = "CurrentUser";
        const string SessionCurrentUserName = "SessionCurrentUserName";
        public SharedController(DeskDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SignIn(string Login, string pass)
        {


            var user = db.Utilisateur.SingleOrDefault(a => a.Email.Equals(Login));
            if (user != null)
            {
                if (user.MotDePasse.Equals(pass))
                {
                    // Session["CurrentUser"] = user.Id;
                    HttpContext.Session.SetInt32(SessionCurrentUser, user.Id);
                    HttpContext.Session.SetString(SessionCurrentUserName, user.FullName );

                    if (user.Role =="Client")
                    {
                        return Json("Client");
                    }
                    else if (user.Role == "technicien")
                    {
                        return Json("technicien");
                    }
                    return Json("Mot De Passe Incorrecte");

                }

                else
                {
                    ViewBag.error1 = "Mot De Passe Incorrecte";
                    return Json("Mot De Passe Incorrecte"); 
                }
            }
            else
            {
                ViewBag.error = "Utilisateur Invalide";
                return Json("Utilisateur Invalide"); ;
            }

        }
    }
}
