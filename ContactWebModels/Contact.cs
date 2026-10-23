
using System.ComponentModel.DataAnnotations;


namespace ContactWebModels
{
    public class Contact
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(ContactManagerConstants.MAX_CONTACT_FIRST_NAME_LENGTH, ErrorMessage = "First name cannot exceed {1} characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(ContactManagerConstants.MAX_CONTACT_LAST_NAME_LENGTH, ErrorMessage = "Last name cannot exceed {1} characters.")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(ContactManagerConstants.MAX_CONTACT_EMAIL_LENGTH, ErrorMessage = "Email address cannot exceed {1} characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Display(Name = "Primary Phone")]
        [StringLength(ContactManagerConstants.MAX_CONTACT_PHONE_LENGTH, ErrorMessage = "Primary phone cannot exceed {1} characters.")]
        [Required(ErrorMessage = "Primary phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhonePrimary { get; set; }

        [Display(Name = "Secondary Phone")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(ContactManagerConstants.MAX_CONTACT_PHONE_LENGTH, ErrorMessage = "Secondary phone cannot exceed {1} characters.")]
        public string PhoneSecondary { get; set; }
        [Display(Name = "Street Address 1")]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH, ErrorMessage = "Street address cannot exceed {1} characters.")]
        [Required(ErrorMessage = "Street address is required.")]
        public string StreetAddress1 { get; set; }
        [Display(Name = "Street Address 2")]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH, ErrorMessage = "Street address cannot exceed {1} characters.")]

        public string StreetAddress2 { get; set; }

        [StringLength(ContactManagerConstants.MAX_CITY_LENGTH, ErrorMessage = "City cannot exceed {1} characters.")]
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required.")]
        public int StateId { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip code is required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid zip code format.")] // US or Canada
        [StringLength(ContactManagerConstants.MAX_CONTACT_ZIP_LENGTH, MinimumLength = ContactManagerConstants.MIN_CONTACT_ZIP_LENGTH, ErrorMessage = "Zip code must be between {2} and {1} characters.")]
        public string Zip { get; set; }
        public virtual State State { get; set; }

        [Required(ErrorMessage = "User ID is required in order to map user correctly.")]
        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Full Name")]
        public string FriendlyName => $"{FirstName} {LastName}";

        [Display(Name = "Full Address")]
        public string FriendlyAddress => State is null ? "" :
               string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City}, {State?.Abbreviation} {Zip}" :
               string.IsNullOrWhiteSpace(StreetAddress2) ? $"{StreetAddress1}, {City}, {State?.Abbreviation} {Zip}" :
               $"{StreetAddress1} {StreetAddress2}, {City}, {State?.Abbreviation} {Zip}";
    }
}
