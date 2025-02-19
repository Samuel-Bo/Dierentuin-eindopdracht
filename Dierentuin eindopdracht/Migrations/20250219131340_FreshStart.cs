using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dierentuin_eindopdracht.Migrations
{
    /// <inheritdoc />
    public partial class FreshStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Zoo",
                columns: table => new
                {
                    ZooId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoo", x => x.ZooId);
                });

            migrationBuilder.CreateTable(
                name: "Enclosure",
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
                    table.PrimaryKey("PK_Enclosure", x => x.EnclosureId);
                    table.ForeignKey(
                        name: "FK_Enclosure_Zoo_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoo",
                        principalColumn: "ZooId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
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
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animal_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Animal_Enclosure_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosure",
                        principalColumn: "EnclosureId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Animal_Zoo_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoo",
                        principalColumn: "ZooId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Insects" },
                    { 2, "Mammals" },
                    { 3, "Reptiles" },
                    { 4, "Mammals" },
                    { 5, "Fishes" },
                    { 6, "Mammals" },
                    { 7, "Birds" },
                    { 8, "Birds" },
                    { 9, "Reptiles" },
                    { 10, "Reptiles" }
                });

            migrationBuilder.InsertData(
                table: "Zoo",
                columns: new[] { "ZooId", "Name" },
                values: new object[,]
                {
                    { 1, "Jeramie Metz" },
                    { 2, "Jeffrey Wunsch" },
                    { 3, "Norwood Rowe" },
                    { 4, "Howard Rempel" },
                    { 5, "Macey Kub" },
                    { 6, "Amber Zemlak" },
                    { 7, "Devan Farrell" },
                    { 8, "Judy Runolfsson" },
                    { 9, "Dariana Langosh" },
                    { 10, "Rowan O'Hara" }
                });

            migrationBuilder.InsertData(
                table: "Enclosure",
                columns: new[] { "EnclosureId", "Climate", "Habitat", "Name", "SecurityLevel", "Size", "ZooId" },
                values: new object[,]
                {
                    { 1, 3, 0, "unde", 3, 841.64121757243811, 5 },
                    { 2, 2, 0, "et", 3, 977.52249437821297, 10 },
                    { 3, 3, 0, "optio", 1, 527.51308609716352, 6 },
                    { 4, 2, 4, "modi", 1, 902.38447889501424, 7 },
                    { 5, 1, 4, "modi", 2, 578.63162132052707, 3 },
                    { 6, 1, 1, "rerum", 2, 826.26411276455883, 1 },
                    { 7, 2, 2, "nisi", 1, 213.62112745019482, 1 },
                    { 8, 2, 1, "nihil", 3, 124.29017987195763, 6 },
                    { 9, 3, 2, "cum", 1, 616.08083770531709, 8 },
                    { 10, 1, 2, "voluptatem", 3, 901.72938789632553, 2 },
                    { 11, 3, 2, "dolores", 1, 225.43836920483369, 9 },
                    { 12, 1, 1, "sapiente", 1, 486.62615349070711, 8 },
                    { 13, 3, 1, "ex", 3, 422.05543959402422, 5 },
                    { 14, 1, 4, "ducimus", 2, 319.71051684332508, 4 },
                    { 15, 2, 4, "corporis", 3, 401.47874081875432, 9 },
                    { 16, 1, 0, "consequuntur", 1, 892.9487193195622, 10 },
                    { 17, 3, 2, "id", 2, 867.91827158256206, 3 },
                    { 18, 2, 4, "qui", 1, 810.9944796860035, 4 },
                    { 19, 2, 0, "velit", 3, 937.82436519726764, 2 },
                    { 20, 3, 4, "alias", 1, 207.36464978763058, 7 }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalId", "ActivityPattern", "Arise", "BedTime", "CategoryId", "DietaryClass", "EnclosureId", "FeedingTime", "Name", "Prey", "SecurityRequirment", "Size", "SpaceRequirement", "Species", "ZooId" },
                values: new object[,]
                {
                    { 1, 2, new TimeSpan(200182117564), new TimeSpan(180134109493), 2, 5, 6, new TimeSpan(65419847840), "Haskell", "molestiae", 1, 2, 383.64650105176895, "Cobra", 1 },
                    { 2, 2, new TimeSpan(30770450166), new TimeSpan(702996273597), 7, 4, 15, new TimeSpan(65114320001), "Napoleon", "qui", 1, 6, 22.097264367573192, "Penguin", 9 },
                    { 3, 2, new TimeSpan(114824357390), new TimeSpan(42999096052), 10, 5, 12, new TimeSpan(2187147807), "Florence", "dolorem", 3, 1, 133.82022730882255, "Cobra", 8 },
                    { 4, 1, new TimeSpan(9411394552), new TimeSpan(352522665957), 6, 1, 12, new TimeSpan(29371363492), "Laney", "quisquam", 2, 2, 203.29529276968219, "Elephant", 8 },
                    { 5, 3, new TimeSpan(129344489563), new TimeSpan(91143972258), 6, 1, 10, new TimeSpan(15055524243), "Agustin", "exercitationem", 1, 1, 258.36142983133698, "Cobra", 2 },
                    { 6, 2, new TimeSpan(185616332717), new TimeSpan(778149941284), 9, 3, 8, new TimeSpan(71030031877), "Gloria", "inventore", 3, 3, 204.69066170591807, "Eagle", 6 },
                    { 7, 3, new TimeSpan(37608962192), new TimeSpan(1126861525), 6, 4, 4, new TimeSpan(52381060166), "Pat", "itaque", 3, 4, 408.0739910357554, "Cobra", 7 },
                    { 8, 2, new TimeSpan(51088790664), new TimeSpan(471568893951), 10, 1, 5, new TimeSpan(66145423250), "Shawn", "ea", 1, 1, 476.53984298867175, "Kangaroo", 3 },
                    { 9, 2, new TimeSpan(49927774862), new TimeSpan(315606380705), 4, 1, 10, new TimeSpan(3761946948), "Megane", "et", 2, 6, 224.84113573862194, "Giraffe", 2 },
                    { 10, 1, new TimeSpan(102305893360), new TimeSpan(357165791407), 8, 1, 1, new TimeSpan(27018965239), "Shanie", "deleniti", 1, 5, 265.78961992673158, "Tiger", 5 },
                    { 11, 2, new TimeSpan(86339881114), new TimeSpan(172624076788), 9, 1, 13, new TimeSpan(2767007975), "Jevon", "error", 2, 1, 163.42002381097569, "Eagle", 5 },
                    { 12, 3, new TimeSpan(206375178726), new TimeSpan(463919143154), 4, 1, 3, new TimeSpan(50435853913), "Darren", "quod", 3, 1, 375.32974812733983, "Tiger", 6 },
                    { 13, 3, new TimeSpan(63805689537), new TimeSpan(73327467480), 10, 5, 11, new TimeSpan(16050594094), "Brett", "eaque", 2, 5, 328.71988496632446, "Tiger", 9 },
                    { 14, 1, new TimeSpan(143026735044), new TimeSpan(791748368447), 1, 4, 11, new TimeSpan(57009691717), "Magdalen", "quam", 3, 1, 256.39396598380802, "Giraffe", 9 },
                    { 15, 3, new TimeSpan(90892765741), new TimeSpan(338366204843), 10, 3, 10, new TimeSpan(951797193), "Darian", "unde", 1, 2, 37.752579420392628, "Lion", 2 },
                    { 16, 3, new TimeSpan(20690538026), new TimeSpan(171642347196), 10, 1, 16, new TimeSpan(4740869519), "Bobby", "dicta", 1, 3, 146.56541220762855, "Kangaroo", 10 },
                    { 17, 3, new TimeSpan(55310785922), new TimeSpan(528003652134), 1, 3, 16, new TimeSpan(826441911), "Harmony", "consequatur", 3, 2, 475.4036827887067, "Penguin", 10 },
                    { 18, 2, new TimeSpan(42785905863), new TimeSpan(490876910815), 10, 5, 17, new TimeSpan(67225248168), "Sanford", "voluptates", 1, 5, 259.71422645809389, "Penguin", 3 },
                    { 19, 2, new TimeSpan(105482106215), new TimeSpan(123803231473), 3, 3, 18, new TimeSpan(65940316022), "Gardner", "atque", 2, 1, 424.52544162174394, "Tiger", 4 },
                    { 20, 1, new TimeSpan(159880392291), new TimeSpan(39336319536), 10, 2, 13, new TimeSpan(20879802473), "Beverly", "nostrum", 2, 1, 126.88994844327411, "Eagle", 5 },
                    { 21, 2, new TimeSpan(43574232937), new TimeSpan(709298708327), 9, 1, 3, new TimeSpan(35179616456), "Lorena", "incidunt", 3, 4, 270.46576953766595, "Elephant", 6 },
                    { 22, 3, new TimeSpan(215221750472), new TimeSpan(200883400486), 4, 1, 17, new TimeSpan(44957298282), "Destiney", "aliquam", 1, 3, 186.83332152101229, "Penguin", 3 },
                    { 23, 2, new TimeSpan(98177557130), new TimeSpan(557794717621), 9, 1, 12, new TimeSpan(58468578182), "Filomena", "voluptate", 2, 4, 430.71728434603796, "Giraffe", 8 },
                    { 24, 3, new TimeSpan(123163444320), new TimeSpan(606539646354), 6, 2, 18, new TimeSpan(68912346884), "Laurence", "cupiditate", 3, 2, 108.9350280396493, "Giraffe", 4 },
                    { 25, 2, new TimeSpan(45769239572), new TimeSpan(388674793193), 9, 5, 18, new TimeSpan(5188010079), "Gudrun", "a", 1, 3, 218.59651636887003, "Elephant", 4 },
                    { 26, 3, new TimeSpan(53483630095), new TimeSpan(734370920941), 5, 1, 7, new TimeSpan(70219854812), "Ila", "magnam", 1, 6, 310.95643452331751, "Elephant", 1 },
                    { 27, 3, new TimeSpan(119109704261), new TimeSpan(261642441290), 4, 3, 10, new TimeSpan(29715681460), "Arnulfo", "dolor", 3, 5, 376.32084913156433, "Kangaroo", 2 },
                    { 28, 2, new TimeSpan(171693329341), new TimeSpan(441806220870), 2, 2, 2, new TimeSpan(11649506346), "Jayden", "error", 2, 1, 313.60364071726309, "Kangaroo", 10 },
                    { 29, 1, new TimeSpan(83722830140), new TimeSpan(435920578944), 10, 5, 3, new TimeSpan(16892794642), "Narciso", "cupiditate", 2, 4, 357.77020725318874, "Kangaroo", 6 },
                    { 30, 3, new TimeSpan(174724969900), new TimeSpan(246383150711), 7, 2, 15, new TimeSpan(33177743172), "Lindsey", "eos", 3, 1, 365.20880730098639, "Tiger", 9 },
                    { 31, 3, new TimeSpan(48755860198), new TimeSpan(655077982563), 6, 4, 20, new TimeSpan(10546947560), "Giovanni", "ipsum", 1, 1, 249.31260418648941, "Lion", 7 },
                    { 32, 1, new TimeSpan(194724353584), new TimeSpan(548134681639), 4, 5, 9, new TimeSpan(61522221875), "Cloyd", "doloribus", 3, 3, 126.31452210258149, "Eagle", 8 },
                    { 33, 2, new TimeSpan(186247866723), new TimeSpan(543820685846), 8, 5, 14, new TimeSpan(65300212895), "Kacey", "et", 1, 5, 244.03192208913978, "Cobra", 4 },
                    { 34, 1, new TimeSpan(175252969422), new TimeSpan(320757952344), 5, 3, 6, new TimeSpan(43016414103), "Raoul", "eveniet", 1, 4, 51.282438211561768, "Elephant", 1 },
                    { 35, 1, new TimeSpan(81568062641), new TimeSpan(417909047382), 5, 3, 5, new TimeSpan(37286821155), "Veronica", "velit", 2, 5, 368.72069285413545, "Lion", 3 },
                    { 36, 2, new TimeSpan(173014615829), new TimeSpan(784968044652), 10, 4, 20, new TimeSpan(66494871645), "Neha", "deleniti", 2, 3, 436.88073782486828, "Giraffe", 7 },
                    { 37, 2, new TimeSpan(92290680294), new TimeSpan(522631708894), 6, 2, 6, new TimeSpan(5717250249), "Everette", "voluptas", 1, 1, 35.719409087700683, "Tiger", 1 },
                    { 38, 3, new TimeSpan(94567393191), new TimeSpan(350818464663), 4, 3, 16, new TimeSpan(33840276266), "Verner", "consequuntur", 3, 1, 371.59520378102928, "Lion", 10 },
                    { 39, 3, new TimeSpan(201977096799), new TimeSpan(291685372864), 8, 3, 4, new TimeSpan(68023053884), "Roselyn", "harum", 3, 2, 496.74224711467923, "Tiger", 7 },
                    { 40, 1, new TimeSpan(108978151391), new TimeSpan(151455119141), 2, 2, 1, new TimeSpan(30434117702), "Rosie", "optio", 1, 3, 324.7553732256186, "Eagle", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_CategoryId",
                table: "Animal",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_EnclosureId",
                table: "Animal",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ZooId",
                table: "Animal",
                column: "ZooId");

            migrationBuilder.CreateIndex(
                name: "IX_Enclosure_ZooId",
                table: "Enclosure",
                column: "ZooId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Enclosure");

            migrationBuilder.DropTable(
                name: "Zoo");
        }
    }
}
