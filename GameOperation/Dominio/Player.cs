using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Player
    {        
        public long Id { get; set; }

        [Display(Name = "Nome Player")]
        [MaxLength(60)]
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string NamePlayer { get; set; }

        [Display(Name = "User Name")]
        [MaxLength(30)]
        [Required(ErrorMessage = "User Name Obrigatório")]
        public string UserName { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Password Obrigatório")]
        public string Password { get; set; }
    }
}
