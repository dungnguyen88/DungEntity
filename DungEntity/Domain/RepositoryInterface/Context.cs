using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entity;
using System.Data.Entity;

namespace Domain.RepositoryInterface
{
    public class Context : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }

        //IEntity

        //public DbSet<IEntity>
    }
}
