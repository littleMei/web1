namespace AutoLotDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AutoLotDAL.Models;
    using System.Web;
    using System.Data.Entity.Infrastructure.Interception;

    public class AutoLotEntities : DbContext
    {
        // Your context has been configured to use a 'AutoLotEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AutoLotDAL.EF.AutoLotEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AutoLotEntities' 
        // connection string in the application configuration file.
        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger($"{HttpRuntime.AppDomainAppPath}/sqllog.txt");
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
            DatabaseLogger.StartLogging();
            DbInterception.Add(DatabaseLogger);
        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}