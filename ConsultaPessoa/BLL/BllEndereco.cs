using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaPessoa.Models
{
    public class BllEndereco : BllBase
    {
        private DalEndereco dalEndereco = new DalEndereco();

        public EntEndereco Inserir(EntEndereco objEndereco)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                dalEndereco.Inserir(objEndereco, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objEndereco;
        }

        public void Alterar(EntEndereco objEndereco)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                dalEndereco.Alterar(objEndereco, cmd);
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

        public EntEndereco Remover(EntEndereco objEndereco)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                objEndereco.Ativo = !objEndereco.Ativo;
                dalEndereco.Remover(objEndereco, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objEndereco;
        }

        public List<EntEndereco> ObterTodos(Int32 IdCliente, Int32 Status)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            List<EntEndereco> lstEndereco = new List<EntEndereco>();

            try
            {
                lstEndereco = dalEndereco.ObterTodos(IdCliente, Status, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return lstEndereco;
        }

        public EntEndereco ObterPorId(Int32 IdEndereco)
        {
            EntEndereco objEndereco = new EntEndereco();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;

            try
            {
                objEndereco = dalEndereco.ObterPorId(IdEndereco, cmd);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return objEndereco;
        }

    }
}