using Note.Domain.States;

namespace Note.Application.Servis.IChecking
{
    interface INote
    {
        bool CheckNoteId(string id);
        NoteEnum CheckNoteType(string type);
    }
}
