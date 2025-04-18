using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    ChatRoomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatRoomName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.ChatRoomId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "boolean", nullable: true),
                    ImgUrl = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoomsUsers",
                columns: table => new
                {
                    RoomUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatRoomId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomsUsers", x => x.RoomUserId);
                    table.ForeignKey(
                        name: "FK_ChatRoomsUsers_ChatRooms_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "ChatRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRoomsUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ChatRoomId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_ChatRooms_UserId",
                        column: x => x.UserId,
                        principalTable: "ChatRooms",
                        principalColumn: "ChatRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MessageId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "Email", "FirstName", "ImgUrl", "IsDeleted", "IsEmailVerified", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 4, 12, 17, 53, 41, 629, DateTimeKind.Utc).AddTicks(6201), "User1@gmail.com", null, null, false, true, "User1", null, null, new byte[] { 44, 168, 89, 139, 28, 90, 35, 60, 165, 11, 224, 169, 59, 188, 208, 195, 16, 141, 21, 37, 204, 207, 175, 242, 131, 72, 138, 226, 255, 14, 233, 175, 138, 67, 46, 209, 186, 179, 34, 227, 9, 68, 109, 151, 75, 59, 165, 239, 225, 17, 133, 156, 107, 14, 188, 146, 117, 53, 89, 74, 205, 85, 101, 45 }, new byte[] { 157, 63, 196, 198, 33, 49, 5, 193, 234, 190, 30, 255, 10, 118, 191, 161, 130, 231, 230, 133, 191, 213, 186, 143, 38, 197, 12, 37, 189, 72, 207, 143, 177, 220, 243, 241, 238, 218, 214, 44, 127, 204, 204, 150, 126, 132, 59, 157, 4, 90, 239, 206, 70, 10, 194, 245, 65, 237, 211, 42, 210, 144, 50, 109, 174, 144, 236, 87, 185, 248, 231, 232, 161, 56, 227, 181, 36, 117, 135, 7, 237, 120, 142, 252, 158, 27, 253, 144, 109, 98, 63, 199, 51, 187, 149, 161, 215, 106, 122, 185, 232, 128, 38, 199, 140, 62, 115, 67, 193, 109, 182, 84, 77, 104, 66, 219, 162, 31, 229, 184, 227, 20, 239, 115, 231, 35, 91, 214 }, null, 0 },
                    { 2, null, new DateTime(2025, 4, 12, 17, 53, 41, 629, DateTimeKind.Utc).AddTicks(6210), "User2@gmail.com", null, null, false, true, "User2", null, null, new byte[] { 78, 119, 145, 35, 138, 55, 254, 126, 111, 190, 148, 34, 88, 30, 174, 216, 31, 47, 150, 41, 9, 207, 157, 24, 91, 152, 203, 152, 140, 176, 68, 100, 30, 255, 164, 192, 171, 70, 127, 201, 186, 191, 30, 99, 162, 14, 202, 132, 164, 111, 10, 16, 129, 200, 95, 160, 171, 189, 182, 111, 86, 75, 59, 24 }, new byte[] { 17, 192, 40, 26, 222, 233, 210, 149, 106, 191, 249, 86, 45, 0, 170, 252, 139, 117, 187, 126, 78, 242, 144, 167, 41, 226, 109, 60, 21, 91, 93, 211, 9, 195, 39, 208, 202, 44, 203, 221, 89, 76, 202, 162, 106, 81, 96, 31, 56, 2, 223, 163, 19, 53, 122, 172, 79, 81, 4, 177, 67, 222, 213, 8, 167, 48, 231, 127, 158, 186, 239, 82, 111, 8, 93, 190, 143, 237, 240, 240, 167, 96, 117, 209, 100, 250, 143, 161, 33, 147, 206, 18, 5, 160, 148, 88, 169, 147, 88, 180, 103, 215, 242, 123, 17, 178, 176, 197, 148, 133, 201, 251, 48, 75, 242, 233, 238, 139, 79, 51, 106, 129, 249, 234, 189, 83, 191, 100 }, null, 0 },
                    { 3, null, new DateTime(2025, 4, 12, 17, 53, 41, 629, DateTimeKind.Utc).AddTicks(6213), "Employer@gmail.com", null, null, false, true, "Employer", null, null, new byte[] { 89, 106, 80, 118, 186, 129, 55, 53, 214, 174, 133, 7, 170, 62, 22, 15, 147, 24, 69, 39, 161, 246, 235, 217, 205, 89, 145, 19, 237, 237, 40, 40, 115, 56, 220, 86, 22, 144, 22, 101, 93, 55, 38, 90, 74, 7, 98, 102, 19, 165, 125, 147, 228, 126, 83, 64, 66, 22, 247, 137, 130, 17, 201, 46 }, new byte[] { 54, 252, 168, 203, 152, 49, 238, 30, 113, 184, 127, 128, 107, 0, 235, 176, 41, 34, 61, 50, 162, 204, 217, 245, 76, 7, 33, 120, 14, 76, 126, 80, 151, 140, 76, 126, 87, 225, 145, 140, 241, 194, 160, 9, 45, 215, 29, 68, 230, 79, 239, 103, 17, 230, 93, 27, 29, 109, 144, 202, 104, 207, 6, 43, 187, 97, 20, 54, 84, 62, 195, 158, 182, 54, 74, 106, 135, 51, 50, 56, 80, 186, 223, 93, 8, 185, 75, 233, 47, 179, 9, 122, 85, 119, 236, 73, 162, 139, 37, 22, 245, 6, 103, 42, 165, 103, 91, 103, 95, 125, 228, 155, 111, 6, 81, 19, 57, 237, 36, 149, 53, 64, 43, 176, 20, 86, 216, 56 }, null, 0 },
                    { 4, null, new DateTime(2025, 4, 12, 17, 53, 41, 629, DateTimeKind.Utc).AddTicks(6215), "Admin@gmail.com", null, null, false, true, "Admin", null, null, new byte[] { 185, 221, 235, 127, 188, 74, 38, 182, 113, 146, 219, 53, 240, 198, 159, 191, 90, 43, 130, 103, 153, 3, 170, 134, 33, 167, 234, 163, 113, 242, 119, 98, 57, 125, 209, 178, 233, 183, 160, 142, 74, 228, 225, 23, 86, 8, 135, 158, 91, 195, 222, 30, 25, 13, 206, 61, 215, 163, 234, 118, 145, 204, 226, 0 }, new byte[] { 134, 86, 153, 163, 99, 230, 71, 33, 235, 54, 128, 78, 251, 91, 127, 41, 26, 59, 81, 119, 40, 186, 173, 181, 56, 210, 233, 195, 178, 141, 54, 221, 97, 70, 75, 234, 1, 190, 114, 88, 239, 16, 43, 99, 225, 91, 181, 144, 255, 176, 216, 208, 106, 2, 166, 246, 89, 164, 244, 190, 255, 167, 30, 184, 247, 196, 33, 146, 2, 82, 55, 0, 142, 111, 89, 26, 36, 48, 228, 62, 131, 79, 62, 75, 87, 136, 147, 22, 219, 129, 126, 68, 229, 175, 166, 141, 141, 146, 63, 29, 133, 137, 80, 199, 220, 205, 15, 95, 80, 255, 83, 204, 247, 170, 89, 133, 200, 247, 234, 82, 254, 242, 162, 54, 228, 36, 146, 73 }, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomsUsers_ChatRoomId",
                table: "ChatRoomsUsers",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomsUsers_UserId",
                table: "ChatRoomsUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_MessageId",
                table: "Notifications",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRoomsUsers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
