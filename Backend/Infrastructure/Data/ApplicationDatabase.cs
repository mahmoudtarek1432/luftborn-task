using Domain.Entities;
using Infrastructure.Bus;
using Infrastructure.Extentions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDatabase : DbContext
    {
        private readonly IEventHandler _eventHandler;

        public DbSet<User> Users { get; set; }
        public ApplicationDatabase(DbContextOptions opt, IEventHandler eventHandler) : base(opt)
        {
            _eventHandler = eventHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>(); // Ignore Event class used for domain events

            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().HasIndex(x => x.Email)
                                       .IsUnique();

            modelBuilder.Entity<User>().HasIndex(nameof(User.FirstName),nameof(User.LastName))
                                       .IsUnique();

            modelBuilder.Entity<User>().OwnsOne(x => x.UserVerification,opt =>
            {
                opt.Property(x => x.VerifyCode).HasColumnName("VerifyCode");
                opt.Property(x => x.VerifyTries).HasColumnName("VerifyTries");
                opt.Property(x => x.VerifyTime).HasColumnName("VerifyTime");
                opt.Property(x => x.IsActive).HasColumnName("IsActive");
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _eventHandler.PublishDomainEvents(this);

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }


    }
}
