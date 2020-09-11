namespace OneInt_test.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        NameOwner = c.String(),
                        SurnameOwner = c.String(),
                        ObjectName = c.String(),
                        ObjectType = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        MonthCreated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Policies");
        }
    }
}
