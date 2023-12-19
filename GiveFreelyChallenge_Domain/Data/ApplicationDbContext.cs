using GiveFreelyChallenge_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GiveFreelyChallenge_Domain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ApplicationUserChatroom>()
            //.HasKey(bc => new { bc.ApplicationUserId, bc.ChatroomId });
            //builder.Entity<ApplicationUserChatroom>()
            //    .HasOne(bc => bc.ApplicationUser)
            //    .WithMany(b => b.Chatrooms)
            //    .HasForeignKey(bc => bc.ApplicationUserId);
            //builder.Entity<ApplicationUserChatroom>()
            //    .HasOne(bc => bc.Chatroom)
            //    .WithMany(c => c.Members)
            //    .HasForeignKey(bc => bc.ChatroomId);

            base.OnModelCreating(builder);
        }

        public DbSet<Affiliate> Affiliates { get; set; }

        public DbSet<Customer> Customers { get; set; }

    }
}