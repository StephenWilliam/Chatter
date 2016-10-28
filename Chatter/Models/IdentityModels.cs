using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Chatter.Models
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
        public string ChatName { get; set; }
        //public string Id { get; set; }
        //public ICollection<ApplicationUser> Followers { get; set; }
        //public ICollection<ApplicationUser> Following { get; set; }

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

        public System.Data.Entity.DbSet<Chatter.Models.Message> Messages { get; set; }

        //public class MyEntities : DbContext
        //{
        //    public DbSet<ApplicationUser> Users { get; set; }

        //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<ApplicationUser>()
        //            .HasMany(x => x.Followers).WithMany(x => x.Following)
        //            .Map(x => x.ToTable("Followers")
        //                .MapLeftKey("UserId")
        //                .MapRightKey("FollowerId"));
        //    }
        //}

        ////public System.Data.Entity.DbSet<Chatter.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}