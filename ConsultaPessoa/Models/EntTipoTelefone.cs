using System;

namespace ConsultaPessoa.Models
{
    public class EntTipoTelefone
    {
        public const Int32 TIPO_TELEFONE_CELULAR = 1;
        public const Int32 TIPO_TELEFONE_RESIDENCIAL = 2;
        public const Int32 TIPO_TELEFONE_COMERCIAL = 3;

        public Int32 IdTipoTelefone { get; set; }
        public String TipoTelefone
        {
            get
            {
                if (IdTipoTelefone == TIPO_TELEFONE_CELULAR)
                {
                    return "Celular";
                }
                else if (IdTipoTelefone == TIPO_TELEFONE_RESIDENCIAL)
                {
                    return "Residencial";
                }
                return "Comercial";
            }
        }
    }
}

