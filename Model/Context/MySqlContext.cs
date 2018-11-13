// using ApiTesteDotNet.Model;
using Microsoft.EntityFrameworkCore;
// using Entity;
// using System.Data.Entity.ModelConfiguration.Conventions;

namespace ApiTesteDotNet.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(){
            
        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options){

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}