using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intelsoft.Niis.Ibd.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ContractId = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    Dispatched = table.Column<bool>(nullable: false),
                    DispatchingDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IbdResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ResponseId = table.Column<string>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: true),
                    ErrorCode = table.Column<string>(nullable: true),
                    DataProcessingText = table.Column<string>(nullable: true),
                    RequestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbdResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    MessageId = table.Column<string>(nullable: true),
                    MessageDate = table.Column<DateTime>(nullable: true),
                    CorrelationId = table.Column<string>(nullable: true),
                    Method = table.Column<string>(maxLength: 50, nullable: false),
                    From = table.Column<string>(maxLength: 50, nullable: false),
                    To = table.Column<string>(maxLength: 50, nullable: false),
                    RawData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractRequestMessageMap",
                columns: table => new
                {
                    ContractRequestId = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequestMessageMap", x => new { x.ContractRequestId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_ContractRequestMessageMap_ContractRequests_ContractRequestId",
                        column: x => x.ContractRequestId,
                        principalTable: "ContractRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequestMessageMap_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IbdResponseMessageMap",
                columns: table => new
                {
                    IbdResponseId = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbdResponseMessageMap", x => new { x.IbdResponseId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_IbdResponseMessageMap_IbdResponses_IbdResponseId",
                        column: x => x.IbdResponseId,
                        principalTable: "IbdResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IbdResponseMessageMap_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequestMessageMap_MessageId",
                table: "ContractRequestMessageMap",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_IbdResponseMessageMap_MessageId",
                table: "IbdResponseMessageMap",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractRequestMessageMap");

            migrationBuilder.DropTable(
                name: "IbdResponseMessageMap");

            migrationBuilder.DropTable(
                name: "ContractRequests");

            migrationBuilder.DropTable(
                name: "IbdResponses");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
