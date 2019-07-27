using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DStock
    {
        Conexao Con = new Conexao();
        public string Insert(StockVestuarioFarda stock, MovimentoStock movimento)
        {
            try
            {
                using (MySqlTransaction trans = Con.Abrir().BeginTransaction())
                {

                    string command = "Select ID, Quantidade from Stock_Vestuario_Farda where Id_Serie=@IdSerie and Id_Farda=@IdFarda and Id_Numero_Vestuario=@IdNumero";
                    MySqlCommand cmdInsert = new MySqlCommand(command, Con.Abrir());
                    cmdInsert.Transaction = trans;

                    cmdInsert.Parameters.Add("@IdFarda", MySqlDbType.Int32).Value = stock.Farda.ID;
                    cmdInsert.Parameters.Add("@IdSerie", MySqlDbType.Int32).Value = stock.Serie.ID;
                    cmdInsert.Parameters.Add("@IdNumero", MySqlDbType.Int32).Value = stock.NumeroVestuario.ID;
                    cmdInsert.Parameters.Add("@Quantidade", MySqlDbType.Int32).Value = stock.Quantidade;
                    cmdInsert.Parameters.Add("@TipoMovimento", MySqlDbType.VarChar).Value = movimento.TipoMovimento.ToString();
                    cmdInsert.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = movimento.Descricao;
                    cmdInsert.Parameters.Add("@IdMilitar", MySqlDbType.Int32).Value = movimento.Militar.ID;
                    cmdInsert.Parameters.Add("@DataMovimento", MySqlDbType.DateTime).Value = movimento.DataMovimento;


                    int id = 0;
                    int quantidadeStock = 0;
                    using (var reader = cmdInsert.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32("ID");
                            quantidadeStock = reader.GetInt32("Quantidade");
                        }
                    }

                    if (id > 0)
                    {
                        cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

                        if (movimento.TipoMovimento == EnumList.TipoMovimento.Entrada)
                        {
                            cmdInsert.CommandText = "Update Stock_Vestuario_Farda set Quantidade=Quantidade+@Quantidade where ID=@ID";
                        }
                        else if(quantidadeStock > stock.Quantidade)
                        {
                            cmdInsert.CommandText = "Update Stock_Vestuario_Farda set Quantidade=Quantidade-@Quantidade where ID=@ID";
                        }
                        else
                        {
                            cmdInsert.CommandText = "Update Stock_Vestuario_Farda set Quantidade=0 where ID=@ID";
                        }
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        if (movimento.TipoMovimento == EnumList.TipoMovimento.Entrada)
                        {
                            cmdInsert.CommandText = "Insert into Stock_Vestuario_Farda(Id_Farda, Id_Serie, " +
                                "Id_Numero_Vestuario, Quantidade) values(@IdFarda, @IdSerie, @IdNumero, @Quantidade)";
                        }
                        else
                        {
                            cmdInsert.CommandText = "Insert into Stock_Vestuario_Farda(Id_Farda, Id_Serie, " +
                                "Id_Numero_Vestuario, Quantidade) values(@IdFarda, @IdSerie, @IdNumero, 0)";
                        }
                        cmdInsert.ExecuteNonQuery();
                        id = (int)cmdInsert.LastInsertedId;
                        cmdInsert.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
                    }

                    //Movimento do Stock
                    cmdInsert.CommandText = "Insert into Movimento_Stock(Id_Stock_Vestuario_Farda, Tipo_Movimento, " +
                        "Quantidade, Descricao, Id_Militar, DataMovimento) values(@ID, @TipoMovimento, @Quantidade, " +
                        "@Descricao, @IdMilitar, @DataMovimento)";
                    cmdInsert.ExecuteNonQuery();

                    trans.Commit();

                    return "OK";
                }
            }
            finally
            {
                Con.Fechar();
            }
        }
    }
}
