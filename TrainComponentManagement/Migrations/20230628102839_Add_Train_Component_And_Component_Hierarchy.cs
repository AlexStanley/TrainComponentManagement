using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainComponentManagement.Migrations
{
    public partial class Add_Train_Component_And_Component_Hierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainComponents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanAssignQuantity = table.Column<bool>(type: "bit", nullable: false),
                    ItemAmount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComponentHierarchies",
                columns: table => new
                {
                    ParentComponentID = table.Column<int>(type: "int", nullable: false),
                    ChildComponentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentHierarchies", x => new { x.ParentComponentID, x.ChildComponentID });
                    table.ForeignKey(
                        name: "FK_ComponentHierarchies_TrainComponents_ChildComponentID",
                        column: x => x.ChildComponentID,
                        principalTable: "TrainComponents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentHierarchies_TrainComponents_ParentComponentID",
                        column: x => x.ParentComponentID,
                        principalTable: "TrainComponents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentHierarchies_ChildComponentID",
                table: "ComponentHierarchies",
                column: "ChildComponentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentHierarchies");

            migrationBuilder.DropTable(
                name: "TrainComponents");
        }
    }
}
