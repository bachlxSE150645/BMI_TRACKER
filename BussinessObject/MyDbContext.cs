using Azure;
using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BussinessObject
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(string connectionString)
        {
            Database.SetConnectionString(connectionString);
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var buider = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = buider.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BMITracker"));
        }

        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<food> foods { get; set; }
        public virtual DbSet<ingredient> ingredients { get; set; }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Menu> menus { get; set; }
        public virtual DbSet<Order> orders { get; set; }
        public virtual DbSet<orderDetail> orderDetails { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<Service> services { get; set; }
        public virtual DbSet<ServiceType> serviceTypes { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<recipe> recipes { get; set; }
        public virtual DbSet<chatSection> chatSections { get; set; }
        public virtual DbSet<favoriteFood> favoriteFoods { get; set; }
        public virtual DbSet<userBodyMax> userBodyMaxes { get; set; }
        public virtual DbSet<Schedule> schedules { get; set; }
        public virtual DbSet<Meal> meals { get; set; }
        public virtual DbSet<payment> Payments { get; set; }
        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<paymentDetails> paymentDetails { get; set; }
        public virtual DbSet<Content> contents { get; set; }
        public virtual DbSet<feebackCategory> feebackCategories { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<chatSection> ChatSections { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

    }
}
