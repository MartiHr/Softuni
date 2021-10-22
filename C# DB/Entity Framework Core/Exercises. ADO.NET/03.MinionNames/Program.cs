using Microsoft.Data.SqlClient;
using System;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection sqlConnection = new SqlConnection("Server=.;Database=MinionsDB;Trusted_Connection=True;");

            sqlConnection.Open();

            string villainId = Console.ReadLine();

            using (sqlConnection)
            {
                SqlCommand getVillainNameCmd = new SqlCommand
                  (@"SELECT Name FROM Villains WHERE Id = @Id", sqlConnection);

                getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

                var villainNameObject = getVillainNameCmd.ExecuteScalar();

                if (villainNameObject == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                string villainName = (string)villainNameObject;

                SqlCommand villainMinionsInfoCmd = new SqlCommand
                    (@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name",
                     sqlConnection
                    );

                villainMinionsInfoCmd.Parameters.AddWithValue("@Id", villainId);

                SqlDataReader sqlDataReader = villainMinionsInfoCmd.ExecuteReader();

                using (sqlDataReader)
                {
                    Console.WriteLine($"Villain: {villainName}");

                    if (!sqlDataReader.HasRows)
                    {
                        Console.WriteLine("(no minions)");  
                    }
                    else
                    {
                        while (sqlDataReader.Read())
                        {
                            long rowNumber = (long)sqlDataReader["RowNum"];
                            string name = (string)sqlDataReader["Name"];
                            int age = (int)sqlDataReader["Age"];

                            Console.WriteLine($"{rowNumber}. {name} {age}");
                        }
                    }
                   
                }
            }
        }
    }
}
