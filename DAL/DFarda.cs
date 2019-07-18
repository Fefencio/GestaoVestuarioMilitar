using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DFarda
    {
        Conexao Con = new Conexao();
        public string Insert(Farda farda)
        {
            try
            {
                using (MySqlTransaction trans = Con.Abrir().BeginTransaction())
                {
                    string command = "Insert into Farda(Nome, Descricao) values(@Nome, @Descricao)";
                    MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());
                    cmdInsert.Transaction = trans;

                    cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = farda.Nome;
                    cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = farda.Descricao;

                    cmdInsert.ExecuteNonQuery();
                    int id = (int)cmdInsert.LastInsertedId;

                    cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
                    cmdInsert.Parameters.Add("@IdVestuario", MySqlDbType.Int32);
                    cmdInsert.CommandText = "Insert into Vestuario_Farda(Id_Farda, Id_Vestuario) values (@ID, @IdVestuario)";

                    foreach (var item in farda.Vestuarios)
                    {
                        cmdInsert.Parameters["@IdVestuario"].Value = item.ID;
                        cmdInsert.ExecuteNonQuery();
                    }

                    trans.Commit();

                    return id.ToString();
                }
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
        public string Update(Farda farda)
        {
            try
            {
                using (MySqlTransaction trans = Con.Abrir().BeginTransaction())
                {
                    string command = "Update Farda set Nome=@Nome, Descricao=@Descricao where ID=@ID";
                    MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());
                    cmdInsert.Transaction = trans;

                    cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = farda.ID;
                    cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = farda.Nome;
                    cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = farda.Descricao;

                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.CommandText = "Delete from Vestuario_Farda where Id_Farda=@ID";
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Parameters.Add("@IdVestuario", MySqlDbType.Int32);
                    cmdInsert.CommandText = "Insert into Vestuario_Farda(Id_Farda, Id_Vestuario) values (@ID, @IdVestuario)";

                    foreach (var item in farda.Vestuarios)
                    {
                        cmdInsert.Parameters["@IdVestuario"].Value = item.ID;
                        cmdInsert.ExecuteNonQuery();
                    }

                    trans.Commit();

                    return "OK";
                }
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
        public string Delete(Farda farda)
        {
            try
            {
                string command = "Delete from Farda where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = farda.ID;

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
        public DataTable Select(Farda farda)
        {
            try
            {
                string command = string.Format("Select Farda.ID, Farda.Nome as Farda, Farda.Descricao as 'Descrição'," +
                    " group_concat(Vestuario.Nome) as Vestuarios from Farda Left join Vestuario_Farda on Vestuario_Farda.Id_Farda=Farda.ID Left join " +
                    "Vestuario on Vestuario_Farda.Id_Vestuario=Vestuario.ID where Farda.Nome like @Nome group by Farda.ID order by Farda.Nome");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = farda.Nome + "%";

                DataTable dtFardas = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdInsert);
                dataAdapter.Fill(dtFardas);

                return dtFardas;
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

                string command = string.Format("Select ID, Nome from Farda where group by Nome");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                Dictionary<string, int> LFarda = new Dictionary<string, int>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LFarda.Add(reader.GetString("Nome"), reader.GetInt32("ID"));
                    }
                }

                return LFarda;
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
