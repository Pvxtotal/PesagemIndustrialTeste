namespace Pesagem_Industrial.DbConnect
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Pesagem_Industrial.Models;

    public class PesagemIndustrialConnect : DbContext
    {
        // Your context has been configured to use a 'PesagemIndustrialConnect' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Pesagem_Industrial.DbConnect.PesagemIndustrialConnect' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PesagemIndustrialConnect' 
        // connection string in the application configuration file.
        public PesagemIndustrialConnect()
            : base("name=PesagemIndustrialConnect")
        {
        }

        static PesagemIndustrialConnect()
        {
            var obj = new DropCreateDatabaseIfModelChanges<PesagemIndustrialConnect>();
            Database.SetInitializer(obj);

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Armazem> Armazens { get; set; }

        public System.Data.Entity.DbSet<Pesagem_Industrial.Models.Unidade> Unidades { get; set; }

        public System.Data.Entity.DbSet<Pesagem_Industrial.Models.Usuario> Usuarios { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}