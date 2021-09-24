using System;

namespace ConsultaPessoa.Models
{
    public class EntCliente
    {
        public Int32 IdCliente { get; set; }
        public String Nome { get; set; }
        public String Documento { get; set; }
        public Boolean IsPessoaFisica { get; set; }
        public Boolean Ativo { get; set; }
    }
}

