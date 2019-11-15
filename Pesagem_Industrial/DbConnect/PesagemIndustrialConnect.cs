namespace Pesagem_Industrial.DbConnect
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Linq;
    using Pesagem_Industrial.Models;

    public class PesagemIndustrialConnect : DbContext
    {

        public PesagemIndustrialConnect()
            : base("name=PesagemIndustrialConnect")
        {
        }

        static PesagemIndustrialConnect()
        {
            var obj = new DropCreateDatabaseIfModelChanges<PesagemIndustrialConnect>();
            Database.SetInitializer(obj);
            System.Data.Entity.Infrastructure.Interception.DbInterception.Add(new DbCommandInterceptor());

        }

        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Armazem> Armazens { get; set; }

        public System.Data.Entity.DbSet<Pesagem_Industrial.Models.Unidade> Unidades { get; set; }

        public System.Data.Entity.DbSet<Pesagem_Industrial.Models.Usuario> Usuarios { get; set; }
    }
}