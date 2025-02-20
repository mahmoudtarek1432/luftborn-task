using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDatabase(DbContextOptions opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().OwnsOne(x => x.UserVerification,opt =>
            {
                opt.Property(x => x.VerifyCode).HasColumnName("VerifyCode");
                opt.Property(x => x.VerifyTries).HasColumnName("VerifyTries");
                opt.Property(x => x.VerifyTime).HasColumnName("VerifyTime");
                opt.Property(x => x.IsActive).HasColumnName("IsActive");
            });
        }
    }
}
