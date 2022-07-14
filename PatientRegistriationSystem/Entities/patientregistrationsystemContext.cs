using Microsoft.EntityFrameworkCore;
using PatientRegistriationSystem.Entities.Concrete;

#nullable disable

namespace PatientRegistriationSystem.Entities
{
    public partial class patientregistrationsystemContext : DbContext
    {
        public patientregistrationsystemContext()
        {
        }

        public patientregistrationsystemContext(DbContextOptions<patientregistrationsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Officer> Officers { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=test;database=patientregistrationsystem");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.HasIndex(e => e.CityId, "FK_city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingNo).HasColumnName("building_no");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_city");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");

                entity.HasIndex(e => e.PatientId, "FK_AppinmentsToPatient");

                entity.HasIndex(e => e.DoctorId, "FK_AppoitmentsToDoctor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppoitmentsToDoctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_AppinmentsToPatient");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctors");

                entity.HasIndex(e => e.EmployeeId, "FK_DoctorsToEmpolyee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorsToEmpolyee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.PhotoId, "FK_PatientsToPhotos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("department");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK_PatientsToPhotos");
            });

            modelBuilder.Entity<Officer>(entity =>
            {
                entity.ToTable("officers");

                entity.HasIndex(e => e.EmployeeId, "FK_OfficerToEmpolyee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Officers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficerToEmpolyee");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patients");

                entity.HasIndex(e => e.AddressId, "FK_PatientsToaddress");

                entity.HasIndex(e => e.PhotoId, "FK_PatientsTophoto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhotoId).HasColumnName("photo_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientsToaddress");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientsTophoto");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("photos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Photo1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("photo");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("prescriptions");

                entity.HasIndex(e => e.DoctorId, "FK_PrescriptionsToDoctor");

                entity.HasIndex(e => e.PatientId, "FK_PrescriptionsToPatient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrescriptionsToDoctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PrescriptionsToPatient");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
