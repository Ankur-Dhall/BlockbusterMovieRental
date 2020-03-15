namespace blockbuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValueOfNameInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name = 'Pay as You go' where Id = 1");
            Sql("Update MembershipTypes set Name = 'Monthly' where Id = 2");
            Sql("Update MembershipTypes set Name = 'Quarterly' where Id = 3");
            Sql("Update MembershipTypes set Name = 'yearly' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
