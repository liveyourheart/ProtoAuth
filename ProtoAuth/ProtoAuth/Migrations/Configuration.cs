using ProtoAuth.Models;

namespace ProtoAuth.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProtoAuth.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProtoAuth.Models.ApplicationDbContext context)
        {
            context.TrendsRoles.AddOrUpdate(
                r => r.Id,
                new TrendsRole() { Id = 1, Name = "Report Administrator" },
                new TrendsRole() { Id = 2, Name = "Client Administrator" },
                new TrendsRole() { Id = 3, Name = "Customer Administrator" },
                new TrendsRole() { Id = 4, Name = "Program Administrator" }
            );
            context.ClientUsers.AddOrUpdate(
                c => c.Id,
                new ClientUser() { Id = Guid.NewGuid(), UserName = "mmchughes@mtmrecognition.com", UnhashedPassword = "password", TrendsRoleId = 1 }
                );
            context.Enterprises.AddOrUpdate(
                e => e.Id,
                    new Enterprise() { Id = Guid.NewGuid(), EnterpriseNumber = 1234567, Name = "Starship Enterprise" }
                );
        }
    }
}
