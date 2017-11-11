using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MediArch.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}