namespace Note.Infrastructure.DbConfiguration
{
    public class GetConfigFromDb
    {
        public static string GetConnect()
        {
            string? config = File.ReadAllText(@"C:\Users\AYBEK\Desktop\C# Home task\NoteConsoleAppliacton\Note.Infrastructure\DbConfiguration\DbConfig.txt");
            return config;
        }
    }
}
