using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoTWAPI.Migrations
{
    public partial class mssql_migration_170 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommanderSkill",
                columns: table => new
                {
                    CommanderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FigthingId = table.Column<int>(type: "int", nullable: true),
                    Fighting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpeditionId = table.Column<int>(type: "int", nullable: true),
                    Expedition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingGroundId = table.Column<int>(type: "int", nullable: true),
                    TrainingGround = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrategicSkillId = table.Column<int>(type: "int", nullable: true),
                    StrategicSkill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeirwoodId = table.Column<int>(type: "int", nullable: true),
                    Weirwood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwakeningId = table.Column<int>(type: "int", nullable: true),
                    Awakening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommanderSkill", x => x.CommanderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommanderSkill");
        }
    }
}
