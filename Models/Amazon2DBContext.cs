using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5_wellingJ.Models
{
    public class Amazon2DBContext : DbContext
    {
        public Amazon2DBContext(DbContextOptions<Amazon2DBContext> options) : base(options)
        {

        }

        public DbSet<Library> Libraries { get; set; }
    }
}
