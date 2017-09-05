using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodTruckAdminTools_v2.Models;

namespace FoodTruckAdminTools_v2.Models
{
    public class FoodTruckCompanyContext : DbContext
    {
        public FoodTruckCompanyContext (DbContextOptions<FoodTruckCompanyContext> options)
            : base(options)
        {
        }

        public DbSet<FoodTruckAdminTools_v2.Models.FoodTruckCompany> FoodTruckCompany { get; set; }

        public DbSet<FoodTruckAdminTools_v2.Models.PersonalInfo> PersonalInfo { get; set; }
    }
}
