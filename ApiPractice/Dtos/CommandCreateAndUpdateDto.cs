using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Dtos
{
    public abstract class CommandCreateAndUpdateDto //The other Dtos inherit from this, this allows me to add to the others seperatly
    {
        [Required]
        [MaxLength(80)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}