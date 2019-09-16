using Repositorio;

/**
 * Classe para instanciar o repositorio
 * */

namespace Aplicacao.GameApp
{
    public class GameConstrutor
    {
        public static GameAplicacao GameAplicacao()
        {
            return new GameAplicacao(new GameRepositorio());
        }
    }

}
