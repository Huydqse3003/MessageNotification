﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.ChatRoom", b =>
                {
                    b.Property<int>("ChatRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChatRoomId"));

                    b.Property<string>("ChatRoomName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ChatRoomId");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("Domain.Entities.ChatRoomUser", b =>
                {
                    b.Property<int>("RoomUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoomUserId"));

                    b.Property<int>("ChatRoomId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("RoomUserId");

                    b.HasIndex("ChatRoomId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatRoomsUsers");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MessageId"));

                    b.Property<int>("ChatRoomId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.Entities.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<int>("MessageId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("NotificationId");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsEmailVerified")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastOnline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedDate = new DateTime(2025, 4, 15, 9, 28, 22, 57, DateTimeKind.Utc).AddTicks(6506),
                            Email = "User1@gmail.com",
                            IsDeleted = false,
                            IsEmailVerified = true,
                            IsOnline = false,
                            LastName = "User1",
                            PasswordHash = new byte[] { 228, 182, 235, 160, 78, 89, 40, 49, 33, 7, 242, 200, 51, 231, 142, 74, 97, 109, 250, 70, 180, 16, 113, 111, 34, 165, 234, 132, 76, 73, 0, 247, 183, 52, 117, 187, 52, 228, 104, 152, 116, 110, 121, 84, 118, 15, 58, 129, 195, 124, 120, 181, 54, 173, 199, 166, 161, 136, 189, 146, 183, 224, 137, 135 },
                            PasswordSalt = new byte[] { 161, 24, 241, 135, 1, 42, 50, 31, 209, 232, 62, 86, 83, 45, 124, 14, 26, 33, 133, 90, 226, 116, 233, 169, 1, 36, 104, 33, 66, 86, 122, 89, 172, 176, 217, 205, 203, 123, 100, 140, 51, 102, 62, 75, 70, 56, 71, 41, 178, 73, 113, 210, 165, 96, 26, 197, 204, 246, 18, 185, 180, 176, 162, 32, 59, 158, 225, 238, 178, 96, 230, 169, 138, 91, 132, 123, 197, 101, 35, 30, 60, 85, 95, 161, 171, 162, 39, 111, 170, 190, 134, 131, 2, 45, 90, 202, 89, 178, 180, 246, 112, 238, 144, 199, 115, 57, 85, 220, 61, 151, 64, 82, 31, 241, 166, 48, 48, 191, 167, 150, 226, 54, 209, 201, 155, 181, 67, 110 },
                            Role = 0
                        },
                        new
                        {
                            UserId = 2,
                            CreatedDate = new DateTime(2025, 4, 15, 9, 28, 22, 57, DateTimeKind.Utc).AddTicks(6514),
                            Email = "User2@gmail.com",
                            IsDeleted = false,
                            IsEmailVerified = true,
                            IsOnline = false,
                            LastName = "User2",
                            PasswordHash = new byte[] { 148, 2, 252, 93, 124, 113, 60, 13, 52, 187, 28, 229, 10, 216, 253, 230, 21, 234, 184, 76, 96, 60, 194, 160, 142, 132, 170, 107, 59, 33, 81, 240, 162, 228, 220, 249, 104, 250, 15, 182, 68, 82, 250, 63, 178, 159, 243, 161, 110, 198, 7, 244, 14, 197, 249, 197, 192, 140, 137, 218, 149, 92, 177, 208 },
                            PasswordSalt = new byte[] { 83, 204, 234, 62, 122, 48, 45, 220, 74, 216, 20, 66, 40, 220, 90, 1, 234, 36, 87, 76, 108, 150, 61, 244, 225, 134, 87, 106, 228, 71, 94, 81, 30, 7, 69, 250, 181, 245, 226, 177, 33, 122, 11, 100, 104, 50, 77, 179, 65, 22, 86, 255, 172, 108, 47, 253, 51, 222, 22, 204, 133, 1, 127, 232, 97, 4, 32, 182, 83, 254, 144, 217, 229, 109, 160, 175, 69, 127, 168, 88, 219, 232, 170, 62, 114, 45, 99, 190, 95, 101, 219, 60, 132, 167, 127, 118, 32, 121, 33, 80, 207, 247, 153, 5, 26, 170, 123, 250, 167, 1, 151, 114, 247, 123, 239, 31, 63, 129, 42, 103, 79, 143, 133, 161, 37, 9, 235, 251 },
                            Role = 0
                        },
                        new
                        {
                            UserId = 3,
                            CreatedDate = new DateTime(2025, 4, 15, 9, 28, 22, 57, DateTimeKind.Utc).AddTicks(6517),
                            Email = "Employer@gmail.com",
                            IsDeleted = false,
                            IsEmailVerified = true,
                            IsOnline = false,
                            LastName = "Employer",
                            PasswordHash = new byte[] { 168, 196, 146, 218, 192, 121, 202, 216, 201, 70, 2, 134, 12, 5, 29, 205, 102, 5, 98, 214, 217, 133, 23, 188, 134, 140, 41, 234, 49, 202, 142, 0, 227, 222, 235, 253, 10, 145, 26, 12, 225, 170, 177, 160, 253, 83, 118, 59, 114, 97, 25, 180, 171, 175, 74, 35, 135, 11, 83, 218, 197, 45, 91, 88 },
                            PasswordSalt = new byte[] { 193, 65, 83, 15, 38, 28, 220, 52, 183, 59, 83, 211, 177, 114, 19, 236, 58, 81, 38, 49, 11, 42, 153, 109, 76, 252, 86, 57, 166, 34, 113, 152, 207, 133, 227, 194, 160, 206, 243, 245, 178, 209, 208, 4, 139, 246, 21, 112, 104, 203, 91, 212, 105, 0, 138, 106, 146, 166, 39, 156, 35, 139, 145, 107, 228, 140, 232, 159, 128, 232, 192, 53, 207, 179, 97, 190, 0, 229, 60, 20, 137, 0, 136, 114, 145, 247, 43, 230, 16, 203, 78, 58, 72, 194, 165, 75, 19, 154, 87, 96, 29, 0, 178, 187, 162, 196, 119, 197, 26, 112, 90, 234, 223, 83, 231, 2, 154, 184, 65, 76, 37, 44, 92, 195, 195, 206, 63, 234 },
                            Role = 0
                        },
                        new
                        {
                            UserId = 4,
                            CreatedDate = new DateTime(2025, 4, 15, 9, 28, 22, 57, DateTimeKind.Utc).AddTicks(6519),
                            Email = "Admin@gmail.com",
                            IsDeleted = false,
                            IsEmailVerified = true,
                            IsOnline = false,
                            LastName = "Admin",
                            PasswordHash = new byte[] { 106, 103, 163, 71, 210, 14, 197, 50, 39, 86, 16, 253, 9, 115, 239, 42, 226, 215, 239, 61, 162, 91, 162, 27, 239, 208, 76, 125, 158, 236, 25, 67, 96, 22, 130, 189, 131, 28, 213, 253, 24, 67, 61, 165, 84, 81, 65, 90, 218, 63, 115, 225, 149, 158, 112, 233, 171, 201, 56, 237, 76, 222, 160, 66 },
                            PasswordSalt = new byte[] { 228, 229, 134, 0, 93, 33, 73, 35, 11, 232, 46, 3, 97, 71, 178, 178, 46, 37, 115, 219, 131, 81, 174, 88, 114, 208, 45, 234, 185, 42, 139, 60, 247, 171, 111, 19, 167, 191, 172, 210, 204, 100, 47, 58, 20, 150, 118, 133, 14, 125, 57, 69, 71, 112, 99, 25, 51, 158, 44, 249, 41, 166, 125, 79, 25, 110, 247, 214, 96, 154, 254, 99, 139, 168, 26, 201, 230, 253, 39, 147, 202, 43, 154, 60, 164, 186, 224, 154, 199, 98, 140, 222, 54, 192, 212, 187, 11, 132, 246, 241, 235, 247, 140, 185, 240, 178, 163, 196, 242, 151, 28, 160, 138, 250, 201, 48, 62, 163, 113, 137, 100, 143, 70, 190, 11, 207, 196, 1 },
                            Role = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.ChatRoomUser", b =>
                {
                    b.HasOne("Domain.Entities.ChatRoom", "ChatRoom")
                        .WithMany("ChatRoomUsers")
                        .HasForeignKey("ChatRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("ChatRoomUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.HasOne("Domain.Entities.ChatRoom", "ChatRoom")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Notification", b =>
                {
                    b.HasOne("Domain.Entities.Message", "Message")
                        .WithOne("Notification")
                        .HasForeignKey("Domain.Entities.Notification", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ChatRoom", b =>
                {
                    b.Navigation("ChatRoomUsers");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.Navigation("Notification")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("ChatRoomUsers");

                    b.Navigation("Messages");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
