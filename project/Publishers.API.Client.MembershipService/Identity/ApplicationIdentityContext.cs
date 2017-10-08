namespace Publishers.API.Client.MembershipService.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AspNet.Identity.MongoDB;
    using MongoDB.Driver;
    using Properties;

    public class ApplicationIdentityContext : IDisposable
    {
        public static ApplicationIdentityContext Create()
        {
            // TODO: add settings where appropriate to switch server & database in your own application
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase(Settings.Default.DatabaseName);
            var users = database.GetCollection<ApplicationUser>(Settings.Default.UserCollection);
            var roles = database.GetCollection<IdentityRole>(Settings.Default.RoleCollection);
            return new ApplicationIdentityContext(users, roles);
        }

        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }

        public IMongoCollection<ApplicationUser> Users { get; set; }

        public Task<List<IdentityRole>> AllRolesAsync()
        {
            return Roles.Find(r => true).ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}