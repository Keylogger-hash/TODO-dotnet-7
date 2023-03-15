using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TODO.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class ApplicationDbContext: IdentityUserContext<IdentityUser>{
    public DbSet<TodoItem> TodoItems{get; set;}
    public DbSet<IdentityUser> User {get; set;}
    public DbSet<IdentityRole> Role {get; set;} 
    public ApplicationDbContext(DbContextOptions options): base(options){

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        this.SeedRoles(modelBuilder);
        modelBuilder.Entity<TodoItem>().HasKey(i=>i.Id).HasName("TodoItemId_PrimaryKey");
        modelBuilder.Entity<TodoItem>().Property(i=>i.IsCompleted).HasDefaultValue(false);

    }

    private void SeedRoles(ModelBuilder modelBuilder){
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole(){
                Id="fab4fac1-c546-41de-aebc-a14da6895711",
                Name="Admin",
                ConcurrencyStamp="1", 
                NormalizedName="admin"                         
            },
            new IdentityRole(){
                Id="43583a5a-e042-4f5b-a9e3-c558be5d6d5e",
                Name="User",
                ConcurrencyStamp="2",
                NormalizedName="user"
            },
            new IdentityRole(){
                Id="90efdbaf-691f-4b29-ad2d-9e1446c9c265",
                Name="PremiumUser",
                ConcurrencyStamp="3",
                NormalizedName="premiumuser"
            }
            
        );
    }
}