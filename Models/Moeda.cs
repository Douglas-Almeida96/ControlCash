using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlCash.Models
{
    public class Moeda
    {
        [Key]
        public int MoedaID { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public string Tipo_Moeda { get; set; }
        public float Cotacao { get; set; }
        public float Valor_Comprado { get; set; }
        public string Data_Inicio { get; set; }
        public String UserID { get; set; }
    }
}