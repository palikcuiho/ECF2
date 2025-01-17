using System.ComponentModel.DataAnnotations;
namespace ECF2.Models
{
    public class Participant
    {
        public int Id { get; set; }
        
        [Display(Name = "Prénom")]
        [StringLength(50, ErrorMessage = "La taille du prénom doit être de maximum {1} caractères.")]
        [MaxLength(50, ErrorMessage = "The first name must contain {1} characters or less.")]
        [Required(ErrorMessage = "Veuillez saisir un prénom.")]
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        [StringLength(50, ErrorMessage = "La taille du nom doit être de maximum {1} caractères.")]
        [MaxLength(50, ErrorMessage = "The last name must contain {1} characters or less.")]
        [Required(ErrorMessage = "Veuillez saisir un nom.")]
        public string LastName { get; set; }

        [Display(Name = "Téléphone")]
        [Phone(ErrorMessage = "Le numéro saisi est invalide.")]
        [Required(ErrorMessage = "Veuillez saisir un numéro de téléphone.")]
        public string Phone { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Veuillez saisir une adresse mail.")]
        [EmailAddress(ErrorMessage ="L'e-mail saisi est invalide.")]
        public string Email { get; set; }

        public List<Event> Events { get; set; }

    }
}
