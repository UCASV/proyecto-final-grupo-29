using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalPOOBD.databaseContext
{
    public partial class FinalProjectPOO_DBContext : DbContext
    {
        public FinalProjectPOO_DBContext()
        {
        }

        public FinalProjectPOO_DBContext(DbContextOptions<FinalProjectPOO_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<EffectAppointment1> EffectAppointment1s { get; set; }
        public virtual DbSet<EffectAppointment2> EffectAppointment2s { get; set; }
        public virtual DbSet<EffectCatalog> EffectCatalogs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<TypeEmployee> TypeEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=FinalProjectPOO_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment1)
                    .HasName("PK__APPOINTM__2130EFA980A45A83");

                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.IdAppointment1).HasColumnName("id_appointment1");

                entity.Property(e => e.IdAppointment2).HasColumnName("id_appointment2");

                entity.Property(e => e.IdCabinAppointment1).HasColumnName("id_cabin_appointment1");

                entity.Property(e => e.IdCabinAppointment2).HasColumnName("id_cabin_appointment2");

                entity.Property(e => e.TimeDat2)
                    .HasColumnType("datetime")
                    .HasColumnName("time_dat2");

                entity.Property(e => e.TimeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("time_date");

                entity.Property(e => e.TimeDateRow)
                    .HasColumnType("datetime")
                    .HasColumnName("time_date_row");

                entity.Property(e => e.TimeDateRow2)
                    .HasColumnType("datetime")
                    .HasColumnName("time_date_row2");

                entity.Property(e => e.TimeDateVaccine)
                    .HasColumnType("datetime")
                    .HasColumnName("time_date_vaccine");

                entity.Property(e => e.TimeDateVaccine2)
                    .HasColumnType("datetime")
                    .HasColumnName("time_date_vaccine2");

                entity.HasOne(d => d.IdCabinAppointment1Navigation)
                    .WithMany(p => p.AppointmentIdCabinAppointment1Navigations)
                    .HasForeignKey(d => d.IdCabinAppointment1)
                    .HasConstraintName("fk_cabin_appointment1");

                entity.HasOne(d => d.IdCabinAppointment2Navigation)
                    .WithMany(p => p.AppointmentIdCabinAppointment2Navigations)
                    .HasForeignKey(d => d.IdCabinAppointment2)
                    .HasConstraintName("fk_cabin_appointment2");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("CABIN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdEmployeeCharge).HasColumnName("id_employee_charge");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.IdEmployeeChargeNavigation)
                    .WithMany(p => p.Cabins)
                    .HasForeignKey(d => d.IdEmployeeCharge)
                    .HasConstraintName("fk_employee_charge");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PK__CITIZEN__D876F1BE0AB4FDF7");

                entity.ToTable("CITIZEN");

                entity.Property(e => e.Dui)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdAppointment1).HasColumnName("id_appointment1");

                entity.Property(e => e.IdInstitution).HasColumnName("id_institution");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.IdAppointment1Navigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdAppointment1)
                    .HasConstraintName("fk_citizen_appointment");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdInstitution)
                    .HasConstraintName("fk_citizen_institution");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("DISEASE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disease1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DISEASE");

                entity.Property(e => e.DuiCitizen)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dui_CITIZEN");

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.Diseases)
                    .HasForeignKey(d => d.DuiCitizen)
                    .HasConstraintName("fk_disease_citizen");
            });

            modelBuilder.Entity<EffectAppointment1>(entity =>
            {
                entity.ToTable("EFFECT_APPOINTMENT1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Effectminute).HasColumnName("effectminute");

                entity.Property(e => e.IdAppointment1).HasColumnName("id_appointment1");

                entity.Property(e => e.IdEffectCatalog).HasColumnName("id_effect_catalog");

                entity.HasOne(d => d.IdAppointment1Navigation)
                    .WithMany(p => p.EffectAppointment1s)
                    .HasForeignKey(d => d.IdAppointment1)
                    .HasConstraintName("fk_id_appointment1");

                entity.HasOne(d => d.IdEffectCatalogNavigation)
                    .WithMany(p => p.EffectAppointment1s)
                    .HasForeignKey(d => d.IdEffectCatalog)
                    .HasConstraintName("fk_effect_catalog");
            });

            modelBuilder.Entity<EffectAppointment2>(entity =>
            {
                entity.ToTable("EFFECT_APPOINTMENT2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Effectminute).HasColumnName("effectminute");

                entity.Property(e => e.IdAppointment2).HasColumnName("id_appointment2");

                entity.Property(e => e.IdEffectCatalog).HasColumnName("id_effect_catalog");

                entity.HasOne(d => d.IdAppointment2Navigation)
                    .WithMany(p => p.EffectAppointment2s)
                    .HasForeignKey(d => d.IdAppointment2)
                    .HasConstraintName("fk_id_appointment2");

                entity.HasOne(d => d.IdEffectCatalogNavigation)
                    .WithMany(p => p.EffectAppointment2s)
                    .HasForeignKey(d => d.IdEffectCatalog)
                    .HasConstraintName("fk_effect_catalog2");
            });

            modelBuilder.Entity<EffectCatalog>(entity =>
            {
                entity.ToTable("EFFECT_CATALOG");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Effect)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("effect");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTypeEmployee).HasColumnName("id_type_employee");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdTypeEmployeeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdTypeEmployee)
                    .HasConstraintName("fk_employee_TypeEmployee");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("INSTITUTION");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Institution1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("institution");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("LOGS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.TimeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("time_date");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.IdCabin)
                    .HasConstraintName("fk_cabin");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("fk_employee");
            });

            modelBuilder.Entity<TypeEmployee>(entity =>
            {
                entity.ToTable("TYPE_EMPLOYEE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
