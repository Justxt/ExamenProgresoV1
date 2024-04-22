using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenProgreso1.Models;

namespace ExamenProgreso.Data
{
    public class ExamenProgresoContext : DbContext
    {
        public ExamenProgresoContext (DbContextOptions<ExamenProgresoContext> options)
            : base(options)
        {
        }

        public DbSet<ExamenProgreso1.Models.JMora> JMora { get; set; } = default!;
    }
}
