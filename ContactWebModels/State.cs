using System.ComponentModel.DataAnnotations;


namespace ContactWebModels
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State name is required.")]
        [StringLength(ContactManagerConstants.MAX_STATE_NAME_LENGTH, ErrorMessage = "State name cannot exceed {1} characters.")]
        public string Name { get; set; }

        [Display(Name = "Abbreviation")]
        [Required(ErrorMessage = "State abbreviation is required.")]
        [StringLength(ContactManagerConstants.MAX_STATE_ABBR_LENGTH, ErrorMessage = "State abbreviation cannot exceed {1} characters.")]
        public string Abbreviation { get; set; }
    }
}
