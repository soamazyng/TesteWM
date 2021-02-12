using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebMotorsDesafio.Contracts;
using WebMotorsDesafio.Entities;

namespace WebMotorsDesafio.Repositories
{
    public class AnuncioRepository : BaseRepository, IAnuncioRepository
    {        
        public void DeleteAnuncio(int Id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE AnuncioWebmotors Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public AnuncioWebmotors GetAnuncioById(int id)
        {
            string sql = $"Select Id, Marca, Modelo, Versao, Ano, Quilometragem, Observacao FROM AnuncioWebmotors WHERE Id={id}";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<AnuncioWebmotors> anunciosList = new List<AnuncioWebmotors>();
                
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                anunciosList.Add(new AnuncioWebmotors
                                {
                                    Id = (int)reader["Id"],
                                    Marca = reader["Marca"].ToString(),
                                    Modelo = reader["Modelo"].ToString(),
                                    Versao = reader["Versao"].ToString(),
                                    Ano = Convert.ToInt32(reader["Ano"]),
                                    Quilometragem = Convert.ToInt32(reader["Quilometragem"]),
                                    Observacao = reader["Observacao"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally{
                    conn.Close();
                }

                return anunciosList.First();
            }
        }

        public IEnumerable<AnuncioWebmotors> GetAnuncios()
        {
            string sql = "Select Id, Marca, Modelo, Versao, Ano, Quilometragem, Observacao FROM AnuncioWebmotors ORDER BY Marca";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<AnuncioWebmotors> anunciosList = new List<AnuncioWebmotors>();
                
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                anunciosList.Add(new AnuncioWebmotors
                                {
                                    Id = (int)reader["Id"],
                                    Marca = reader["Marca"].ToString(),
                                    Modelo = reader["Modelo"].ToString(),
                                    Versao = reader["Versao"].ToString(),
                                    Ano = Convert.ToInt32(reader["Ano"]),
                                    Quilometragem = Convert.ToInt32(reader["Quilometragem"]),
                                    Observacao = reader["Observacao"].ToString()
                                });
                            }                            
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return anunciosList;
            }
        }

        public void InsertAnuncio(AnuncioWebmotors anunciowebMotors)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO AnuncioWebmotors ( Marca, Modelo, Versao, Ano, Quilometragem, Observacao) VALUES ( @Marca, @Modelo, @Versao, @Ano, @Quilometragem, @Observacao)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Marca", anunciowebMotors.Marca);
                cmd.Parameters.AddWithValue("@Modelo", anunciowebMotors.Modelo);
                cmd.Parameters.AddWithValue("@Versao", anunciowebMotors.Versao);
                cmd.Parameters.AddWithValue("@Ano", anunciowebMotors.Ano);
                cmd.Parameters.AddWithValue("@Quilometragem", anunciowebMotors.Quilometragem);
                cmd.Parameters.AddWithValue("@Observacao", anunciowebMotors.Observacao);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public void UpdateAnuncio(AnuncioWebmotors anuncioWebmotors)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE AnuncioWebmotors SET Marca=@Marca, Modelo=@Modelo, Versao=@Versao, Ano=@Ano, Quilometragem=@Quilometragem, Observacao=@Observacao Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@Id", anuncioWebmotors.Id);
                cmd.Parameters.AddWithValue("@Marca", anuncioWebmotors.Marca);
                cmd.Parameters.AddWithValue("@Modelo", anuncioWebmotors.Modelo);
                cmd.Parameters.AddWithValue("@Versao", anuncioWebmotors.Versao);
                cmd.Parameters.AddWithValue("@Ano", anuncioWebmotors.Ano);
                cmd.Parameters.AddWithValue("@Quilometragem", anuncioWebmotors.Quilometragem);
                cmd.Parameters.AddWithValue("@Observacao", anuncioWebmotors.Observacao);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}