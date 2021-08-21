using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlCash.Models
{
    public class Tesouro_Direto
    {
        [Key]
        public int TesousoID { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public string Titulo { get; set; }
        public string Aplica_por { get; set; } //Por valor ou Por quantidade e preço.
        public float Valor_Aplicado { get; set; }
        public int Quantidade { get; set; }
        public float Preco_Compra { get; set; }
        public string Data_Inicio { get; set; }
        public String UserID { get; set; }
    }
}