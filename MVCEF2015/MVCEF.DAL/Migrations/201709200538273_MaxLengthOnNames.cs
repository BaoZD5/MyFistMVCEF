namespace MVCEF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.SysUser", "SysDepartmentID", c => c.Int());
            AlterColumn("dbo.SysUser", "UserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.SysUser", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.SysUser", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.SysUser", "Sex", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SysUser", "Sex", c => c.String());
            AlterColumn("dbo.SysUser", "Password", c => c.String());
            AlterColumn("dbo.SysUser", "Email", c => c.String());
            AlterColumn("dbo.SysUser", "UserName", c => c.String());
            DropColumn("dbo.SysUser", "SysDepartmentID");
        }
    }
}
