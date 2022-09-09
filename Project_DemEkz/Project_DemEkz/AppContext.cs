using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_DemEkz
{
    class AppContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }

        public AppContext() : base("DefaultConnection") { }
    }
}
