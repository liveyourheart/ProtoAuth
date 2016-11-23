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
                new ClientUser() { Id = new Guid("B7CE9BC0-10C8-4299-B631-D142772C7436"), UserName = "mmchughes@mtmrecognition.com", UnhashedPassword = "password", TrendsRoleId = 1 },
                new ClientUser() { Id = new Guid("5A18923B-7027-4664-8A5C-8ABC3FA59D9C"), UserName = "client@mtmrecognition.com", UnhashedPassword = "password", TrendsRoleId = 2 },
                new ClientUser() { Id = new Guid("F4698909-3F7F-4F97-8E55-FA49B2A6C74C"), UserName = "customer@mtmrecognition.com", UnhashedPassword = "password", TrendsRoleId = 3 },
                new ClientUser() { Id = new Guid("D10FF4AD-CA69-4C8F-802E-CFAB9500E9DC"), UserName = "program@mtmrecognition.com", UnhashedPassword = "password", TrendsRoleId = 4 }
                );
            context.Enterprises.AddOrUpdate(
                e => e.Id,
                new Enterprise() { Id = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D"), EnterpriseNumber = 1234567, Name = "Starship Enterprise" }
                );
            context.Customers.AddOrUpdate(
                s => s.Id,
                new Customer() { Id = new Guid("45D64E0C-A76B-4679-8682-D5D6052D9045"), Name = "Customer One", CID = 1234567, EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D")},
                new Customer() { Id = new Guid("6BA276F7-3BEC-445A-AD06-E06ECBD1599B"), Name = "Customer Two", CID = 7654321, EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D") },
                new Customer() { Id = new Guid("37DC8443-90A0-4CCB-A13E-58F7BED17D29"), Name = "Customer Three", CID = 123654, EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D") }
                );
            context.ServiceOrders.AddOrUpdate(
                s => s.Id,
                new ServiceOrder() { Id = new Guid("131F4786-3AD3-4A2E-96E9-5836AD773B79"), ServiceOrderNumber = 123456, Description = "Service Order One", CustomerId = new Guid("45D64E0C-A76B-4679-8682-D5D6052D9045")},
                new ServiceOrder() { Id = new Guid("8F57E63A-CA9E-475A-9908-FDA164145957"), ServiceOrderNumber = 234567, Description = "Service Order Two", CustomerId = new Guid("45D64E0C-A76B-4679-8682-D5D6052D9045") },
                new ServiceOrder() { Id = new Guid("C7D97590-4D65-4B01-BC7F-C257D24791D0"), ServiceOrderNumber = 654321, Description = "Service Order Three", CustomerId = new Guid("45D64E0C-A76B-4679-8682-D5D6052D9045") },
                new ServiceOrder() { Id = new Guid("8E23DA39-74DF-4D6C-B39C-2B5304AE11F4"), ServiceOrderNumber = 123123, Description = "Service Order Four", CustomerId = new Guid("6BA276F7-3BEC-445A-AD06-E06ECBD1599B") },
                new ServiceOrder() { Id = new Guid("AC60DF53-83AD-498F-ABDF-7E9C012FAEED"), ServiceOrderNumber = 222222, Description = "Service Order Five", CustomerId = new Guid("6BA276F7-3BEC-445A-AD06-E06ECBD1599B") },
                new ServiceOrder() { Id = new Guid("E53F5E86-29E6-4962-B275-0BE026E91EE3"), ServiceOrderNumber = 234234, Description = "Service Order Six", CustomerId = new Guid("37DC8443-90A0-4CCB-A13E-58F7BED17D29") }

                );
            context.Enrollments.AddOrUpdate(
                e => e.EnterpriseId,
               
                new Enrollment()
                {
                    Id = new Guid("89D4438A-F2C0-4BBF-9CA4-C72E27BF1FFE"),
                    ClientUserId = new Guid("B7CE9BC0-10C8-4299-B631-D142772C7436"),
                    EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D"),
                    CustomerId = new Guid("45D64E0C-A76B-4679-8682-D5D6052D9045"),
                    ServiceOrderId = new Guid("131F4786-3AD3-4A2E-96E9-5836AD773B79")
                },
                new Enrollment()
                {
                    Id = new Guid("04727861-FD40-487C-BC5E-F2624C6D83D4"),
                    ClientUserId = new Guid("B7CE9BC0-10C8-4299-B631-D142772C7436"),
                    EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D"),
                    CustomerId = new Guid("45D64E0C-A76B-4679-8682-D5D6052D9045"),
                    ServiceOrderId = new Guid("8F57E63A-CA9E-475A-9908-FDA164145957")
                },
                new Enrollment()
                {
                    Id = new Guid("12742348-CA36-4E81-B244-0F50A936A97F"),
                    ClientUserId = new Guid("B7CE9BC0-10C8-4299-B631-D142772C7436"),
                    EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D"),
                    CustomerId = new Guid("45D64E0C-A76B-4679-8682-D5D6052D9045"),
                    ServiceOrderId = new Guid("C7D97590-4D65-4B01-BC7F-C257D24791D0")
                },
                new Enrollment()
                {
                    Id = new Guid("D726332B-6A12-48A9-B680-6B4AB522209C"),
                    ClientUserId = new Guid("B7CE9BC0-10C8-4299-B631-D142772C7436"),
                    EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D"),
                    CustomerId = new Guid("6BA276F7-3BEC-445A-AD06-E06ECBD1599B"),
                    ServiceOrderId = new Guid("8E23DA39-74DF-4D6C-B39C-2B5304AE11F4")
                },
                new Enrollment()
                {
                    Id = new Guid("3A72EDEA-AD7E-4F83-9267-1772F1B28B0A"),
                    ClientUserId = new Guid("B7CE9BC0-10C8-4299-B631-D142772C7436"),
                    EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D"),
                    CustomerId = new Guid("6BA276F7-3BEC-445A-AD06-E06ECBD1599B"),
                    ServiceOrderId = new Guid("AC60DF53-83AD-498F-ABDF-7E9C012FAEED")
                },
                new Enrollment()
                {
                    Id = new Guid("76654581-1EE8-4A89-BEBD-D0F2A79210BF"),
                    ClientUserId = new Guid("B7CE9BC0-10C8-4299-B631-D142772C7436"),
                    EnterpriseId = new Guid("0121E718-7302-492D-BCCB-7445F9A7679D"),
                    CustomerId = new Guid("37DC8443-90A0-4CCB-A13E-58F7BED17D29"),
                    ServiceOrderId = new Guid("E53F5E86-29E6-4962-B275-0BE026E91EE3")
                }
                );
            
        }
    }
}
