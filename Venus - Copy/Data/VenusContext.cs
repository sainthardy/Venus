using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Venus.Models;

namespace Venus.Data
{
    public class VenusContext : DbContext
    {
        public VenusContext (DbContextOptions<VenusContext> options)
            : base(options)
        {
        }

        public DbSet<Venus.Models.RegistrationApproval> RegistrationApproval { get; set; }

        public DbSet<Venus.Models.Email> Email { get; set; }
    }
}
