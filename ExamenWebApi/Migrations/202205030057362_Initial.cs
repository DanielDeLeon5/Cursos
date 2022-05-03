namespace ExamenWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        DPI = c.String(),
                        Edad = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: true)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Categoria = c.String(),
                        Descripcion = c.String(),
                        CatedraticoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catedraticoes", t => t.CatedraticoId, cascadeDelete: true)
                .Index(t => t.CatedraticoId);
            
            CreateTable(
                "dbo.Catedraticoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        DPI = c.String(),
                        Especialidad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumnoes", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Cursoes", "CatedraticoId", "dbo.Catedraticoes");
            DropIndex("dbo.Cursoes", new[] { "CatedraticoId" });
            DropIndex("dbo.Alumnoes", new[] { "CursoId" });
            DropTable("dbo.Catedraticoes");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Alumnoes");
        }
    }
}
