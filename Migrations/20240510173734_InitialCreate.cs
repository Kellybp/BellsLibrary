﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BellsLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PgCount = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Loans_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "AccountType", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 21, "librarian", "Jimmy", "Bradtke", "Ex quaerat itaque.", "Nathan.OConnell" },
                    { 22, "librarian", "Kara", "Lehner", "Eos dolor beatae.", "Hilton79" },
                    { 23, "admin", "Else", "Dicki", "Aut quae recusandae.", "Everett_Hagenes54" },
                    { 24, "librarian", "Sigrid", "Windler", "Aut odio quasi.", "Anibal.Kunze" },
                    { 25, "customer", "Ricky", "Hilpert", "Itaque minus sunt.", "Nikolas_Lemke16" },
                    { 26, "admin", "Carmel", "Walter", "Nemo et sed.", "Mario77" },
                    { 27, "customer", "Rickey", "Auer", "Aut voluptas iure.", "Nolan93" },
                    { 28, "librarian", "Ashlee", "Schmidt", "Doloremque dolores fugiat.", "Guy.Beatty25" },
                    { 29, "customer", "Litzy", "Walker", "Quam hic minus.", "Derrick_Sanford50" },
                    { 30, "admin", "Samara", "Larkin", "Fugiat placeat et.", "Keshaun82" },
                    { 31, "librarian", "Maximillian", "Mante", "Dolorem ea facere.", "Fae_Johnston32" },
                    { 32, "customer", "Marlen", "Wilkinson", "Rerum nam et.", "Jesus69" },
                    { 33, "customer", "Brad", "Dach", "Eum et ea.", "Rey13" },
                    { 34, "admin", "Nick", "Kovacek", "Porro nihil ab.", "Myriam38" },
                    { 35, "admin", "Narciso", "Mraz", "Nesciunt minus ut.", "Larry.Dickinson" },
                    { 36, "librarian", "Rose", "Effertz", "Sequi dolore vel.", "Cristobal15" },
                    { 37, "admin", "Kyra", "Champlin", "Saepe pariatur voluptates.", "Cade_Hansen8" },
                    { 38, "customer", "Linda", "Ratke", "Ut ut cum.", "Juvenal32" },
                    { 39, "admin", "Travon", "Little", "Sunt et voluptatibus.", "Stacey76" },
                    { 40, "librarian", "Alysa", "Kunde", "Et quia ut.", "Rodrick_Gorczany" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Category", "CoverImage", "Description", "ISBN", "PgCount", "PublicationDate", "Publisher", "Title" },
                values: new object[,]
                {
                    { 21, "Lauriane McClure", "Philosophy", new byte[] { 47, 82, 240, 189, 248, 255, 145, 2, 239, 105, 116, 242, 173, 77, 44, 19, 90, 182, 75, 12, 200, 217, 217, 80, 62, 204, 126, 61, 54, 154, 154, 188, 240, 85, 234, 229, 152, 192, 85, 112, 64, 200, 41, 232, 140, 42, 2, 130, 135, 50, 144, 211, 2, 167, 212, 255, 97, 70, 15, 95, 245, 223, 117, 150, 110, 24, 95, 43, 19, 75, 66, 240, 179, 236, 199, 113, 228, 199, 61, 201, 90, 217, 160, 49, 23, 1, 45, 70, 244, 73, 130, 155, 70, 203, 23, 221, 171, 168, 10, 81, 200, 120, 248, 219, 20, 95, 226, 214, 106, 254, 236, 81, 216, 38, 102, 239, 239, 151, 2, 156, 166, 27, 199, 223, 170, 128, 3, 216, 158, 40, 248, 229, 73, 111, 225, 19, 237, 107, 37, 142, 192, 105 }, "Provident odio harum officia voluptate commodi iusto et hic ut. Qui ullam ut consequuntur. Aliquam dignissimos explicabo assumenda reiciendis corporis. Sed voluptatum ut voluptatem quam quis dolore.", "4432650248093", 682, new DateTime(2021, 11, 7, 8, 20, 19, 297, DateTimeKind.Local).AddTicks(3571), "Ebert - Grimes", "A autem soluta." },
                    { 22, "Pearlie Reichert", "Literary fiction", new byte[] { 171, 220, 253, 74, 236, 241, 141, 27, 148, 127, 142, 201, 55, 49, 110, 13, 192, 66, 75, 19, 28, 231, 236, 56, 224, 8, 104, 11, 84, 236, 39, 98, 150, 33, 61, 180, 231, 145, 189, 53, 97, 0, 164, 97, 144, 242, 214, 249, 145, 163, 88, 82, 104, 136, 78, 6, 221, 14, 127, 184, 143, 156, 116, 83, 177, 46, 243, 0, 228, 83, 123, 129, 201, 79, 93, 62, 44, 237, 148, 12, 95, 5, 147, 122, 205, 148, 7, 117, 69, 4, 35, 106, 172, 109, 208, 74, 187, 102, 130, 17, 64, 235, 77, 119, 231, 5, 120, 41, 10, 118, 14, 245, 154, 62, 14, 29, 3, 135, 13, 190, 104, 34, 49, 110, 186, 49, 99, 252, 187, 189, 239, 49, 72, 158, 24, 1, 224, 230, 235, 49, 105, 114 }, "Nobis minus consequuntur quia quae est error. Unde eveniet facilis sit voluptas reiciendis explicabo soluta dolore fuga. At quo omnis impedit est. Quasi sed dolore. Iure eligendi ducimus consequatur quis eaque omnis autem quia molestias. Eos quas dolores.", "0307295468622", 509, new DateTime(2021, 6, 11, 20, 32, 3, 992, DateTimeKind.Local).AddTicks(5670), "Jakubowski - Buckridge", "Saepe consequuntur cumque." },
                    { 23, "Elza Mraz", "Humor", new byte[] { 36, 150, 193, 206, 174, 147, 43, 76, 147, 159, 226, 175, 55, 158, 232, 195, 45, 203, 237, 117, 149, 91, 109, 131, 59, 210, 61, 7, 41, 28, 53, 246, 244, 8, 154, 74, 229, 237, 203, 62, 225, 115, 113, 199, 29, 62, 244, 90, 15, 152, 200, 40, 20, 13, 227, 194, 60, 39, 203, 169, 181, 35, 252, 75, 174, 136, 146, 234, 221, 141, 26, 162, 17, 153, 87, 124, 215, 209, 151, 159, 2, 124, 229, 98, 120, 121, 179, 238, 214, 134, 46, 182, 85, 51, 12, 237, 146, 62, 61, 199, 37, 41, 146, 94, 72, 146, 94, 17, 232, 103, 79, 129, 254, 221, 247, 225, 81, 175, 181, 43, 238, 142, 167, 23, 148, 58, 182, 6, 242, 196, 129, 144, 123, 26, 121, 181, 117, 144, 252, 210, 169, 234 }, "Quidem ea perspiciatis hic minus aut officia. Voluptatem accusantium enim et et. Accusantium tenetur maxime occaecati consequuntur doloremque. Dolorem totam eius voluptatem voluptas veritatis nobis nam facere impedit.", "6581641537680", 412, new DateTime(2017, 8, 28, 4, 37, 49, 134, DateTimeKind.Local).AddTicks(6378), "Hand Group", "Enim voluptas error." },
                    { 24, "Rickie Romaguera", "Parenting", new byte[] { 131, 194, 224, 42, 136, 77, 132, 23, 165, 177, 233, 179, 47, 144, 62, 115, 59, 231, 127, 161, 120, 174, 192, 148, 164, 71, 174, 99, 183, 32, 161, 43, 148, 143, 220, 46, 144, 241, 44, 228, 180, 0, 140, 254, 237, 126, 191, 48, 252, 110, 190, 87, 173, 171, 73, 28, 117, 191, 209, 40, 223, 61, 154, 254, 221, 193, 112, 154, 85, 204, 223, 215, 227, 133, 254, 78, 70, 225, 77, 228, 115, 44, 254, 170, 5, 9, 207, 100, 237, 90, 210, 75, 170, 67, 101, 157, 82, 63, 9, 0, 44, 119, 60, 131, 167, 55, 178, 130, 12, 212, 59, 171, 119, 34, 35, 90, 5, 226, 153, 253, 133, 151, 247, 17, 128, 129, 131, 56, 64, 66, 36, 189, 228, 50, 122, 6, 59, 53, 69, 141, 133, 75 }, "Fugit omnis ad qui et consequatur voluptatum est asperiores atque. Quaerat quis et hic libero minus ducimus excepturi. Omnis voluptatem aut quasi et eum voluptatum perspiciatis expedita rerum.", "3490132014858", 116, new DateTime(2018, 10, 15, 2, 51, 52, 836, DateTimeKind.Local).AddTicks(6887), "Gutmann, Lindgren and Harber", "Id dignissimos ut." },
                    { 25, "Mallory Swift", "Religion & spirituality", new byte[] { 189, 43, 192, 148, 96, 36, 147, 174, 200, 73, 89, 210, 123, 83, 51, 179, 95, 63, 23, 55, 146, 37, 42, 54, 95, 94, 86, 3, 179, 60, 181, 174, 234, 184, 153, 157, 70, 42, 168, 133, 116, 216, 54, 64, 88, 204, 161, 167, 231, 179, 108, 88, 102, 172, 242, 126, 1, 41, 31, 8, 79, 131, 73, 160, 235, 61, 133, 162, 212, 254, 3, 97, 147, 103, 85, 12, 182, 62, 190, 81, 149, 215, 101, 112, 231, 149, 63, 6, 15, 215, 127, 84, 133, 107, 102, 241, 240, 122, 158, 59, 26, 249, 237, 112, 238, 27, 92, 249, 30, 153, 120, 105, 44, 154, 227, 162, 142, 169, 97, 25, 129, 247, 70, 241, 121, 240, 27, 63, 116, 78, 222, 167, 246, 113, 189, 155, 220, 173, 33, 207, 64, 224 }, "Odit sit quisquam vel. Quia quia omnis beatae at laborum eos qui eligendi vitae. Exercitationem sit delectus. Aliquam aperiam accusamus. Inventore deleniti doloribus labore ab voluptatem. Non beatae quia voluptatem nemo quam.", "6931218589398", 409, new DateTime(2022, 7, 13, 22, 6, 23, 804, DateTimeKind.Local).AddTicks(5113), "Hudson, Hahn and Beatty", "Quam enim fugit." },
                    { 26, "Estell Roberts", "Art & photography", new byte[] { 9, 76, 209, 212, 40, 43, 123, 225, 245, 0, 40, 219, 125, 53, 89, 101, 80, 204, 100, 214, 15, 133, 220, 223, 49, 249, 26, 59, 53, 228, 132, 20, 204, 27, 171, 73, 99, 221, 206, 102, 43, 162, 151, 29, 171, 23, 220, 59, 135, 126, 246, 241, 216, 162, 66, 135, 245, 207, 64, 240, 5, 80, 229, 127, 91, 250, 53, 160, 195, 199, 36, 83, 33, 85, 45, 188, 85, 79, 192, 21, 120, 88, 76, 135, 2, 221, 80, 139, 105, 176, 105, 141, 68, 134, 193, 11, 124, 113, 40, 121, 182, 214, 111, 106, 185, 184, 8, 250, 95, 94, 38, 175, 108, 131, 145, 104, 66, 91, 88, 158, 101, 164, 143, 240, 47, 226, 90, 164, 71, 52, 35, 110, 33, 226, 99, 118, 144, 131, 182, 124, 18, 40 }, "Recusandae iste ad. Placeat reprehenderit voluptas. Et et minima nobis ea qui quia laborum earum. Aut quia sint quod quas enim possimus saepe.", "0567367985888", 217, new DateTime(2022, 9, 4, 15, 22, 15, 369, DateTimeKind.Local).AddTicks(6072), "Jenkins - Welch", "Molestias nam excepturi." },
                    { 27, "Zoey Schaden", "Historical fiction", new byte[] { 145, 31, 196, 18, 186, 30, 25, 18, 25, 110, 192, 244, 102, 3, 77, 154, 152, 108, 252, 48, 173, 129, 77, 180, 138, 239, 111, 177, 189, 228, 94, 243, 123, 157, 151, 42, 79, 69, 125, 19, 112, 91, 205, 25, 19, 225, 148, 21, 90, 122, 42, 50, 94, 71, 217, 80, 87, 81, 107, 247, 75, 106, 123, 165, 39, 42, 146, 32, 228, 130, 182, 253, 240, 8, 239, 234, 222, 85, 230, 213, 177, 53, 222, 117, 101, 215, 251, 111, 84, 66, 214, 11, 3, 171, 198, 111, 181, 151, 30, 8, 103, 87, 186, 54, 192, 224, 16, 81, 94, 173, 47, 155, 70, 93, 5, 99, 38, 255, 10, 252, 205, 32, 123, 175, 146, 209, 252, 224, 64, 11, 190, 223, 6, 233, 91, 118, 38, 231, 79, 82, 24, 43 }, "Quaerat perferendis aspernatur. Tenetur sint minus esse molestiae et vero eaque aut debitis. Nulla in architecto voluptates. Placeat pariatur modi accusamus.", "1361759491792", 911, new DateTime(2024, 2, 20, 21, 16, 31, 776, DateTimeKind.Local).AddTicks(4529), "Beier LLC", "Error quis sequi." },
                    { 28, "Juston Reinger", "Romance", new byte[] { 207, 181, 32, 6, 4, 95, 190, 171, 55, 189, 45, 138, 67, 211, 45, 185, 255, 53, 207, 212, 228, 135, 159, 4, 49, 222, 148, 143, 69, 229, 227, 105, 38, 167, 218, 225, 188, 147, 84, 25, 76, 236, 79, 183, 155, 225, 8, 142, 82, 78, 195, 42, 210, 70, 65, 83, 184, 97, 183, 243, 24, 169, 39, 209, 109, 88, 162, 175, 14, 119, 101, 204, 224, 196, 131, 70, 113, 73, 49, 164, 41, 55, 238, 198, 246, 233, 254, 29, 227, 115, 63, 148, 81, 254, 175, 247, 181, 170, 220, 108, 111, 203, 72, 72, 23, 8, 101, 25, 197, 205, 178, 60, 23, 41, 92, 12, 15, 84, 98, 83, 36, 63, 169, 27, 158, 101, 68, 77, 173, 38, 53, 116, 116, 6, 117, 210, 232, 165, 60, 53, 146, 238 }, "Reprehenderit sapiente deserunt blanditiis fuga soluta sunt magnam. Ut error earum ea corrupti veritatis ut beatae ipsam earum. Quia architecto rerum unde ut dolores impedit eveniet dignissimos. Delectus voluptatem odio sequi ducimus id. Ea nostrum laborum aut expedita facilis et amet.", "8242149638948", 804, new DateTime(2017, 6, 30, 12, 1, 3, 564, DateTimeKind.Local).AddTicks(8882), "Wilkinson Group", "Optio eaque sed." },
                    { 29, "Walker Langworth", "Biography", new byte[] { 184, 159, 227, 8, 102, 128, 31, 105, 45, 2, 213, 113, 39, 164, 22, 144, 52, 141, 215, 49, 63, 44, 188, 79, 114, 175, 130, 106, 156, 211, 71, 146, 226, 134, 73, 10, 201, 181, 239, 203, 15, 203, 55, 196, 25, 53, 11, 42, 185, 122, 41, 245, 201, 122, 106, 208, 161, 243, 231, 30, 54, 117, 185, 178, 51, 168, 136, 45, 240, 8, 251, 90, 119, 170, 92, 87, 43, 244, 34, 122, 106, 126, 193, 209, 166, 77, 75, 130, 171, 153, 109, 59, 91, 114, 206, 90, 228, 101, 234, 142, 186, 32, 208, 135, 83, 89, 120, 78, 138, 86, 113, 154, 212, 222, 5, 248, 90, 166, 7, 13, 110, 88, 106, 39, 205, 170, 229, 212, 149, 115, 70, 48, 151, 210, 54, 167, 55, 104, 187, 161, 13, 177 }, "Distinctio velit rerum ex ipsa ullam consequatur nihil reiciendis. Ipsa similique commodi esse eius dolorem beatae vel. Quis labore in quis debitis mollitia. Voluptas ea in delectus animi qui porro voluptatibus odit est. Dolor rem molestiae debitis enim impedit exercitationem nesciunt excepturi. Rem non in.", "6900068186279", 175, new DateTime(2021, 12, 2, 19, 50, 11, 271, DateTimeKind.Local).AddTicks(6176), "Rutherford and Sons", "Et provident dolores." },
                    { 30, "Paige Schoen", "Historical fiction", new byte[] { 151, 179, 93, 122, 97, 180, 173, 24, 73, 146, 92, 235, 125, 160, 179, 181, 227, 112, 82, 79, 141, 162, 186, 145, 156, 54, 173, 30, 122, 87, 70, 8, 236, 146, 156, 58, 205, 50, 146, 195, 62, 198, 19, 158, 172, 109, 72, 199, 246, 189, 114, 40, 112, 62, 90, 190, 59, 52, 183, 33, 3, 167, 66, 84, 174, 116, 179, 103, 125, 99, 142, 252, 179, 156, 215, 124, 14, 115, 197, 17, 125, 242, 170, 137, 23, 239, 236, 35, 149, 1, 47, 65, 157, 254, 95, 188, 101, 4, 228, 2, 166, 151, 171, 141, 16, 20, 92, 10, 13, 24, 133, 85, 138, 126, 96, 95, 140, 243, 222, 79, 197, 196, 23, 127, 232, 43, 88, 44, 27, 153, 138, 28, 2, 81, 199, 202, 4, 212, 230, 67, 65, 28 }, "Reprehenderit veritatis eius assumenda eius et voluptas. Iusto dolores et rerum. Perferendis veniam eius in. Quod aut fuga. Quas commodi repellat quis est sit mollitia deserunt fugiat voluptatem. Enim dolores illo ut.", "7618886565983", 130, new DateTime(2021, 2, 11, 9, 12, 31, 842, DateTimeKind.Local).AddTicks(8888), "Kuhic - Sanford", "Exercitationem rerum fuga." },
                    { 31, "Susana Jakubowski", "Art & photography", new byte[] { 90, 234, 214, 199, 188, 236, 174, 131, 76, 160, 218, 93, 109, 215, 102, 157, 223, 51, 95, 73, 242, 133, 34, 186, 110, 94, 50, 210, 229, 73, 213, 105, 139, 170, 65, 76, 127, 175, 80, 75, 155, 45, 73, 233, 203, 8, 214, 2, 199, 206, 219, 90, 45, 129, 221, 123, 15, 181, 227, 243, 196, 195, 173, 231, 198, 211, 169, 180, 243, 193, 95, 55, 132, 61, 212, 17, 130, 250, 81, 222, 85, 198, 19, 106, 73, 1, 154, 30, 175, 223, 174, 80, 215, 21, 160, 251, 229, 94, 158, 133, 219, 104, 123, 0, 53, 145, 224, 205, 61, 86, 109, 214, 42, 227, 162, 141, 23, 251, 246, 135, 73, 153, 22, 52, 55, 172, 64, 147, 198, 246, 87, 78, 132, 124, 143, 183, 241, 53, 161, 31, 189, 87 }, "Aliquid nihil nisi molestiae. Fugit nostrum corporis. Dolores id eveniet veritatis dolores ipsam laboriosam et.", "8144280728017", 915, new DateTime(2016, 1, 2, 2, 17, 1, 967, DateTimeKind.Local).AddTicks(6346), "D'Amore, Huels and Zemlak", "Omnis sed autem." },
                    { 32, "Johathan Schmeler", "Food & drink", new byte[] { 211, 49, 227, 140, 34, 195, 81, 97, 48, 28, 13, 18, 160, 189, 199, 37, 207, 28, 149, 226, 109, 155, 165, 198, 117, 147, 59, 149, 164, 231, 250, 85, 48, 187, 80, 231, 33, 213, 57, 228, 107, 204, 175, 55, 217, 30, 101, 83, 215, 43, 149, 202, 79, 210, 48, 176, 22, 213, 44, 213, 225, 173, 192, 111, 154, 81, 221, 230, 206, 181, 170, 39, 200, 202, 195, 58, 101, 251, 237, 9, 48, 36, 21, 208, 54, 135, 201, 34, 42, 213, 230, 252, 221, 193, 25, 2, 248, 193, 71, 186, 117, 37, 221, 45, 250, 69, 128, 207, 110, 186, 147, 54, 11, 66, 215, 255, 232, 225, 249, 45, 233, 163, 206, 194, 189, 51, 110, 178, 58, 149, 244, 77, 201, 73, 184, 117, 227, 214, 118, 107, 72, 32 }, "Rerum harum aut tempore. Molestiae cumque omnis. Et unde aut qui velit reiciendis voluptatem quis.", "8487657566622", 605, new DateTime(2016, 1, 20, 15, 3, 15, 708, DateTimeKind.Local).AddTicks(5343), "White, Gibson and Crooks", "Necessitatibus voluptatum voluptas." },
                    { 33, "Gia Legros", "Fantasy", new byte[] { 8, 99, 193, 46, 95, 220, 241, 189, 220, 243, 114, 135, 121, 229, 252, 31, 196, 138, 245, 98, 132, 71, 57, 211, 236, 248, 32, 220, 16, 138, 145, 137, 77, 37, 185, 158, 112, 162, 253, 169, 85, 138, 54, 4, 140, 182, 2, 59, 19, 198, 202, 206, 254, 221, 67, 135, 199, 128, 66, 78, 143, 7, 10, 91, 185, 110, 10, 99, 103, 98, 236, 221, 193, 197, 88, 180, 84, 55, 97, 181, 140, 189, 61, 109, 214, 43, 65, 26, 92, 128, 212, 198, 22, 31, 173, 16, 191, 118, 36, 184, 44, 185, 50, 183, 45, 190, 40, 19, 115, 53, 213, 62, 54, 66, 37, 183, 227, 255, 238, 27, 178, 2, 168, 119, 78, 200, 99, 27, 183, 161, 160, 60, 110, 137, 98, 63, 26, 97, 36, 235, 161, 72 }, "Qui incidunt autem aperiam. Voluptatem nostrum consectetur temporibus facilis sint. Sit magnam aliquid tempore. Adipisci qui nostrum possimus id ea non qui et delectus. Quae vitae voluptate aut dolor tempore rerum et asperiores nemo. Et veniam voluptatem rerum dolorem quia inventore aut ex sint.", "9946825244032", 207, new DateTime(2017, 8, 26, 5, 30, 3, 517, DateTimeKind.Local).AddTicks(6527), "VonRueden and Sons", "Molestiae ipsam quae." },
                    { 34, "Berniece Gerlach", "Horror", new byte[] { 21, 253, 230, 104, 244, 100, 23, 118, 198, 143, 203, 157, 94, 255, 245, 247, 243, 95, 235, 160, 176, 149, 194, 92, 56, 141, 194, 154, 210, 120, 164, 235, 0, 254, 125, 207, 31, 118, 9, 117, 9, 195, 7, 28, 233, 33, 198, 161, 159, 67, 250, 48, 171, 241, 121, 30, 198, 18, 189, 156, 207, 126, 92, 39, 124, 192, 34, 8, 195, 123, 89, 180, 137, 16, 78, 220, 233, 194, 51, 120, 226, 98, 20, 64, 17, 51, 218, 192, 178, 16, 243, 238, 137, 113, 127, 78, 58, 25, 26, 242, 101, 222, 121, 5, 67, 199, 110, 124, 13, 124, 113, 178, 81, 230, 254, 96, 123, 193, 169, 144, 151, 169, 249, 98, 133, 202, 78, 199, 142, 206, 223, 226, 118, 224, 64, 135, 236, 195, 33, 30, 5, 232 }, "Dolores fugit fugiat perferendis maiores officia incidunt doloremque. Sit amet aut expedita ut eos aliquam assumenda consequuntur dolor. Iste commodi nesciunt praesentium animi reprehenderit.", "5842309867954", 571, new DateTime(2022, 5, 1, 7, 54, 7, 400, DateTimeKind.Local).AddTicks(4885), "Dickens Inc", "Assumenda voluptatibus ut." },
                    { 35, "Dallin Nolan", "Mystery", new byte[] { 121, 206, 6, 154, 217, 30, 237, 65, 189, 159, 246, 164, 195, 54, 92, 129, 161, 26, 75, 143, 177, 157, 174, 61, 15, 124, 85, 59, 106, 202, 250, 62, 205, 201, 81, 168, 217, 178, 159, 104, 224, 17, 231, 201, 115, 126, 128, 115, 225, 110, 237, 162, 250, 191, 246, 126, 21, 229, 185, 10, 146, 248, 147, 3, 234, 50, 155, 124, 65, 31, 195, 214, 98, 190, 49, 225, 239, 100, 11, 113, 57, 159, 234, 4, 224, 42, 246, 153, 73, 5, 231, 104, 202, 70, 46, 177, 224, 219, 32, 234, 220, 83, 102, 195, 71, 125, 229, 60, 132, 18, 67, 250, 232, 141, 142, 110, 235, 31, 49, 198, 246, 213, 166, 212, 134, 134, 43, 194, 68, 247, 129, 97, 55, 34, 64, 58, 193, 71, 174, 159, 193, 153 }, "Eum enim nostrum labore enim. Vel pariatur omnis eaque at. Ullam aspernatur ullam et non nihil optio distinctio.", "9344232274831", 536, new DateTime(2016, 9, 9, 1, 48, 31, 119, DateTimeKind.Local).AddTicks(6991), "Orn - Batz", "Consequatur velit ut." },
                    { 36, "Tommie Tromp", "How-To/Guides", new byte[] { 88, 160, 122, 221, 228, 118, 214, 190, 4, 4, 87, 98, 108, 31, 135, 142, 226, 76, 19, 201, 78, 177, 254, 27, 245, 18, 37, 84, 214, 135, 83, 50, 208, 234, 138, 212, 105, 190, 36, 18, 111, 105, 255, 200, 32, 93, 15, 88, 15, 195, 115, 12, 87, 11, 41, 251, 6, 29, 194, 122, 187, 131, 173, 103, 240, 96, 56, 157, 77, 247, 89, 84, 177, 8, 196, 166, 248, 41, 161, 35, 84, 119, 26, 230, 70, 169, 120, 209, 16, 69, 139, 235, 99, 113, 212, 108, 165, 137, 195, 216, 194, 255, 99, 12, 26, 21, 10, 188, 208, 150, 24, 171, 187, 42, 53, 207, 64, 12, 99, 172, 197, 21, 217, 212, 244, 92, 231, 131, 114, 145, 98, 149, 63, 170, 255, 17, 177, 132, 214, 253, 149, 39 }, "Cumque eum provident. Corrupti eos qui. Eaque ipsa est. Minus totam vel cupiditate cumque aut.", "1736322074571", 638, new DateTime(2020, 12, 20, 5, 31, 40, 509, DateTimeKind.Local).AddTicks(7378), "Stracke LLC", "Perspiciatis debitis architecto." },
                    { 37, "Unique Schaefer", "New adult", new byte[] { 140, 102, 141, 119, 198, 0, 213, 191, 89, 120, 78, 220, 122, 81, 51, 171, 130, 127, 98, 218, 62, 169, 126, 90, 250, 148, 137, 149, 177, 9, 21, 28, 79, 193, 232, 169, 137, 90, 144, 94, 242, 240, 76, 16, 12, 163, 76, 108, 3, 39, 98, 71, 130, 60, 34, 126, 65, 239, 66, 63, 250, 36, 254, 35, 231, 114, 111, 36, 129, 254, 232, 251, 142, 222, 198, 132, 252, 8, 56, 127, 177, 138, 123, 132, 230, 169, 128, 197, 21, 101, 238, 8, 162, 185, 155, 125, 42, 167, 33, 165, 228, 183, 248, 152, 224, 221, 207, 245, 78, 146, 190, 189, 227, 142, 171, 21, 1, 253, 154, 248, 134, 122, 129, 9, 43, 28, 31, 107, 50, 235, 186, 20, 104, 20, 74, 191, 216, 76, 252, 182, 11, 136 }, "Velit corporis illo maiores consequatur suscipit. Quod minus voluptas quisquam ea. Consequatur eum quo animi praesentium qui minima. Voluptatem quibusdam qui repellendus rem. Qui quidem earum nemo ut ab adipisci sunt.", "4923358720894", 391, new DateTime(2019, 9, 7, 15, 46, 59, 448, DateTimeKind.Local).AddTicks(6881), "Beier and Sons", "Laboriosam porro cum." },
                    { 38, "Garret Quigley", "How-To/Guides", new byte[] { 1, 158, 5, 229, 23, 4, 36, 59, 83, 11, 26, 173, 132, 226, 126, 99, 103, 12, 140, 163, 161, 115, 146, 4, 253, 237, 1, 246, 248, 40, 253, 61, 129, 134, 98, 188, 24, 77, 95, 236, 74, 132, 34, 51, 116, 165, 72, 213, 196, 63, 8, 145, 131, 107, 66, 103, 111, 122, 23, 250, 37, 141, 175, 37, 48, 44, 253, 195, 141, 200, 140, 242, 59, 158, 163, 228, 235, 145, 139, 119, 84, 170, 90, 228, 0, 124, 72, 148, 82, 233, 221, 13, 205, 97, 21, 186, 18, 66, 5, 13, 22, 76, 168, 140, 183, 51, 185, 83, 117, 74, 55, 226, 102, 212, 40, 223, 29, 69, 53, 41, 85, 1, 145, 58, 199, 154, 215, 58, 26, 102, 247, 240, 155, 24, 124, 106, 143, 10, 151, 185, 127, 83 }, "Est aut voluptatem et eaque et autem officiis. Sequi odit sed culpa est deserunt non. Odit ut voluptates.", "0101188963283", 529, new DateTime(2019, 10, 13, 17, 28, 59, 340, DateTimeKind.Local).AddTicks(3300), "Satterfield - Brekke", "At eos est." },
                    { 39, "Alisha Mann", "Biography", new byte[] { 130, 206, 64, 96, 44, 251, 203, 88, 206, 253, 97, 154, 224, 37, 83, 133, 250, 56, 51, 48, 236, 41, 153, 153, 45, 117, 212, 82, 52, 11, 22, 8, 115, 162, 179, 199, 190, 183, 94, 0, 134, 251, 177, 94, 134, 135, 233, 133, 17, 32, 17, 85, 41, 226, 21, 20, 53, 204, 181, 179, 135, 86, 231, 135, 9, 166, 55, 128, 32, 244, 110, 66, 102, 137, 58, 168, 99, 207, 23, 132, 113, 222, 165, 174, 212, 119, 202, 182, 110, 120, 244, 179, 42, 108, 229, 127, 64, 186, 241, 246, 135, 116, 244, 23, 202, 74, 14, 222, 232, 69, 2, 146, 3, 208, 209, 159, 242, 73, 30, 231, 107, 78, 110, 209, 117, 11, 56, 155, 17, 112, 168, 1, 101, 74, 208, 192, 12, 200, 234, 189, 87, 254 }, "Accusamus assumenda eveniet quis est veritatis et repellendus. Officia aliquid quam cum aut eaque recusandae rerum iure. Est repellat quae et delectus. Libero in sequi atque odio temporibus deleniti nam sed. Autem quia aut. Et enim eos in veritatis quam maiores eveniet nesciunt.", "2659463620959", 409, new DateTime(2021, 8, 17, 22, 26, 24, 430, DateTimeKind.Local).AddTicks(8142), "Terry - Roob", "Ut distinctio dolor." },
                    { 40, "Savannah Borer", "Mystery", new byte[] { 158, 53, 126, 34, 184, 130, 216, 215, 68, 238, 52, 33, 155, 159, 230, 173, 91, 182, 43, 133, 254, 151, 248, 150, 39, 94, 191, 197, 30, 47, 11, 24, 123, 127, 171, 65, 36, 0, 110, 212, 143, 28, 116, 159, 116, 89, 23, 5, 161, 189, 104, 156, 17, 3, 15, 240, 231, 127, 59, 74, 144, 227, 103, 129, 49, 18, 237, 8, 44, 214, 82, 45, 255, 13, 241, 203, 117, 122, 180, 11, 100, 31, 2, 10, 153, 43, 141, 127, 137, 221, 181, 12, 115, 80, 133, 206, 233, 88, 230, 211, 140, 53, 178, 95, 191, 49, 2, 100, 65, 61, 183, 236, 212, 106, 10, 26, 47, 163, 245, 179, 183, 173, 59, 65, 176, 240, 130, 101, 215, 170, 102, 216, 214, 46, 230, 28, 92, 29, 107, 181, 30, 106 }, "Quia et illum molestias velit et voluptatibus qui. Sint exercitationem deserunt accusamus voluptas enim nulla et quis. Veritatis est est officia eos.", "5281785485267", 282, new DateTime(2023, 9, 5, 5, 7, 6, 762, DateTimeKind.Local).AddTicks(8841), "Crona and Sons", "Mollitia possimus laborum." }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "ID", "AccountId", "BookId", "LoanDate", "ReturnedDate" },
                values: new object[,]
                {
                    { 21, 27, 34, new DateTime(2024, 5, 2, 7, 6, 4, 731, DateTimeKind.Local).AddTicks(7022), new DateTime(2024, 4, 14, 2, 4, 7, 559, DateTimeKind.Local).AddTicks(664) },
                    { 22, 23, 28, new DateTime(2024, 5, 4, 10, 45, 15, 729, DateTimeKind.Local).AddTicks(4369), null },
                    { 23, 22, 21, new DateTime(2024, 4, 25, 2, 17, 48, 342, DateTimeKind.Local).AddTicks(5124), new DateTime(2024, 4, 20, 13, 50, 5, 995, DateTimeKind.Local).AddTicks(1138) },
                    { 24, 21, 23, new DateTime(2024, 4, 22, 17, 23, 20, 295, DateTimeKind.Local).AddTicks(1139), null },
                    { 25, 33, 31, new DateTime(2024, 4, 28, 23, 52, 1, 429, DateTimeKind.Local).AddTicks(65), null },
                    { 26, 21, 29, new DateTime(2024, 4, 30, 17, 31, 47, 175, DateTimeKind.Local).AddTicks(3341), new DateTime(2024, 4, 13, 13, 15, 32, 622, DateTimeKind.Local).AddTicks(6471) },
                    { 27, 36, 36, new DateTime(2024, 4, 27, 0, 48, 1, 915, DateTimeKind.Local).AddTicks(9826), null },
                    { 28, 36, 22, new DateTime(2024, 5, 4, 19, 37, 50, 572, DateTimeKind.Local).AddTicks(3901), new DateTime(2024, 5, 1, 16, 15, 22, 733, DateTimeKind.Local).AddTicks(6627) },
                    { 29, 36, 34, new DateTime(2024, 5, 1, 9, 32, 28, 740, DateTimeKind.Local).AddTicks(5431), null },
                    { 30, 32, 34, new DateTime(2024, 4, 26, 17, 27, 24, 471, DateTimeKind.Local).AddTicks(6173), new DateTime(2024, 4, 12, 23, 21, 44, 188, DateTimeKind.Local).AddTicks(8593) },
                    { 31, 39, 38, new DateTime(2024, 4, 12, 3, 58, 17, 255, DateTimeKind.Local).AddTicks(4187), new DateTime(2024, 4, 23, 8, 9, 41, 70, DateTimeKind.Local).AddTicks(8205) },
                    { 32, 37, 32, new DateTime(2024, 4, 27, 23, 6, 14, 71, DateTimeKind.Local).AddTicks(4114), null },
                    { 33, 23, 21, new DateTime(2024, 4, 15, 21, 17, 54, 281, DateTimeKind.Local).AddTicks(6449), new DateTime(2024, 4, 19, 3, 53, 48, 530, DateTimeKind.Local).AddTicks(382) },
                    { 34, 37, 35, new DateTime(2024, 5, 6, 8, 9, 52, 179, DateTimeKind.Local).AddTicks(7841), null },
                    { 35, 28, 32, new DateTime(2024, 4, 30, 12, 3, 43, 324, DateTimeKind.Local).AddTicks(607), null },
                    { 36, 24, 26, new DateTime(2024, 4, 17, 8, 14, 45, 900, DateTimeKind.Local).AddTicks(9417), null },
                    { 37, 31, 27, new DateTime(2024, 5, 9, 23, 47, 47, 111, DateTimeKind.Local).AddTicks(2593), new DateTime(2024, 4, 15, 8, 23, 57, 897, DateTimeKind.Local).AddTicks(9102) },
                    { 38, 21, 21, new DateTime(2024, 4, 23, 4, 59, 32, 375, DateTimeKind.Local).AddTicks(5112), new DateTime(2024, 5, 3, 21, 11, 49, 490, DateTimeKind.Local).AddTicks(6216) },
                    { 39, 32, 29, new DateTime(2024, 4, 26, 7, 46, 59, 287, DateTimeKind.Local).AddTicks(8904), new DateTime(2024, 4, 30, 23, 10, 17, 208, DateTimeKind.Local).AddTicks(3757) },
                    { 40, 31, 32, new DateTime(2024, 4, 21, 13, 55, 20, 27, DateTimeKind.Local).AddTicks(4884), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_AccountId",
                table: "Loans",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
