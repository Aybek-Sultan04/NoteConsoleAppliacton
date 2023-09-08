using Dapper;
using Note.Application.Servis;
using Note.Domain.Models;
using Note.Infrastructure.DbConfiguration;
using Npgsql;
using System.Data;

namespace Note.Infrastructure.DbServices
{
    public class DbUserContext : IUserDbContext
    {
        private static string config = GetConfigFromDb.GetConnect();
       

        public async Task<int> ExecuteCommandAsync(string command)
        {
            using IDbConnection connection = new NpgsqlConnection(config);
            int effectRows = await connection.ExecuteAsync(command);
            return effectRows;
            #region Ado.net
            //using NpgsqlConnection connection = new(config);
            //connection.Open();
            //NpgsqlCommand cmd = new NpgsqlCommand(command, connection);
            //int effectRows = await cmd.ExecuteNonQueryAsync();
            //return effectRows;
            #endregion
        }

        public ICollection<User> ExecuteQuery(string getAllQuery)
        {
            using NpgsqlConnection connection = new(config);
            connection.Open();
            ICollection<User> authors = connection.Query<User>(getAllQuery).ToList();
            #region Ado.net
            //NpgsqlCommand npgsqlCommand = new(getAllQuery, connection);
            //NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
            //ICollection<Domain.Models.User> users = new List<Domain.Models.User>();
            //while (reader.Read())
            //{
            //    users.Add(new()
            //    {
            //        Id = (Guid)reader[0],
            //        Name = (string)reader[1],
            //        Email = (string)reader[2],
            //        Password = (string)reader[3],
            //        Login = (string)reader[4],
            //        Age = (byte)reader[5]
            //    });
            //}
            #endregion
            return authors; 
        }

       
    }
}
