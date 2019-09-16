using Dominio;
using Dominio.Contrato;
using System.Collections.Generic;

/**
 * Classe para acesso ao repósitório (CRUD)
 * */

namespace Aplicacao.GameApp
{
    public class GameAplicacao
    {
        private readonly IRepositorio<Game> _repositorio;

        public GameAplicacao(IRepositorio<Game> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Salvar(Game game)
        {
            _repositorio.Salvar(game);
        }

        public void Editar(Game game)
        {
            _repositorio.Editar(game);
        }

        public void Excluir(Game game)
        {
            _repositorio.Excluir(game);
        }

        public IEnumerable<Game> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public Game BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }
    }
}
