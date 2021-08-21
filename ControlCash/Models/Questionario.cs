using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControlCash.Models
{
    public class Questionario
    {
        [Key]
        public int QuestID { get; set; }
        public int Perg1 { get; set; }
        public int Perg2 { get; set; }
        public int Perg3 { get; set; }
        public int Perg4 { get; set; }
        public int Perg5 { get; set; }
        public bool Perg6a { get; set; }
        public bool Perg6b { get; set; }
        public bool Perg6c { get; set; }
        public bool Perg6d { get; set; }
        public bool Perg6e { get; set; }
        public bool Perg6f { get; set; }
        public int Perg7 { get; set; }
        public int Perg8 { get; set; }
        public String UserID { get; set; }
    }
}