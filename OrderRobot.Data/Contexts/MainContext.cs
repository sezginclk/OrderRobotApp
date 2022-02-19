using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderRobot.Data.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRobot.Data.Contexts
{
    public class MainContext : DbContext
    {

        private string _connectionString;
        private readonly IConfiguration _config;
        public MainContext(string connectionString, IConfiguration config) : base()
        {
            _config = config;
        }

        public MainContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //postresql veya no sql ver, tabanları için
            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Userid=TestUser;Password=SecuredPassword!123;Database=OrderRobotDb");


            optionsBuilder.UseSqlite(@"DataSource=C:\Temp\OrderRobotDb.db");
            base.OnConfiguring(optionsBuilder);
        }


        #region  Dbsets
        public virtual DbSet<RobotTask> RobotTasks { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        #endregion
    }
}
