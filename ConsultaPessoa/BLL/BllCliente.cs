using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPessoa.Models
{
    public class BllCliente : BllBase
    {
        private DalCliente dalCliente = new DalCliente();

        public EntCliente Inserir(EntCliente objCliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                dalCliente.Inserir(objCliente, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objCliente;
        }

        public void Alterar(EntCliente objCliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                dalCliente.Alterar(objCliente, cmd);
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

        public EntCliente Remover(EntCliente objCliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                objCliente.Ativo = !objCliente.Ativo;
                dalCliente.Remover(objCliente, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objCliente;
        }

        public List<EntCliente> ObterTodos(Int32 IdCliente, Int32 Status)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            List<EntCliente> lstCliente = new List<EntCliente>();

            try
            {
                lstCliente = dalCliente.ObterTodos(IdCliente, Status, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return lstCliente;
        }

        public EntCliente ObterPorId(Int32 IdCliente)
        {
            EntCliente objCliente = new EntCliente();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                objCliente = dalCliente.ObterPorId(IdCliente, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objCliente;
        }

    }
}