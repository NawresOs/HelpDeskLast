using HelpDeskIdentity.Models.HelpDeskModels;
using HelpDeskLast.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskLast.Controllers
{
    public class TechnicienController : Controller
    {
        const string SessionCurrentUser = "CurrentUser";
        public DeskDbContext db { get; private set; }
        public TechnicienController(DeskDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            List<Reclamation> ListeReclamations = new List<Reclamation>();
            ListeReclamations = db.Reclamation.Where(x=>!x.Take).ToList();
            return View(ListeReclamations);
        }
   
        public IActionResult TakeReclamation(int id)
        {
            Reclamation reclamationEntity = db.Reclamation.Find(id);
            reclamationEntity.Take = true;
            db.SaveChanges();
            return View(reclamationEntity);
        }
        [HttpPost]
        public JsonResult ModifierReclamation(string TypePanne, string StatusFinal, int id)
        {
            Reclamation reclamationEntity = db.Reclamation.Find(id);
            reclamationEntity.TypePanne = TypePanne;
            reclamationEntity.StatusFinal = StatusFinal;
            db.SaveChanges();
            return Json("Success");
        }

    }
}
