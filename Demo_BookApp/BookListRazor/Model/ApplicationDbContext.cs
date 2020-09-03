using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class ApplicationDbContext : DbContext 
    {


        // we have to pass the DbContext options, to the parent class for DI
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // in order to add anything to the DB, we need an entry
        public DbSet<BookModel> Book { get; set; }


    }
}
