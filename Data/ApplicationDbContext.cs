using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TODO.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class ApplicationDbContext: IdentityUserContext<IdentityUser>{
    public DbSet<TodoItem> TodoItems{get; set;}
    public DbSet<IdentityUser> User {get; set;}
    public ApplicationDbContext(DbContextOptions options): base(options){

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<TodoItem>().HasKey(i=>i.Id).HasName("TodoItemId_PrimaryKey");
        modelBuilder.Entity<TodoItem>().Property(i=>i.IsCompleted).HasDefaultValue(false);

    }
}