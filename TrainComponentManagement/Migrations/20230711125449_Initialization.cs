using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainComponentManagement.Migrations
{
    public partial class Initialization : Migration
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
                    CanAssignQuantity = table.Column<bool>(type: "bit", nullable: false)
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
                    ChildComponentID = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentHierarchies", x => new { x.ParentComponentID, x.ChildComponentID });
                    table.ForeignKey(
                        name: "FK_ComponentHierarchies_TrainComponents_ChildComponentID",
                        column: x => x.ChildComponentID,
                        principalTable: "TrainComponents",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ComponentHierarchies_TrainComponents_ParentComponentID",
                        column: x => x.ParentComponentID,
                        principalTable: "TrainComponents",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TrainComponentQuantityAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    TrainComponentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponentQuantityAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainComponentQuantityAssignments_TrainComponents_TrainComponentID",
                        column: x => x.TrainComponentID,
                        principalTable: "TrainComponents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentHierarchies_ChildComponentID",
                table: "ComponentHierarchies",
                column: "ChildComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentQuantityAssignments_TrainComponentID",
                table: "TrainComponentQuantityAssignments",
                column: "TrainComponentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentHierarchies");

            migrationBuilder.DropTable(
                name: "TrainComponentQuantityAssignments");

            migrationBuilder.DropTable(
                name: "TrainComponents");
        }
    }
}
