using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GameResultService_1.Business
{
    public class OperacoesLeaderboard
    {
        private string strConnection = "Data Source=.\\SQLEXPRESS; Initial Catalog=GameOperationDB; User id=sa; Password=123456;";

        // Lista direto da View Leaderboard
        public List<Leaderboard> ListarLeaderboard()
        {
            List<Leaderboard> listLeaderbord = new List<Leaderboard>();

            try
            {
                SqlConnection sqlConn = new SqlConnection(strConnection);

                sqlConn.Open();

                string query = @"SELECT * FROM Leaderboard;";

                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Leaderboard ld = new Leaderboard();
                    ld.PlayerId = Convert.ToInt64(dr["playerId"]);
                    ld.Balance = Convert.ToInt64(dr["balance"]);
                    ld.LastUpdateDate = Convert.ToDateTime(dr["lastUpdateDate"]);

                    listLeaderbord.Add(ld);
                }

                sqlConn.Close();
            }
            catch
            {
                throw new Exception("Não foi possível carregar o Leaderbord");
            }

            return listLeaderbord;
        }
    }
}