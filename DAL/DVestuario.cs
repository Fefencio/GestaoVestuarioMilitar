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
                string command = "Insert into Vestuario(Nome, Descricao) values(@Nome, @Descricao)";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = vestuario.Nome;
                cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = vestuario.Descricao;

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
        public string Update(Vestuario vestuario)
        {
            try
            {
                string command = "Update Vestuario set Nome=@Nome, Descricao=@Descricao where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = vestuario.ID;
                cmdInsert.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = vestuario.Nome;
                cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = vestuario.Descricao;

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
                string command = string.Format("Select ID, Nome as Vestuario, Descricao as 'Descrição' from Vestuario where Nome like @Nome order by Nome");
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
                            reader.GetString("Descricao"));
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
    }
}
