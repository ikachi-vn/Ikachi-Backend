using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public AppEntities db = new AppEntities();
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser user, UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("myCustomClaim", "value of claim"));
            userIdentity.AddClaim(new Claim("IDStaff", user.StaffID.ToString()));

            var staff = db.tbl_HRM_Staff.Find(user.StaffID);
            List<int> JobTitles = new List<int>();

            JobTitles.Add(staff.IDJobTitle.GetValueOrDefault());
            JobTitles.AddRange(staff.tbl_HRM_Staff_ConcurrentPosition.Where(d => d.IsDeleted == false && d.IsDisabled == false).Select(s => s.IDJobTitle.GetValueOrDefault()));

            userIdentity.AddClaim(new Claim("JobTitles", string.Join(",", JobTitles.ToArray())));
            return userIdentity;
        }

        public string Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int StaffID { get; set; }
        public int CustomerId { get; set; }
        public int IDBranch { get; set; }

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
    }
}