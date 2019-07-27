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
    public class DNumeroVestuario
    {
        Conexao Con = new Conexao();
        public string Insert(NumeroVestuario numeroVestuario)
        {
            try
            {
                string command = "Insert into NumeroVestuario(Numero, IdVestuario) values(@Numero, @IdVestuario)";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Numero", MySqlDbType.VarChar).Value = numeroVestuario.Numero;
                cmdInsert.Parameters.Add("@IdVestuario", MySqlDbType.Int16).Value = numeroVestuario.Vestuario.ID;

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
        public string Update(NumeroVestuario numeroVestuario)
        {
            try
            {
                string command = "Update NumeroVestuario set Numero=@Numero, IdVestuario=@IdVestuario where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = numeroVestuario.ID;
                cmdInsert.Parameters.Add("@Numero", MySqlDbType.Int16).Value = numeroVestuario.Numero;
                cmdInsert.Parameters.Add("@IdVestuario", MySqlDbType.Int16).Value = numeroVestuario.Vestuario.ID;

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
        public string Delete(NumeroVestuario numeroVestuario)
        {
            try
            {
                string command = "Delete from  NumeroVestuario where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int16).Value = numeroVestuario.ID;

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
    }
}
