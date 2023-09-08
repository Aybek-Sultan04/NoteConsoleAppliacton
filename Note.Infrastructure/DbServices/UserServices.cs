using Note.Application.Servis;
using Note.Application.Servis.Checking;
using Note.Domain.Models;

namespace Note.Infrastructure.DbServices
{
    public class UserServices : IUserService
    {
        private IUserDbContext _servise;
        public UserServices()
        {
            _servise = new DbUserContext();
        }
        public  async Task<bool> AddUserAsync(User user)
        {
            string cmd = @$"insert into users values('{user.Id}','{user.Name}','{user.Email}','{user.Password}','{user.Login}',{user.Age})";
            int effectRows = await _servise.ExecuteCommandAsync(cmd);
            return effectRows > 0;
        }
        public async Task<bool> CheckUserAsync(Guid UserId)
        {
            string cmd = "select id from users";
            var reder = _servise.ExecuteQuery(cmd);
            foreach (var res in reder)
            {
                if (res.Id==UserId)
                    return true;
            }
            return false;   
        }
        public async Task<bool> DeleteUserAsync(User user)
        {
            string cmd = $"delete from users where id = {user.Id}";
            int effectedRows = await _servise.ExecuteCommandAsync(cmd);
            return (effectedRows > 0);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            string cmd = "select * from users";
            var reder =  _servise.ExecuteQuery(cmd);
            return reder;
        }

        public async Task<User> GetUserByIdAsync(Guid UserId)
        {
            string cmd = $"select * from users where id = {UserId}";
            var reder =  _servise.ExecuteQuery(cmd);
            User users = new (); 
            foreach (var item in reder)
            {
                if (item.Id == UserId)
                {
                    return item;
                }
            }    
            return users;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            CheckUser checkUser = new(); 
            await Console.Out.WriteLineAsync("write name: ");
            var name = Console.ReadLine();
            bool resName = checkUser.CheckName(name);
            if (!resName)
            {
                await Console.Out.WriteLineAsync("Ivalid Name");
                return false;
            }
            else
                user.Name = name;
            await Console.Out.WriteLineAsync("write email:");
            var email = await Console.In.ReadLineAsync();
            bool resEmail = checkUser.CheckEmailAsync(email).Result;
            if (!resName)
            {
                await Console.Out.WriteLineAsync("Ivalid Email");
            }
            else user.Email = email;
            await Console.Out.WriteLineAsync("write password:");
            var password = await Console.In.ReadLineAsync();
            bool resPass = checkUser.CheckPassword(password).Result;
            if (!resPass) 
            {
                await Console.Out.WriteLineAsync("Ivalid Password");
            }
            else user.Password = password;
            await Console.Out.WriteLineAsync("write login:");
            var login = await Console.In.ReadLineAsync();
            bool resLog = checkUser.CheckLogin(login);
            if(!resLog)
            {
                await Console.Out.WriteLineAsync("Invalid Login");
            }
            else user.Login = login;
            await Console.Out.WriteLineAsync("write Age:");
            var age = await Console.In.ReadLineAsync();
            bool resAge = checkUser.CheckAge(age);
            if (!resAge)
            {
                await Console.Out.WriteLineAsync("Invalid Age");
                return false;
            }
            else user.Age = Convert.ToByte(age);
            return true;
        }
    }
}
