using System;
using System.ServiceModel;
using GameResultService_1.Business;
using System.Collections.Generic;

namespace GameResultService_1
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class GameOperationService : IGameOperationService
    {     
        public void InserirResultado(long playerId, long gameID, long win)
        {
            GameResultService_1 result = new GameResultService_1();

            result.playerId = playerId;
            result.gameId = gameID;
            result.win = win;
            result.timestamp = DateTime.Now;

            OperacoesGameOperation op = new OperacoesGameOperation();
            op.Salvar(result);
        }

        public List<Leaderboard> ListarLeaderboard()
        {
            OperacoesLeaderboard op = new OperacoesLeaderboard();

            return op.ListarLeaderboard();
        }
    }
}
