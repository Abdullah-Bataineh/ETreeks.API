using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<AvailableTime> AvailableTimes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<HomePage> HomePages { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TrainerCourse> TrainerCourses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=JOR17_User168;PASSWORD=Jmma123;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JOR17_USER168")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("ABOUT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Text)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<AvailableTime>(entity =>
            {
                entity.ToTable("AVAILABLE_TIME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.End_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Start_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Trainer_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRAINER_ID");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.AvailableTimes)
                    .HasForeignKey(d => d.Trainer_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295778");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CATEGORY_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.ToTable("CONTACT_INFO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Phone_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Website_Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_NAME");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.ToTable("CONTACT_US");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Cat_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CAT_ID");

                entity.Property(e => e.COURSE_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

               

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Cat_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295708");
            });

            modelBuilder.Entity<HomePage>(entity =>
            {
                entity.ToTable("HOME_PAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Text)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.HasIndex(e => e.Email, "SYS_C00295703")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Role_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Verify_Code)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VERIFY_CODE");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Role_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00295704");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295705");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("RESERVATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.End_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Start_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Trainer_Course_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRAINER_COURSE_ID");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.TrainerCourse)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Trainer_Course_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295782");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295781");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("REVIEW");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Review1)
                    .HasColumnType("FLOAT")
                    .HasColumnName("REVIEW");

                entity.Property(e => e.Text)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Role_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Text)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295771");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("TRAINER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Cat_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CAT_ID");

                entity.Property(e => e.Certificate)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CERTIFICATE");

                entity.Property(e => e.Cv)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CV");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.Cat_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C00295767");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295768");
            });

            modelBuilder.Entity<TrainerCourse>(entity =>
            {
                entity.ToTable("TRAINER_COURSE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Course_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.Trainer_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRAINER_ID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TrainerCourses)
                    .HasForeignKey(d => d.Course_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295774");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainerCourses)
                    .HasForeignKey(d => d.Trainer_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00295775");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasIndex(e => e.Phone_Number, "SYS_C00295690")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Birth_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTH_DATE");

                entity.Property(e => e.First_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Last_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Phone_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
