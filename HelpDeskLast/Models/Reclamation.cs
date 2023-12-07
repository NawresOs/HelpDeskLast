using HelpDeskIdentity.Models.HelpDeskModels;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskLast.Models
{
    public class Reclamation
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        public bool Take { get; set; }

        public string? TypePanne { get; set; }

        public string? StatusFinal { get; set; }

        public string? Satisfaction { get; set; }



    }
}
