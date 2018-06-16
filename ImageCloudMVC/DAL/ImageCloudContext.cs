using System.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace ImageCloudMVC.DAL
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

    public class ImageCloudContext : IdentityDbContext<ApplicationUser>
    {
        public ImageCloudContext() : base("ImageCloudConnString")
        {}

        public static ImageCloudContext Create()
        {
            return new ImageCloudContext();
        }

        public DbSet<File> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }
    }

}