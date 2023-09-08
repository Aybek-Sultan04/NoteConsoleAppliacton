namespace Note.Application.Exeption
{
    public class IvalidEmailException:Exception
    {
        public IvalidEmailException()
        {
        }
        public IvalidEmailException(string message)
             : base(message)
        {

        }
        public IvalidEmailException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
