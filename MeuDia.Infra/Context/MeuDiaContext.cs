using MeuDia.Domain.Entities;
using MeuDia.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace MeuDia.Infra.Context
{
    public class MeuDiaContext : DbContext
    {

        // private readonly IConfiguration _configuration;

        public MeuDiaContext() { }
        public MeuDiaContext(
            DbContextOptions<MeuDiaContext> options
            //, IConfiguration configuration
            ) : base(options)
        {
            //_configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new RGBColorMap());
            modelBuilder.ApplyConfiguration(new HexColorMap());
            //     modelBuilder.ApplyConfiguration(new TaskTagMap());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conectionString = "Server=JEFERSON\\SQLDEV;Database=meudia;User Id=sa;Password=123456789;TrustServerCertificate=true;"; // _configuration["univida_connectionstring"];

            if (conectionString == "")
            {
                throw new ArgumentException("Connection string value cannot be empty");
            }

            optionsBuilder.UseSqlServer(conectionString);

            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<Domain.Entities.Task> Task { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<RGBColor> RGBColor { get; set; }
        public DbSet<HexColor> HexColor { get; set; }
        public DbSet<TaskTag> TaskTag { get; set; }

    }
}
