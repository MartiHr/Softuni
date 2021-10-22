using Microsoft.Data.SqlClient;
using System;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection("Server=.;Database=MinionsDB;Trusted_Connection=True;");

            sqlConnection.Open();

            string[] minionInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];
            
            string[] villainInfo = Console.ReadLine()
                           .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string villainName = villainInfo[1];

            using (sqlConnection)
            {
                SqlCommand getTownIdCmd = new SqlCommand(@"SELECT Id FROM Towns WHERE Name = @townName", sqlConnection);
                getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

                object townObject = getTownIdCmd.ExecuteScalar();

                if (townObject == null)
                {
                    SqlCommand insertTownCmd = new SqlCommand(@"INSERT INTO Towns (Name) VALUES (@townName)", sqlConnection);
                    insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                    int rowsAffectedT = insertTownCmd.ExecuteNonQuery();

                    if (rowsAffectedT == 0)
                    {
                        Console.WriteLine("Problem occured while inserting new town into the database MinionsDB! Please try again later!");
                        return;
                    }

                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                int townId = (int)townObject;

                SqlCommand getVillainIdCmd = new SqlCommand(@"SELECT Id FROM Villains WHERE Name = @Name", sqlConnection);
                getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);

                object villainIdObject = getVillainIdCmd.ExecuteScalar();

                if (villainIdObject == null)
                {
                    SqlCommand addVillain = new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", sqlConnection);
                    addVillain.Parameters.AddWithValue("@villainName", villainName);

                    int rowsAffectedV = addVillain.ExecuteNonQuery();

                    if (rowsAffectedV == 0)
                    {
                        Console.WriteLine("Problem occured while inserting new villain into the database MinionsDB! Please try again later!"); 
                        return;
                    }

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                int villainId = (int)villainIdObject;

                SqlCommand insertMinionCmd =
                    new SqlCommand(@"INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)", sqlConnection);
                insertMinionCmd.Parameters.AddWithValue("@nam", minionName);
                insertMinionCmd.Parameters.AddWithValue("@age", minionAge);
                insertMinionCmd.Parameters.AddWithValue("@townId", townId);

                int rowsAffected = insertMinionCmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("Problem occured while inserting new minion into the database MinionsDB! Please try again later!");
                    return;
                }

                SqlCommand getMinionIdCmd = new SqlCommand(@"SELECT Id FROM Minions WHERE Name = @Name", sqlConnection);
                getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);

                int minionId = (int)getMinionIdCmd.ExecuteScalar();


                SqlCommand insertMinionVillainCmd = 
                    new SqlCommand("INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)", sqlConnection);
              
                insertMinionVillainCmd.Parameters.AddWithValue("@villainId", villainId);
                insertMinionVillainCmd.Parameters.AddWithValue("@minionId", minionId);

                int rowsAffectedMV = insertMinionVillainCmd.ExecuteNonQuery();

                if (rowsAffectedMV == 0)
                {
                    Console.WriteLine("Problem occured while inserting new minion under the control of the given villain! Please try again later!");
                    return;
                }

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
