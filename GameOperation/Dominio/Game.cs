using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Game
    {
        public long Id { get; set; }

        [Display(Name = "Nome do jogo")]
        [MaxLength(60)]
        [Required(ErrorMessage = "Nome do jogo é Obrigatório")]
        public string GameName { get; set; }
    }
}
