using MapOfTheProblematique.Models;
using MapOfTheProblematque.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MapOfTheProblematque.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {


        public DbSet<Problem> Problem { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        


    }

}