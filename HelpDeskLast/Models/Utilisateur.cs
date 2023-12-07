using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace HelpDeskLast.Models
{
    public class Utilisateur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [MaxLength(8)]
        [Required]
        public string CIN { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }

        [NotMapped]
        public String FullName
        {
            get { return Prenom + " " + Nom; }
            set { _fullName = value; }
        }

        private String _fullName;

        [Required]
        public string Telephone { get; set; }




        [EmailAddress(ErrorMessage = "Adresse email Invalid")]

        public string Email { get; set; }
        public string MotDePasse { get; set; }

        public String Role { get; set; }

    }
}
