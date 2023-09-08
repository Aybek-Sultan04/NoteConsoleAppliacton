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
            string cmdText = $@"insert into note 
                                values('{note.UserID}','{note.Id}','{note.Title}',{note.IsComplitet},'{note.Type}','{note.CreationDate}');";
            int effectedRows = await _service.ExecuteCommandAsync(cmdText);
            return effectedRows > 0;
        }
        public async Task<bool> DeleteNote(Guid noteId)
        {
            string cmdText = $"delete from note where id = '{noteId}'";
            int effctedRows = await _service.ExecuteCommandAsync(cmdText);
            return effctedRows > 0;
        }
        public async Task<IEnumerable<Domain.Models.Note>> GetAll(Guid userId)
        {
            string cmdText = $"select * from note where userid = '{userId}'";
            var reder =  _service.ExecuteQuery(cmdText);
            return reder;
        }
        public async Task<Domain.Models.Note> GetById(Guid noteId)
        {
            string cmd = $"select * from note where id = '{noteId}'";
            var reder = _service.ExecuteQuery(cmd);
            var note = new Domain.Models.Note();
            foreach (var item in reder)
            {
                if(item.Id==noteId)
                    return item;
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
            DbContext dbContext = new ();
            string cmd = $"update note set title = '{note.Title}',iscomplitet = {note.IsComplitet}";
            int res = await dbContext.ExecuteCommandAsync(cmd);
            return res>0;
        }
    }
}
