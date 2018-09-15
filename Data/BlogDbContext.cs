using CursoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoWebApi.Data {
    public class BlogDbContext : DbContext {
        public BlogDbContext (DbContextOptions<BlogDbContext> options) : base (options) { }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Categoria> (entity => {
                entity.Property (e => e.Id).HasColumnName ("ID");

                entity.Property (e => e.Nome)
                    .HasColumnName ("Nome")
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.PalavraChave)
                    .HasColumnName ("Key")
                    .HasMaxLength (255)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<Post> (entity => {
                entity.Property (e => e.PostId).HasColumnName ("PostId");

                entity.Property (e => e.CategoriaId).HasColumnName ("CategoriaId");

                entity.Property (e => e.DataCriacao)
                    .HasColumnName ("Data")
                    .HasColumnType ("datetime");

                entity.Property (e => e.Descricao)
                    .HasColumnName ("DescricaoPost")
                    .IsUnicode (false);

                entity.Property (e => e.Titulo)
                    .HasColumnName ("TituloPost")
                    .HasMaxLength (2000)
                    .IsUnicode (false);

                entity.HasOne (d => d.Categoria)
                    .WithMany (p => p.Posts)
                    .HasForeignKey (d => d.CategoriaId)
                    .HasConstraintName ("FK__Post__CategoriaId");
            });

            modelBuilder.Entity<Categoria> ().HasData (
                new Categoria () { Id = 1, Nome = "CSHARP", PalavraChave = "csharp" },
                new Categoria () { Id = 2, Nome = "VISUAL STUDIO 2017", PalavraChave = "visualstudio" },
                new Categoria () { Id = 3, Nome = "SQL SERVER", PalavraChave = "sqlserver" },
                new Categoria () { Id = 4, Nome = "ASP.NET CORE", PalavraChave = "aspnetcore" });
        }

    }
}