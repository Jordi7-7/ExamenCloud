using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenCloud.Entidades;

    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<ExamenCloud.Entidades.VideoJuego> VideoJuegos { get; set; } = default!;

public DbSet<ExamenCloud.Entidades.Distribuidor> Distribuidores { get; set; } = default!;
    }
