using HelpDeskIdentity.Models.HelpDeskModels;
using HelpDeskLast.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskLast.Controllers
{
    public class ClientController : Controller
    {
        const string SessionCurrentUser = "CurrentUser";
        public DeskDbContext db { get; private set; }
        public ClientController(DeskDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MesReclamations()
        {
            var IdUser = HttpContext.Session.GetInt32(SessionCurrentUser);
            List<Reclamation> ListeReclamations = new List<Reclamation>();
            ListeReclamations = db.Reclamation.Where(x=>x.UserId== IdUser).ToList();
            return View(ListeReclamations);
        }
        [HttpPost]
        public JsonResult AjouterReclamations( string Description)
        {
            var IdUser = HttpContext.Session.GetInt32(SessionCurrentUser);
            Reclamation reclamationEntity = new Reclamation();
            reclamationEntity.Description = Description;
            reclamationEntity.UserId = IdUser.Value;
            reclamationEntity.Status = "EnAttente";
            db.Reclamation.Add(reclamationEntity);
            db.SaveChanges();
            reclamationEntity.Code = "R" + (reclamationEntity.Id).ToString("D8");
            db.SaveChanges();
            return Json("Success");
        }
        [HttpGet]
        public JsonResult DeleteReclamation(int Code)
        {
            Reclamation reclamationEntity = db.Reclamation.Find(Code);
            db.Reclamation.Remove(reclamationEntity);
            db.SaveChanges();
            return Json("Success");
        }
      
        public IActionResult ModifierReclamation(int id)
        {
            Reclamation reclamationEntity = db.Reclamation.Find(id);
            return View(reclamationEntity);
        }
        [HttpPost]
        public JsonResult ModifierReclamation(string Description , int id)
        {
            Reclamation reclamationEntity = db.Reclamation.Find(id);
            reclamationEntity.Description= Description;
            db.SaveChanges();
            return Json("Success");
        }

    }
}
