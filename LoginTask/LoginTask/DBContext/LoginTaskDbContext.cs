using System;
using System.Collections.Generic;
using LoginTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoginTask.DBContext;

public partial class LoginTaskDbContext : DbContext
{
    public LoginTaskDbContext()
    {
    }

    public LoginTaskDbContext(DbContextOptions<LoginTaskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserInfo> UserInfos { get; set; } 

    //public DbSet<UserInfoModel> userInfoModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-BFOIOD35\\MSSQLSERVER02;Database=LoginTaskDB;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4C0F627ABF");

            entity.ToTable("UserInfo");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Birthday).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            /*entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.Passwordhash).HasMaxLength(50);*/
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
