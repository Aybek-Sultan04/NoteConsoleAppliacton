using Note.Application.Service;
using Note.Application.Servis;
using Note.Domain.States;
using Npgsql;

namespace Note.Infrastructure.DbServices
{
    public class NoteService : INoteService
    {
        private INoteDbContext _service;
        public NoteService()
        {
            _service = new DbContext();
        }
        public async Task<bool> CreateNote(Domain.Models.Note note)
        {
            string cmdText = $@"insert into note(user_id,note_id,title,create_date,is_complitet,note_type) 
                                values({note.UserID},{note.Id},{note.Title},{note.CreationDate},{note.IsComplitet},{note.Type})";
            int effectedRows = await _service.ExecuteCommandAsync(cmdText);
            return effectedRows > 0;
        }
        public async Task<bool> DeleteNote(Guid noteId)
        {
            string cmdText = $"delete from note where note_id = {noteId}";
            int effctedRows = await _service.ExecuteCommandAsync(cmdText);
            return effctedRows > 0;
        }
        public async Task<IEnumerable<Domain.Models.Note>> GetAll()
        {
            string cmdText = "select * from note";
            NpgsqlDataReader reder = await _service.ExecuteQueryAsync(cmdText);
            ICollection<Domain.Models.Note> notes = new List<Domain.Models.Note>();
            while (reder.Read())
            {
                notes.Add(new()
                {
                    UserID = (Guid)reder[0],
                    Id = (Guid)reder[1],
                    Title = (string)reder[2],
                    CreationDate = (DateTime)reder[3],
                    IsComplitet = (bool)reder[4],
                    Type = (NoteEnum)reder[5]
                });
            }
            return notes;
        }
        public async Task<Domain.Models.Note> GetById(Guid noteId)
        {
            string cmd = $"select * from note ";
            var reder = await _service.ExecuteQueryAsync(cmd);
            var note = new Domain.Models.Note();
            while (reder.Read())
            {
                if ((Guid)reder[1] == noteId)
                {
                    note.UserID = (Guid)reder[0];
                    note.Id = (Guid)reder[1];
                    note.Title = (string)reder[2];
                    note.CreationDate = (DateTime)reder[3];
                    note.IsComplitet = (bool)reder[4];
                    note.Type = (NoteEnum)reder[5];
                }
            }
            if (note.Title == String.Empty || note.Title == null)
                Console.WriteLine("Not Found This Note");
            return note;
        }
        public async Task<bool> UpdateNote(Domain.Models.Note note)
        {
            Console.WriteLine("Write new title:");
            var title = await Console.In.ReadLineAsync();
            Console.WriteLine("Is Complitet?\n1.Yes\n2.No");
            var isComplitet = await Console.In.ReadLineAsync();
            note.Title = title ?? "Empty Body...";
            if (isComplitet == "1")
                note.IsComplitet = true;
            else
                note.IsComplitet = false;
            return true;
        }
    }
}
