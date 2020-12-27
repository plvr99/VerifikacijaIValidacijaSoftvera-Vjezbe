using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightControlApp.Models;

namespace FlightControlApp.Data
{
    public class FlightControlAppContext : DbContext
    {
        public FlightControlAppContext (DbContextOptions<FlightControlAppContext> options)
            : base(options)
        {
        }

        public DbSet<FlightControlApp.Models.Let> Let { get; set; }
    }
}
