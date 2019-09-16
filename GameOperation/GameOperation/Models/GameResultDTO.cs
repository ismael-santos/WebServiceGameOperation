using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameOperation.Models
{
    public class GameResultDTO
    {
        [Display(Name = "Pontuação a somar")] 
        [Required(ErrorMessage = "A pontuação é Obrigatório")]
        public long win { get; set; }

        [Display(Name = "Jogador")]
        [Required(ErrorMessage = "O jogador é Obrigatório")]
        public long playerId { get; set; }

        [Display(Name = "Jogo")]
        [Required(ErrorMessage = "O jogo é Obrigatório")]
        public long gameId { get; set; }
    }
}