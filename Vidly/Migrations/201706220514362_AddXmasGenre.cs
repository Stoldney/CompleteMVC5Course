namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class AddXmasGenre : DbMigration
	{
		public override void Up()
		{
			Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Xmas')");
		}
		
		public override void Down()
		{
		}
	}
}
