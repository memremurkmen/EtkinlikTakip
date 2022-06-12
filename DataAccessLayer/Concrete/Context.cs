using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    internal class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=EMRE-PC\\SQLEXPRESS;database=EtkinlikTakip; " +
                "integrated security=true;");
        }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityInvite> ActivityInvite { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ActivityInvite>()
                .HasOne(c => c.InvitedUser)
                .WithMany().HasForeignKey(x => x.InvitedUserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ActivityInvite>()
                .HasOne(c => c.AIActivity)
               .WithMany(c => c.Invitees).HasForeignKey(x => x.ActivityId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ActivityInvite>()
                .HasOne(c => c.AICreatedUser)
               .WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ActivityInvite>()
                .HasOne(c => c.AIConfirmedUser)
               .WithMany().HasForeignKey(x => x.ConfirmedBy).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ActivityInvite>()
                .HasOne(c => c.AIDeletedUser)
                .WithMany().HasForeignKey(x => x.DeletedBy).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Activity>()
                .HasOne(c => c.ConfirmedUser)
                .WithMany().HasForeignKey(x => x.ConfirmedBy).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Activity>()
                .HasOne(c => c.CreatedUser)
                .WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Activity>()
                .HasOne(c => c.UpdatedUser)
                .WithMany().HasForeignKey(x => x.UpdatedBy).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Activity>()
                .HasOne(c => c.DeletedUser)
                .WithMany().HasForeignKey(x => x.DeletedBy).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserRole>()
                .HasOne(c => c.User)
                .WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRole>()
                .HasOne(c => c.Role)
                .WithMany().HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
