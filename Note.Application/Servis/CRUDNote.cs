using Note.Application.Servis.Checking;

namespace Note.Application.Servis
{
    public class CRUDNote
    {
        public Domain.Models.Note Create(ref Guid UserId)
        {
            Console.Clear();
            CheckNote checkNote = new CheckNote();
            Domain.Models.Note note = new Domain.Models.Note();
            note.UserID = UserId;
            note.Id = Guid.NewGuid();
            note.CreationDate = DateTime.Now;
            Console.WriteLine("Title:");
            string title = Console.ReadLine() ?? String.Empty;
            note.Title = title;
            note.IsComplitet = false;
            Console.Clear();
            Console.WriteLine("1.HomeTasks\n2.WorkTasks\n3.Education\n4.Money\n5.Hobby\n6.Others");
            var type = Console.ReadLine() ?? "Others";
            if (type == "1")
                note.Type = checkNote.CheckNoteType("HomeTasks");
            else if (type == "2")
                note.Type = checkNote.CheckNoteType("WorkTasks");
            else if (type == "3")
                note.Type = checkNote.CheckNoteType("Education");
            else if (type == "4")
                note.Type = checkNote.CheckNoteType("Money");
            else if (type == "5")
                note.Type = checkNote.CheckNoteType("Hobby");
            else if (type == "6")
                note.Type = checkNote.CheckNoteType("Others");
            else
                note.Type = checkNote.CheckNoteType("Others");
            return note;

        }
    }
}
