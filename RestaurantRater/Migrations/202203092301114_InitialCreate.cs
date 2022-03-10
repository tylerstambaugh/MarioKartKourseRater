namespace RestaurantRater.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kourses",
                c => new
                    {
                        KourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cup = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KourseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kourses");
        }
    }
}
