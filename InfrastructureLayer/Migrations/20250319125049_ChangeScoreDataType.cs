using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeScoreDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_AspNetUsers_IdentityUserId",
                table: "UserExams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.RenameTable(
                name: "UserExams",
                newName: "UserExamResults");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_IdentityUserId",
                table: "UserExamResults",
                newName: "IX_UserExamResults_IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_ExamId",
                table: "UserExamResults",
                newName: "IX_UserExamResults_ExamId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "UserExamResults",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExamResults",
                table: "UserExamResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExamResults_AspNetUsers_IdentityUserId",
                table: "UserExamResults",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExamResults_Exams_ExamId",
                table: "UserExamResults",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExamResults_AspNetUsers_IdentityUserId",
                table: "UserExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExamResults_Exams_ExamId",
                table: "UserExamResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExamResults",
                table: "UserExamResults");

            migrationBuilder.RenameTable(
                name: "UserExamResults",
                newName: "UserExams");

            migrationBuilder.RenameIndex(
                name: "IX_UserExamResults_IdentityUserId",
                table: "UserExams",
                newName: "IX_UserExams_IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExamResults_ExamId",
                table: "UserExams",
                newName: "IX_UserExams_ExamId");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "UserExams",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_AspNetUsers_IdentityUserId",
                table: "UserExams",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
