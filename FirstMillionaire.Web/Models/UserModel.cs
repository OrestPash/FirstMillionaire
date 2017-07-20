using System.ComponentModel.DataAnnotations;

namespace FirstMillionaire.Web.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please, enter your Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter your Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        [StringLength(50)]
        public string Email { get; set; }
    }
}