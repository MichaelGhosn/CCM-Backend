using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CCM.Domain
{
    public partial class ccmContext : DbContext
    {
        public ccmContext()
        {
        }

        public ccmContext(DbContextOptions<ccmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<Openingtime> Openingtime { get; set; }
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=ccm");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>(entity =>
            {
                entity.ToTable("day");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Day1)
                    .IsRequired()
                    .HasColumnName("Day")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.ToTable("map");

                entity.HasIndex(e => e.OrganisationId)
                    .HasName("map_organisation_Id_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AuthorizedCapacity)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'100'");

                entity.Property(e => e.Capacity)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrganisationId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.Map)
                    .HasForeignKey(d => d.OrganisationId)
                    .HasConstraintName("map_organisation_Id_fk");
            });

            modelBuilder.Entity<Openingtime>(entity =>
            {
                entity.ToTable("openingtime");

                entity.HasIndex(e => e.DayId)
                    .HasName("openingtime_day_Id_fk");

                entity.HasIndex(e => e.MapId)
                    .HasName("openingtime_map_Id_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DayId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MapId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.Openingtime)
                    .HasForeignKey(d => d.DayId)
                    .HasConstraintName("openingtime_day_Id_fk");

                entity.HasOne(d => d.Map)
                    .WithMany(p => p.Openingtime)
                    .HasForeignKey(d => d.MapId)
                    .HasConstraintName("openingtime_map_Id_fk");
            });

            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.ToTable("organisation");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservation");

                entity.HasIndex(e => e.SeatId)
                    .HasName("reservation_seat_Id_fk");

                entity.HasIndex(e => e.UserId)
                    .HasName("reservation_user_Id_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EndHour).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SeatId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StartHour).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Time)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.SeatId)
                    .HasConstraintName("reservation_seat_Id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("reservation_user_Id_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("seat");

                entity.HasIndex(e => e.MapId)
                    .HasName("seat_map_Id_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.MapId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Map)
                    .WithMany(p => p.Seat)
                    .HasForeignKey(d => d.MapId)
                    .HasConstraintName("seat_map_Id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.OrganisationId)
                    .HasName("user_organisation_Id_fk");

                entity.HasIndex(e => e.RoleId)
                    .HasName("user_role_Id_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OrganisationId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.OrganisationId)
                    .HasConstraintName("user_organisation_Id_fk");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("user_role_Id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
