namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class SeedUsers : DbMigration
	{
		public override void Up()
		{
			Sql(@"
				INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'512f1301-ae63-4764-8145-ac844ceceaa4', N'admin@vidly.com', 0, N'ADy5MLKs3ZdBpBU9dNtrpMsLr0R0ef4exh2X3oFfCsp8xhgxlCA8A0YUK4/U5TC6wQ==', N'5f2204cf-bb6b-42d1-8874-0cf2757760fd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
				INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'a3ee5bda-0e44-4d4c-8a87-f995f8869f82', N'guest@vidly.com', 0, N'AJ8W/M2VoGKi9E3yXaSAM8b2e/0cb6il96OQxeR5wTMYo0JRgAnJOy6AfzF3x71gfQ==', N'23ea1f08-fe1a-475c-8b1d-90ad6d047a67', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

				INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b0b76951-401a-49ba-bcaa-cf69ae3da861', N'CanManageMovies')

				INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'512f1301-ae63-4764-8145-ac844ceceaa4', N'b0b76951-401a-49ba-bcaa-cf69ae3da861')				
			");
		}
		
		public override void Down()
		{
		}
	}
}
