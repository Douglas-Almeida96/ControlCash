using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlCash.Models
{
    public class TipoCartao
    {
        [Key]
        public int id { get; set; }
        public string Tipo { get; set; }
    }
}