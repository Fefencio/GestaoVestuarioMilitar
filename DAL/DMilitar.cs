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
    public class DMilitar
    {
        Conexao Con = new Conexao();
        public string Insert(Militar militar)
        {
            try
            {
                string command = "Insert into Militar(Nome, BI, Telefone, Email, Morada, Data_Nascimento, Estado)" +
                    " values(@Nome, @BI, @Telefone, @Email, @Morada, @DataNascimento, @Estado)";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = militar.Nome;
                cmdInsert.Parameters.Add("@BI", MySqlDbType.VarChar).Value = militar.BI;
                cmdInsert.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = militar.Telefone;
                cmdInsert.Parameters.Add("@Email", MySqlDbType.VarChar).Value = militar.Email;
                cmdInsert.Parameters.Add("@Morada", MySqlDbType.VarChar).Value = militar.Morada;
                cmdInsert.Parameters.Add("@DataNascimento", MySqlDbType.DateTime).Value = militar.DataNascimento;
                cmdInsert.Parameters.Add("@Estado", MySqlDbType.Byte).Value = militar.Estado;

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
        public string Update(Militar militar)
        {
            try
            {
                string command = "Update Militar set Nome=@Nome, BI=@BI, Telefone=@Telefone," +
                    " Email=@Email, Morada=@Morada, Data_Nascimento=@DataNascimento, Estado=@Estado where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = militar.ID;
                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = militar.Nome;
                cmdInsert.Parameters.Add("@BI", MySqlDbType.VarChar).Value = militar.BI;
                cmdInsert.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = militar.Telefone;
                cmdInsert.Parameters.Add("@Email", MySqlDbType.VarChar).Value = militar.Email;
                cmdInsert.Parameters.Add("@Morada", MySqlDbType.VarChar).Value = militar.Morada;
                cmdInsert.Parameters.Add("@DataNascimento", MySqlDbType.DateTime).Value = militar.DataNascimento;
                cmdInsert.Parameters.Add("@Estado", MySqlDbType.Byte).Value = militar.Estado;

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
        public string Delete(Militar militar)
        {
            try
            {
                string command = "Delete from Militar where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = militar.ID;

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
        public DataTable Select(Militar militar)
        {
            try
            {

                string filtro = "";
                if (!string.IsNullOrWhiteSpace(militar.BI))
                {
                    filtro += " and BI like @BI";
                }
                if (militar.DataNascimento > DateTime.MinValue)
                {
                    filtro += " and Date(Data_Nascimento)=Date(@DataNascimento)";
                }

                string command = string.Format("Select ID, Nome as Militar, Data_Nascimento as 'Data de Nascimento', " +
                    "BI as 'B.I. nº', Telefone, Email, Morada " +
                    "from Militar where Nome like @Nome and Estado=true {0} order by Nome", filtro);
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = militar.Nome + "%";
                cmdInsert.Parameters.Add("@DataNascimento", MySqlDbType.DateTime).Value = militar.DataNascimento;
                cmdInsert.Parameters.Add("@BI", MySqlDbType.VarChar).Value = militar.BI + "%";

                DataTable dtMilitars = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdInsert);
                dataAdapter.Fill(dtMilitars);

                return dtMilitars;
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

                string command = string.Format("Select ID, Nome from Militar where Estado=true group by Nome");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                Dictionary<string, int> LMilitar = new Dictionary<string, int>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while(reader.Read())
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
