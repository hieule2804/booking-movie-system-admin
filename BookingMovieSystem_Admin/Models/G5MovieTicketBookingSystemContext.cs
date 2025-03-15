using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingMovieSystem_Admin.Models;

public partial class G5MovieTicketBookingSystemContext : DbContext
{
    public G5MovieTicketBookingSystemContext()
    {
    }

    public G5MovieTicketBookingSystemContext(DbContextOptions<G5MovieTicketBookingSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Screen> Screens { get; set; }

    public virtual DbSet<ScreenSeat> ScreenSeats { get; set; }

    public virtual DbSet<SeatLock> SeatLocks { get; set; }

    public virtual DbSet<SeatType> SeatTypes { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketScanLog> TicketScanLogs { get; set; }

    public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ZIWLLE\\ZIWLLW;Database=G5_MovieTicketBookingSystem;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CinemaName).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(100);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Language).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

            entity.Property(e => e.OrderStatus).HasMaxLength(20);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderItems_OrderId");

            entity.HasIndex(e => e.ScreenSeatId, "IX_OrderItems_ScreenSeatId");

            entity.HasIndex(e => e.ShowtimeId, "IX_OrderItems_ShowtimeId");

            entity.Property(e => e.PriceCharged).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.ScreenSeat).WithMany(p => p.OrderItems).HasForeignKey(d => d.ScreenSeatId);

            entity.HasOne(d => d.Showtime).WithMany(p => p.OrderItems).HasForeignKey(d => d.ShowtimeId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Screen>(entity =>
        {
            entity.HasIndex(e => e.CinemaId, "IX_Screens_CinemaId");

            entity.Property(e => e.ScreenName).HasMaxLength(100);

            entity.HasOne(d => d.Cinema).WithMany(p => p.Screens).HasForeignKey(d => d.CinemaId);
        });

        modelBuilder.Entity<ScreenSeat>(entity =>
        {
            entity.HasIndex(e => e.ScreenId, "IX_ScreenSeats_ScreenId");

            entity.HasIndex(e => e.SeatTypeId, "IX_ScreenSeats_SeatTypeId");

            entity.Property(e => e.SeatLabel).HasMaxLength(10);

            entity.HasOne(d => d.Screen).WithMany(p => p.ScreenSeats).HasForeignKey(d => d.ScreenId);

            entity.HasOne(d => d.SeatType).WithMany(p => p.ScreenSeats).HasForeignKey(d => d.SeatTypeId);
        });

        modelBuilder.Entity<SeatLock>(entity =>
        {
            entity.HasIndex(e => e.ScreenSeatId, "IX_SeatLocks_ScreenSeatId");

            entity.HasIndex(e => e.ShowtimeId, "IX_SeatLocks_ShowtimeId");

            entity.HasIndex(e => e.UserId, "IX_SeatLocks_UserId");

            entity.HasOne(d => d.ScreenSeat).WithMany(p => p.SeatLocks).HasForeignKey(d => d.ScreenSeatId);

            entity.HasOne(d => d.Showtime).WithMany(p => p.SeatLocks).HasForeignKey(d => d.ShowtimeId);

            entity.HasOne(d => d.User).WithMany(p => p.SeatLocks).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<SeatType>(entity =>
        {
            entity.Property(e => e.BasePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SeatTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasIndex(e => e.MovieId, "IX_Showtimes_MovieId");

            entity.HasIndex(e => e.ScreenId, "IX_Showtimes_ScreenId");

            entity.Property(e => e.ExperienceType).HasMaxLength(20);

            entity.HasOne(d => d.Movie).WithMany(p => p.Showtimes).HasForeignKey(d => d.MovieId);

            entity.HasOne(d => d.Screen).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.ScreenId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasIndex(e => e.OrderItemId, "IX_Tickets_OrderItemId").IsUnique();

            entity.Property(e => e.TicketStatus).HasMaxLength(20);
            entity.Property(e => e.UniqueCode).HasMaxLength(255);

            entity.HasOne(d => d.OrderItem).WithOne(p => p.Ticket).HasForeignKey<Ticket>(d => d.OrderItemId);
        });

        modelBuilder.Entity<TicketScanLog>(entity =>
        {
            entity.HasKey(e => e.ScanId);

            entity.HasIndex(e => e.ScannedBy, "IX_TicketScanLogs_ScannedBy");

            entity.HasIndex(e => e.TicketId, "IX_TicketScanLogs_TicketId");

            entity.Property(e => e.ScanResult).HasMaxLength(20);

            entity.HasOne(d => d.ScannedByNavigation).WithMany(p => p.TicketScanLogs)
                .HasForeignKey(d => d.ScannedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketScanLogs).HasForeignKey(d => d.TicketId);
        });

        modelBuilder.Entity<TransactionLog>(entity =>
        {
            entity.HasKey(e => e.PaymentId);

            entity.HasIndex(e => e.OrderId, "IX_TransactionLogs_OrderId");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.GatewayResponse).HasMaxLength(1000);
            entity.Property(e => e.PaymentGateway).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);

            entity.HasOne(d => d.Order).WithMany(p => p.TransactionLogs).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("UserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
