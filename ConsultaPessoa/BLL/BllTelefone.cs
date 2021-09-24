using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPessoa.Models
{
    public class BllTelefone : BllBase
    {
        private DalTelefone dalTelefone = new DalTelefone();

        public EntTelefone Inserir(EntTelefone objTelefone)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                dalTelefone.Inserir(objTelefone, cmd); //Chama método de inserção de Telefone passando o objeto
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objTelefone;
        }

        public void Alterar(EntTelefone objTelefone)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                dalTelefone.Alterar(objTelefone, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }
        }

        public EntTelefone Remover(EntTelefone objTelefone)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                objTelefone.Ativo = !objTelefone.Ativo;
                dalTelefone.Remover(objTelefone, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objTelefone;
        }

        public List<EntTelefone> ObterTodos(Int32 IdCliente, Int32 Status)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            List<EntTelefone> lstTelefone = new List<EntTelefone>();

            try
            {
                lstTelefone = dalTelefone.ObterTodos(IdCliente, Status, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return lstTelefone;
        }

        public EntTelefone ObterPorId(Int32 IdTelefone)
        {
            EntTelefone objTelefone = new EntTelefone();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                objTelefone = dalTelefone.ObterPorId(IdTelefone, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objTelefone;
        }

    }
}