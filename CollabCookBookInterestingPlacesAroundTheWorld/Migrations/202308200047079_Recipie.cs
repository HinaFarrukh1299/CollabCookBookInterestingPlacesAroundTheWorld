namespace CollabCookBookInterestingPlacesAroundTheWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recipie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        RecipeTitle = c.String(),
                        Instructions = c.String(),
                        CookTime = c.String(),
                        ServingSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.RecipeOrigins",
                c => new
                    {
                        Recipe_RecipeId = c.Int(nullable: false),
                        Origin_OriginID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeId, t.Origin_OriginID })
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Origins", t => t.Origin_OriginID, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeId)
                .Index(t => t.Origin_OriginID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeOrigins", "Origin_OriginID", "dbo.Origins");
            DropForeignKey("dbo.RecipeOrigins", "Recipe_RecipeId", "dbo.Recipes");
            DropIndex("dbo.RecipeOrigins", new[] { "Origin_OriginID" });
            DropIndex("dbo.RecipeOrigins", new[] { "Recipe_RecipeId" });
            DropTable("dbo.RecipeOrigins");
            DropTable("dbo.Recipes");
        }
    }
}
