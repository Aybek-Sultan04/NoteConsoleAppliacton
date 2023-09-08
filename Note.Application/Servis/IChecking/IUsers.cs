namespace Note.Application.Servis.IChecking
{
    interface IUsers
    {
        bool CheckId(string id);
        bool CheckName(string name);
        Task<bool> CheckPassword(string password);
        Task<bool> CheckEmailAsync(string email);
        bool CheckAge(string age);
        bool CheckLogin(string login);
    }
}
