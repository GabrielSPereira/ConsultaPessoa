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
    public class DalCliente
    {
        public void Inserir(EntCliente objCliente, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_ClienteInserir", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_CLIENTE", SqlDbType.Int).Value = objCliente.IdCliente;
            scCommand.Parameters.Add("@TX_NOME", SqlDbType.VarChar).Value = objCliente.Nome;
            scCommand.Parameters.Add("@TX_DOCUMENTO", SqlDbType.VarChar).Value = objCliente.Documento;
            scCommand.Parameters.Add("@FL_IS_PESSOA_FISICA", SqlDbType.Bit).Value = objCliente.IsPessoaFisica;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objCliente.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public void Alterar(EntCliente objCliente, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_ClienteAlterar", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_CLIENTE", SqlDbType.Int).Value = objCliente.IdCliente;
            scCommand.Parameters.Add("@TX_NOME", SqlDbType.VarChar).Value = objCliente.Nome;
            scCommand.Parameters.Add("@TX_DOCUMENTO", SqlDbType.VarChar).Value = objCliente.Documento;
            scCommand.Parameters.Add("@FL_IS_PESSOA_FISICA", SqlDbType.Bit).Value = objCliente.IsPessoaFisica;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objCliente.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public void Remover(EntCliente objCliente, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_ClienteRemover", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_CLIENTE", SqlDbType.Int).Value = objCliente.IdCliente;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objCliente.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public List<EntCliente> ObterTodos(Int32 IdCliente, Int32 Status, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_ClienteSelecionarTodos", db.Connection);
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
                return new List<EntCliente>();
            }
        }

        private List<EntCliente> Popular(SqlDataReader dtrDados)
        {
            List<EntCliente> listEntReturn = new List<EntCliente>();
            EntCliente entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntCliente();

                    entReturn.IdCliente = (int)dtrDados["PK_CLIENTE"];
                    entReturn.Nome = dtrDados["TX_NOME"].ToString();
                    entReturn.Documento = dtrDados["TX_DOCUMENTO"].ToString();
                    entReturn.Ativo = (Boolean)dtrDados["FL_IS_PESSOA_FISICA"];
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

        public EntCliente ObterPorId(Int32 IdCliente, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_ClienteSelecionarPorId", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@IdCliente", SqlDbType.Int).Value = IdCliente;

            SqlDataReader reader = scCommand.ExecuteReader();

            if (reader.FieldCount > 0)
            {
                return this.Popular(reader)[0];
            }
            else
            {
                return new EntCliente();
            }
        }
    }
}