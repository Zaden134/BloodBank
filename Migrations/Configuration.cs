namespace BloodBank.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BloodBank.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BloodBank.Controllers.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BloodBank.Controllers.ApplicationDbContext context)
        {


        }
    }
}
