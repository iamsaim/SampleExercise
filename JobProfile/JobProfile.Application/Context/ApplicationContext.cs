using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobProfile.Domain.Entity;

namespace JobProfile.Application.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<JobEntity> Jobs { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        {
            
        }
    }
}
