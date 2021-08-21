using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlCash.Models
{
    public class Instituicao
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
    }
}