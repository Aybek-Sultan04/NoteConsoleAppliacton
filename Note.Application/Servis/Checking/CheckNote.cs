using Note.Application.Servis.IChecking;
using Note.Domain.States;

namespace Note.Application.Servis.Checking
{
    public class CheckNote : INote
    {
        public bool CheckNoteId(string id)
        {
            Guid idValue;
            if (!Guid.TryParse(id, out idValue))
                return false;
            return true;
        }

        public NoteEnum CheckNoteType(string type)
        {
            NoteEnum noteEnum;
            if (!Enum.TryParse(type, out noteEnum))
                return NoteEnum.Others;
            return noteEnum;
        }
    }
}
