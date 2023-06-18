using System;
using System.Collections.Generic;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;


namespace BusinessLogic.Context;

public partial class ES2DbContext : DbContext
{
    public ES2DbContext()
    {
    }

    public ES2DbContext(DbContextOptions<ES2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Utilizadors>? Utilizadors { get; set; }
    
    public virtual DbSet<Imovels>? Imovels { get; set; }
    
    public virtual DbSet<Fundos>? Fundos { get; set; }
    
    public virtual DbSet<Depositos>? Depositos { get; set; }
    
    public virtual DbSet<Codpostals>? Codpostals { get; set; }
    
    public virtual DbSet<Ativofinanceiros>? Ativofinanceiros { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(
            "Host=localhost;Database=es2;Username=es2;Password=es2;SearchPath=public;Port=15432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utilizadors>(entity =>
        {
            entity.HasKey(e => e.IdUtilizador);

            entity.ToTable("Utilizador");

            entity.Property(e => e.IdUtilizador)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("IdUtilizador");
            entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
            entity.Property(e => e.nif).HasMaxLength(10).IsRequired();
            entity.Property(e => e.ncc).HasMaxLength(10).IsRequired();
            entity.Property(e => e.rua).HasMaxLength(100).IsRequired();
            entity.Property(e => e.n_porta).IsRequired();
            entity.Property(e => e.username).HasMaxLength(100).IsRequired();
            entity.Property(e => e.pass).HasMaxLength(100).IsRequired();
            entity.Property(e => e.codpostal).HasMaxLength(9).IsRequired();
            entity.Property(e => e.tipoutilizador).IsRequired();
        });

       modelBuilder.Entity<Imovels>(entity =>
       {
           entity.ToTable("Imovels");
       
           entity.HasKey(e => e.idimovel);
       
           entity.Property(e => e.idimovel)
               .HasDefaultValueSql("uuid_generate_v4()")
               .HasColumnName("idimovel");
       
           entity.Property(e => e.nome)
               .HasMaxLength(100)
               .IsRequired();
       
           entity.Property(e => e.valorrenda)
               .IsRequired();
       
           entity.Property(e => e.valorcondo)
               .IsRequired();
       
           entity.Property(e => e.valoresti)
               .IsRequired();
       
           entity.Property(e => e.rua)
               .HasMaxLength(100)
               .IsRequired();
       
           entity.Property(e => e.nporta)
               .HasMaxLength(10)
               .IsRequired();
       
           entity.Property(e => e.codpostal)
               .HasMaxLength(20);
       
           entity.Property(e => e.idativofk)
               .HasColumnName("idativofk")
               .IsRequired();
       
           entity.HasOne(d => d.idativoNavigation)
               .WithMany(p => p.Imovels)
               .HasForeignKey(d => d.idativofk)
               .HasConstraintName("imovels_idativofk_fkey")
               .OnDelete(DeleteBehavior.Restrict);
       });


        modelBuilder.Entity<Fundos>(entity =>
        {
            entity.HasKey(e => e.idfundo);

            entity.ToTable("Fundos");

            entity.Property(e => e.idfundo)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("idfundo");
            entity.Property(e => e.nome).HasMaxLength(100).IsRequired();
            entity.Property(e => e.montante).IsRequired();
            entity.Property(e => e.taxajuro).IsRequired();

            entity.HasOne(d => d.idativoNavigation)
                .WithMany(p => p.Fundos)
                .HasForeignKey(d => d.idativofk)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Depositos>(entity =>
        {
            entity.HasKey(e => e.iddeposito);

            entity.ToTable("Depositos");
            entity.Property(e => e.iddeposito)
            .HasDefaultValueSql("uuid_generate_v4()")
            .HasColumnName("iddeposito");
        entity.Property(e => e.banco).HasMaxLength(100).IsRequired();
        entity.Property(e => e.titulares).HasMaxLength(255).IsRequired();
        entity.Property(e => e.valor).IsRequired();
        entity.Property(e => e.taxajuro).IsRequired();
        entity.Property(e => e.nconta).HasMaxLength(100).IsRequired();

        entity.HasOne(d => d.idativoNavigation)
            .WithMany(p => p.Depositos)
            .HasForeignKey(d => d.idativofk)
            .OnDelete(DeleteBehavior.Restrict);
    });

        modelBuilder.Entity<Codpostals>(entity =>
        {
            entity.HasKey(e => e.codpostal1);

            entity.ToTable("Codpostals");

            entity.Property(e => e.codpostal1).HasMaxLength(20).HasColumnName("codpostal1");
            entity.Property(e => e.localidade).HasMaxLength(100);

            entity.HasMany(d => d.Imovels)
                .WithOne()
                .HasForeignKey(d => d.codpostal)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(d => d.Utilizadors)
                .WithOne()
                .HasForeignKey(d => d.codpostal)
                .OnDelete(DeleteBehavior.Restrict); 
        });



        modelBuilder.Entity<Ativofinanceiros>(entity =>
        {
            entity.HasKey(e => e.idativo);

            entity.ToTable("Ativofinanceiro");

            entity.Property(e => e.idativo)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("idativo");
            entity.Property(e => e.datainicio).IsRequired();
            entity.Property(e => e.duracao).IsRequired();
            entity.Property(e => e.taxaimposto).IsRequired();
            entity.Property(e => e.idcliente).IsRequired();

            entity.HasOne(d => d.idclienteNavigation)
                .WithMany(p => p.Ativofinanceiros)
                .HasForeignKey(d => d.idcliente)
                .OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
