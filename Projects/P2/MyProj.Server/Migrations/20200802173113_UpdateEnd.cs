using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProj.Server.Migrations
{
    public partial class UpdateEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booklets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    College = table.Column<string>(nullable: true),
                    Lesson = table.Column<string>(nullable: true),
                    Professor = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booklets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    College = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BehaviorRate = table.Column<int>(nullable: false),
                    TeachingRate = table.Column<int>(nullable: false),
                    ScoreRate = table.Column<int>(nullable: false),
                    AttendanceRate = table.Column<int>(nullable: false),
                    ExamRate = table.Column<int>(nullable: false),
                    VoteNum = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    College = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 1L, "مهندسی کامپیوتر", "گسسته", "Nadjafikhah - Calculus II - Persian.pdf", "وصال حکمی" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 2L, "مهندسی کامپیوتر", "گسسته", "Nadjafikhah - Calculus II - Persian.pdf", "رضا انتظاری ملکی" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 3L, "مهندسی کامپیوتر", "مبانی کامپیوتر", "Nadjafikhah - Calculus II - Persian.pdf", "صالح اعتمادی" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 4L, "مهندسی کامپیوتر", "مبانی کامپیوتر", "Nadjafikhah - Calculus II - Persian.pdf", "مرضیه ملکی مجد" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 5L, "مهندسی کامپیوتر", "طراحی بازیهای کامپیوتری", "Nadjafikhah - Calculus II - Persian.pdf", "زینب موحدی" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 6L, "مهندسی کامپیوتر", "برنامه نویسی پیشرفته", "Nadjafikhah - Calculus II - Persian.pdf", "صالح اعتمادی" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 7L, "مهندسی کامپیوتر", "برنامه نویسی پیشرفته", "Nadjafikhah - Calculus II - Persian.pdf", "مرضیه ملکی مجد" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 8L, "ریاضی", "ریاضی2", "Nadjafikhah - Calculus II - Persian.pdf", "سمانه مشهدی" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 9L, "ریاضی", "ریاضی2", "Nadjafikhah - Calculus II - Persian.pdf", "مهدی نجفی خواه" });

            migrationBuilder.InsertData(
                table: "Booklets",
                columns: new[] { "Id", "College", "Lesson", "Link", "Professor" },
                values: new object[] { 10L, "ریاضی", "ریاضی2", "Nadjafikhah - Calculus II - Persian.pdf", "محمد یعقوبی فر" });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 17L, 0, 0, "معماری و شهرسازی", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 18L, 0, 0, "مهندسی پیشرفت", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 19L, 0, 0, "مهندسی خودرو", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 20L, 0, 0, "مهندسی راه آهن", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 21L, 0, 0, "مهندسی شیمی", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 26L, 0, 0, "فیزیک", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 23L, 0, 0, "مهندسی مکانیک", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 24L, 0, 0, "مهندسی مواد و متالوژی", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 25L, 0, 0, "ریاضی", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 16L, 0, 0, "معماری و شهرسازی", 0, "اصغر محمدمرادی", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 27L, 0, 0, "زبان", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 22L, 0, 0, "مهندسی عمران", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 15L, 0, 0, "معماری و شهرسازی", 0, "محسن فیضی", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 10L, 0, 0, "مهندسی برق", 0, "کریم محمدی", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 13L, 0, 0, "مهندسی برق", 0, "یاوند حسنی", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 12L, 0, 0, "مهندسی برق", 0, "موسوی میرکلایی", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 11L, 0, 0, "مهندسی برق", 0, "محمدنژاد", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 28L, 0, 0, "تربیت بدنی", 0, "محسن وفامهر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 9L, 0, 0, "مهندسی صنایع", 0, "مهدی حیدری", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 8L, 0, 0, "مهندسی صنایع", 0, "محمد سعیدی مهرآباد", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 7L, 0, 0, "مهندسی صنایع", 0, "رسول نورالنساء", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 6L, 0, 0, "مهندسی صنایع", 0, "فرناز برزین پور", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 5L, 0, 0, "مهندسی کامپیوتر", 0, "صالح اعتمادی", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 4L, 0, 0, "مهندسی کامپیوتر", 0, "مرضیه ملکی مجد", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 3L, 0, 0, "مهندسی کامپیوتر", 0, "سعید پارسا", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 2L, 0, 0, "مهندسی کامپیوتر", 0, "رضا انتظاری", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 1L, 0, 0, "مهندسی کامپیوتر", 0, "مهرداد آشتیانی", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 14L, 0, 0, "معماری و شهرسازی", 0, "مصطفی بهزادفر", 0, 0, 0L });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "AttendanceRate", "BehaviorRate", "College", "ExamRate", "Name", "ScoreRate", "TeachingRate", "VoteNum" },
                values: new object[] { 29L, 0, 0, "معارف", 0, "محسن وفامهر", 0, 0, 0L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booklets");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
