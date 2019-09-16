using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameResultService_1.Business
{        
    public class OperacoesGameOperation
    {
        private readonly GameOperationDBEntities _contexto;

        public OperacoesGameOperation()
        {
            _contexto = new GameOperationDBEntities();
        }

        public void Salvar(GameResultService_1 entidade)
        {
            // verifica se o id do GameResultService_1 já existe para não inserir código duplicado
            var result = _contexto.GameResultService_1.FirstOrDefault(x => x.ID == entidade.ID);

            if (result == null)
            {
                _contexto.GameResultService_1.Add(entidade);
            }
            else
            {
                result.playerId = entidade.playerId;
                result.gameId = entidade.gameId;
                result.win = entidade.win;
                result.timestamp = entidade.timestamp;
            }

            _contexto.SaveChanges();

        }
    }
}