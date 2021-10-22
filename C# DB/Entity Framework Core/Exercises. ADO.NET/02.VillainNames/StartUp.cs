using Microsoft.Data.SqlClient;
using System;

namespace _02.VillainNames
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = 
                new SqlConnection(@"Server=.;Database=MinionsDB;Trusted_Connection=True;");

            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand sqlCommand =
                    new SqlCommand(@"  SELECT v.Name, 
                                              COUNT(mv.VillainId) AS MinionsCount  
                                         FROM Villains AS v 
                                         JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                     GROUP BY v.Id, v.Name 
                                       HAVING COUNT(mv.VillainId) > 3 
                                     ORDER BY COUNT(mv.VillainId)",
                                     sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        string villainName = (string)sqlDataReader["Name"];
                        int minionsCount = (int)sqlDataReader["MinionsCount"];
                        
                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
            }
        }
    }
}
