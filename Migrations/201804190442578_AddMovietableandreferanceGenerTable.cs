namespace MoRe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovietableandreferanceGenerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GenerId = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(),
                        AddedDate = c.DateTime(),
                        NumberinStock = c.Int(nullable: false),
                        Genres_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genres_Id)
                .Index(t => t.Genres_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genres_Id" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
