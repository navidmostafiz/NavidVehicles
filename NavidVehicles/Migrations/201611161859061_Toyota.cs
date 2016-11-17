namespace NavidVehicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Toyota : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Make", c => c.String(maxLength: 100));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Model", c => c.String());
            AlterColumn("dbo.Vehicles", "Make", c => c.String());
        }
    }
}
