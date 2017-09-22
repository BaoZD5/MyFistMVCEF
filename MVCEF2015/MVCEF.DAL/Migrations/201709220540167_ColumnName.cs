namespace MVCEF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SysUser", name: "UserName", newName: "Name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.SysUser", name: "Name", newName: "UserName");
        }
    }
}
