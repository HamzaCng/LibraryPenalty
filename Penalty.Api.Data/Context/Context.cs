using Microsoft.EntityFrameworkCore;
using Penalty.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Api.Data.Context
{
    public class PenaltyDbContext : DbContext
    {
        #region Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-FO3DFL9;database=VeriparkDb; integrated security=true; TrustServerCertificate=True");
        }

        #endregion

        #region Entities DbSet

        public DbSet<Book> Books { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Penalties> Penalties { get; set; }

        #endregion 


    }
}
