using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DVestuario
    {
        Conexao Con = new Conexao();
        public string Insert(Vestuario vestuario)
        {
            try
            {
                using (MySqlTransaction trans = Con.Abrir().BeginTransaction())
                {
                    string command = "Insert into Vestuario(Nome, Descricao) values(@Nome, @Descricao)";
                    MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());
                    cmdInsert.Transaction = trans;

                    cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = vestuario.Nome;
                    cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = vestuario.Descricao;

                    cmdInsert.ExecuteNonQuery();
                    int id = (int)cmdInsert.LastInsertedId;

                    cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = id;
                    cmdInsert.Parameters.Add("@Numero", MySqlDbType.VarChar);
                    cmdInsert.CommandText = "Insert into Numero_Vestuario(Id_Vestuario, Numero) values (@ID, @Numero)";

                    foreach (var item in vestuario.Numeros)
                    {
                        cmdInsert.Parameters["@Numero"].Value = item.Numero;
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
        public string Update(Vestuario vestuario)
        {
            try
            {
                using (MySqlTransaction trans = Con.Abrir().BeginTransaction())
                {
                    string command = "Update Vestuario set Nome=@Nome, Descricao=@Descricao where ID=@IdVestuario";
                    MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());
                    cmdInsert.Transaction = trans;

                    cmdInsert.Parameters.Add("@IdVestuario", MySqlDbType.Int16).Value = vestuario.ID;
                    cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = vestuario.Nome;
                    cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = vestuario.Descricao;

                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = 0;

                    cmdInsert.Parameters.Add("@Numero", MySqlDbType.VarChar);
                    
                    foreach (var item in vestuario.Numeros)
                    {
                        if (item.ID == 0)
                        {
                            cmdInsert.CommandText = "Insert into Numero_Vestuario(Id_Vestuario, Numero) values (@IdVestuario, @Numero)";
                            cmdInsert.Parameters["@Numero"].Value = item.Numero;
                        }
                        else
                        {
                            cmdInsert.Parameters["ID"].Value = item.ID;
                            cmdInsert.CommandText = "Update set Numero=@Numero where ID=@ID)";
                            cmdInsert.Parameters["@Numero"].Value = item.Numero;
                        }
                        
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
        public string Delete(Vestuario vestuario)
        {
            try
            {
                string command = "Delete from Vestuario where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = vestuario.ID;

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
        public DataTable Select(Vestuario vestuario)
        {
            try
            {
                string command = string.Format("Select Vestuario.ID, Vestuario.Nome as Vestuario, Vestuario.Descricao as 'Descrição', " +
                    "group_Concat(Numero_Vestuario.numero) as Numeros from Vestuario left join Numero_Vestuario on " +
                    "Numero_Vestuario.Id_Vestuario=Vestuario.ID where Vestuario.Nome like @Nome group by Vestuario.Nome " +
                    "order by Vestuario.Nome");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = vestuario.Nome + "%";

                DataTable dtVestuarios = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdInsert);
                dataAdapter.Fill(dtVestuarios);

                return dtVestuarios;
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
        public Vestuario SelectID(Vestuario vestuario)
        {
            try
            {

                string command = string.Format("Select ID, Nome, Descricao from Vestuario where ID=@ID");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = vestuario.ID;
                using (var reader = cmdInsert.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        vestuario = new Vestuario(reader.GetInt32("ID"), reader.GetString("Nome"),
                            reader.GetString("Descricao"), null);
                    }
                }

                return vestuario;
            }
            catch
            {
                return new Vestuario();
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

                string command = string.Format("Select ID, Nome from Vestuario group by Nome");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                Dictionary<string, int> LVestuario = new Dictionary<string, int>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LVestuario.Add(reader.GetString("Nome"), reader.GetInt32("ID"));
                    }
                }

                return LVestuario;
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
        public Dictionary<string, int> ListarNumerosNomeID(Vestuario vestuario)
        {
            try
            {

                string command = string.Format("Select ID, Numero from Numero_Vestuario where Id_Vestuario=@ID group by Numero");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = vestuario.ID;

                Dictionary<string, int> LNumeros = new Dictionary<string, int>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LNumeros.Add(reader.GetString("Numero"), reader.GetInt32("ID"));
                    }
                }

                return LNumeros;
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
