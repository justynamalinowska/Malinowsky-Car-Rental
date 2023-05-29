using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Malinowsky_Car_Rental.DB
{
    public partial class MalinowskyCarRentalContext : DbContext
    {
        public MalinowskyCarRentalContext()
        {
        }

        public MalinowskyCarRentalContext(DbContextOptions<MalinowskyCarRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bazy> Bazy { get; set; }
        public virtual DbSet<Klienci> Klienci { get; set; }
        public virtual DbSet<ModeleSamochodow> ModeleSamochodow { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<RodzajePaliwa> RodzajePaliwa { get; set; }
        public virtual DbSet<Samochody> Samochody { get; set; }
        public virtual DbSet<StanySamochodu> StanySamochodu { get; set; }
        public virtual DbSet<TypyNadwozia> TypyNadwozia { get; set; }
        public virtual DbSet<TypySamochodow> TypySamochodow { get; set; }
        public virtual DbSet<WersjeModeli> WersjeModeli { get; set; }
        public virtual DbSet<Wypozyczenia> Wypozyczenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.; Database=MalinowskyCarRental; trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bazy>(entity =>
            {
                entity.HasKey(e => e.IdBazy)
                    .HasName("pk_id_bazy");

                entity.Property(e => e.IdBazy).HasColumnName("id_bazy");

                entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

                entity.Property(e => e.Kraj)
                    .HasColumnName("kraj")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Miasto)
                    .HasColumnName("miasto")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumerDomu)
                    .HasColumnName("numer_domu")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumerLokalu)
                    .HasColumnName("numer_lokalu")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ulica)
                    .HasColumnName("ulica")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdPracownikaNavigation)
                    .WithMany(p => p.Bazy)
                    .HasForeignKey(d => d.IdPracownika)
                    .HasConstraintName("ref_Bazy_id_pracownika");
            });

            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.HasKey(e => e.IdKlienta)
                    .HasName("pk_id_klienta");

                entity.HasIndex(e => e.Pesel)
                    .HasName("UQ__Klienci__DC3B1BB80C2CE2F9")
                    .IsUnique();

                entity.Property(e => e.IdKlienta).HasColumnName("id_klienta");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnName("data_urodzenia")
                    .HasColumnType("date");

                entity.Property(e => e.Imie)
                    .HasColumnName("imie")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kraj)
                    .HasColumnName("kraj")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Miasto)
                    .HasColumnName("miasto")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nazwisko)
                    .HasColumnName("nazwisko")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NrTelefonu)
                    .HasColumnName("nr_telefonu")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumerDomu)
                    .HasColumnName("numer_domu")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumerLokalu)
                    .HasColumnName("numer_lokalu")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("pesel")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ulica)
                    .HasColumnName("ulica")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ModeleSamochodow>(entity =>
            {
                entity.HasKey(e => e.IdModelu)
                    .HasName("pk_id_modelu");

                entity.ToTable("Modele samochodow");

                entity.Property(e => e.IdModelu).HasColumnName("id_modelu");

                entity.Property(e => e.Marka)
                    .HasColumnName("marka")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.HasKey(e => e.IdPracownika)
                    .HasName("pk_id_pracownika");

                entity.HasIndex(e => e.Pesel)
                    .HasName("UQ__Pracowni__DC3B1BB8543AFD50")
                    .IsUnique();

                entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnName("data_urodzenia")
                    .HasColumnType("date");

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnName("data_zatrudnienia")
                    .HasColumnType("date");

                entity.Property(e => e.IdBazy).HasColumnName("id_bazy");

                entity.Property(e => e.Imie)
                    .HasColumnName("imie")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kraj)
                    .HasColumnName("kraj")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Miasto)
                    .HasColumnName("miasto")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nazwisko)
                    .HasColumnName("nazwisko")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NrTelefonu)
                    .HasColumnName("nr_telefonu")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumerDomu)
                    .HasColumnName("numer_domu")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumerLokalu)
                    .HasColumnName("numer_lokalu")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("pesel")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Stanowisko)
                    .HasColumnName("stanowisko")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StawkaGodzinowa).HasColumnName("stawka_godzinowa");

                entity.Property(e => e.Ulica)
                    .HasColumnName("ulica")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdBazyNavigation)
                    .WithMany(p => p.Pracownicy)
                    .HasForeignKey(d => d.IdBazy)
                    .HasConstraintName("ref_Pracownicy_id_bazy");
            });

            modelBuilder.Entity<RodzajePaliwa>(entity =>
            {
                entity.HasKey(e => e.IdRodzajuPaliwa)
                    .HasName("pk_id_rodzaju_paliwa");

                entity.ToTable("Rodzaje paliwa");

                entity.Property(e => e.IdRodzajuPaliwa).HasColumnName("id_rodzaju_paliwa");

                entity.Property(e => e.RodzajPaliwa)
                    .HasColumnName("rodzaj_paliwa")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Samochody>(entity =>
            {
                entity.HasKey(e => e.IdSamochodu)
                    .HasName("pk_id_samochodu");

                entity.HasIndex(e => e.Vin)
                    .HasName("UQ__Samochod__DDB00C6661425A8F")
                    .IsUnique();

                entity.Property(e => e.IdSamochodu).HasColumnName("id_samochodu");

                entity.Property(e => e.CenaZaDzien).HasColumnName("cena_za_dzien");

                entity.Property(e => e.IdBazy).HasColumnName("id_bazy");

                entity.Property(e => e.IdStanuSamochodu).HasColumnName("id_stanu_samochodu");

                entity.Property(e => e.IdTypu).HasColumnName("id_typu");

                entity.Property(e => e.Przebieg).HasColumnName("przebieg");

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasColumnName("vin")
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdBazyNavigation)
                    .WithMany(p => p.Samochody)
                    .HasForeignKey(d => d.IdBazy)
                    .HasConstraintName("ref_Samochody_id_bazy");

                entity.HasOne(d => d.IdStanuSamochoduNavigation)
                    .WithMany(p => p.Samochody)
                    .HasForeignKey(d => d.IdStanuSamochodu)
                    .HasConstraintName("ref_Samochody_id_stanu_samochodu");

                entity.HasOne(d => d.IdTypuNavigation)
                    .WithMany(p => p.Samochody)
                    .HasForeignKey(d => d.IdTypu)
                    .HasConstraintName("ref_Samochody_id_typu");
            });

            modelBuilder.Entity<StanySamochodu>(entity =>
            {
                entity.HasKey(e => e.IdStanuSamochodu)
                    .HasName("pk_id_stanu_samochodu");

                entity.ToTable("Stany samochodu");

                entity.Property(e => e.IdStanuSamochodu).HasColumnName("id_stanu_samochodu");

                entity.Property(e => e.StanSamochodu)
                    .HasColumnName("stan_samochodu")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TypyNadwozia>(entity =>
            {
                entity.HasKey(e => e.IdTypuNadwozia)
                    .HasName("pk_id_typu_nadwozia");

                entity.ToTable("Typy nadwozia");

                entity.Property(e => e.IdTypuNadwozia).HasColumnName("id_typu_nadwozia");

                entity.Property(e => e.TypNadwozia)
                    .HasColumnName("typ_nadwozia")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TypySamochodow>(entity =>
            {
                entity.HasKey(e => e.IdTypu)
                    .HasName("pk_id_typu");

                entity.ToTable("Typy samochodow");

                entity.Property(e => e.IdTypu).HasColumnName("id_typu");

                entity.Property(e => e.IdWersji).HasColumnName("id_wersji");

                entity.Property(e => e.Kolor)
                    .HasColumnName("kolor")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RokProdukcji).HasColumnName("rok_produkcji");

                entity.HasOne(d => d.IdWersjiNavigation)
                    .WithMany(p => p.TypySamochodow)
                    .HasForeignKey(d => d.IdWersji)
                    .HasConstraintName("ref_Typy_id_wersji");
            });

            modelBuilder.Entity<WersjeModeli>(entity =>
            {
                entity.HasKey(e => e.IdWersji)
                    .HasName("pk_id_wersji");

                entity.ToTable("Wersje modeli");

                entity.Property(e => e.IdWersji).HasColumnName("id_wersji");

                entity.Property(e => e.IdModelu).HasColumnName("id_modelu");

                entity.Property(e => e.IdPaliwa).HasColumnName("id_paliwa");

                entity.Property(e => e.IdTypuNadwozia).HasColumnName("id_typu_nadwozia");

                entity.Property(e => e.LiczbaMiejsc).HasColumnName("liczba_miejsc");

                entity.Property(e => e.MocKw).HasColumnName("moc_kw");

                entity.Property(e => e.PojemnoscSilnika).HasColumnName("pojemnosc_silnika");

                entity.HasOne(d => d.IdModeluNavigation)
                    .WithMany(p => p.WersjeModeli)
                    .HasForeignKey(d => d.IdModelu)
                    .HasConstraintName("ref_Wersje_id_modelu");

                entity.HasOne(d => d.IdPaliwaNavigation)
                    .WithMany(p => p.WersjeModeli)
                    .HasForeignKey(d => d.IdPaliwa)
                    .HasConstraintName("ref_Wersje_id_paliwa");

                entity.HasOne(d => d.IdTypuNadwoziaNavigation)
                    .WithMany(p => p.WersjeModeli)
                    .HasForeignKey(d => d.IdTypuNadwozia)
                    .HasConstraintName("ref_Wersje_id_typu_nadwozia");
            });

            modelBuilder.Entity<Wypozyczenia>(entity =>
            {
                entity.HasKey(e => e.IdWypozyczenia)
                    .HasName("pk_id_wypozyczenia");

                entity.Property(e => e.IdWypozyczenia).HasColumnName("id_wypozyczenia");

                entity.Property(e => e.DataWypozyczenia)
                    .HasColumnName("data_wypozyczenia")
                    .HasColumnType("date");

                entity.Property(e => e.DataZwrotu)
                    .HasColumnName("data_zwrotu")
                    .HasColumnType("date");

                entity.Property(e => e.IdKlienta).HasColumnName("id_klienta");

                entity.Property(e => e.IdPracownika).HasColumnName("id_pracownika");

                entity.Property(e => e.IdSamochodu).HasColumnName("id_samochodu");

                entity.Property(e => e.OplataDodatkowa).HasColumnName("oplata_dodatkowa");

                entity.Property(e => e.PlanowanaDataZwrotu)
                    .HasColumnName("planowana_data_zwrotu")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdKlientaNavigation)
                    .WithMany(p => p.Wypozyczenia)
                    .HasForeignKey(d => d.IdKlienta)
                    .HasConstraintName("ref_Wypozyczenia_id_klienta");

                entity.HasOne(d => d.IdPracownikaNavigation)
                    .WithMany(p => p.Wypozyczenia)
                    .HasForeignKey(d => d.IdPracownika)
                    .HasConstraintName("ref_Wypozyczenia_id_pracownika");

                entity.HasOne(d => d.IdSamochoduNavigation)
                    .WithMany(p => p.Wypozyczenia)
                    .HasForeignKey(d => d.IdSamochodu)
                    .HasConstraintName("ref_Wypozyczenia_id_samochodu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
