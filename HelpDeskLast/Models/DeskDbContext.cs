using HelpDeskLast.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskIdentity.Models.HelpDeskModels
{
    public class DeskDbContext : IdentityDbContext
    {
        public DeskDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Reclamation> Reclamation { get; set; }

    

        public DbSet<Utilisateur> Utilisateur { get; set; }

     
    }
}
