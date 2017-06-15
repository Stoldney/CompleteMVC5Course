namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MemberShipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipType_Id" });
            RenameColumn(table: "dbo.Customers", name: "MemberShipType_Id", newName: "MembershipTypeId");
            AddColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MembershipId");
            DropColumn("dbo.MembershipTypes", "DurationInMonth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DurationInMonth", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            DropColumn("dbo.MembershipTypes", "DurationInMonths");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MemberShipType_Id");
            CreateIndex("dbo.Customers", "MemberShipType_Id");
            AddForeignKey("dbo.Customers", "MemberShipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
