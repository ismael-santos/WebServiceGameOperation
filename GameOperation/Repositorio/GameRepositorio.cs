using Dominio;
using Dominio.Contrato;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class GameRepositorio : IRepositorio<Game>
    {
        private readonly Contexto _contexto;

        public GameRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Salvar(Game entidade)
        {
            // verifica se o ID do Game já existe para não inserir código duplicado
            var gameAlterar = _contexto.Game.FirstOrDefault(x => x.Id == entidade.Id);

            if (gameAlterar == null)
            {
                _contexto.Game.Add(entidade);
            }
            else
            {
                gameAlterar.GameName = entidade.GameName;                
            }

            _contexto.SaveChanges();
        }

        public void Excluir(Game entidade)
        {
            var GameExcluir = _contexto.Game.FirstOrDefault(x => x.Id == entidade.Id);
            _contexto.Set<Game>().Remove(GameExcluir);
            _contexto.SaveChanges();
        }

        public IEnumerable<Game> ListarTodos()
        {
            return _contexto.Game;
        }

        public Game BuscarPorId(int id)
        {
            return _contexto.Game.FirstOrDefault(x => x.Id == id);
        }

        public void Editar(Game entidade)
        {
            if (entidade.Id > 0)
            {
                var GameAlterar = _contexto.Game.FirstOrDefault(x => x.Id == entidade.Id);
                if (GameAlterar != null)
                {
                    GameAlterar.GameName = entidade.GameName;
                }
                _contexto.SaveChanges();
            }
        }

    }
}
