using System;
using ContactCards.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactCards.Domain
{
    public partial class ContactsdbContext : DbContext
    {
        public ContactsdbContext()
        {
        }

        public ContactsdbContext(DbContextOptions<ContactsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=contactsdb;Username=postgres;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contacts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(128)
                    .HasColumnName("facebook");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .HasColumnName("imagepath");

                entity.Property(e => e.Lasttimeaccess).HasColumnName("lasttimeaccess");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Twitter)
                    .HasMaxLength(128)
                    .HasColumnName("twitter");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
