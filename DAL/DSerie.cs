using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class DSerie
    {
        Conexao Con = new Conexao();
        public string Insert(Serie serie)
        {
            try
            {
                string command = "Insert into Serie(Nome, Descricao, DataCriacao, DataInicial, DataValidade, Estado)" +
                    " values(@Nome, @Descricao, @DataCriacao, @DataInicial, @DataValidade, @Estado)";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = serie.Nome;
                cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = serie.Descricao;
                cmdInsert.Parameters.Add("@DataCriacao", MySqlDbType.DateTime).Value = serie.DataCriacao;
                cmdInsert.Parameters.Add("@DataInicial", MySqlDbType.DateTime).Value = serie.DataInicial;
                cmdInsert.Parameters.Add("@DataValidade", MySqlDbType.DateTime).Value = serie.DataValidade;
                cmdInsert.Parameters.Add("@Estado", MySqlDbType.Byte).Value = serie.Estado;

                cmdInsert.ExecuteNonQuery();
                return cmdInsert.LastInsertedId.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                Con.Fechar();
            }
        }
        public string Update(Serie serie)
        {
            try
            {
                string command = "Update Serie set Nome=@Nome, Descricao=@Descricao, DataCriacao=@DataCriacao," +
                    " DataInicial=@DataInicial, DataValidade=@DataValidade, Estado=@Estado where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = serie.ID;
                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = serie.Nome;
                cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = serie.Descricao;
                cmdInsert.Parameters.Add("@DataCriacao", MySqlDbType.DateTime).Value = serie.DataCriacao;
                cmdInsert.Parameters.Add("@DataInicial", MySqlDbType.DateTime).Value = serie.DataInicial;
                cmdInsert.Parameters.Add("@DataValidade", MySqlDbType.DateTime).Value = serie.DataValidade;
                cmdInsert.Parameters.Add("@Estado", MySqlDbType.Byte).Value = serie.Estado;

                cmdInsert.ExecuteNonQuery();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                Con.Fechar();
            }
        }
        public string Delete(Serie serie)
        {
            try
            {
                string command = "Delete from Serie where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = serie.ID;

                cmdInsert.ExecuteNonQuery();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                Con.Fechar();
            }
        }
        public DataTable Select (Serie serie)
        {
            try
            {
                
                string filtro = "";
                if (serie.DataInicial > DateTime.MinValue)
                {
                    filtro += " and Date(DataInicial)=Date(@DataInicial)";
                }
                if (serie.DataValidade > DateTime.MinValue)
                {
                    filtro += " and Date(DataValidade)=Date(@DataValidade)";
                }

                string command = string.Format("Select ID, Nome as Série, Descricao as 'Descrição', " +
                    "Date(DataInicial) as 'Data Inicial', Date(DataValidade) as 'Data de Validade' " +
                    "from Serie where Nome like @Nome {0} order by ID desc", filtro);
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = serie.Nome + "%";
                cmdInsert.Parameters.Add("@DataInicial", MySqlDbType.DateTime).Value = serie.DataInicial;
                cmdInsert.Parameters.Add("@DataValidade", MySqlDbType.DateTime).Value = serie.DataValidade;

                DataTable dtSeries = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdInsert);
                dataAdapter.Fill(dtSeries);

                return dtSeries;
            }
            catch
            {
                return null;
            }
            finally
            {
                Con.Fechar();
            }
        }
        public Dictionary<string, int> ListarNomeID()
        {
            try
            {

                string command = string.Format("Select ID, Nome from Serie where Estado=true group by Nome");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                Dictionary<string, int> LMilitar = new Dictionary<string, int>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LMilitar.Add(reader.GetString("Nome"), reader.GetInt32("ID"));
                    }
                }

                return LMilitar;
            }
            catch
            {
                return new Dictionary<string, int>();
            }
            finally
            {
                Con.Fechar();
            }
        }

    }
}
