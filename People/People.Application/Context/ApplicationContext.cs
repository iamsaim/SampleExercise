using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Domain.Entity;

namespace People.Application.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PersonEntity> People { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        {
            
        }
    }
}
