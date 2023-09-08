using Dapper;
using Note.Application.Servis;
using Note.Infrastructure.DbConfiguration;
using Npgsql;
using System.Data;

namespace Note.Infrastructure.DbServices
{
    public class DbContext : INoteDbContext
    {
        private static string connectionString = GetConfigFromDb.GetConnect();

        public async Task<int> ExecuteCommandAsync(string command)
        {
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            int effectRows = await connection.ExecuteAsync(command);
            return effectRows;
            #region Ado.net
            //using NpgsqlConnection connection = new(connectionString);
            //connection.Open();
            //NpgsqlCommand npgsqlCommand = new NpgsqlCommand(command, connection);
            //int effectedRows = await npgsqlCommand.ExecuteNonQueryAsync();
            //return effectedRows;
            #endregion
        }
        ICollection<Domain.Models.Note> INoteDbContext.ExecuteQuery(string getAllQuery)
        {
            using NpgsqlConnection connection = new(connectionString);
            connection.Open();
            ICollection<Domain.Models.Note> notes = connection.Query<Domain.Models.Note>(getAllQuery).ToList();  
            #region Ado.net
            //NpgsqlCommand npgsqlCommand = new(getAllQuery, connection);
            //NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
            //ICollection<Domain.Models.Note> notes = new List<Domain.Models.Note>();
            //while (reader.Read())
            //{
            //    notes.Add(new()
            //    {
            //        UserID = (Guid)reader[0],
            //        Id = (Guid)reader[1],
            //        Title = (string)reader[2],
            //        CreationDate = (DateTime)reader[3],
            //        IsComplitet = (bool)reader[4],
            //        Type = (Domain.States.NoteEnum)reader[5]
            //    });
            //}
            #endregion
            return notes;
        }
    }
}
