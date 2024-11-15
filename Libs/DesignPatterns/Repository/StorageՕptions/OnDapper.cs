using System.Data.SqlClient;
using Dapper;

namespace DesignPatterns.Repository.StorageՕptions
{
    internal class OnDapper
    {
        public static string connectionString;
        internal static IEnumerable<T> Load<T>()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Чтение записей
                var entities = connection.Query<T>($"Select * from {OnAdoNetExpression._Tables[typeof(T).Name]}").ToList();
                foreach (var entity in entities)
                {
                    yield return entity;
                }
            }
        }

        internal static void Write<T>(List<T> source)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();


                var ColumnNames = typeof(T).GetProperties().Select(e => e.Name).ToList();
                // SQL query to insert data into a table
                string insertQuery = $"INSERT INTO {OnAdoNetExpression._Tables[typeof(T).Name]} ({string.Join(", ", ColumnNames)}) VALUES ({$"@{string.Join(", @", ColumnNames)}"})";
                insertQuery = $" IF NOT EXISTS (SELECT 1 FROM {OnAdoNetExpression._Tables[typeof(T).Name]} WHERE ID = @ID) BEGIN {insertQuery} END";

                // Вставка записи
                connection.Execute(insertQuery, source);
            }

        }
    }
}
