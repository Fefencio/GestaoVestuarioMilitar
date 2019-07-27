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
    public class DEcomenda
    {
        Conexao Con = new Conexao();
        public string Insert(Ecomenda ecomenda)
        {
            try
            {
                using (MySqlTransaction trans = Con.Abrir().BeginTransaction())
                {
                    string command = "Insert into Ecomenda(Descricao, Data_Criacao, Data_Chegada, Id_Militar, Estado)" +
                    " values(@Descricao, @Data_Criacao, @Data_Chegada, @Id_Militar, @Estado)";
                    MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());
                    cmdInsert.Transaction = trans;

                    
                    cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = ecomenda.Descricao;
                    cmdInsert.Parameters.Add("@Data_Criacao", MySqlDbType.DateTime).Value = ecomenda.DataCriacao;
                    cmdInsert.Parameters.Add("@Data_Chegada", MySqlDbType.DateTime).Value = ecomenda.DataChegada;
                    cmdInsert.Parameters.Add("@Id_Militar", MySqlDbType.Int32).Value = ecomenda.Militar.ID;
                    cmdInsert.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = ecomenda.Estado.ToString();

                    cmdInsert.ExecuteNonQuery();
                    int id = (int)cmdInsert.LastInsertedId;


                    cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

                    cmdInsert.Parameters.Add("@Codigo", MySqlDbType.VarChar).Value = "E" + id.ToString("00000");
                    cmdInsert.CommandText = "Update Ecomenda set Codigo=@Codigo where ID=@ID";
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Parameters.Add("@Id_Farda", MySqlDbType.Int32);
                    cmdInsert.Parameters.Add("@Id_Serie", MySqlDbType.Int32);
                    cmdInsert.Parameters.Add("@Id_Numero_Vestuario", MySqlDbType.Int32);
                    cmdInsert.Parameters.Add("@Quantidade", MySqlDbType.Int32);
                    cmdInsert.CommandText = "Insert into EcomendaItems(Id_Farda, Id_Serie, Id_Numero_Vestuario, Quantidade, Id_Ecomenda) " +
                        "values (@Id_Farda, @Id_Serie, @Id_Numero_Vestuario,@Quantidade,@ID)";

                    foreach (var item in ecomenda.EcomendaItens)
                    {
                        cmdInsert.Parameters["@Id_Farda"].Value = item.Farda.ID;
                        cmdInsert.Parameters["@Id_Serie"].Value = item.Serie.ID;
                        cmdInsert.Parameters["@Id_Numero_Vestuario"].Value = item.NumeroVestuario.ID;
                        cmdInsert.Parameters["@Quantidade"].Value = item.Quantidade;
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
        public string Update(Ecomenda ecomenda)
        {
            try
            {
                using (MySqlTransaction trans = Con.Abrir().BeginTransaction())
                {
                    string command = "Update Ecomenda set Codigo=@Codigo, Descricao=@Descricao, Data_Criacao=@Data_Criacao," +
                    " Data_Chegada=@Data_Chegada, Id_Militar=@Id_Militar, Estado=@Estado where ID=@ID";
                    MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());
                    cmdInsert.Transaction = trans;
                    cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = ecomenda.ID;
                    cmdInsert.Parameters.Add("@Codigo", MySqlDbType.VarChar).Value = ecomenda.Codigo;
                    cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = ecomenda.Descricao;
                    cmdInsert.Parameters.Add("@Data_Criacao", MySqlDbType.DateTime).Value = ecomenda.DataCriacao;
                    cmdInsert.Parameters.Add("@Data_Chegada", MySqlDbType.DateTime).Value = ecomenda.DataChegada;
                    cmdInsert.Parameters.Add("@Id_Militar", MySqlDbType.Int32).Value = ecomenda.Militar.ID;
                    cmdInsert.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = ecomenda.Estado.ToString();

                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.CommandText = "Delete from EcomendaItems where Id_Ecomenda=@ID";
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Parameters.Add("@Id_Farda", MySqlDbType.Int32);
                    cmdInsert.Parameters.Add("@Id_Serie", MySqlDbType.Int32);
                    cmdInsert.Parameters.Add("@Id_Numero_Vestuario", MySqlDbType.Int32);
                    cmdInsert.Parameters.Add("@Quantidade", MySqlDbType.Int32);
                    cmdInsert.CommandText = "Insert into EcomendaItems(Id_Farda, Id_Serie, Id_Numero_Vestuario, Quantidade, Id_Ecomenda) " +
                        "values (@Id_Farda, @Id_Serie, @Id_Numero_Vestuario, @Quantidade, @ID)";

                    foreach (var item in ecomenda.EcomendaItens)
                    {
                        cmdInsert.Parameters["@Id_Farda"].Value = item.Farda.ID;
                        cmdInsert.Parameters["@Id_Serie"].Value = item.Serie.ID;
                        cmdInsert.Parameters["@Id_Numero_Vestuario"].Value = item.NumeroVestuario.ID;
                        cmdInsert.Parameters["@Quantidade"].Value = item.Quantidade;
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
        public string Delete(Ecomenda ecomenda)
        {
            try
            {
                string command = "Delete from Ecomenda where ID=@ID";
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = ecomenda.ID;

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
        public DataTable Select(Ecomenda ecomenda)
        {
            try
            {

                string filtro = "";
                if (ecomenda.DataChegada > DateTime.MinValue)
                {
                    filtro += " and Date(Data_Chegada)=Date(@Data_Chegada)";
                }
                if (ecomenda.DataCriacao > DateTime.MinValue)
                {
                    filtro += " and Date(Data_Criacao)=Date(@Data_Criacao)";
                }

                string command = string.Format("Select ID, Codigo, Descricao as 'Descrição', Data_Criacao as " +
                    "'Data de Criação' from Ecomenda where Codigo like @Codigo {0} order by ID desc", filtro);
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Codigo", MySqlDbType.VarChar).Value = ecomenda.Codigo + "%";
                cmdInsert.Parameters.Add("@Data_Chegada", MySqlDbType.DateTime).Value = ecomenda.DataChegada;
                cmdInsert.Parameters.Add("@Data_Criacao", MySqlDbType.DateTime).Value = ecomenda.DataCriacao;

                DataTable dtEcomendas = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdInsert);
                dataAdapter.Fill(dtEcomendas);

                return dtEcomendas;
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
        public Dictionary<string, int> ListarCodigoID()
        {
            try
            {

                string command = string.Format("Select ID, Codigo from Ecomenda where Estado=@Estado group by Codigo");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = EnumList.AbertoFechadoCancelado.Aberto.ToString();

                Dictionary<string, int> LMilitar = new Dictionary<string, int>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LMilitar.Add(reader.GetString("Codigo"), reader.GetInt32("ID"));
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
        public List<EcomendaItens> SelectTotalEncomendar(EcomendaItens ecomendaItens)
        {
            try
            {

                string filtro = "";
                if (ecomendaItens.Farda.ID > 0)
                {
                    filtro += " and Farda.ID=@IdFarda";
                }
                if (!string.IsNullOrWhiteSpace(ecomendaItens.NumeroVestuario.Numero))
                {
                    filtro += " and Numero_Vestuario.Numero like @Numero";
                }
                if (ecomendaItens.NumeroVestuario.Vestuario.ID > 0)
                {
                    filtro += " and Vestuario.ID=@IdVestuario";
                }

                string command = string.Format("Select Farda.ID as IdFarda, Farda.Nome as Farda, Vestuario.ID as IdVestuario, " +
                    "Vestuario.Nome as Vestuario, Numero_Vestuario.ID as IdNumero, Numero_Vestuario.Numero, " +
                    "count(Militar.ID) as Total from Numero_Vestuario inner join " +
                    "Militar_Numero on Numero_Vestuario.ID = Militar_Numero.Id_Numero_Vestuario inner join Farda " +
                    "on Farda.ID=Militar_Numero.Id_Farda inner join Militar on Militar.ID=Militar_Numero.Id_Militar " +
                    "inner join Vestuario on Vestuario.ID=Numero_Vestuario.Id_Vestuario where Vestuario.ID>0 {0} " +
                    "group by Vestuario.Nome, Numero_Vestuario.Numero", filtro);
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@IdFarda", MySqlDbType.Int32).Value = ecomendaItens.Farda.ID;
                cmdInsert.Parameters.Add("@Numero", MySqlDbType.VarChar).Value = ecomendaItens.NumeroVestuario.Numero + "%";
                cmdInsert.Parameters.Add("@IdVestuario", MySqlDbType.Int32).Value = ecomendaItens.NumeroVestuario.Vestuario.ID;

                List<EcomendaItens> lEcomendas = new List<EcomendaItens>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Farda farda = new Farda(reader.GetInt32("IdFarda"), reader.GetString("Farda"));
                        Vestuario vestuario = new Vestuario(reader.GetInt32("IdVestuario"), reader.GetString("Vestuario"));
                        NumeroVestuario numeroVestuario = new NumeroVestuario(reader.GetInt32("IdNumero"), vestuario, reader.GetString("Numero"));
                        int quantidade = reader.GetInt32("Total");

                        EcomendaItens ecomenda = new EcomendaItens()
                        {
                            Farda = farda,
                            NumeroVestuario = numeroVestuario,
                            Quantidade = quantidade
                        };

                        lEcomendas.Add(ecomenda);
                    }
                }

                return lEcomendas;
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
        public List<EcomendaItens> SelectItemsEncomenda(Ecomenda ecomenda)
        {
            try
            {

                string command = string.Format("Select Serie.ID as IdSerie, Serie.Nome as Serie, Farda.ID as IdFarda, " +
                    "Farda.Nome as Farda, Numero_Vestuario.ID as IdNumero, Vestuario.ID as IdVestuario, " +
                    "Vestuario.Nome as Vestuario, Numero_Vestuario.Numero, " +
                    "EcomendaItems.Quantidade from EcomendaItems inner join Serie on EcomendaItems.Id_Serie=Serie.ID " +
                    "inner join Farda on EcomendaItems.Id_Farda = Farda.ID inner join Numero_Vestuario on " +
                    "Numero_Vestuario.ID=EcomendaItems.Id_Numero_Vestuario inner join Vestuario on " +
                    "Vestuario.ID=Numero_Vestuario.Id_Vestuario where EcomendaItems.Id_Ecomenda=@ID group by EcomendaItems.ID;");
                MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());

                cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = ecomenda.ID;
                List<EcomendaItens> lEcomendas = new List<EcomendaItens>();
                using (var reader = cmdInsert.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Serie serie = new Serie(reader.GetInt32("IdSerie"), reader.GetString("Serie"));
                        Farda farda = new Farda(reader.GetInt32("IdFarda"), reader.GetString("Farda"));
                        Vestuario vestuario = new Vestuario(reader.GetInt32("IdVestuario"), reader.GetString("Vestuario"));
                        NumeroVestuario numeroVestuario = new NumeroVestuario(reader.GetInt32("IdNumero"), vestuario, reader.GetString("Numero"));
                        int quantidade = reader.GetInt32("Quantidade");

                        EcomendaItens ecomendaIt = new EcomendaItens()
                        {
                            Serie = serie,
                            Farda = farda,
                            NumeroVestuario = numeroVestuario,
                            Quantidade = quantidade
                        };

                        lEcomendas.Add(ecomendaIt);
                    }
                }

                return lEcomendas;
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
    }
}
