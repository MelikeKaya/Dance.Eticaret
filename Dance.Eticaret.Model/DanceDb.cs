using Dance.Eticaret.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance.Eticaret.Model
{
    public class DanceDb:DbContext
    {
        public DanceDb()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> userAddresses { get; set; }
        public DbSet<DanceType> DanceTypes { get; set; }
        public DbSet<DanceLesson> DanceLessons { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLesson> OrderLessons { get; set; }

        public DbSet<OrderPayment> OrderPayments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
