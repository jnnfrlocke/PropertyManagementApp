﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PropertyManagementApp.Models
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

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.PreferredServiceProviders> PreferredServiceProviders { get; set; }

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.TypesOfService> TypesOfServices { get; set; }

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.ServiceRequests> ServiceRequests { get; set; }

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.Locations> Locations { get; set; }

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.Manager> Managers { get; set; }

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.Resident> Residents { get; set; }

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.Vacancies> Vacancies { get; set; }

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.Messages> Messages { get; set; }

        public System.Data.Entity.DbSet<PropertyManagementApp.Models.AvailableUnitInfoRequests> AvailableUnitInfoRequests { get; set; }
    }
}