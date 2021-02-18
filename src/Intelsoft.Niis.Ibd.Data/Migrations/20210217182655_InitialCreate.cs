using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intelsoft.Niis.Ibd.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "ContractTypes",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRu = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_ContractTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                "IbdResponses",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseId = table.Column<string>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: true),
                    ErrorCode = table.Column<string>(nullable: true),
                    DataProcessingText = table.Column<string>(nullable: true),
                    RequestId = table.Column<string>(nullable: true),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_IbdResponses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Messages",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<string>(nullable: true),
                    MessageDate = table.Column<DateTime>(nullable: true),
                    CorrelationId = table.Column<string>(nullable: true),
                    Method = table.Column<string>(maxLength: 50, nullable: false),
                    From = table.Column<string>(maxLength: 50, nullable: false),
                    To = table.Column<string>(maxLength: 50, nullable: false),
                    RawData = table.Column<string>(nullable: true),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Messages", x => x.Id); });

            migrationBuilder.CreateTable(
                "Properties",
                table => new
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
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Properties", x => x.Id); });

            migrationBuilder.CreateTable(
                "IbdResponseMessageMap",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IbdResponseId = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbdResponseMessageMap", x => new {x.IbdResponseId, x.MessageId});
                    table.ForeignKey(
                        "FK_IbdResponseMessageMap_IbdResponses_IbdResponseId",
                        x => x.IbdResponseId,
                        "IbdResponses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_IbdResponseMessageMap_Messages_MessageId",
                        x => x.MessageId,
                        "Messages",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ContractRequests",
                table => new
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
                    TypeId = table.Column<int>(nullable: false),
                    ContractValidityDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DispatchStatusId = table.Column<int>(nullable: true),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequests", x => x.Id);
                    table.ForeignKey(
                        "FK_ContractRequests_Properties_PropertyId",
                        x => x.PropertyId,
                        "Properties",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ContractRequests_ContractTypes_TypeId",
                        x => x.TypeId,
                        "ContractTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ContractRequestDispatchStatuses",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dispatched = table.Column<bool>(nullable: false),
                    DispatchingDate = table.Column<DateTime>(nullable: true),
                    ContractRequestId = table.Column<int>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequestDispatchStatuses", x => x.Id);
                    table.ForeignKey(
                        "FK_ContractRequestDispatchStatuses_ContractRequests_ContractRequestId",
                        x => x.ContractRequestId,
                        "ContractRequests",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ContractRequestMessageMap",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ContractRequestId = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    RowCreatedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequestMessageMap", x => new {x.ContractRequestId, x.MessageId});
                    table.ForeignKey(
                        "FK_ContractRequestMessageMap_ContractRequests_ContractRequestId",
                        x => x.ContractRequestId,
                        "ContractRequests",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ContractRequestMessageMap_Messages_MessageId",
                        x => x.MessageId,
                        "Messages",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_ContractRequestDispatchStatuses_ContractRequestId",
                "ContractRequestDispatchStatuses",
                "ContractRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ContractRequestMessageMap_MessageId",
                "ContractRequestMessageMap",
                "MessageId");

            migrationBuilder.CreateIndex(
                "IX_ContractRequests_DispatchStatusId",
                "ContractRequests",
                "DispatchStatusId");

            migrationBuilder.CreateIndex(
                "IX_ContractRequests_PropertyId",
                "ContractRequests",
                "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ContractRequests_TypeId",
                "ContractRequests",
                "TypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_IbdResponseMessageMap_MessageId",
                "IbdResponseMessageMap",
                "MessageId");

            migrationBuilder.AddForeignKey(
                "FK_ContractRequests_ContractRequestDispatchStatuses_DispatchStatusId",
                "ContractRequests",
                "DispatchStatusId",
                "ContractRequestDispatchStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_ContractRequestDispatchStatuses_ContractRequests_ContractRequestId",
                "ContractRequestDispatchStatuses");

            migrationBuilder.DropTable(
                "ContractRequestMessageMap");

            migrationBuilder.DropTable(
                "IbdResponseMessageMap");

            migrationBuilder.DropTable(
                "IbdResponses");

            migrationBuilder.DropTable(
                "Messages");

            migrationBuilder.DropTable(
                "ContractRequests");

            migrationBuilder.DropTable(
                "ContractRequestDispatchStatuses");

            migrationBuilder.DropTable(
                "Properties");

            migrationBuilder.DropTable(
                "ContractTypes");
        }
    }
}