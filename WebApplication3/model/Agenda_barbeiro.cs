using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.model
{
    public class Agenda_barbeiro
    {
        [Key]
        public int ID { get; set; }
        ///intervalo de trabalho ex: 30 ou 20 min
        public int TempoDeProdução { get; set; }
        ///dias de trabalho na semana
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }
    }
}
