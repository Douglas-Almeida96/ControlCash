using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlCash.Models
{
    public class RendaExtra
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public double Valor { get; set; }
        public string UserID { get; set; }
    }
}