using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ConsultaPessoa.Commons;

namespace ConsultaPessoa.Models
{
    public class DalEndereco
    {
        public void Inserir(EntEndereco objEndereco, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_EnderecoInserir", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_ENDERECO", SqlDbType.Int).Value = objEndereco.IdEndereco;
            scCommand.Parameters.Add("@FK_TIPO_ENDERECO", SqlDbType.Int).Value = objEndereco.TipoEndereco.IdTipoEndereco;
            scCommand.Parameters.Add("@FK_CLIENTE", SqlDbType.Int).Value = objEndereco.Cliente.IdCliente;
            scCommand.Parameters.Add("@TX_ENDERECO", SqlDbType.VarChar).Value = objEndereco.Endereco;
            scCommand.Parameters.Add("@NU_NUMERO", SqlDbType.Int).Value = objEndereco.Numero;
            scCommand.Parameters.Add("@TX_COMPLEMENTO", SqlDbType.VarChar).Value = objEndereco.Complemento;
            scCommand.Parameters.Add("@TX_BAIRRO", SqlDbType.VarChar).Value = objEndereco.Bairro;
            scCommand.Parameters.Add("@TX_CIDADE", SqlDbType.VarChar).Value = objEndereco.Cidade;
            scCommand.Parameters.Add("@TX_ESTADO", SqlDbType.VarChar).Value = objEndereco.Estado;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objEndereco.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public void Alterar(EntEndereco objEndereco, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_EnderecoAlterar", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_ENDERECO", SqlDbType.Int).Value = objEndereco.IdEndereco;
            scCommand.Parameters.Add("@FK_TIPO_ENDERECO", SqlDbType.Int).Value = objEndereco.TipoEndereco.IdTipoEndereco;
            scCommand.Parameters.Add("@FK_CLIENTE", SqlDbType.Int).Value = objEndereco.Cliente.IdCliente;
            scCommand.Parameters.Add("@TX_ENDERECO", SqlDbType.VarChar).Value = objEndereco.Endereco;
            scCommand.Parameters.Add("@NU_NUMERO", SqlDbType.Int).Value = objEndereco.Numero;
            scCommand.Parameters.Add("@TX_COMPLEMENTO", SqlDbType.VarChar).Value = objEndereco.Complemento;
            scCommand.Parameters.Add("@TX_BAIRRO", SqlDbType.VarChar).Value = objEndereco.Bairro;
            scCommand.Parameters.Add("@TX_CIDADE", SqlDbType.VarChar).Value = objEndereco.Cidade;
            scCommand.Parameters.Add("@TX_ESTADO", SqlDbType.VarChar).Value = objEndereco.Estado;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objEndereco.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public void Remover(EntEndereco objEndereco, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_EnderecoRemover", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_ENDERECO", SqlDbType.Int).Value = objEndereco.IdEndereco;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objEndereco.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public List<EntEndereco> ObterTodos(Int32 IdCliente, Int32 Status, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_EnderecoSelecionarTodos", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@IdCliente", SqlDbType.Int).Value = Utils.ToIntNull(IdCliente);
            scCommand.Parameters.Add("@Status", SqlDbType.Bit).Value = Utils.ToBooleanNull(Status);

            SqlDataReader reader = scCommand.ExecuteReader();

            if (reader.FieldCount > 0)
            {
                return this.Popular(reader);
            }
            else
            {
                return new List<EntEndereco>();
            }
        }

        private List<EntEndereco> Popular(SqlDataReader dtrDados)
        {
            List<EntEndereco> listEntReturn = new List<EntEndereco>();
            EntEndereco entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntEndereco();

                    entReturn.IdEndereco = (int)dtrDados["PK_ENDERECO"];
                    entReturn.TipoEndereco.IdTipoEndereco = (int)dtrDados["FK_TIPO_ENDERECO"];
                    entReturn.Cliente.IdCliente = (int)dtrDados["FK_CLIENTE"];
                    entReturn.Endereco = dtrDados["TX_ENDERECO"].ToString();
                    entReturn.Bairro = dtrDados["TX_BAIRRO"].ToString();
                    entReturn.Cep = dtrDados["TX_CEP"].ToString();
                    entReturn.Cidade = dtrDados["TX_CIDADE"].ToString();
                    entReturn.Estado = dtrDados["TX_ESTADO"].ToString();
                    entReturn.Complemento = dtrDados["TX_COMPLEMENTO"].ToString();
                    entReturn.Numero = (int)dtrDados["NU_NUMERO"];
                    entReturn.Ativo = (Boolean)dtrDados["FL_ATIVO"];
                    listEntReturn.Add(entReturn);
                }

                dtrDados.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listEntReturn;
        }

        public EntEndereco ObterPorId(Int32 IdEndereco, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_EnderecoSelecionarPorId", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@IdEndereco", SqlDbType.Int).Value = IdEndereco;

            SqlDataReader reader = scCommand.ExecuteReader();

            if (reader.FieldCount > 0)
            {
                return this.Popular(reader)[0];
            }
            else
            {
                return new EntEndereco();
            }
        }
    }
}