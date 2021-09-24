using System;

namespace ConsultaPessoa.Models
{
    public class EntTelefone
    {
        public Int32 IdTelefone { get; set; }
        public String Numero { get; set; }
        private EntCliente _Cliente;
        public EntCliente Cliente
        {
            get
            {
                if (_Cliente == null)
                {
                    _Cliente = new EntCliente();
                }
                return _Cliente;
            }

            set { _Cliente = value; }
        }
        private EntTipoTelefone _TipoTelefone;
        public EntTipoTelefone TipoTelefone
        {
            get
            {
                if (_TipoTelefone == null)
                {
                    _TipoTelefone = new EntTipoTelefone();
                }
                return _TipoTelefone;
            }

            set { _TipoTelefone = value; }
        }
        public Boolean Ativo { get; set; }
    }
}

