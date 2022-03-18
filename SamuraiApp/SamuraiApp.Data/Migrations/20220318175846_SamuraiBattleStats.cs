using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class SamuraiBattleStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"  CREATE FUNCTION[dbo].[EarliesBattleFoughtBySamurai](@samuraiId int)
                    RETURNS char(30) AS
                    BEGIN
                        DECLARE @ret char(30)
                        SELECT TOP 1 @ret = Name
                        FROM Battles
                        WHERE Battles.Id IN(
                            SELECT BattleId 
                            FROM BattleSamurai 
                            WHERE SamuraiId = @samuraiId)
                        ORDER BY StartDate
                        RETURN @ret
                    END");
            migrationBuilder.Sql(
                @"  CREATE VIEW dbo.SamuraiBattleStats
                    AS
                    SELECT  dbo.Samurais.Name,
                            COUNT(dbo.BattleSamurai.BattleId) AS NumberOfBattles,
                            dbo.EarliesBattleFoughtBySamurai(MIN(dbo.Samurais.Id)) AS EarliesBattle
                    FROM dbo.BattleSamurai INNER JOIN dbo.Samurais ON dbo.BattleSamurai.SamuraiId = dbo.Samurais.Id
                    GROUP BY dbo.Samurais.Name, dbo.BattleSamurai.SamuraiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.SamuraiBatleStats");
            migrationBuilder.Sql("DROP FONCTION dbo.EarliesBattleFoughtBySamurai");
        }
    }
}
