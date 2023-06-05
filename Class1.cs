using System;
using System.Data.SqlClient;

class GuessingGameDB
{
    private const string ConnectionString = "Data Source=shobi;Initial Catalog=gusssing;Integrated Security=True";

    public static void SaveGame(string difficulty, int targetNumber, int maxAttempts, string playerGuesses)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO Game (Difficulty, TargetNumber, MaxAttempts, PlayerGuesses) VALUES (@Difficulty, @TargetNumber, @MaxAttempts, @PlayerGuesses)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Difficulty", difficulty);
                command.Parameters.AddWithValue("@TargetNumber", targetNumber);
                command.Parameters.AddWithValue("@MaxAttempts", maxAttempts);
                command.Parameters.AddWithValue("@PlayerGuesses", playerGuesses);

                command.ExecuteNonQuery();
            }
        }
    }
}
}
}
