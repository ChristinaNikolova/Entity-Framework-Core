﻿using Microsoft.EntityFrameworkCore;

using BookShop.Data.Models;

namespace BookShop.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AuthorBook>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });
        }
    }
}