using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Library
{
    public class Context: DbContext
    {
        public Context() : base("LibraryDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
        }
     
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
