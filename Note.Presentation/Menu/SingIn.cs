using Note.Application.Servis;
using Note.Application.Servis.Checking;
using Note.Domain.Models;
using Note.Infrastructure.DbServices;

namespace Note.Presentation.Menu
{
    internal class SingIn
    {
        public void InnerId()
        {
            Console.Clear();
            Console.Write("Enter ID:");
            string id = Console.ReadLine() ?? String.Empty;
            Guid userId;
            if (Guid.TryParse(id, out userId))
            {
                UserServices userServices = new UserServices();
                bool check = userServices.CheckUserAsync(userId).Result;
                if (check)
                {
                    MenuSing(ref userId);
                }
                else
                {
                    Console.WriteLine("User not found!");
                }
            }
            else Console.WriteLine("Wrong Id try again");
        }
        private void MenuSing(ref Guid UserId)
        {
            NoteService noteService = new NoteService();
            bool move = true;
            while (move)
            {
                Console.Clear();
                Console.WriteLine("1.Add new note\n2.Show all note\n3.update note\n4.delete note\n5.Edit my accaunt\n6.Back");
                string action = Console.ReadLine() ?? "7";
                Console.Clear();
                if (action == "1")
                {
                    CRUDNote Servicenote = new CRUDNote();
                    Domain.Models.Note note = new();
                    note = Servicenote.Create(ref UserId);
                    bool result = noteService.CreateNote(note).Result;
                    if (result)
                    {
                        Console.WriteLine("Note has created =)");
                    }
                    else
                    {
                        Console.WriteLine("Note Has't created\nPlease try again...");
                    }
                }
                else if (action == "2")
                {
                    IEnumerable<Domain.Models.Note> notes = noteService.GetAll(UserId).Result;
                    foreach (var note in notes)
                        Console.WriteLine(note.ToString());
                    Console.ReadKey();
                }
                else if (action == "3")
                {
                    CheckNote checkNote = new CheckNote();
                    Console.Write("Write Note id: ");
                    var noteId = Console.ReadLine() ?? String.Empty;
                    bool checkId = checkNote.CheckNoteId(noteId);
                    if (checkId)
                    {
                        Guid idValue;
                        Guid.TryParse(noteId, out idValue);
                        Domain.Models.Note note = noteService.GetById(idValue).Result;
                        if (note.Title == String.Empty)
                            Console.WriteLine("This note not found!\nTry again...");
                        else
                        {
                            bool res = noteService.UpdateNote(note).Result;
                            Console.WriteLine("Completed successfully!");
                        }
                    }
                    else { Console.WriteLine("Wrong Id"); }
                }
                else if (action == "4")
                {
                    CheckNote checkNote = new CheckNote();
                    Console.Write("Write Note id: ");
                    Guid Id;
                    var noteId = Console.ReadLine() ?? String.Empty;
                    bool checkId = checkNote.CheckNoteId(noteId);
                    if (checkId)
                    {
                        Guid.TryParse(noteId, out Id);
                        bool res = noteService.DeleteNote(Id).Result;
                        if (res)
                            Console.WriteLine("Delete successfully!");
                        else
                            Console.WriteLine("This note not found!\nTry again...");
                    }
                    else { Console.WriteLine("Wrong Id"); }
                }
                else if (action == "5")
                {
                    UserServices userServices = new UserServices();
                    User user = userServices.GetUserByIdAsync(UserId).Result;
                    if (user != null)
                    {
                        bool res = userServices.UpdateUserAsync(user).Result;
                        if (res)
                        {
                            Console.WriteLine("Something went wrong\nTry again...");
                        }
                        else Console.WriteLine("Completed successfully!");
                    }
                    else Console.WriteLine("Something went wrong\nTry again...");
                }
                else if (action == "6")
                    move = false;
                else
                {
                    Console.WriteLine("No such options\nTry again...");
                }
                Console.ReadKey();
            }
        }
    }
}
