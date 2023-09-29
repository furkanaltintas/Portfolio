using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Introduces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ExperiencePeriod = table.Column<short>(type: "smallint", nullable: false),
                    ExperienceContent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectCount = table.Column<short>(type: "smallint", nullable: false),
                    ProjectContent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Introduces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Header = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Queue = table.Column<short>(type: "smallint", nullable: false),
                    IsHeaderActive = table.Column<bool>(type: "bit", nullable: false),
                    IsIconActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRange = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Point = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalProject = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuHeaders_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(498), null, "Ben Furkan Altıntaş. Düzce Üniversitesi Mezunuyum.", true, false, "Ben Kimim ?", null });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "FullName", "IsActive", "IsDeleted", "Message", "Phone", "Subject", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(2905), null, "berketest@gmail.com", "Berke Altıntaş", true, false, "Bu bir deneme mesajıdır", "+90 555 555 55 55", "Deneme", null });

            migrationBuilder.InsertData(
                table: "Introduces",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ExperienceContent", "ExperiencePeriod", "IsActive", "IsDeleted", "ProjectContent", "ProjectCount", "Title", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(5044), null, "And I'm sick of waiting patiently for someone that won't even arrive", "Yazılım Tecrübesi", (short)0, true, false, "Toplam Proje Sayısı (GitHub)", (short)0, "Merhaba ben Furkan", null });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ComponentName", "CreatedDate", "DeletedDate", "Header", "IconName", "IsActive", "IsDeleted", "IsHeaderActive", "IsIconActive", "Queue", "Slug", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Introduce", new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(7173), null, "Introduce", "las la-home", true, false, false, false, (short)1, "home", null },
                    { 2, "About", new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(7175), null, "About", "lar la-user", true, false, false, false, (short)2, "about", null },
                    { 3, "Resume", new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(7177), null, "Resume", "las la-briefcase", true, false, false, false, (short)3, "resume", null },
                    { 4, "Service", new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(7180), null, "Services", "las la-stream", true, false, false, false, (short)4, "services", null },
                    { 5, "Skill", new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(7181), null, "My Skills", "las la-shapes", true, false, false, false, (short)5, "skills", null },
                    { 6, "Portfolio", new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(7183), null, "Portfolio", "las la-grip-vertical", true, false, false, false, (short)6, "portfolio", null },
                    { 7, "Testimonial", new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(7185), null, "Testimonial", "lar la-comment", true, false, false, false, (short)7, "testimonial", null },
                    { 8, "Contact", new DateTime(2023, 9, 26, 23, 57, 13, 938, DateTimeKind.Local).AddTicks(7187), null, "Contact", "las la-envelope", true, false, false, false, (short)8, "contact", null }
                });

            migrationBuilder.InsertData(
                table: "Resumes",
                columns: new[] { "Id", "CreatedDate", "DateRange", "DeletedDate", "IsActive", "IsDeleted", "SubTitle", "Title", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(1970), "2019 - 2021", null, true, false, "Düzce Üniversitesi", "Bilgisayar Programcılığı", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IconName", "IsActive", "IsDeleted", "Name", "Point", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(3965), null, "...", true, false, "Net Core", (short)60, null },
                    { 2, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(3968), null, "...", true, false, "Wordpress", (short)45, null },
                    { 3, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(3970), null, "...", true, false, "Angular", (short)35, null }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IconName", "IsActive", "IsDeleted", "Link", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(6123), null, "lab la-github", true, false, "https://github.com/FurkanAltintas", "GitHub", null },
                    { 2, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(6125), null, "lab la-linkedin", false, false, "https://www.linkedin.com/in/furkanaltintas/", "Linkedin", null }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IconName", "IsActive", "IsDeleted", "Title", "TotalProject", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(8157), null, "I build website go live with Framer, Webflow or WordPress", "las la-code", true, false, "Development", "4 Projects", null });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "CreatedDate", "Degree", "DeletedDate", "Description", "FullName", "IsActive", "IsDeleted", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(9922), "Bilgisayar Mühendisi", null, "\"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book\"", "Berkay Akar", true, false, null },
                    { 2, new DateTime(2023, 9, 26, 23, 57, 13, 939, DateTimeKind.Local).AddTicks(9925), "Unity Developer", null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Nihat Ovalıoğlu", true, false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuHeaders_MenuId",
                table: "MenuHeaders",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Introduces");

            migrationBuilder.DropTable(
                name: "MenuHeaders");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
