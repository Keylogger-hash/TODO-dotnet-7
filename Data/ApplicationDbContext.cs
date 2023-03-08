using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TODO.Data.Models;

public class ApplicationDbContext: DbContext{
    public DbSet<TodoItem> TodoItems{get; set;}

    public ApplicationDbContext(DbContextOptions options): base(options){

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<TodoItem>().HasKey(i=>i.Id).HasName("TodoItemId_PrimaryKey");
    }

}