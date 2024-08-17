using Microsoft.EntityFrameworkCore;
using Continuum.Core.Entities;

namespace Continuum.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<ContentBlock> ContentBlocks { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<MediaContent> MediaContents { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Client)
                .WithOne(c => c.User)
                .HasForeignKey<Client>(c => c.UserId);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Configuration)
                .WithOne(cfg => cfg.Client)
                .HasForeignKey<Configuration>(cfg => cfg.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.ContentBlocks)
                .WithOne(cb => cb.Client)
                .HasForeignKey(cb => cb.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Pages)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.MediaContents)
                .WithOne(mc => mc.Client)
                .HasForeignKey(mc => mc.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.SocialMedias)
                .WithOne(sm => sm.Client)
                .HasForeignKey(sm => sm.ClientId);
            
            modelBuilder.Entity<Configuration>()
                .HasOne(c => c.Client)
                .WithOne(c => c.Configuration)
                .HasForeignKey<Configuration>(c => c.ClientId);
            
            modelBuilder.Entity<ContentBlock>()
                .HasOne(cb => cb.Client)
                .WithMany(c => c.ContentBlocks)
                .HasForeignKey(cb => cb.ClientId);
            
            modelBuilder.Entity<MediaContent>()
                .HasOne(mc => mc.Client)
                .WithMany(c => c.MediaContents)
                .HasForeignKey(mc => mc.ClientId);
            
            modelBuilder.Entity<Page>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Pages)
                .HasForeignKey(p => p.ClientId);
            
            modelBuilder.Entity<SocialMedia>()
                .HasOne(sm => sm.Client)
                .WithMany(c => c.SocialMedias)
                .HasForeignKey(sm => sm.ClientId);
        }
    }
}