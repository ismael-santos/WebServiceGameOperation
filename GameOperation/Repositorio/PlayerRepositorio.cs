using Dominio;
using System.Collections.Generic;
using System.Linq;
using Dominio.Contrato;

namespace Repositorio
{
    public class PlayerRepositorio : IRepositorio<Player>
    {
        private readonly Contexto _contexto;

        public PlayerRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Salvar(Player entidade)
        {
            // verifica se o código do player já existe para não inserir código duplicado
            var playerAlterar = _contexto.Player.FirstOrDefault(x => x.Id == entidade.Id);

            if (playerAlterar == null)
            {
                _contexto.Player.Add(entidade);
            }
            else
            {
                playerAlterar.NamePlayer = entidade.NamePlayer;
                playerAlterar.Password = entidade.Password;
                playerAlterar.UserName = entidade.UserName;
            }

            _contexto.SaveChanges();
            
        }

        public void Excluir(Player entidade)
        {
            var playerExcluir = _contexto.Player.FirstOrDefault(x => x.Id == entidade.Id);
            _contexto.Set<Player>().Remove(playerExcluir);
            _contexto.SaveChanges();
        }

        public IEnumerable<Player> ListarTodos()
        {
            return _contexto.Player;
        }

        public Player BuscarPorId(int id)
        {
            return _contexto.Player.FirstOrDefault(x => x.Id == id);
        }


        public void Editar(Player entidade)
        {
            if (entidade.Id > 0)
            {
                var playerAlterar = _contexto.Player.FirstOrDefault(x => x.Id == entidade.Id);
                if (playerAlterar != null)
                {
                    playerAlterar.NamePlayer = entidade.NamePlayer;
                    playerAlterar.Password = entidade.Password;
                    playerAlterar.UserName = entidade.UserName;
                }
                _contexto.SaveChanges();
            }
        }

    }
}
