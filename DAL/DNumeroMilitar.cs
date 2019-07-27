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
    public class DNumeroMilitar : ICRUD
    {
        Conexao Con = new Conexao();
        public string Insert(NumeroMilitar numeroMilitar)
        {
            try
            {
                string command = "Insert into Militar_Numero(Id_Militar, Id_Numero_Vestuario, Id_Farda)" +
                    " values(@Id_Militar, @Id_Numero_Vestuario, @Id_Farda)";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Id_Militar", MySqlDbType.Int32).Value = numeroMilitar.Militar.ID;
                cmdInsert.Parameters.Add("@Id_Numero_Vestuario", MySqlDbType.Int32).Value = numeroMilitar.NumeroVestuario.ID;
                cmdInsert.Parameters.Add("@Id_Farda", MySqlDbType.Int32).Value = numeroMilitar.Farda.ID;

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
        public string Update(NumeroMilitar numeroMilitar)
        {
            try
            {
                string command = "Update Militar_Numero set Id_Militar=@Id_Militar, Id_Numero_Vestuario=" +
                    "@Id_Numero_Vestuario, Id_Farda=@Id_Farda where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = numeroMilitar.ID;
                cmdInsert.Parameters.Add("@Id_Militar", MySqlDbType.Int32).Value = numeroMilitar.Militar.ID;
                cmdInsert.Parameters.Add("@Id_Numero_Vestuario", MySqlDbType.Int32).Value = numeroMilitar.NumeroVestuario.ID;
                cmdInsert.Parameters.Add("@Id_Farda", MySqlDbType.Int32).Value = numeroMilitar.Farda.ID;

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
        public string Delete(NumeroMilitar numeroMilitar)
        {
            try
            {
                string command = "Delete from Militar_Numero where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = numeroMilitar.ID;

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
        public List<NumeroMilitar> Select()
        {
            try
            {

                string command = string.Format("Select Militar_Numero.ID, Militar.ID as IdMilitar, Militar.Nome as " +
                    "Militar, Farda.ID as IdFarda, Farda.Nome as Farda, Numero_Vestuario.ID as IdNumeroVestuario, " +
                    "Vestuario.ID as IdVestuario, Vestuario.Nome as Vestuario, Numero_Vestuario.Numero " +
                    "from Militar_Numero inner join Militar on Militar.ID=Militar_Numero.Id_Militar inner join Farda " +
                    "on Farda.ID=Militar_Numero.Id_Farda inner join Numero_Vestuario on Numero_Vestuario.ID=" +
                    "Militar_Numero.Id_Numero_Vestuario inner join Vestuario on Numero_Vestuario.Id_Vestuario=" +
                    "Vestuario.ID group by Numero_Vestuario.ID order by Farda.Nome");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                List<NumeroMilitar> LNumeroMilitar = new List<NumeroMilitar>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Militar militarN = new Militar(reader.GetInt32("IdMilitar"), reader.GetString("Militar"));
                        Farda farda = new Farda(reader.GetInt32("IdFarda"), reader.GetString("Farda"));
                        Vestuario vestuario = new Vestuario(reader.GetInt32("IdVestuario"), reader.GetString("Vestuario"));
                        NumeroVestuario numeroVestuario = new NumeroVestuario(reader.GetInt32("IdNumeroVestuario"),
                            vestuario, reader.GetString("Numero"));

                        NumeroMilitar numeroMilitar = new NumeroMilitar(reader.GetInt32("ID"), militarN, numeroVestuario, farda);

                        LNumeroMilitar.Add(numeroMilitar);
                    }
                }

                return LNumeroMilitar;
            }
            catch
            {
                return new List<NumeroMilitar>();
            }
            finally
            {
                Con.Fechar();
            }
        }
    }
}
