using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstApiProject.Models
{
    public class CodeFirstApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}