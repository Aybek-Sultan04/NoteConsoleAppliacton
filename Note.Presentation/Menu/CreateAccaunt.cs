using Note.Application.Servis.Checking;
using Note.Domain.Models;
using Note.Infrastructure.DbServices;

namespace Note.Presentation.Menu
{
    public class CreateAccaunt
    {
            CheckUser checkUser = new CheckUser();
            User user = new User();
        public bool Create()
        {
            Console.Clear();
            user.Id = Guid.NewGuid();
            Console.Write("Enter Name:");
            var name = Console.ReadLine();
            bool checkName = checkUser.CheckName(name);
            if (!checkName)
            {
                Console.WriteLine("Wrong name!!\nTry again");
                Console.ReadKey();
                Create();
            }
            else user.Name = name;
            Console.Write("Email:");
            var eamil = Console.ReadLine();
            bool checkEmail = checkUser.CheckEmailAsync(eamil).Result;
            if (!checkEmail)
            {
                user.Email = null;
                Console.WriteLine("Wrong Eamil!!\nTry again");
                Console.ReadKey();
            }
            else user.Email = eamil;
            Console.Write("Enter Password:");
            var password = Console.ReadLine();
            bool checkPass = checkUser.CheckPassword(password).Result;
            if (!checkPass)
            {
                Console.WriteLine("Wrong Password!!\nTry again");
                Console.ReadKey();
                Create();
            }
            else user.Password = password;
            Console.Write("Enter Login:");
            var login = Console.ReadLine();
            bool checkLog = checkUser.CheckLogin(login);
            if(!checkLog)
            {
                Console.WriteLine("Wrong Login!!\nTry again");
                Console.ReadKey();
                Create();
            }
            else user.Login = login;
            Console.Write("Enter Age:");
            var age = Console.ReadLine();
            bool checAge = checkUser.CheckAge(age);
            if(!checAge)
            {
                Console.WriteLine("Wrong Age!!\nTry again");
                Console.ReadKey();
                Create();
            }
            else user.Age = Convert.ToByte(age);
            UserServices services = new UserServices();
            bool res = services.AddUserAsync(user).Result;
            return res;
        }
    }
}
