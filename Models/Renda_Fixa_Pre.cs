using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlCash.Models
{
    public class Renda_Fixa_Pre
    {
        [Key]
        public int Renda_PreID { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public string Emissor { get; set; }
        public string Papel { get; set; }
        public float Taxa_Juros_Ano { get; set; }
        public string Data_Inicio { get; set; }
        public string Data_Venc { get; set; } //Data de Vencimento
        public float Valor_Aplicado { get; set; }
        public String UserID { get; set; }
    }
}