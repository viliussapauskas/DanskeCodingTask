using Microsoft.EntityFrameworkCore.Migrations;

namespace DCT.Persistence.Migrations
{
    public partial class AddDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.Municipalities (Name,RuleKey)
                VALUES
                    (
                        'Kaunas',
                        1
                    ),
                    (
                        'Vilnius',
                        2
                    );
                GO"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
