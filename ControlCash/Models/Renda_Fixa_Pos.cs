using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlCash.Models
{
    public class Renda_Fixa_Pos
    {
        [Key]
        public int Renda_PosID { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public string Emissor { get; set; }
        public string Papel { get; set; }
        public string Indexador { get; set; }
        public float Porcentagem { get; set; }
        public string Data_Inicio { get; set; }
        public string Data_Venc { get; set; } //Data de Vencimento
        public float Valor_Aplicado { get; set; }
        public String UserID { get; set; }
    }
}