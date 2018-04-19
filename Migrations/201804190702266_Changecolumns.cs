namespace MoRe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changecolumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genres_Id" });
            RenameColumn(table: "dbo.Movies", name: "Genres_Id", newName: "GenresId");
            AlterColumn("dbo.Movies", "GenresId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenresId");
            AddForeignKey("dbo.Movies", "GenresId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "GenerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenerId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Movies", "GenresId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenresId" });
            AlterColumn("dbo.Movies", "GenresId", c => c.Byte());
            RenameColumn(table: "dbo.Movies", name: "GenresId", newName: "Genres_Id");
            CreateIndex("dbo.Movies", "Genres_Id");
            AddForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres", "Id");
        }
    }
}
