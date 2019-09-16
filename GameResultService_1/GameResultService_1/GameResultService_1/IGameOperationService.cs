using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameResultService_1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGameOperationService" in both code and config file together.
    [ServiceContract]
    public interface IGameOperationService
    {
        [OperationContract]
        void InserirResultado(long playerId, long gameID, long win);

        [OperationContract]
        List<Leaderboard> ListarLeaderboard();
    }

    [DataContract]
    public class Leaderboard
    {
        private long playerId = 0;
        private long balance = 0;
        private DateTime lastUpdateDate = new DateTime();

        [DataMember]
        public long PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }

        [DataMember]
        public long Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        [DataMember]
        public DateTime LastUpdateDate
        {
            get { return lastUpdateDate; }
            set { lastUpdateDate = value; }
        }

    }
}
