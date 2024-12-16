using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace library.Models;

public partial class LibrarydbContext : DbContext
{
    public LibrarydbContext()
    {
    }

    public LibrarydbContext(DbContextOptions<LibrarydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PRIMARY");

            entity.ToTable("authors");

            entity.Property(e => e.AuthorId)
                .HasColumnType("int(11)")
                .HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => new { e.AuthorId, e.CategoryId }, "author_id");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.Property(e => e.BookId)
                .HasColumnType("int(11)")
                .HasColumnName("book_id");
            entity.Property(e => e.AuthorId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("author_id");
            entity.Property(e => e.CategoryId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("category_id");
            entity.Property(e => e.PublishDate)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date")
                .HasColumnName("publish_date");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("books_ibfk_1");

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("books_ibfk_2");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryName, "category_name");

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("category_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
