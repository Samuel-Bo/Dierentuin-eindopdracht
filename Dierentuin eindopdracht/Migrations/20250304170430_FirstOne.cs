using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dierentuin_eindopdracht.Migrations
{
    /// <inheritdoc />
    public partial class FirstOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalCategories",
                columns: table => new
                {
                    AnimalCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalCategories", x => x.AnimalCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Zoos",
                columns: table => new
                {
                    ZooId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoos", x => x.ZooId);
                });

            migrationBuilder.CreateTable(
                name: "Enclosures",
                columns: table => new
                {
                    EnclosureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Climate = table.Column<int>(type: "int", nullable: false),
                    Habitat = table.Column<int>(type: "int", nullable: false),
                    SecurityLevel = table.Column<int>(type: "int", nullable: false),
                    ZooId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.EnclosureId);
                    table.ForeignKey(
                        name: "FK_Enclosures_Zoos_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoos",
                        principalColumn: "ZooId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpaceRequirement = table.Column<double>(type: "float", nullable: false),
                    FeedingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Arise = table.Column<TimeSpan>(type: "time", nullable: false),
                    BedTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    DietaryClass = table.Column<int>(type: "int", nullable: false),
                    ActivityPattern = table.Column<int>(type: "int", nullable: false),
                    SecurityRequirement = table.Column<int>(type: "int", nullable: false),
                    EnclosureId = table.Column<int>(type: "int", nullable: true),
                    AnimalCategoryId = table.Column<int>(type: "int", nullable: true),
                    ZooId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalCategories_AnimalCategoryId",
                        column: x => x.AnimalCategoryId,
                        principalTable: "AnimalCategories",
                        principalColumn: "AnimalCategoryId");
                    table.ForeignKey(
                        name: "FK_Animals_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "EnclosureId");
                    table.ForeignKey(
                        name: "FK_Animals_Zoos_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoos",
                        principalColumn: "ZooId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AnimalCategories",
                columns: new[] { "AnimalCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Birds" },
                    { 2, "Arachnids" },
                    { 3, "Birds" },
                    { 4, "Arachnids" },
                    { 5, "Birds" },
                    { 6, "Arachnids" },
                    { 7, "Insects" }
                });

            migrationBuilder.InsertData(
                table: "Zoos",
                columns: new[] { "ZooId", "Name" },
                values: new object[] { 1, "Tremblay - Hamill" });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "EnclosureId", "Climate", "Habitat", "Name", "SecurityLevel", "Size", "ZooId" },
                values: new object[,]
                {
                    { 1, 1, 8, "Grayson", 2, 448.99073820514172, 1 },
                    { 2, 2, 4, "Uriah", 1, 405.91602617218905, 1 },
                    { 3, 3, 2, "Hayley", 3, 435.78062550433941, 1 },
                    { 4, 1, 0, "Marty", 1, 296.87672797910722, 1 },
                    { 5, 2, 0, "Orpha", 2, 300.83291497120302, 1 },
                    { 6, 1, 1, "Cristian", 3, 443.15214740259211, 1 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "ActivityPattern", "AnimalCategoryId", "Arise", "BedTime", "DietaryClass", "EnclosureId", "FeedingTime", "Name", "Prey", "SecurityRequirement", "Size", "SpaceRequirement", "Species", "ZooId" },
                values: new object[,]
                {
                    { 1, 1, 7, new TimeSpan(204936100038), new TimeSpan(639929576997), 4, 6, new TimeSpan(24439393770), "Grayson", "Giraffe", 2, 4, 473.9013915992814, "Eagle", 1 },
                    { 2, 2, 2, new TimeSpan(17720186935), new TimeSpan(99330009689), 3, 4, new TimeSpan(5365199963), "Jamal", "Zebra", 1, 5, 296.87672797910722, "Wolf", 1 },
                    { 3, 1, 5, new TimeSpan(107426665803), new TimeSpan(410371992042), 3, 3, new TimeSpan(54176958229), "Shawna", "Giraffe", 1, 6, 448.47399293373985, "Elephant", 1 },
                    { 4, 3, 7, new TimeSpan(111519569877), new TimeSpan(399521969314), 4, 5, new TimeSpan(66083643802), "Lisandro", "Crocodile", 1, 2, 82.512082873150746, "Eagle", 1 },
                    { 5, 2, 4, new TimeSpan(41852732775), new TimeSpan(243734136646), 1, 5, new TimeSpan(25330644821), "Ian", "Elephant", 1, 1, 404.71676491420567, "Eagle", 1 },
                    { 6, 1, 5, new TimeSpan(102754421077), new TimeSpan(186054146388), 3, 3, new TimeSpan(36385736341), "Thad", "Lion", 1, 3, 468.34364081655798, "Giraffe", 1 },
                    { 7, 2, 7, new TimeSpan(16272114422), new TimeSpan(94591060872), 1, 5, new TimeSpan(41974582345), "Leon", "Lion", 2, 6, 56.579863082887542, "Tiger", 1 },
                    { 8, 1, 2, new TimeSpan(91478088049), new TimeSpan(315905564336), 3, 6, new TimeSpan(22879923552), "Aisha", "Crocodile", 1, 3, 285.21334405765555, "Lion", 1 },
                    { 9, 1, 7, new TimeSpan(10746789531), new TimeSpan(285113426103), 3, 6, new TimeSpan(43451053517), "Roosevelt", "Penguin", 1, 5, 491.68804400213435, "Crocodile", 1 },
                    { 10, 1, 7, new TimeSpan(80826539200), new TimeSpan(167761950385), 3, 6, new TimeSpan(51812972525), "Amely", "Zebra", 3, 4, 432.04042462727074, "Zebra", 1 },
                    { 11, 2, 1, new TimeSpan(193345395450), new TimeSpan(191294216137), 2, 1, new TimeSpan(70624234612), "Quinn", "Elephant", 2, 3, 16.313045614544791, "Lion", 1 },
                    { 12, 3, 4, new TimeSpan(99618252912), new TimeSpan(468805838904), 2, 5, new TimeSpan(62611278876), "Laverna", "Tiger", 3, 3, 223.17880367542563, "Giraffe", 1 },
                    { 13, 1, 2, new TimeSpan(132349561310), new TimeSpan(70577464565), 2, 4, new TimeSpan(25083270684), "Ona", "Crocodile", 2, 4, 199.41648925627419, "Zebra", 1 },
                    { 14, 3, 3, new TimeSpan(64352514990), new TimeSpan(622210020716), 4, 1, new TimeSpan(3653405251), "Chyna", "Crocodile", 2, 5, 411.3170782110268, "Wolf", 1 },
                    { 15, 2, 2, new TimeSpan(129931104601), new TimeSpan(220119403796), 1, 6, new TimeSpan(19979382051), "Griffin", "Crocodile", 3, 4, 222.31171337995292, "Giraffe", 1 },
                    { 16, 3, 6, new TimeSpan(152857818418), new TimeSpan(683754096838), 2, 4, new TimeSpan(3619670270), "Orville", "Giraffe", 3, 5, 182.93205114683698, "Shark", 1 },
                    { 17, 3, 1, new TimeSpan(28083613930), new TimeSpan(289542201017), 2, 5, new TimeSpan(57129796535), "Frida", "Wolf", 1, 1, 498.99183494923255, "Shark", 1 },
                    { 18, 3, 6, new TimeSpan(161271415312), new TimeSpan(770496067041), 3, 3, new TimeSpan(9242950943), "Rupert", "Zebra", 1, 5, 42.225983786501914, "Elephant", 1 },
                    { 19, 1, 6, new TimeSpan(165497481911), new TimeSpan(697386550897), 2, 1, new TimeSpan(31555508833), "Nash", "Zebra", 3, 4, 72.629228761712668, "Tiger", 1 },
                    { 20, 2, 6, new TimeSpan(73708368492), new TimeSpan(428877822405), 5, 2, new TimeSpan(14361095182), "Mariane", "Elephant", 1, 1, 289.29339600694061, "Penguin", 1 },
                    { 21, 1, 3, new TimeSpan(95051427047), new TimeSpan(454837718490), 2, 1, new TimeSpan(10821104356), "Arden", "Eagle", 2, 6, 427.09427699311368, "Crocodile", 1 },
                    { 22, 2, 5, new TimeSpan(181584039706), new TimeSpan(746942967934), 1, 6, new TimeSpan(69495288211), "Easter", "Penguin", 2, 2, 315.28516944743933, "Shark", 1 },
                    { 23, 1, 2, new TimeSpan(132488325494), new TimeSpan(727653002549), 4, 3, new TimeSpan(42345596158), "Victor", "Wolf", 2, 5, 446.3634764712134, "Eagle", 1 },
                    { 24, 2, 5, new TimeSpan(177995547601), new TimeSpan(386270163127), 1, 2, new TimeSpan(19631051881), "Fred", "Eagle", 2, 6, 151.97761894295812, "Crocodile", 1 },
                    { 25, 3, 5, new TimeSpan(61080534345), new TimeSpan(715448422326), 3, 3, new TimeSpan(6309776615), "Claud", "Penguin", 1, 4, 13.287990751344706, "Elephant", 1 },
                    { 26, 2, 2, new TimeSpan(176255972747), new TimeSpan(191489009052), 3, 5, new TimeSpan(45376925020), "Oceane", "Zebra", 2, 5, 300.35924553422223, "Tiger", 1 },
                    { 27, 2, 2, new TimeSpan(53099359466), new TimeSpan(523820289439), 3, 5, new TimeSpan(19547945613), "Paula", "Wolf", 1, 6, 451.99132277257337, "Penguin", 1 },
                    { 28, 1, 7, new TimeSpan(129353015904), new TimeSpan(628046762547), 1, 3, new TimeSpan(61647658440), "Gayle", "Zebra", 1, 4, 443.87651552626699, "Penguin", 1 },
                    { 29, 2, 3, new TimeSpan(194868312356), new TimeSpan(179691622088), 3, 4, new TimeSpan(62727033797), "Mireille", "Eagle", 3, 6, 360.46767217594561, "Shark", 1 },
                    { 30, 3, 4, new TimeSpan(76969667843), new TimeSpan(720225221839), 3, 4, new TimeSpan(36771497375), "Virginie", "Zebra", 1, 3, 179.08981631933236, "Eagle", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalCategoryId",
                table: "Animals",
                column: "AnimalCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_EnclosureId",
                table: "Animals",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ZooId",
                table: "Animals",
                column: "ZooId");

            migrationBuilder.CreateIndex(
                name: "IX_Enclosures_ZooId",
                table: "Enclosures",
                column: "ZooId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalCategories");

            migrationBuilder.DropTable(
                name: "Enclosures");

            migrationBuilder.DropTable(
                name: "Zoos");
        }
    }
}
