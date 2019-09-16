using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOperationInsertScore
{
    public partial class InsertJob : Form
    {
        private string strConnection = "Data Source=.\\SQLEXPRESS; Initial Catalog=GameOperationDB; User id=sa; Password=123456;";

        public InsertJob()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            txtIntervalo.Enabled = false;
            VerificaPorTempoDeterminadoAsync();
        }

        //Rotina que verifica se há um novo registro, pelo tempo informado na tela 
        private async void VerificaPorTempoDeterminadoAsync()
        {
            try
            {
                int intervalorInformado = Convert.ToInt32(txtIntervalo.Text);
                int intervalo = 0;

                while (true)
                {                    
                    await Task.Delay(1000);
                    intervalo++;

                    if (intervalo == intervalorInformado)
                    {
                        ExecutarInserts();
                        intervalo = 0;
                    }
                }
            }
            catch (Exception e)
            {
                button1.Enabled = true;
                txtIntervalo.Enabled = true;
                MessageBox.Show("Erro ao executar Job!\n" + e.Message);
            }
        }

        //Executa os inserts para a tabela GameResult
        private void ExecutarInserts()
        {
            List<string> inserts = ListaDeInserts();

            try
            {
                SqlConnection sqlConn = new SqlConnection(strConnection);

                sqlConn.Open();

                StringBuilder insertConcat = new StringBuilder();

                foreach (string insert in inserts)
                {
                    insertConcat.Append(insert + "\n");
                }

                if (inserts.Any())
                {
                    SqlCommand cmd = new SqlCommand(insertConcat.ToString(), sqlConn);
                    cmd.ExecuteReader();
                }

                sqlConn.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Não foi possível iniciar o Job!\n" + e.Message);
            }
        }

        //Seleciona os campos que ainda não foram persistidos na tabela GameResult e monta o insert para ela
        private List<string> ListaDeInserts()
        {
            List<string> lstInserts = new List<string>();

            try
            {
                SqlConnection sqlConn = new SqlConnection(strConnection);

                sqlConn.Open();

                string query = @"select 'insert into GameResult(win, timestamp, playerID, gameID) values ('+ CAST(s1.win as varchar(max)) +', ''' + Convert(nvarchar, s1.timestamp, 121) + ''', '+ CAST(s1.playerID as varchar(max)) +', '+ CAST(s1.gameID as varchar(max)) +') ' as InsertQuery
                                 from GameResultService_1 s1 where s1.timestamp > (select IsNull(MAX(gr.timestamp), '1900-01-01 00:00:00.000') from GameResult gr);";

                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string insert = dr["InsertQuery"].ToString();
                    lstInserts.Add(insert);
                }

                sqlConn.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Não foi possível iniciar o Job!\n" + e.Message);
            }

            return lstInserts;
        }

    }
}
