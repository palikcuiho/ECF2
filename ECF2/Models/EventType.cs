using System.ComponentModel.DataAnnotations;

namespace ECF2.Models
{
    public class EventType
    {
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "Le type d'évènement doit être de maximum {1} caractères.")] // User input
        [MaxLength(30, ErrorMessage = "The event type must contain {1} characters or less.")] // VARCHAR(30)
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}
