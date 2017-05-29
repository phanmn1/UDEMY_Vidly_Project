namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5f1b4533-9173-4938-8f59-569eb1aa5167', N'admin@vidly.com', 0, N'AB77eo0n6+bP2twAFpLGjrhxsVUfS2vqFOdq6LCixHNCebeamk348sc4KPR4cDUsEg==', N'29d42860-f4d3-4ca1-ba4c-3dddae7a8873', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                   INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b4fe9c0c-5f9f-4344-b94e-1632e54854ec', N'guest@vidly.com', 0, N'AJW6Jvr6JFT0Npr9U63L2IE96pcqajCFgfFm6e9LihQ/c95v81kFm+7T5h5CVwzaeg==', N'0cf2f5d5-831e-49f3-9968-7b8e1d3a16e2', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                   INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ff375b3d-ceae-4f79-8a75-d5339c55dfa0', N'CanManageMovies')
                   INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5f1b4533-9173-4938-8f59-569eb1aa5167', N'ff375b3d-ceae-4f79-8a75-d5339c55dfa0')
");
        }
        
        public override void Down()
        {
        }
    }
}
