using System;

namespace ConsultaPessoa.Models
{
    public class EntEndereco
    {
        public Int32 IdEndereco { get; set; }
        public String Cep { get; set; }
        public String Endereco { get; set; }
        public Int32 Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        private EntTipoEndereco _TipoEndereco;
        public EntTipoEndereco TipoEndereco
        {
            get
            {
                if (_TipoEndereco == null)
                {
                    _TipoEndereco = new EntTipoEndereco();
                }
                return _TipoEndereco;
            }

            set { _TipoEndereco = value; }
        }
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
        public Boolean Ativo { get; set; }
    }
}

