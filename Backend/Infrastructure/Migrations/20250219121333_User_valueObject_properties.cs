using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class User_valueObject_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserVerification_VerifyTries",
                table: "Users",
                newName: "VerifyTries");

            migrationBuilder.RenameColumn(
                name: "UserVerification_VerifyTime",
                table: "Users",
                newName: "VerifyTime");

            migrationBuilder.RenameColumn(
                name: "UserVerification_VerifyCode",
                table: "Users",
                newName: "VerifyCode");

            migrationBuilder.RenameColumn(
                name: "UserVerification_IsActive",
                table: "Users",
                newName: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerifyTries",
                table: "Users",
                newName: "UserVerification_VerifyTries");

            migrationBuilder.RenameColumn(
                name: "VerifyTime",
                table: "Users",
                newName: "UserVerification_VerifyTime");

            migrationBuilder.RenameColumn(
                name: "VerifyCode",
                table: "Users",
                newName: "UserVerification_VerifyCode");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "UserVerification_IsActive");
        }
    }
}
