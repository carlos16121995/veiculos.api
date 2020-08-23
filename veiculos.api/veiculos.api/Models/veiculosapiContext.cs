using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace veiculos.api.Models
{
    public partial class veiculosapiContext : DbContext
    {
        public veiculosapiContext()
        {
        }

        public veiculosapiContext(DbContextOptions<veiculosapiContext> options)
            : base(options)
        {
        }
        //Scaffold-DbContext "Server=den1.mysql6.gear.host;User ID=veiculosapi;Password=Qv8j4sh_Hpk_;Database=veiculosapi;Persist Security Info=True" MySql.Data.EntityFrameworkCore -OutputDir Models -f
        public virtual DbSet<Abastecimento> Abastecimento { get; set; }
        public virtual DbSet<MarcaVeiculo> MarcaVeiculo { get; set; }
        public virtual DbSet<ModeloVeiculo> ModeloVeiculo { get; set; }
        public virtual DbSet<TipoCombustivel> TipoCombustivel { get; set; }
        public virtual DbSet<TipoVeiculo> TipoVeiculo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=den1.mysql6.gear.host;User ID=veiculosapi;Password=Qv8j4sh_Hpk_;Database=veiculosapi;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Abastecimento>(entity =>
            {
                entity.ToTable("abastecimento", "veiculosapi");

                entity.HasIndex(e => e.TipoCombustivelId)
                    .HasName("COMBUSTIVEL_ABASTECIMENTO_idx");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("USUARIO_ABASTECIMENTO_idx");

                entity.HasIndex(e => e.VeiculoId)
                    .HasName("VEICULO_ABASTECIMENTO_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Km)
                    .HasColumnName("km")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Litro).HasColumnName("litro");

                entity.Property(e => e.Posto)
                    .IsRequired()
                    .HasColumnName("posto")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCombustivelId)
                    .HasColumnName("tipo_combustivel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.VeiculoId)
                    .HasColumnName("veiculo_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.TipoCombustivel)
                    .WithMany(p => p.Abastecimento)
                    .HasForeignKey(d => d.TipoCombustivelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_COMBUSTIVEL_ABASTECIMENTO");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Abastecimento)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_ABASTECIMENTO");

                entity.HasOne(d => d.Veiculo)
                    .WithMany(p => p.Abastecimento)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VEICULO_ABASTECIMENTO");
            });

            modelBuilder.Entity<MarcaVeiculo>(entity =>
            {
                entity.ToTable("marca_veiculo", "veiculosapi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModeloVeiculo>(entity =>
            {
                entity.ToTable("modelo_veiculo", "veiculosapi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCombustivel>(entity =>
            {
                entity.ToTable("tipo_combustivel", "veiculosapi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoVeiculo>(entity =>
            {
                entity.ToTable("tipo_veiculo", "veiculosapi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario", "veiculosapi");

                entity.HasIndex(e => e.Email)
                   .HasName("email_UNIQUE")
                   .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.ToTable("veiculo", "veiculosapi");

                entity.HasIndex(e => e.MarcaVeiculoId)
                    .HasName("MARCA_VEICULO_VEICULO_idx");

                entity.HasIndex(e => e.ModeloVeiculoId)
                    .HasName("MODELO_VEICULO_VEICULO_idx");

                entity.HasIndex(e => e.TipoCombustivelId)
                    .HasName("COMBUSTIVEL_VEICULO_idx");

                entity.HasIndex(e => e.TipoVeiculoId)
                    .HasName("TIPO_VEICULO_VEICULO_idx");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("USUARIO_VEICULO_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ano)
                    .IsRequired()
                    .HasColumnName("ano")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MarcaVeiculoId)
                    .HasColumnName("marca_veiculo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModeloVeiculoId)
                    .HasColumnName("modelo_veiculo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("placa")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Quilometragem)
                    .HasColumnName("quilometragem")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoCombustivelId)
                    .HasColumnName("tipo_combustivel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TipoVeiculoId)
                    .HasColumnName("tipo_veiculo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.MarcaVeiculo)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.MarcaVeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MARCA_VEICULO_VEICULO");

                entity.HasOne(d => d.ModeloVeiculo)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.ModeloVeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODELO_VEICULO_VEICULO");

                entity.HasOne(d => d.TipoCombustivel)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.TipoCombustivelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_COMBUSTIVEL_VEICULO");

                entity.HasOne(d => d.TipoVeiculo)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.TipoVeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_VEICULO_VEICULO");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_VEICULO");
            });
        }
    }
}
