using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ControlCash.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
        }
         public DbSet<Cartao> Cartaos { get; set; }
         public DbSet<Gasto> Gastoes { get; set; }
         public DbSet<RendaExtra> RendaExtras { get; set; }
         public DbSet<Instituicao> Instituicoes { get; set; }
         public DbSet<TipoCartao> TipoCartaos { get; set; }
         public DbSet<TipoConsumo> TipoConsumoes { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Acoes_BDR_FII> Acoes_BDR_FII { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Criptomoeda> Criptomoedas { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Debenture> Debentures { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Fundo> Fundoes { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Moeda> Moedas { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Poupanca> Poupancas { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Previdencia> Previdencias { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Renda_Fixa_Pos> Renda_Fixa_Pos { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Renda_Fixa_Pre> Renda_Fixa_Pre { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Tesouro_Direto> Tesouro_Direto { get; set; }

        public System.Data.Entity.DbSet<ControlCash.Models.Questionario> Questionarios { get; set; }
    }
}