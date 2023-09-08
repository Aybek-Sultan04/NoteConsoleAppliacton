using Note.Domain.States;

namespace Note.Domain.Models
{
    public class Note
    {
        public Guid UserID { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public bool IsComplitet { get; set; } = false;
        public NoteEnum Type { get; set; } = NoteEnum.Others;
        public override string ToString()
        {
            return $"Note Id: {Id} | Title: {Title} | Create Date: {CreationDate} | Is complited: {IsComplitet} | Type: {Type}";
        }
    }

}
