using Repositorio;

/**
 * Classe para instanciar o repositorio
 * */

namespace Aplicacao.PlayerApp
{
    public class PlayerConstrutor
    {
        public static PlayerAplicacao PlayerAplicacao()
        {
            return new PlayerAplicacao(new PlayerRepositorio());
        }
    }
}
