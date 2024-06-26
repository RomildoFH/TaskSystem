﻿using Microsoft.EntityFrameworkCore;
using TaskSystem.Data.Map;
using TaskSystem.Models;

namespace TaskSystem.Data
{
    public class TasksSystemDbContext : DbContext
    {
        public TasksSystemDbContext(DbContextOptions<TasksSystemDbContext> options)
            : base(options) 
        {            
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
