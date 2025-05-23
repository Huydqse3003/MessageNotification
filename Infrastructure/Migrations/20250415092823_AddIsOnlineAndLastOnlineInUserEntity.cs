﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsOnlineAndLastOnlineInUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOnline",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsOnline", "LastOnline", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 4, 15, 9, 28, 22, 57, DateTimeKind.Utc).AddTicks(6506), false, null, new byte[] { 228, 182, 235, 160, 78, 89, 40, 49, 33, 7, 242, 200, 51, 231, 142, 74, 97, 109, 250, 70, 180, 16, 113, 111, 34, 165, 234, 132, 76, 73, 0, 247, 183, 52, 117, 187, 52, 228, 104, 152, 116, 110, 121, 84, 118, 15, 58, 129, 195, 124, 120, 181, 54, 173, 199, 166, 161, 136, 189, 146, 183, 224, 137, 135 }, new byte[] { 161, 24, 241, 135, 1, 42, 50, 31, 209, 232, 62, 86, 83, 45, 124, 14, 26, 33, 133, 90, 226, 116, 233, 169, 1, 36, 104, 33, 66, 86, 122, 89, 172, 176, 217, 205, 203, 123, 100, 140, 51, 102, 62, 75, 70, 56, 71, 41, 178, 73, 113, 210, 165, 96, 26, 197, 204, 246, 18, 185, 180, 176, 162, 32, 59, 158, 225, 238, 178, 96, 230, 169, 138, 91, 132, 123, 197, 101, 35, 30, 60, 85, 95, 161, 171, 162, 39, 111, 170, 190, 134, 131, 2, 45, 90, 202, 89, 178, 180, 246, 112, 238, 144, 199, 115, 57, 85, 220, 61, 151, 64, 82, 31, 241, 166, 48, 48, 191, 167, 150, 226, 54, 209, 201, 155, 181, 67, 110 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "IsOnline", "LastOnline", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 4, 15, 9, 28, 22, 57, DateTimeKind.Utc).AddTicks(6514), false, null, new byte[] { 148, 2, 252, 93, 124, 113, 60, 13, 52, 187, 28, 229, 10, 216, 253, 230, 21, 234, 184, 76, 96, 60, 194, 160, 142, 132, 170, 107, 59, 33, 81, 240, 162, 228, 220, 249, 104, 250, 15, 182, 68, 82, 250, 63, 178, 159, 243, 161, 110, 198, 7, 244, 14, 197, 249, 197, 192, 140, 137, 218, 149, 92, 177, 208 }, new byte[] { 83, 204, 234, 62, 122, 48, 45, 220, 74, 216, 20, 66, 40, 220, 90, 1, 234, 36, 87, 76, 108, 150, 61, 244, 225, 134, 87, 106, 228, 71, 94, 81, 30, 7, 69, 250, 181, 245, 226, 177, 33, 122, 11, 100, 104, 50, 77, 179, 65, 22, 86, 255, 172, 108, 47, 253, 51, 222, 22, 204, 133, 1, 127, 232, 97, 4, 32, 182, 83, 254, 144, 217, 229, 109, 160, 175, 69, 127, 168, 88, 219, 232, 170, 62, 114, 45, 99, 190, 95, 101, 219, 60, 132, 167, 127, 118, 32, 121, 33, 80, 207, 247, 153, 5, 26, 170, 123, 250, 167, 1, 151, 114, 247, 123, 239, 31, 63, 129, 42, 103, 79, 143, 133, 161, 37, 9, 235, 251 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "IsOnline", "LastOnline", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 4, 15, 9, 28, 22, 57, DateTimeKind.Utc).AddTicks(6517), false, null, new byte[] { 168, 196, 146, 218, 192, 121, 202, 216, 201, 70, 2, 134, 12, 5, 29, 205, 102, 5, 98, 214, 217, 133, 23, 188, 134, 140, 41, 234, 49, 202, 142, 0, 227, 222, 235, 253, 10, 145, 26, 12, 225, 170, 177, 160, 253, 83, 118, 59, 114, 97, 25, 180, 171, 175, 74, 35, 135, 11, 83, 218, 197, 45, 91, 88 }, new byte[] { 193, 65, 83, 15, 38, 28, 220, 52, 183, 59, 83, 211, 177, 114, 19, 236, 58, 81, 38, 49, 11, 42, 153, 109, 76, 252, 86, 57, 166, 34, 113, 152, 207, 133, 227, 194, 160, 206, 243, 245, 178, 209, 208, 4, 139, 246, 21, 112, 104, 203, 91, 212, 105, 0, 138, 106, 146, 166, 39, 156, 35, 139, 145, 107, 228, 140, 232, 159, 128, 232, 192, 53, 207, 179, 97, 190, 0, 229, 60, 20, 137, 0, 136, 114, 145, 247, 43, 230, 16, 203, 78, 58, 72, 194, 165, 75, 19, 154, 87, 96, 29, 0, 178, 187, 162, 196, 119, 197, 26, 112, 90, 234, 223, 83, 231, 2, 154, 184, 65, 76, 37, 44, 92, 195, 195, 206, 63, 234 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "IsOnline", "LastOnline", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 4, 15, 9, 28, 22, 57, DateTimeKind.Utc).AddTicks(6519), false, null, new byte[] { 106, 103, 163, 71, 210, 14, 197, 50, 39, 86, 16, 253, 9, 115, 239, 42, 226, 215, 239, 61, 162, 91, 162, 27, 239, 208, 76, 125, 158, 236, 25, 67, 96, 22, 130, 189, 131, 28, 213, 253, 24, 67, 61, 165, 84, 81, 65, 90, 218, 63, 115, 225, 149, 158, 112, 233, 171, 201, 56, 237, 76, 222, 160, 66 }, new byte[] { 228, 229, 134, 0, 93, 33, 73, 35, 11, 232, 46, 3, 97, 71, 178, 178, 46, 37, 115, 219, 131, 81, 174, 88, 114, 208, 45, 234, 185, 42, 139, 60, 247, 171, 111, 19, 167, 191, 172, 210, 204, 100, 47, 58, 20, 150, 118, 133, 14, 125, 57, 69, 71, 112, 99, 25, 51, 158, 44, 249, 41, 166, 125, 79, 25, 110, 247, 214, 96, 154, 254, 99, 139, 168, 26, 201, 230, 253, 39, 147, 202, 43, 154, 60, 164, 186, 224, 154, 199, 98, 140, 222, 54, 192, 212, 187, 11, 132, 246, 241, 235, 247, 140, 185, 240, 178, 163, 196, 242, 151, 28, 160, 138, 250, 201, 48, 62, 163, 113, 137, 100, 143, 70, 190, 11, 207, 196, 1 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastOnline",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 53, 41, 629, DateTimeKind.Utc).AddTicks(6201), new byte[] { 44, 168, 89, 139, 28, 90, 35, 60, 165, 11, 224, 169, 59, 188, 208, 195, 16, 141, 21, 37, 204, 207, 175, 242, 131, 72, 138, 226, 255, 14, 233, 175, 138, 67, 46, 209, 186, 179, 34, 227, 9, 68, 109, 151, 75, 59, 165, 239, 225, 17, 133, 156, 107, 14, 188, 146, 117, 53, 89, 74, 205, 85, 101, 45 }, new byte[] { 157, 63, 196, 198, 33, 49, 5, 193, 234, 190, 30, 255, 10, 118, 191, 161, 130, 231, 230, 133, 191, 213, 186, 143, 38, 197, 12, 37, 189, 72, 207, 143, 177, 220, 243, 241, 238, 218, 214, 44, 127, 204, 204, 150, 126, 132, 59, 157, 4, 90, 239, 206, 70, 10, 194, 245, 65, 237, 211, 42, 210, 144, 50, 109, 174, 144, 236, 87, 185, 248, 231, 232, 161, 56, 227, 181, 36, 117, 135, 7, 237, 120, 142, 252, 158, 27, 253, 144, 109, 98, 63, 199, 51, 187, 149, 161, 215, 106, 122, 185, 232, 128, 38, 199, 140, 62, 115, 67, 193, 109, 182, 84, 77, 104, 66, 219, 162, 31, 229, 184, 227, 20, 239, 115, 231, 35, 91, 214 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 53, 41, 629, DateTimeKind.Utc).AddTicks(6210), new byte[] { 78, 119, 145, 35, 138, 55, 254, 126, 111, 190, 148, 34, 88, 30, 174, 216, 31, 47, 150, 41, 9, 207, 157, 24, 91, 152, 203, 152, 140, 176, 68, 100, 30, 255, 164, 192, 171, 70, 127, 201, 186, 191, 30, 99, 162, 14, 202, 132, 164, 111, 10, 16, 129, 200, 95, 160, 171, 189, 182, 111, 86, 75, 59, 24 }, new byte[] { 17, 192, 40, 26, 222, 233, 210, 149, 106, 191, 249, 86, 45, 0, 170, 252, 139, 117, 187, 126, 78, 242, 144, 167, 41, 226, 109, 60, 21, 91, 93, 211, 9, 195, 39, 208, 202, 44, 203, 221, 89, 76, 202, 162, 106, 81, 96, 31, 56, 2, 223, 163, 19, 53, 122, 172, 79, 81, 4, 177, 67, 222, 213, 8, 167, 48, 231, 127, 158, 186, 239, 82, 111, 8, 93, 190, 143, 237, 240, 240, 167, 96, 117, 209, 100, 250, 143, 161, 33, 147, 206, 18, 5, 160, 148, 88, 169, 147, 88, 180, 103, 215, 242, 123, 17, 178, 176, 197, 148, 133, 201, 251, 48, 75, 242, 233, 238, 139, 79, 51, 106, 129, 249, 234, 189, 83, 191, 100 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 53, 41, 629, DateTimeKind.Utc).AddTicks(6213), new byte[] { 89, 106, 80, 118, 186, 129, 55, 53, 214, 174, 133, 7, 170, 62, 22, 15, 147, 24, 69, 39, 161, 246, 235, 217, 205, 89, 145, 19, 237, 237, 40, 40, 115, 56, 220, 86, 22, 144, 22, 101, 93, 55, 38, 90, 74, 7, 98, 102, 19, 165, 125, 147, 228, 126, 83, 64, 66, 22, 247, 137, 130, 17, 201, 46 }, new byte[] { 54, 252, 168, 203, 152, 49, 238, 30, 113, 184, 127, 128, 107, 0, 235, 176, 41, 34, 61, 50, 162, 204, 217, 245, 76, 7, 33, 120, 14, 76, 126, 80, 151, 140, 76, 126, 87, 225, 145, 140, 241, 194, 160, 9, 45, 215, 29, 68, 230, 79, 239, 103, 17, 230, 93, 27, 29, 109, 144, 202, 104, 207, 6, 43, 187, 97, 20, 54, 84, 62, 195, 158, 182, 54, 74, 106, 135, 51, 50, 56, 80, 186, 223, 93, 8, 185, 75, 233, 47, 179, 9, 122, 85, 119, 236, 73, 162, 139, 37, 22, 245, 6, 103, 42, 165, 103, 91, 103, 95, 125, 228, 155, 111, 6, 81, 19, 57, 237, 36, 149, 53, 64, 43, 176, 20, 86, 216, 56 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 53, 41, 629, DateTimeKind.Utc).AddTicks(6215), new byte[] { 185, 221, 235, 127, 188, 74, 38, 182, 113, 146, 219, 53, 240, 198, 159, 191, 90, 43, 130, 103, 153, 3, 170, 134, 33, 167, 234, 163, 113, 242, 119, 98, 57, 125, 209, 178, 233, 183, 160, 142, 74, 228, 225, 23, 86, 8, 135, 158, 91, 195, 222, 30, 25, 13, 206, 61, 215, 163, 234, 118, 145, 204, 226, 0 }, new byte[] { 134, 86, 153, 163, 99, 230, 71, 33, 235, 54, 128, 78, 251, 91, 127, 41, 26, 59, 81, 119, 40, 186, 173, 181, 56, 210, 233, 195, 178, 141, 54, 221, 97, 70, 75, 234, 1, 190, 114, 88, 239, 16, 43, 99, 225, 91, 181, 144, 255, 176, 216, 208, 106, 2, 166, 246, 89, 164, 244, 190, 255, 167, 30, 184, 247, 196, 33, 146, 2, 82, 55, 0, 142, 111, 89, 26, 36, 48, 228, 62, 131, 79, 62, 75, 87, 136, 147, 22, 219, 129, 126, 68, 229, 175, 166, 141, 141, 146, 63, 29, 133, 137, 80, 199, 220, 205, 15, 95, 80, 255, 83, 204, 247, 170, 89, 133, 200, 247, 234, 82, 254, 242, 162, 54, 228, 36, 146, 73 } });
        }
    }
}
