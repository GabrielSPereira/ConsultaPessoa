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
    public class DalTelefone
    {
        public void Inserir(EntTelefone objTelefone, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_TelefoneInserir", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_TELEFONE", SqlDbType.Int).Value = objTelefone.IdTelefone;
            scCommand.Parameters.Add("@FK_TIPO_TELEFONE", SqlDbType.Int).Value = objTelefone.TipoTelefone.IdTipoTelefone;
            scCommand.Parameters.Add("@FK_CLIENTE", SqlDbType.Int).Value = objTelefone.Cliente.IdCliente;
            scCommand.Parameters.Add("@TX_NUMERO", SqlDbType.VarChar).Value = objTelefone.Numero;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objTelefone.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public void Alterar(EntTelefone objTelefone, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_TelefoneAlterar", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_TELEFONE", SqlDbType.Int).Value = objTelefone.IdTelefone;
            scCommand.Parameters.Add("@FK_TIPO_TELEFONE", SqlDbType.Int).Value = objTelefone.TipoTelefone.IdTipoTelefone;
            scCommand.Parameters.Add("@FK_CLIENTE", SqlDbType.Int).Value = objTelefone.Cliente.IdCliente;
            scCommand.Parameters.Add("@TX_NUMERO", SqlDbType.VarChar).Value = objTelefone.Numero;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objTelefone.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public void Remover(EntTelefone objTelefone, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_TelefoneRemover", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@PK_TELEFONE", SqlDbType.Int).Value = objTelefone.IdTelefone;
            scCommand.Parameters.Add("@FL_ATIVO", SqlDbType.Bit).Value = objTelefone.Ativo;

            scCommand.ExecuteNonQuery();
        }

        public List<EntTelefone> ObterTodos(Int32 IdCliente, Int32 Status, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_TelefoneSelecionarTodos", db.Connection);
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
                return new List<EntTelefone>();
            }
        }

        private List<EntTelefone> Popular(SqlDataReader dtrDados)
        {
            List<EntTelefone> listEntReturn = new List<EntTelefone>();
            EntTelefone entReturn;

            try
            {
                while (dtrDados.Read())
                {
                    entReturn = new EntTelefone();

                    entReturn.IdTelefone = (int)dtrDados["PK_TELEFONE"];
                    entReturn.Cliente.IdCliente = (int)dtrDados["FK_CLIENTE"];
                    entReturn.TipoTelefone.IdTipoTelefone = (int)dtrDados["FK_TIPO_TELEFONE"];
                    entReturn.Numero = dtrDados["TX_NUMERO"].ToString();
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

        public EntTelefone ObterPorId(Int32 IdTelefone, SqlCommand db)
        {
            SqlCommand scCommand = new SqlCommand("STP_TelefoneSelecionarPorId", db.Connection);
            scCommand.CommandType = CommandType.StoredProcedure;

            scCommand.Parameters.Add("@IdTelefone", SqlDbType.Int).Value = IdTelefone;

            SqlDataReader reader = scCommand.ExecuteReader();

            if (reader.FieldCount > 0)
            {
                return this.Popular(reader)[0];
            }
            else
            {
                return new EntTelefone();
            }
        }
    }
}