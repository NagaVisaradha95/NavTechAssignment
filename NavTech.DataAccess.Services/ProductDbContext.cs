/************************************************************************************************************
************************************************************************************************************
    File Name     :   ProductDbContext.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Db context for EF core using to get/update information from sql server
************************************************************************************************************
************************************************************************************************************/

using Microsoft.EntityFrameworkCore;
using NavTech.AppGateway.Model.DatabaseModel;

#nullable disable

namespace NavTech.AppGateway.DataAccess.Services
{
    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ProductDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product");

                entity.Property(e => e.EntityName).HasMaxLength(50);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FieldSource).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
