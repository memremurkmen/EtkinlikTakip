﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    internal class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=EMRE-PC\\SQLEXPRESS;database=EtkinlikTakip; " +
                "integrated security=true;");
        }

        public DbSet<Etkinlik> Etkinlik { get; set; }
    }
}
