using Note.Application.Exeption;
using Note.Application.Servis.IChecking;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Note.Application.Servis.Checking
{
    public class CheckUser : IUsers
    {
        public bool CheckAge(string age)
        {
            byte ageValue;
            if (!byte.TryParse(age, out ageValue))
            {
                throw new InvalidAgeException("Age must be a valid integer.");
            }
            if (ageValue < 0 || ageValue > 150)
            {
                throw new InvalidAgeException("Age must be between 0 and 150.");
            }
            return true;
        }
        public async Task<bool> CheckEmailAsync(string email)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            Regex regex = new Regex(pattern);
            MatchCollection match = await Task.Run(() => regex.Matches(email));
            if (match.Count > 0)
                return match.Count > 0;
            else
                throw new IvalidEmailException("Invalid Email");
        }

        public bool CheckId(string id)
        {
            Guid idValue;
            if(!Guid.TryParse(id,out idValue))
                return false;
            return true;
        }

        public bool CheckLogin(string login)
        {
            string pattern = @"^\S{5,50}$";
            Regex regex = new(pattern);
            MatchCollection match = regex.Matches(login);
            return match.Count > 0;
        }

        public bool CheckName(string name)
        {
            string pattern = @"^\S{2,30}$";
            Regex regex = new(pattern);
            MatchCollection match = regex.Matches(name);
            return match.Count > 0;
        }

        public async Task<bool> CheckPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,50}$";
            Regex regex = new Regex(pattern);
            MatchCollection match = await Task.Run(() => regex.Matches(password));
            return match.Count > 0;
        }
    }
}
