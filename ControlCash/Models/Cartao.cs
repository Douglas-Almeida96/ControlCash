using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlCash.Models
{
    public class Cartao
    {
        [Key]
        public int Id { get; set; }
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }
        public int TipoCartaoId { get; set; }
        public  virtual TipoCartao TipoCartao { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public double limite { get; set; }
        public String UserID { get; set; }
    }
}