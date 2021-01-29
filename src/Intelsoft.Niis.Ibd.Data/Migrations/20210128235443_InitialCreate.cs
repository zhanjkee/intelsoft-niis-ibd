using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intelsoft.Niis.Ibd.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IbdResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseId = table.Column<string>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: true),
                    ErrorCode = table.Column<string>(nullable: true),
                    DataProcessingText = table.Column<string>(nullable: true),
                    RequestId = table.Column<string>(nullable: true),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true)
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
                    MessageId = table.Column<string>(nullable: true),
                    MessageDate = table.Column<DateTime>(nullable: true),
                    CorrelationId = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: false),
                    From = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: false),
                    RawData = table.Column<string>(nullable: true),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntellectualPropertyId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ProtectionNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ValidityDate = table.Column<DateTime>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IbdResponseMessageMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IbdResponseId = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbdResponseMessageMap", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ContractRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(nullable: false),
                    Xin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false),
                    AssigneeXin = table.Column<string>(nullable: true),
                    AssigneeName = table.Column<string>(nullable: true),
                    ContractNumber = table.Column<string>(nullable: true),
                    ContractRegistrationDate = table.Column<DateTime>(nullable: true),
                    ContractTypeId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: true),
                    ContractValidityDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRequests_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractRequests_ContractTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractRequestDispatchStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dispatched = table.Column<bool>(nullable: false),
                    DispatchingDate = table.Column<DateTime>(nullable: false),
                    ContractRequestId = table.Column<int>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequestDispatchStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRequestDispatchStatuses_ContractRequests_ContractRequestId",
                        column: x => x.ContractRequestId,
                        principalTable: "ContractRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractRequestMessageMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractRequestId = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequestMessageMap", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequestDispatchStatuses_ContractRequestId",
                table: "ContractRequestDispatchStatuses",
                column: "ContractRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequestMessageMap_ContractRequestId",
                table: "ContractRequestMessageMap",
                column: "ContractRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequestMessageMap_MessageId",
                table: "ContractRequestMessageMap",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequests_PropertyId",
                table: "ContractRequests",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequests_TypeId",
                table: "ContractRequests",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IbdResponseMessageMap_IbdResponseId",
                table: "IbdResponseMessageMap",
                column: "IbdResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_IbdResponseMessageMap_MessageId",
                table: "IbdResponseMessageMap",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractRequestDispatchStatuses");

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

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "ContractTypes");
        }
    }
}
