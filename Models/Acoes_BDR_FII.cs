using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlCash.Models
{
    public class Acoes_BDR_FII
    {
        [Key]
        public int Acoes_BDR_FIIID { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public string Ativo { get; set; }
        public int Quantidade { get; set; }
        public float Preco_Compra { get; set; }
        public string Data_Inicio { get; set; }
        public float Taxa { get; set; } //Corretagem + Emolumentos + Liquidação (Cálculo feito pelo cliente..)
        public String UserID { get; set; }
    }
}