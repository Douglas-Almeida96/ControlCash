using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlCash.Models
{
    public class Poupanca
    {
        [Key]
        public int PoupancaID { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public float Valor_Aplicado { get; set; }
        public string Data_Inicio { get; set; }
        public String UserID { get; set; }
    }
}