namespace AhorcadoWCF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AhorcadoDBEntities : DbContext
    {
        public AhorcadoDBEntities()
            : base("name=AhorcadoDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<palabra> palabra { get; set; }
        public virtual DbSet<partida> partida { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<historial_puntaje> historial_puntaje { get; set; }
        public virtual DbSet<movimiento> movimiento { get; set; }
    }
}
