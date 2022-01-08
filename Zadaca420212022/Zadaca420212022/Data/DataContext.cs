using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zadaca420212022.Models;

namespace Zadaca420212022.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Zadaca420212022.Models.Strip> Strip { get; set; }

        public DbSet<Zadaca420212022.Models.Izlet> Izlet { get; set; }

        public DbSet<Zadaca420212022.Models.Pjesma> Pjesma { get; set; }

        public DbSet<Zadaca420212022.Models.Film> Film { get; set; }
    }
}
