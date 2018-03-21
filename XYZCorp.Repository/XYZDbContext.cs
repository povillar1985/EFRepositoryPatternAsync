using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XYZCorp.Core.Domain;

namespace XYZCorp.Repository
{
    public class XYZDbContext : DbContext
    {
        public XYZDbContext(): base("XYZConnectionDb")
        {
        }

        //////private static XYZDbContext _context;
        //////public static XYZDbContext XYZDbCtx()
        //////{
        //////    if (_context == null)
        //////    {
        //////        _context = new XYZDbContext();
        //////    }
        //////    return _context;
        //////}

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //alternatively, I can use data anotations from my domain object(s) for this
            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
