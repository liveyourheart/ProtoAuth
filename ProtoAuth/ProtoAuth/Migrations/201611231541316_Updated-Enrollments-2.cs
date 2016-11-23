namespace ProtoAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEnrollments2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Enrollments", "EnterpriseId");
            CreateIndex("dbo.Enrollments", "CustomerId");
            CreateIndex("dbo.Enrollments", "ServiceOrderId");
            AddForeignKey("dbo.Enrollments", "CustomerId", "dbo.Customers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Enrollments", "EnterpriseId", "dbo.Enterprises", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Enrollments", "ServiceOrderId", "dbo.ServiceOrders", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "ServiceOrderId", "dbo.ServiceOrders");
            DropForeignKey("dbo.Enrollments", "EnterpriseId", "dbo.Enterprises");
            DropForeignKey("dbo.Enrollments", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Enrollments", new[] { "ServiceOrderId" });
            DropIndex("dbo.Enrollments", new[] { "CustomerId" });
            DropIndex("dbo.Enrollments", new[] { "EnterpriseId" });
        }
    }
}
