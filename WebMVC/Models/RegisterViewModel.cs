using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(maximumLength:16,MinimumLength =6,ErrorMessage ="Username must be between 6 & 16 characters")]
        public string UserName { set; get; }

        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email not valid")]
        public string Email { set; get; }

        [Required]
        public string FirstName { set; get; }

        [Required]
        public string LastName { set; get; }

        [DataType(DataType.Password)]
        [StringLength(maximumLength:32,MinimumLength =6,ErrorMessage ="Password must be between 6 & 32 characters")]
        public string Password { set; get; }
        [DataType(DataType.Password)]

        [Compare("Password", ErrorMessage ="Password and PasswordConfirm do not match")]
        public string PasswordConfirm { set; get; }
    }
}