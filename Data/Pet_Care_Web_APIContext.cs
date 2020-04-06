using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Web_API.Model;

namespace Pet_Care_Web_API.Models
{
    //Pet care database connection
    public class Pet_Care_Web_APIContext : DbContext
    {
        public Pet_Care_Web_APIContext (DbContextOptions<Pet_Care_Web_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Pet_Care_Web_API.Model.PetCareSession> PetCareSession { get; set; }
    }
}
