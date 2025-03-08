using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryZ> CategoryZs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade); // Keep cascade on Post

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Reader)
                .WithMany(U => U.Comments) // Ensure there's no conflicting cascade
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent multiple cascades


            modelBuilder.Entity<Like>()
                .HasOne(c => c.Readers)
                .WithMany(U => U.Likes) // Ensure there's no conflicting cascade
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Prevent multiple cascades


            modelBuilder.Entity<Like>()
                .HasOne(c => c.Post)
                .WithMany(U => U.Likes) // Ensure there's no conflicting cascade
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent multiple cascades
        }

        internal void SaveChanges(Category category)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
