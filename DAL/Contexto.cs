﻿using Microsoft.EntityFrameworkCore;
using Ralfy_Genao_P1_AP1.Models;

namespace Ralfy_Genao_P1_AP1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
              : base(options) { }

        public DbSet<Aporte> Aporte { get; set; }
    }
}
