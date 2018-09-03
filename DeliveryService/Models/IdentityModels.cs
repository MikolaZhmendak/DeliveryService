using System.Collections;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeliveryService.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<BackgroundCheck> BackgroundCheck { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<AccetpOrder> AccetpOrder { get; set; }
        public DbSet<FinishOrder> FinishOrder { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public IEnumerable ApplicationUsers { get; internal set; }

        public System.Data.Entity.DbSet<DeliveryService.Models.CustomerOrderViewModel> CustomerOrderViewModels { get; set; }
        public System.Data.Entity.DbSet<DeliveryService.Models.FinishedCustomerOrderView> FinishedCustomerOrderView { get; set; }
        //  AIzaSyDAVUCRfT4tOXt1ThRoWc4SSPBgVUXkUP4
    }
}