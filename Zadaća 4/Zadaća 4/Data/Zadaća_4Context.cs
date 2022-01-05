using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zadaća_4.Models;

namespace Zadaća_4.Data
{
    public class Zadaća_4Context : DbContext
    {
        public Zadaća_4Context (DbContextOptions<Zadaća_4Context> options)
            : base(options)
        {
        }

        public DbSet<Zadaća_4.Models.Knjiga> Knjiga { get; set; }

        public DbSet<Zadaća_4.Models.KućnaDostava> KućnaDostava { get; set; }

        public DbSet<Zadaća_4.Models.KvizOdgovor> KvizOdgovor { get; set; }

        public DbSet<Zadaća_4.Models.Prijava> Prijava { get; set; }

        public DbSet<Zadaća_4.Models.SvemirskiBrod> SvemirskiBrod { get; set; }

        public DbSet<Zadaća_4.Models.Umjetnina> Umjetnina { get; set; }

        public DbSet<Zadaća_4.Models.Donacija> Donacija { get; set; }

        public DbSet<Zadaća_4.Models.GodisnjiOdmor> GodisnjiOdmor { get; set; }

        public DbSet<Zadaća_4.Models.Cvijet> Cvijet { get; set; }

        public DbSet<Zadaća_4.Models.Nekretnina> Nekretnina { get; set; }
    }
}
