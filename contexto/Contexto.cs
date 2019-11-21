using Oficial.models;
using System;
using System.Data.Entity;
using System.Windows;

namespace Oficial.contexto
{
    public class Contexto : DbContext
    {

        public Contexto() : base(nameOrConnectionString: "oficial")
        {
            //Database.SetInitializer<Contexto>(new OficialContextoInitializer());
        }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Carro> Carro { get; set; }

        public class OficialContextoInitializer :
        DropCreateDatabaseAlways<Contexto>
        {
        }
    }
}
