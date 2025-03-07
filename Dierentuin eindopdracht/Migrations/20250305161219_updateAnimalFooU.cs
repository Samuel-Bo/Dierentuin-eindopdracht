using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dierentuin_eindopdracht.Migrations
{
    /// <inheritdoc />
    public partial class updateAnimalFooU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FeedingTime",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "FeedingTime",
                value: "Kip");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "FeedingTime",
                value: "Appel");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "FeedingTime",
                value: "Tomaat");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4,
                column: "FeedingTime",
                value: "Ei");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5,
                column: "FeedingTime",
                value: "Kip");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6,
                column: "FeedingTime",
                value: "Pasta");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7,
                column: "FeedingTime",
                value: "Pasta");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 8,
                column: "FeedingTime",
                value: "Kip");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 9,
                column: "FeedingTime",
                value: "Rijst");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 10,
                column: "FeedingTime",
                value: "Tomaat");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 11,
                column: "FeedingTime",
                value: "Ei");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 12,
                column: "FeedingTime",
                value: "Melk");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 13,
                column: "FeedingTime",
                value: "Kip");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 14,
                column: "FeedingTime",
                value: "Appel");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 15,
                column: "FeedingTime",
                value: "Broccoli");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 16,
                column: "FeedingTime",
                value: "Appel");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 17,
                column: "FeedingTime",
                value: "Tomaat");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 18,
                column: "FeedingTime",
                value: "Banaan");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 19,
                column: "FeedingTime",
                value: "Zalm");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 20,
                column: "FeedingTime",
                value: "Banaan");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 21,
                column: "FeedingTime",
                value: "Banaan");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 22,
                column: "FeedingTime",
                value: "Ei");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 23,
                column: "FeedingTime",
                value: "Pasta");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 24,
                column: "FeedingTime",
                value: "Broccoli");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 25,
                column: "FeedingTime",
                value: "Appel");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 26,
                column: "FeedingTime",
                value: "Rijst");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 27,
                column: "FeedingTime",
                value: "Broccoli");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 28,
                column: "FeedingTime",
                value: "Melk");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 29,
                column: "FeedingTime",
                value: "Melk");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 30,
                column: "FeedingTime",
                value: "Pasta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FeedingTime",
                table: "Animals",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "FeedingTime",
                value: new TimeSpan(24439393770));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "FeedingTime",
                value: new TimeSpan(5365199963));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "FeedingTime",
                value: new TimeSpan(54176958229));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4,
                column: "FeedingTime",
                value: new TimeSpan(66083643802));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5,
                column: "FeedingTime",
                value: new TimeSpan(25330644821));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6,
                column: "FeedingTime",
                value: new TimeSpan(36385736341));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7,
                column: "FeedingTime",
                value: new TimeSpan(41974582345));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 8,
                column: "FeedingTime",
                value: new TimeSpan(22879923552));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 9,
                column: "FeedingTime",
                value: new TimeSpan(43451053517));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 10,
                column: "FeedingTime",
                value: new TimeSpan(51812972525));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 11,
                column: "FeedingTime",
                value: new TimeSpan(70624234612));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 12,
                column: "FeedingTime",
                value: new TimeSpan(62611278876));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 13,
                column: "FeedingTime",
                value: new TimeSpan(25083270684));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 14,
                column: "FeedingTime",
                value: new TimeSpan(3653405251));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 15,
                column: "FeedingTime",
                value: new TimeSpan(19979382051));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 16,
                column: "FeedingTime",
                value: new TimeSpan(3619670270));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 17,
                column: "FeedingTime",
                value: new TimeSpan(57129796535));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 18,
                column: "FeedingTime",
                value: new TimeSpan(9242950943));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 19,
                column: "FeedingTime",
                value: new TimeSpan(31555508833));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 20,
                column: "FeedingTime",
                value: new TimeSpan(14361095182));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 21,
                column: "FeedingTime",
                value: new TimeSpan(10821104356));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 22,
                column: "FeedingTime",
                value: new TimeSpan(69495288211));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 23,
                column: "FeedingTime",
                value: new TimeSpan(42345596158));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 24,
                column: "FeedingTime",
                value: new TimeSpan(19631051881));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 25,
                column: "FeedingTime",
                value: new TimeSpan(6309776615));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 26,
                column: "FeedingTime",
                value: new TimeSpan(45376925020));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 27,
                column: "FeedingTime",
                value: new TimeSpan(19547945613));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 28,
                column: "FeedingTime",
                value: new TimeSpan(61647658440));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 29,
                column: "FeedingTime",
                value: new TimeSpan(62727033797));

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 30,
                column: "FeedingTime",
                value: new TimeSpan(36771497375));
        }
    }
}
