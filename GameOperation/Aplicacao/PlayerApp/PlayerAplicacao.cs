using Dominio;
using Dominio.Contrato;
using System.Collections.Generic;

/**
 * Classe para acesso ao repósitório (CRUD)
 * */

namespace Aplicacao.PlayerApp
{
    public class PlayerAplicacao
    {
        private readonly IRepositorio<Player> _repositorio;

        public PlayerAplicacao(IRepositorio<Player> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Salvar(Player player)
        {
            _repositorio.Salvar(player);
        }

        public void Editar(Player player)
        {
            _repositorio.Editar(player);
        }

        public void Excluir(Player player)
        {
            _repositorio.Excluir(player);
        }

        public IEnumerable<Player> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public Player BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }
    }
}
