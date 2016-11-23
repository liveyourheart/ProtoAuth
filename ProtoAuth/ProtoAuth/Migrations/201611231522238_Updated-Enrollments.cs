namespace ProtoAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEnrollments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClientUserId = c.Guid(nullable: false),
                        EnterpriseId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        ServiceOrderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientUsers", t => t.ClientUserId, cascadeDelete: true)
                .Index(t => t.ClientUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "ClientUserId", "dbo.ClientUsers");
            DropIndex("dbo.Enrollments", new[] { "ClientUserId" });
            DropTable("dbo.Enrollments");
        }
    }
}
