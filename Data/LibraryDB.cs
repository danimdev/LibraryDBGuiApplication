using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDBGuiApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryDBGuiApplication.Data
{
    public class LibraryDB : DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Library;Trusted_Connection=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
