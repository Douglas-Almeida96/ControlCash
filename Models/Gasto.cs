using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlCash.Models
{
    public class Gasto
    {
        [Key]
        public int Id { get; set; }

        public int CartaoId { get; set; }
        public virtual Cartao Cartao { get; set; }

        public int RendaExtraId { get; set; }
        public virtual RendaExtra RendaExtra { get; set; }

        public int Nparcelas { get; set; }
        public double ValorTotal { get; set; }

        public int TipoConsumoId { get; set; }
        public virtual TipoConsumo TipoConsumo{ get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public string UserID{ get; set; }
    }
}