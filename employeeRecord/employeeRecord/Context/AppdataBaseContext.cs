using employeeRecord.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace employeeRecord.Context
{
    public class AppdataBaseContext : DbContext           //configure appdataBaseContext from entityframe work
    {
        public AppdataBaseContext(DbContextOptions<AppdataBaseContext> options) : base(options) { }

        //bring in the db set from the model(employee model) created earlier
        public DbSet<Employee>Employees { get; set; }   //N/B Employees reperesent the name of our table in the data base having the fields from the Employee table
        //introducing the model creating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

        }
    }
}
