namespace MVCEF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysDepartment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.SysUser", "SysDepartmentID");
            AddForeignKey("dbo.SysUser", "SysDepartmentID", "dbo.SysDepartment", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysUser", "SysDepartmentID", "dbo.SysDepartment");
            DropIndex("dbo.SysUser", new[] { "SysDepartmentID" });
            DropTable("dbo.SysDepartment");
        }
    }
}
