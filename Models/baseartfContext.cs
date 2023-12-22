using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ARTF2.Models
{
    public partial class baseartfContext : DbContext
    {
        public baseartfContext()
        {
        }

        public baseartfContext(DbContextOptions<baseartfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Canrf> Canrves { get; set; } = null!;
        public virtual DbSet<CombustibleType> CombustibleTypes { get; set; } = null!;
        public virtual DbSet<EmpreType> EmpreTypes { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<EquipoType> EquipoTypes { get; set; } = null!;
        public virtual DbSet<Equiuni> Equiunis { get; set; } = null!;
        public virtual DbSet<Fabricante> Fabricantes { get; set; } = null!;
        public virtual DbSet<Insrf> Insrves { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Modrf> Modrves { get; set; } = null!;
        public virtual DbSet<Monedum> Moneda { get; set; } = null!;
        public virtual DbSet<Permican> Permicans { get; set; } = null!;
        public virtual DbSet<Permisoin> Permisoins { get; set; } = null!;
        public virtual DbSet<Permisomod> Permisomods { get; set; } = null!;
        public virtual DbSet<Permrect> Permrects { get; set; } = null!;
        public virtual DbSet<Rectrf> Rectrves { get; set; } = null!;
        public virtual DbSet<RegimenJuridico> RegimenJuridicos { get; set; } = null!;
        public virtual DbSet<Solrf> Solrves { get; set; } = null!;
        public virtual DbSet<SolrfDoc> SolrfDocs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Usoequi> Usoequis { get; set; } = null!;
        public virtual DbSet<ModaEqui> ModaEquis { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=baseartf; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Canrf>(entity =>
            {
                entity.HasKey(e => e.Idcan)
                    .HasName("PK__canrf__0640C861DF87F879");

                entity.ToTable("canrf", "Artf");

                entity.Property(e => e.Idcan).HasColumnName("idcan");

                entity.Property(e => e.Fechacan)
                    .HasColumnType("date")
                    .HasColumnName("fechacan");

                entity.Property(e => e.Fechaofcan)
                    .HasColumnType("date")
                    .HasColumnName("fechaofcan");

                entity.Property(e => e.Fichacan).HasColumnName("fichacan");

                entity.Property(e => e.Homoclavecan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("homoclavecan");

                entity.Property(e => e.Juscan)
                    .IsUnicode(false)
                    .HasColumnName("juscan");

                entity.Property(e => e.NameFichaDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameFichaDoc");

                entity.Property(e => e.NumacuofsolNavigator)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("numacuofsolNavigator");

                entity.Property(e => e.Obscan)
                    .IsUnicode(false)
                    .HasColumnName("obscan");

                entity.HasOne(d => d.NumacuofsolNavigatorNavigation)
                    .WithMany(p => p.Canrves)
                    .HasForeignKey(d => d.NumacuofsolNavigator)
                    .HasConstraintName("FK__canrf__fechacan__6D0D32F4");
            });

            modelBuilder.Entity<CombustibleType>(entity =>
            {
                entity.HasKey(e => e.Idcomb)
                    .HasName("PK__Combusti__4E32D0FD30913FAC");

                entity.ToTable("CombustibleType", "Catalogs");

                entity.Property(e => e.Idcomb).HasColumnName("idcomb");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<EmpreType>(entity =>
            {
                entity.ToTable("EmpreType", "Catalogs");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Idempre)
                    .HasName("PK__empresa__B647E140A43B0789");

                entity.ToTable("empresa", "Catalogs");

                entity.Property(e => e.Idempre).HasColumnName("idempre");

                entity.Property(e => e.Dirempre)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("dirempre");

                entity.Property(e => e.Rsempre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("rsempre");

                entity.Property(e => e.TipoempreIdNavigation).HasColumnName("tipoempreIdNavigation");

                entity.HasOne(d => d.TipoempreIdNavigationNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.TipoempreIdNavigation)
                    .HasConstraintName("FK__empresa__tipoemp__5165187F");
            });

            modelBuilder.Entity<EquipoType>(entity =>
            {
                entity.HasKey(e => e.IdEqui)
                    .HasName("PK__EquipoTy__8D0491E2D9598D28");

                entity.ToTable("EquipoType", "Catalogs");

                entity.Property(e => e.IdEqui).HasColumnName("idEqui");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Equiuni>(entity =>
            {
                entity.HasKey(e => e.Idequi)
                    .HasName("PK__equiuni__C74D423413367851");

                entity.ToTable("equiuni", "Artf");

                entity.Property(e => e.Idequi).HasColumnName("idequi");

                entity.Property(e => e.CombuequiIdNavigation).HasColumnName("combuequiIdNavigation");

                entity.Property(e => e.EmpresaId).HasColumnName("empresaId");

                entity.Property(e => e.FabricanteId).HasColumnName("fabricanteId");

                entity.Property(e => e.Fcons)
                    .HasColumnType("date")
                    .HasColumnName("fcons");

                entity.Property(e => e.Fcontra)
                    .HasColumnType("date")
                    .HasColumnName("fcontra");

                entity.Property(e => e.Fecharequi)
                    .HasColumnType("date")
                    .HasColumnName("fecharequi");

                entity.Property(e => e.Fichaequi).HasColumnName("fichaequi");

                entity.Property(e => e.Graequi).HasColumnName("graequi");

                entity.Property(e => e.MarcaId).HasColumnName("marcaId");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("matricula");

                entity.Property(e => e.ModaEquiId).HasColumnName("modaEquiId");

                entity.Property(e => e.ModaequiIdNavigation).HasColumnName("modaequiIdNavigation");

                entity.Property(e => e.MonrentIdNavigation).HasColumnName("monrentIdNavigation");

                entity.Property(e => e.Mrent).HasColumnName("mrent");

                entity.Property(e => e.NameFichaDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameFichaDoc");

                entity.Property(e => e.Nofact)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nofact");

                entity.Property(e => e.Nserie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nserie");

                entity.Property(e => e.NumacuofsolNavigator)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("numacuofsolNavigator");

                entity.Property(e => e.Obsarre).HasColumnName("obsarre");

                entity.Property(e => e.Obsequi).HasColumnName("obsequi");

                entity.Property(e => e.Obsgra).HasColumnName("obsgra");

                entity.Property(e => e.RegiequiIdNavigation).HasColumnName("regiequiIdNavigation");

                entity.Property(e => e.Tcontra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tcontra");

                entity.Property(e => e.TipequiIdNavigation).HasColumnName("tipequiIdNavigation");

                entity.Property(e => e.UsoequiIdNavigation).HasColumnName("usoequiIdNavigation");

                entity.Property(e => e.Vcontra)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("vcontra");

                entity.HasOne(d => d.CombuequiIdNavigationNavigation)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.CombuequiIdNavigation)
                    .HasConstraintName("FK__equiuni__combueq__73BA3083");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__equiuni__empresa__7B5B524B");

                entity.HasOne(d => d.Fabricante)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.FabricanteId)
                    .HasConstraintName("FK__equiuni__fabrica__7A672E12");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.MarcaId)
                    .HasConstraintName("FK__equiuni__marcaId__797309D9");

                entity.HasOne(d => d.ModaEqui)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.ModaEquiId)
                    .HasConstraintName("FK__equiuni__modaEqu__787EE5A0");

                entity.HasOne(d => d.ModaequiIdNavigationNavigation)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.ModaequiIdNavigation)
                    .HasConstraintName("FK__equiuni__empresa__71D1E811");

                entity.HasOne(d => d.MonrentIdNavigationNavigation)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.MonrentIdNavigation)
                    .HasConstraintName("FK__equiuni__monrent__76969D2E");

                entity.HasOne(d => d.NumacuofsolNavigatorNavigation)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.NumacuofsolNavigator)
                    .HasConstraintName("FK__equiuni__numacuo__778AC167");

                entity.HasOne(d => d.RegiequiIdNavigationNavigation)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.RegiequiIdNavigation)
                    .HasConstraintName("FK__equiuni__regiequ__74AE54BC");

                entity.HasOne(d => d.TipequiIdNavigationNavigation)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.TipequiIdNavigation)
                    .HasConstraintName("FK__equiuni__tipequi__72C60C4A");

                entity.HasOne(d => d.UsoequiIdNavigationNavigation)
                    .WithMany(p => p.Equiunis)
                    .HasForeignKey(d => d.UsoequiIdNavigation)
                    .HasConstraintName("FK__equiuni__usoequi__75A278F5");
            });

            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.HasKey(e => e.Idfab)
                    .HasName("PK__fabrican__0180CDBD0CC41299");

                entity.ToTable("fabricante", "Catalogs");

                entity.Property(e => e.Idfab).HasColumnName("idfab");

                entity.Property(e => e.Rsfab)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("rsfab");
            });

            modelBuilder.Entity<Insrf>(entity =>
            {
                entity.HasKey(e => e.Idins)
                    .HasName("PK__insrf__047FB55537AB565A");

                entity.ToTable("insrf", "Artf");

                entity.Property(e => e.Idins).HasColumnName("idins");

                entity.Property(e => e.Cancelled)
                    .HasColumnName("cancelled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fecapins)
                    .HasColumnType("date")
                    .HasColumnName("fecapins");

                entity.Property(e => e.Homoclaveins)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("homoclaveins");

                entity.Property(e => e.NumacuofsolNavigator)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("numacuofsolNavigator");

                entity.Property(e => e.Obsins)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("obsins");

                entity.HasOne(d => d.NumacuofsolNavigatorNavigation)
                    .WithMany(p => p.Insrves)
                    .HasForeignKey(d => d.NumacuofsolNavigator)
                    .HasConstraintName("FK__insrf__homoclave__66603565");
            });


            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marca", "Catalogs");

                entity.Property(e => e.RsMarca)
                    .HasMaxLength(100)
                    .HasColumnName("rsMarca");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.Idmod)
                    .HasName("PK__modelo__0577AC63C8D9D2A0");

                entity.ToTable("modelo", "Catalogs");

                entity.Property(e => e.Idmod).HasColumnName("idmod");

                entity.Property(e => e.Modequi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modequi");
            });

            modelBuilder.Entity<Modrf>(entity =>
            {
                entity.HasKey(e => e.Idmod)
                    .HasName("PK__modrf__0577AC637C9E5046");

                entity.ToTable("modrf", "Artf");

                entity.Property(e => e.Idmod).HasColumnName("idmod");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Acumod).HasColumnName("acumod");

                entity.Property(e => e.Clavemod)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("clavemod");

                entity.Property(e => e.Desmod)
                    .IsUnicode(false)
                    .HasColumnName("desmod");

                entity.Property(e => e.Fechamod)
                    .HasColumnType("date")
                    .HasColumnName("fechamod");

                entity.Property(e => e.Fichatecmod).HasColumnName("fichatecmod");

                entity.Property(e => e.NameAcuDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameAcuDoc");

                entity.Property(e => e.NameFichaTecDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameFichaTecDoc");

                entity.Property(e => e.NumacuofsolNavigator)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("numacuofsolNavigator");

                entity.Property(e => e.Obsmod)
                    .IsUnicode(false)
                    .HasColumnName("obsmod");

                entity.HasOne(d => d.NumacuofsolNavigatorNavigation)
                    .WithMany(p => p.Modrves)
                    .HasForeignKey(d => d.NumacuofsolNavigator)
                    .HasConstraintName("FK__modrf__clavemod__6C190EBB");
            });

            modelBuilder.Entity<Monedum>(entity =>
            {
                entity.ToTable("Moneda", "Catalogs");

                entity.Property(e => e.Tipomoneda)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipomoneda");
            });

            modelBuilder.Entity<Permican>(entity =>
            {
                entity.HasKey(e => e.Idper)
                    .HasName("PK__permican__98FE8B7ED2A77A1D");

                entity.ToTable("permican", "Permission");

                entity.Property(e => e.Idper).HasColumnName("IDPER");

                entity.Property(e => e.Areapro)
                    .HasMaxLength(150)
                    .HasColumnName("AREAPRO");

                entity.Property(e => e.Areares)
                    .HasMaxLength(250)
                    .HasColumnName("AREARES");

                entity.Property(e => e.Cauter).HasColumnName("CAUTER");

                entity.Property(e => e.Condper).HasColumnName("CONDPER");

                entity.Property(e => e.Descancelacion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCANCELACION");

                entity.Property(e => e.Estaper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTAPER");

                entity.Property(e => e.Fechaappro)
                    .HasColumnType("date")
                    .HasColumnName("FECHAAPPRO");

                entity.Property(e => e.Fechaoficiocancelacion)
                    .HasColumnType("date")
                    .HasColumnName("FECHAOFICIOCANCELACION");

                entity.Property(e => e.Fechaper)
                    .HasColumnType("date")
                    .HasColumnName("FECHAPER");

                entity.Property(e => e.Instnot)
                    .HasMaxLength(800)
                    .HasColumnName("INSTNOT");

                entity.Property(e => e.Justcancelacion).HasColumnName("JUSTCANCELACION");

                entity.Property(e => e.Lugaper)
                    .HasMaxLength(800)
                    .HasColumnName("LUGAPER");

                entity.Property(e => e.Montgar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MONTGAR");

                entity.Property(e => e.Munper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MUNPER");

                entity.Property(e => e.Natgar)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NATGAR");

                entity.Property(e => e.Noautpro)
                    .HasMaxLength(250)
                    .HasColumnName("NOAUTPRO");

                entity.Property(e => e.Numoficiocancelacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMOFICIOCANCELACION");

                entity.Property(e => e.Numofper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMOFPER");

                entity.Property(e => e.Numper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMPER");

                entity.Property(e => e.Obper).HasColumnName("OBPER");

                entity.Property(e => e.Obrper).HasColumnName("OBRPER");

                entity.Property(e => e.Obsper).HasColumnName("OBSPER");

                entity.Property(e => e.Pdfcancelacion).HasColumnName("PDFCANCELACION");

                entity.Property(e => e.Proejeper).HasColumnName("PROEJEPER");

                entity.Property(e => e.Replegal)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("REPLEGAL");

                entity.Property(e => e.Rfmobservaciones).HasColumnName("RFMOBSERVACIONES");

                entity.Property(e => e.Tergar)
                    .HasMaxLength(250)
                    .HasColumnName("TERGAR");

                entity.Property(e => e.Tipoasientocan)
                    .HasMaxLength(250)
                    .HasColumnName("TIPOASIENTOCAN");

                entity.Property(e => e.Tipoper)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIPOPER");

                entity.Property(e => e.Ultimoasientoregistrado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ULTIMOASIENTOREGISTRADO");

                entity.Property(e => e.Vigenper)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VIGENPER");
            });

            modelBuilder.Entity<Permisoin>(entity =>
            {
                entity.HasKey(e => e.Idperins)
                    .HasName("PK__permisoi__8D8AB69FB728636E");

                entity.ToTable("permisoins", "Permission");

                entity.Property(e => e.Idperins).HasColumnName("IDPERINS");

                entity.Property(e => e.Areapro)
                    .HasMaxLength(150)
                    .HasColumnName("AREAPRO");

                entity.Property(e => e.Areares)
                    .HasMaxLength(250)
                    .HasColumnName("AREARES");

                entity.Property(e => e.Cauter).HasColumnName("CAUTER");

                entity.Property(e => e.Condper).HasColumnName("CONDPER");

                entity.Property(e => e.Estaper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTAPER");

                entity.Property(e => e.Fechaappro)
                    .HasColumnType("date")
                    .HasColumnName("FECHAAPPRO");

                entity.Property(e => e.Fechaper)
                    .HasColumnType("date")
                    .HasColumnName("FECHAPER");

                entity.Property(e => e.Homoins)
                    .HasMaxLength(150)
                    .HasColumnName("HOMOINS");

                entity.Property(e => e.Instnot)
                    .HasMaxLength(800)
                    .HasColumnName("INSTNOT");

                entity.Property(e => e.Lugaper)
                    .HasMaxLength(800)
                    .HasColumnName("LUGAPER");

                entity.Property(e => e.Montgar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MONTGAR");

                entity.Property(e => e.Munper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MUNPER");

                entity.Property(e => e.Natgar)
                    .HasMaxLength(250)
                    .HasColumnName("NATGAR");

                entity.Property(e => e.Noautpro)
                    .HasMaxLength(250)
                    .HasColumnName("NOAUTPRO");

                entity.Property(e => e.Numofper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMOFPER");

                entity.Property(e => e.Numper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMPER");

                entity.Property(e => e.Obper).HasColumnName("OBPER");

                entity.Property(e => e.Obrper).HasColumnName("OBRPER");

                entity.Property(e => e.Obsper).HasColumnName("OBSPER");

                entity.Property(e => e.Proejeper).HasColumnName("PROEJEPER");

                entity.Property(e => e.Replegal)
                    .HasMaxLength(250)
                    .HasColumnName("REPLEGAL");

                entity.Property(e => e.Tergar)
                    .HasMaxLength(250)
                    .HasColumnName("TERGAR");

                entity.Property(e => e.Tipoper)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIPOPER");

                entity.Property(e => e.Vigenper)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VIGENPER");
            });

            modelBuilder.Entity<Permisomod>(entity =>
            {
                entity.HasKey(e => e.Idpermod)
                    .HasName("PK__permisom__83725E4B59D94574");

                entity.ToTable("permisomod", "Permission");

                entity.Property(e => e.Idpermod).HasColumnName("IDPERMOD");

                entity.Property(e => e.Areapro)
                    .HasMaxLength(150)
                    .HasColumnName("AREAPRO");

                entity.Property(e => e.Areares)
                    .HasMaxLength(250)
                    .HasColumnName("AREARES");

                entity.Property(e => e.Cauter).HasColumnName("CAUTER");

                entity.Property(e => e.Condper).HasColumnName("CONDPER");

                entity.Property(e => e.Consmod).HasColumnName("CONSMOD");

                entity.Property(e => e.Desmod)
                    .HasMaxLength(250)
                    .HasColumnName("DESMOD");

                entity.Property(e => e.Domicilio).HasColumnName("DOMICILIO");

                entity.Property(e => e.Estaper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTAPER");

                entity.Property(e => e.Fechaappro)
                    .HasColumnType("date")
                    .HasColumnName("FECHAAPPRO");

                entity.Property(e => e.Fechainsc)
                    .HasColumnType("date")
                    .HasColumnName("FECHAINSC");

                entity.Property(e => e.Fechaofimod)
                    .HasColumnType("date")
                    .HasColumnName("FECHAOFIMOD");

                entity.Property(e => e.Fechaper)
                    .HasColumnType("date")
                    .HasColumnName("FECHAPER");

                entity.Property(e => e.Homoins)
                    .HasMaxLength(150)
                    .HasColumnName("HOMOINS");

                entity.Property(e => e.Idempresa).HasColumnName("IDEMPRESA");

                entity.Property(e => e.Instnot)
                    .HasMaxLength(800)
                    .HasColumnName("INSTNOT");

                entity.Property(e => e.Lugaper)
                    .HasMaxLength(800)
                    .HasColumnName("LUGAPER");

                entity.Property(e => e.Montgar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MONTGAR");

                entity.Property(e => e.Munper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MUNPER");

                entity.Property(e => e.Natgar)
                    .HasMaxLength(250)
                    .HasColumnName("NATGAR");

                entity.Property(e => e.Noautpro)
                    .HasMaxLength(250)
                    .HasColumnName("NOAUTPRO");

                entity.Property(e => e.Nummod).HasColumnName("NUMMOD");

                entity.Property(e => e.Numofimod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMOFIMOD");

                entity.Property(e => e.Numofper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMOFPER");

                entity.Property(e => e.Numper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMPER");

                entity.Property(e => e.Obper).HasColumnName("OBPER");

                entity.Property(e => e.Obrper).HasColumnName("OBRPER");

                entity.Property(e => e.Obsper).HasColumnName("OBSPER");

                entity.Property(e => e.Pdfmod).HasColumnName("PDFMOD");

                entity.Property(e => e.Proejeper).HasColumnName("PROEJEPER");

                entity.Property(e => e.Replegal)
                    .HasMaxLength(250)
                    .HasColumnName("REPLEGAL");

                entity.Property(e => e.Rfmobs).HasColumnName("RFMOBS");

                entity.Property(e => e.Tergar)
                    .HasMaxLength(250)
                    .HasColumnName("TERGAR");

                entity.Property(e => e.Tipoasientomod)
                    .HasMaxLength(250)
                    .HasColumnName("TIPOASIENTOMOD");

                entity.Property(e => e.Tipoper)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIPOPER");

                entity.Property(e => e.Vigenper)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VIGENPER");
            });

            modelBuilder.Entity<Permrect>(entity =>
            {
                entity.HasKey(e => e.Idpermrect)
                    .HasName("PK__permrect__E20D7A1E453E2E33");

                entity.ToTable("permrect", "Permission");

                entity.Property(e => e.Idpermrect).HasColumnName("idpermrect");

                entity.Property(e => e.Areapro)
                    .HasMaxLength(150)
                    .HasColumnName("AREAPRO");

                entity.Property(e => e.Areares)
                    .HasMaxLength(250)
                    .HasColumnName("AREARES");

                entity.Property(e => e.Cauter).HasColumnName("CAUTER");

                entity.Property(e => e.Condper).HasColumnName("CONDPER");

                entity.Property(e => e.ConsideracionesRectificacion).HasColumnName("CONSIDERACIONES_RECTIFICACION");

                entity.Property(e => e.DescripcionRectificacion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_RECTIFICACION");

                entity.Property(e => e.Estaper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTAPER");

                entity.Property(e => e.FechaInscripcion)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_INSCRIPCION");

                entity.Property(e => e.FechaOficioRectificacion)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_OFICIO_RECTIFICACION");

                entity.Property(e => e.Fechaappro)
                    .HasColumnType("date")
                    .HasColumnName("FECHAAPPRO");

                entity.Property(e => e.Fechaper)
                    .HasColumnType("date")
                    .HasColumnName("FECHAPER");

                entity.Property(e => e.Instnot)
                    .HasMaxLength(800)
                    .HasColumnName("INSTNOT");

                entity.Property(e => e.Lugaper)
                    .HasMaxLength(800)
                    .HasColumnName("LUGAPER");

                entity.Property(e => e.Montgar)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MONTGAR");

                entity.Property(e => e.Munper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MUNPER");

                entity.Property(e => e.Natgar)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NATGAR");

                entity.Property(e => e.Noautpro)
                    .HasMaxLength(250)
                    .HasColumnName("NOAUTPRO");

                entity.Property(e => e.NumeroOficioRectificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO_OFICIO_RECTIFICACION");

                entity.Property(e => e.NumeroRectificacion).HasColumnName("NUMERO_RECTIFICACION");

                entity.Property(e => e.Numofper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMOFPER");

                entity.Property(e => e.Numper)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMPER");

                entity.Property(e => e.Obper).HasColumnName("OBPER");

                entity.Property(e => e.Obrper).HasColumnName("OBRPER");

                entity.Property(e => e.Obsper).HasColumnName("OBSPER");

                entity.Property(e => e.PdfRectificacion).HasColumnName("PDF_RECTIFICACION");

                entity.Property(e => e.Proejeper).HasColumnName("PROEJEPER");

                entity.Property(e => e.Replegal)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("REPLEGAL");

                entity.Property(e => e.RfmObservaciones).HasColumnName("RFM_OBSERVACIONES");

                entity.Property(e => e.Tergar)
                    .HasMaxLength(250)
                    .HasColumnName("TERGAR");

                entity.Property(e => e.TipoAsientoRect)
                    .HasMaxLength(250)
                    .HasColumnName("TIPO_ASIENTO_RECT");

                entity.Property(e => e.Tipoper)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIPOPER");

                entity.Property(e => e.Vigenper)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VIGENPER");
            });

            modelBuilder.Entity<Rectrf>(entity =>
            {
                entity.HasKey(e => e.Idrect)
                    .HasName("PK__rectrf__EEB277A372405D52");

                entity.ToTable("rectrf", "Artf");

                entity.Property(e => e.Idrect).HasColumnName("idrect");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Acurect).HasColumnName("acurect");

                entity.Property(e => e.Desrect)
                    .IsUnicode(false)
                    .HasColumnName("desrect");

                entity.Property(e => e.Fechadocsol)
                    .HasColumnType("date")
                    .HasColumnName("fechadocsol");

                entity.Property(e => e.Fechamodrect)
                    .HasColumnType("date")
                    .HasColumnName("fechamodrect");

                entity.Property(e => e.Fecharect)
                    .HasColumnType("date")
                    .HasColumnName("fecharect");

                entity.Property(e => e.Fichatecrect).HasColumnName("fichatecrect");

                entity.Property(e => e.Homoclaverect)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("homoclaverect");

                entity.Property(e => e.NameAcuDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameAcuDoc");

                entity.Property(e => e.NameFichatecDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameFichatecDoc");

                entity.Property(e => e.NumacuofsolNavigator)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("numacuofsolNavigator");

                entity.Property(e => e.Numdocemp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numdocemp");

                entity.Property(e => e.Obsrect)
                    .IsUnicode(false)
                    .HasColumnName("obsrect");

                entity.HasOne(d => d.NumacuofsolNavigatorNavigation)
                    .WithMany(p => p.Rectrves)
                    .HasForeignKey(d => d.NumacuofsolNavigator)
                    .HasConstraintName("FK__rectrf__fechamod__693CA210");
            });

            modelBuilder.Entity<RegimenJuridico>(entity =>
            {
                entity.ToTable("RegimenJuridico", "Catalogs");

                entity.Property(e => e.Regimen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("regimen");
            });

            modelBuilder.Entity<Solrf>(entity =>
            {
                entity.HasKey(e => e.Numacuofsol)
                    .HasName("PK__solrf__6FB626EFDB3CC805");

                entity.ToTable("solrf", "Artf");

                entity.Property(e => e.Numacuofsol)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("numacuofsol");

                entity.Property(e => e.Fecapsol)
                    .HasColumnType("date")
                    .HasColumnName("fecapsol");

                entity.Property(e => e.Obssol)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("obssol");
            });

            modelBuilder.Entity<SolrfDoc>(entity =>
            {
                entity.HasKey(e => e.Iddoc)
                    .HasName("PK__solrfDoc__060F9C746FA22BFE");

                entity.ToTable("solrfDoc", "Artf");

                entity.Property(e => e.Iddoc).HasColumnName("iddoc");

                entity.Property(e => e.Docsol).HasColumnName("docsol");

                entity.Property(e => e.NameDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameDoc");

                entity.Property(e => e.NumacuofsolNavigator)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("numacuofsolNavigator");

                entity.HasOne(d => d.NumacuofsolNavigatorNavigation)
                    .WithMany(p => p.SolrfDocs)
                    .HasForeignKey(d => d.NumacuofsolNavigator)
                    .HasConstraintName("FK__solrfDoc__docsol__619B8048");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PK__users__2A50F1CEAED62BA7");

                entity.ToTable("users", "Catalogs");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Mailuser)
                    .HasMaxLength(100)
                    .HasColumnName("mailuser");

                entity.Property(e => e.Nomuser)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nomuser");

                entity.Property(e => e.Passuser).HasColumnName("passuser");

                entity.Property(e => e.Pauser)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("pauser");

                entity.Property(e => e.Sauser)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("sauser");

                entity.Property(e => e.Tipouser)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tipouser");
            });

            modelBuilder.Entity<Usoequi>(entity =>
            {
                entity.ToTable("Usoequi", "Catalogs");

                entity.Property(e => e.Usoequi1)
                    .HasMaxLength(50)
                    .HasColumnName("usoequi");
            });

            modelBuilder.Entity<ModaEqui>(entity =>
            {
                entity.ToTable("ModaEqui", "Catalogs");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
