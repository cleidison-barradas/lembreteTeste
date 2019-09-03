using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeusLembretes.com.Models
{
    public class LembreteContext:DbContext
    {
        public LembreteContext():base("DbLembrete")
        {

        }

        public System.Data.Entity.DbSet<MeusLembretes.com.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<MeusLembretes.com.Models.Lembrete> Lembretes { get; set; }
    }
}