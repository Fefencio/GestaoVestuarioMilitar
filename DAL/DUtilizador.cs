using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DUtilizador
    {
        Conexao Con = new Conexao();
        public Militar Login(Utilizador utilizador)
        {
            try
            {
                string command = string.Format("Select Militar.ID, Militar.Nome, Militar.Data_Nascimento, Militar.BI, " +
                    "Militar.Telefone, Militar.Email, Militar.Morada from Militar inner join Utilizador on " +
                    "Utilizador.Id_Militar=Militar.ID where Utilizador.Usuario=@Usuario and Utilizador.Senha=md5(@Senha) " +
                    "order by Militar.ID");

                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = utilizador.Usuario;
                cmdInsert.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = utilizador.Senha;

                var militar = new Militar();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        militar.ID = reader.GetInt32("ID");
                        militar.Nome = reader.GetString("Nome");
                    }
                    else
                    {
                        throw new InvalidOperationException("Utilizador e Senha Errados");
                    }
                }
                return militar;
            }
            finally
            {
                Con.Fechar();
            }
        }
    }
}
