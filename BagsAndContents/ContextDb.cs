using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagsAndContents
{
    public class ContextDb:DbContext
    {
        private string filename;
        public ContextDb(string filename)
        {
            this.filename = filename;
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Bag> Bags {get; set; }
        public DbSet<Content> Contents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlitepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DataBase");
            Directory.CreateDirectory(sqlitepath);
            var fileName=$"{sqlitepath}\f{filename}";
            if(!File.Exists(fileName))
                File.Create(fileName);
            optionsBuilder.UseSqlite($"Filename={fileName}");
        }
    }
}
