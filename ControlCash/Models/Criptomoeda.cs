using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlCash.Models
{
    public class Criptomoeda
    {
        [Key]
        public int CriptomoedaID { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public string Tipo_Moeda { get; set; }
        public int Quantidade { get; set; }
        public float Preco_Compra { get; set; }
        public string Data_Inicio { get; set; }
        public String UserID { get; set; }
    }
}