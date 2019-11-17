namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingMembershipTypetablepropertynamewithsomenames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE MembershipTypeId = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE MembershipTypeId = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE MembershipTypeId = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE MembershipTypeId = 4");

        }
        
        public override void Down()
        {
        }
    }
}
