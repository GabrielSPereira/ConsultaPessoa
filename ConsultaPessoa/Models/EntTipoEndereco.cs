using System;

namespace ConsultaPessoa.Models
{
    public class EntTipoEndereco
    {
        public const Int32 TIPO_ENDERECO_COBRANCA = 1;
        public const Int32 TIPO_ENDERECO_COMERCIAL = 2;
        public const Int32 TIPO_ENDERECO_CORRESPONDENCIA = 3;
        public const Int32 TIPO_ENDERECO_ENTREGA = 4;
        public const Int32 TIPO_ENDERECO_RESIDENCIAL = 5;

        public Int32 IdTipoEndereco { get; set; }
        public String TipoEndereco
        {
            get
            {
                if (IdTipoEndereco == TIPO_ENDERECO_COBRANCA)
                {
                    return "Cobrança";
                }
                else if (IdTipoEndereco == TIPO_ENDERECO_COMERCIAL)
                {
                    return "Comercial";
                }
                else if (IdTipoEndereco == TIPO_ENDERECO_CORRESPONDENCIA)
                {
                    return "Correspondência";
                }
                else if (IdTipoEndereco == TIPO_ENDERECO_ENTREGA)
                {
                    return "Entrega";
                }
                return "Residencial";
            }
        }
    }
}

