using System.ComponentModel.DataAnnotations;

namespace Sklepy.Models.ViewModel
{
    public class UserSignUpView
    {
        [Key]
        public int SYSUserID { get; set; }
        public int LOOKUPRoleID { get; set; }
        public string RoleName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Płeć")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "*")]
        public string Adres { get; set; }//////////////////////////
        [Required(ErrorMessage = "*")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

    }
}
