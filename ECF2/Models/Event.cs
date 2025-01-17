using System.ComponentModel.DataAnnotations;

namespace ECF2.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Display(Name = "Intitulé")]
        [Required(ErrorMessage = "Veuillez saisir l'intitulé")]
        [StringLength(50, ErrorMessage = "L'intitulé de l'évènement doit être de maximum {1} caractères.")] 
        [MaxLength(50, ErrorMessage = "The event title must contain {1} characters or less.")] 
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Veuillez saisir la description")]
        [StringLength(255, ErrorMessage = "La description de l'évènement doit être de maximum {1} caractères.")]
        [MaxLength(255, ErrorMessage = "The event description must contain {1} characters or less.")]
        public string Description { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Veuillez saisir l'adresse de l'événement'")]
        [StringLength(255, ErrorMessage = "L'adresse' doit être de maximum {1} caractères.")]
        [MaxLength(255, ErrorMessage = "The address must contain {1} characters or less.")]
        public string Address { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Veuillez sélectionner le type d'événement")]
        public EventType EventType { get; set; }

        public int EventTypeId { get; set; }

        [Display(Name = "Date de début")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date de fin")]
        public DateTime EndDate { get; set; }

    }
}
