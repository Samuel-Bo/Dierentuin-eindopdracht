using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dierentuin_eindopdracht.Migrations
{
    /// <inheritdoc />
    public partial class NewStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
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
                    SecurityRequirment = table.Column<int>(type: "int", nullable: false),
                    EnclosureId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ZooId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Animals_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "EnclosureId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Animals_Zoos_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoos",
                        principalColumn: "ZooId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Fishes" },
                    { 2, "Reptiles" },
                    { 3, "Reptiles" },
                    { 4, "Mammals" },
                    { 5, "Mammals" }
                });

            migrationBuilder.InsertData(
                table: "Zoos",
                columns: new[] { "ZooId", "Name" },
                values: new object[] { 1, "Schmidt LLC" });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "EnclosureId", "Climate", "Habitat", "Name", "SecurityLevel", "Size", "ZooId" },
                values: new object[,]
                {
                    { 1, 3, 4, "iusto", 2, 628.25270603018873, 1 },
                    { 2, 1, 1, "nulla", 1, 409.33744118448237, 1 },
                    { 3, 3, 8, "odio", 1, 834.97963382873229, 1 },
                    { 4, 3, 0, "est", 1, 756.2794256963673, 1 },
                    { 5, 2, 0, "ducimus", 3, 168.89336363545044, 1 },
                    { 6, 2, 4, "voluptas", 1, 456.43705507639908, 1 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "ActivityPattern", "Arise", "BedTime", "CategoryId", "DietaryClass", "EnclosureId", "FeedingTime", "Name", "Prey", "SecurityRequirment", "Size", "SpaceRequirement", "Species", "ZooId" },
                values: new object[,]
                {
                    { 1, 2, new TimeSpan(47314443712), new TimeSpan(275482728665), 5, 5, 6, new TimeSpan(54843076852), "Hattie", "Lion", 2, 1, 387.23341698203183, "Elephant", 1 },
                    { 2, 1, new TimeSpan(178738956670), new TimeSpan(268858208707), 5, 2, 4, new TimeSpan(41722100711), "Idella", "Penguin", 1, 4, 495.52163265420398, "Lion", 1 },
                    { 3, 1, new TimeSpan(46125502544), new TimeSpan(272432288544), 5, 5, 3, new TimeSpan(51777067818), "Liza", "Lion", 1, 2, 357.39589480402924, "Lion", 1 },
                    { 4, 2, new TimeSpan(139845612075), new TimeSpan(209381115322), 5, 5, 4, new TimeSpan(30258155207), "Maurice", "Penguin", 2, 5, 149.7243389014221, "Elephant", 1 },
                    { 5, 1, new TimeSpan(183378337156), new TimeSpan(606897816802), 1, 2, 4, new TimeSpan(64852849105), "Richie", "Tiger", 3, 2, 48.504286897227352, "Penguin", 1 },
                    { 6, 2, new TimeSpan(185047792117), new TimeSpan(401790895226), 3, 5, 5, new TimeSpan(13450433904), "Buck", "Lion", 3, 3, 244.33639718905684, "Lion", 1 },
                    { 7, 3, new TimeSpan(199697444227), new TimeSpan(776823335418), 1, 1, 6, new TimeSpan(52774688983), "Cade", "Tiger", 1, 6, 382.72789653954305, "Giraffe", 1 },
                    { 8, 2, new TimeSpan(94685397162), new TimeSpan(287533875186), 5, 5, 4, new TimeSpan(66128477796), "Lizzie", "Giraffe", 1, 1, 16.015820295910981, "Tiger", 1 },
                    { 9, 1, new TimeSpan(201598183116), new TimeSpan(476027202125), 4, 4, 4, new TimeSpan(21147670512), "May", "Elephant", 3, 5, 180.60968908315795, "Tiger", 1 },
                    { 10, 2, new TimeSpan(133759977685), new TimeSpan(107261277721), 2, 5, 4, new TimeSpan(67289902542), "Don", "Penguin", 1, 2, 239.06306665958337, "Elephant", 1 },
                    { 11, 2, new TimeSpan(144098375657), new TimeSpan(657971483613), 3, 4, 2, new TimeSpan(45984647751), "Laurianne", "Elephant", 2, 5, 429.67011478053092, "Elephant", 1 },
                    { 12, 1, new TimeSpan(75011657048), new TimeSpan(572312848364), 5, 5, 3, new TimeSpan(30274135927), "Lauretta", "Elephant", 2, 4, 248.51109664917183, "Penguin", 1 },
                    { 13, 2, new TimeSpan(26660064931), new TimeSpan(434168964258), 1, 2, 3, new TimeSpan(43651018392), "Aurelio", "Tiger", 2, 1, 114.04001765193084, "Elephant", 1 },
                    { 14, 2, new TimeSpan(7035749112), new TimeSpan(117790016682), 3, 3, 4, new TimeSpan(40997552952), "Donato", "Penguin", 2, 4, 147.11069506749681, "Lion", 1 },
                    { 15, 2, new TimeSpan(47765150544), new TimeSpan(7083953155), 3, 1, 4, new TimeSpan(23979544026), "Reece", "Elephant", 1, 5, 78.39218871021373, "Elephant", 1 },
                    { 16, 2, new TimeSpan(204207458821), new TimeSpan(19522794249), 1, 1, 1, new TimeSpan(19306960545), "Mariana", "Tiger", 1, 2, 87.316844657781616, "Penguin", 1 },
                    { 17, 1, new TimeSpan(172575835538), new TimeSpan(595460353567), 5, 4, 1, new TimeSpan(42946154529), "Kiel", "Penguin", 1, 5, 434.47274809660837, "Penguin", 1 },
                    { 18, 3, new TimeSpan(57182537585), new TimeSpan(492526206177), 5, 1, 5, new TimeSpan(30378208429), "Jedidiah", "Penguin", 1, 1, 396.23434305356307, "Penguin", 1 },
                    { 19, 2, new TimeSpan(58229305341), new TimeSpan(437213422470), 4, 4, 4, new TimeSpan(5714525601), "Golden", "Elephant", 1, 3, 59.417505129701553, "Tiger", 1 },
                    { 20, 1, new TimeSpan(37945734298), new TimeSpan(394245190856), 4, 5, 4, new TimeSpan(50137239445), "Willa", "Giraffe", 1, 3, 19.217550991013653, "Tiger", 1 },
                    { 21, 3, new TimeSpan(7917982568), new TimeSpan(269286848531), 3, 2, 1, new TimeSpan(17782663723), "Simeon", "Giraffe", 3, 2, 415.08112566132615, "Elephant", 1 },
                    { 22, 1, new TimeSpan(154418060060), new TimeSpan(576609208502), 1, 4, 6, new TimeSpan(43630863403), "Odell", "Giraffe", 1, 5, 446.25900703567845, "Elephant", 1 },
                    { 23, 1, new TimeSpan(144248523062), new TimeSpan(187234051384), 3, 4, 3, new TimeSpan(45655050724), "Makayla", "Elephant", 3, 1, 80.084243130882811, "Lion", 1 },
                    { 24, 2, new TimeSpan(58198134314), new TimeSpan(168036387456), 3, 1, 1, new TimeSpan(49615524561), "Emiliano", "Tiger", 1, 2, 353.09382913789835, "Lion", 1 },
                    { 25, 1, new TimeSpan(166344798044), new TimeSpan(450725749334), 3, 5, 6, new TimeSpan(69798229360), "Jovanny", "Giraffe", 1, 4, 262.58858107410492, "Tiger", 1 },
                    { 26, 2, new TimeSpan(54669294918), new TimeSpan(542504046106), 1, 1, 3, new TimeSpan(61677456327), "Gunner", "Penguin", 1, 4, 461.32822953275718, "Giraffe", 1 },
                    { 27, 2, new TimeSpan(68983715406), new TimeSpan(260382031383), 1, 1, 3, new TimeSpan(37322565542), "Katherine", "Penguin", 2, 4, 364.08086782810994, "Lion", 1 },
                    { 28, 2, new TimeSpan(8079244242), new TimeSpan(67335219099), 2, 4, 2, new TimeSpan(40241331823), "Brigitte", "Elephant", 3, 5, 357.41735660029195, "Lion", 1 },
                    { 29, 2, new TimeSpan(74832041473), new TimeSpan(471025959801), 2, 5, 2, new TimeSpan(35992052659), "Domenica", "Elephant", 3, 6, 27.850196066951142, "Lion", 1 },
                    { 30, 3, new TimeSpan(112422616530), new TimeSpan(39739689031), 5, 4, 6, new TimeSpan(8500789948), "Skylar", "Giraffe", 2, 2, 295.08229847584334, "Tiger", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Enclosures");

            migrationBuilder.DropTable(
                name: "Zoos");
        }
    }
}
