﻿namespace ProblemsOnADO.NET
{
    public static class SqlQuery
    {
        public const string VillainsNamesAndTheirMinions =
                @"  SELECT 
                    CONCAT_WS(' - ',v.Name, COUNT(*)) AS [Output]
                    FROM Villains AS v
                    JOIN MinionsVillains AS mv
                    ON mv.VillainId = v.Id
                    JOIN Minions AS m
                    ON m.Id = mv.MinionId
                    GROUP BY v.Id, v.Name
                    HAVING COUNT(*) > @minMinions
                    ORDER BY COUNT(*) DESC
                ";

        public const string MinionNamesForVillian =
                @"
                    SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                             m.Name, 
                                                             m.Age
                                                        FROM MinionsVillains AS mv
                                                        JOIN Minions As m ON mv.MinionId = m.Id
                                                       WHERE mv.VillainId = @Id
                                                    ORDER BY m.Name
                ";

        public const string GetVillianById =
                @"
                    SELECT Name FROM Villains WHERE Id = @Id
                ";

        public const string GetVillainIdByName =
                @"
                    SELECT Id FROM Villains WHERE Name = @Name
                ";

        public const string GetMinionIdByName =
                @"
                    SELECT Id FROM Minions WHERE Name = @Name
                ";

        public const string GetTownIdByName =
                @"
                    SELECT Id FROM Towns WHERE Name = @townName
                ";

        public const string AddMinion =

                @"
                    INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)
                ";

        public const string AddTown =
                @"
                    INSERT INTO Towns (Name) VALUES (@townName)
                ";

        public const string AddVillain =
                @"
                    INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)
                ";

        public const string AddMinionsVillainsIdKey =
                @"
                    INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)
                ";
    }
}