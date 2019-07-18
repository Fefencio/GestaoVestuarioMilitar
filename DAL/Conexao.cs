using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    internal class Conexao
    {
        string strConexao;
        MySqlConnection myConnection;

        internal Conexao()
        {
            strConexao = ConfigurationManager.ConnectionStrings["MySqlConnetion"].ConnectionString;
            myConnection = new MySqlConnection(strConexao);
        }

        internal MySqlConnection Abrir()
        {
            if (myConnection.State != ConnectionState.Open)
            {
                myConnection.Open();
            }
            return myConnection;
        }

        internal void Fechar()
        {
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
        }
    }
}
