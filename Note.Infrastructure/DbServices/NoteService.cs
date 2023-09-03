using Note.Application.Service;
using Note.Application.Servis;

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
            string command
        }

        public  Task<bool> DeleteNote(Guid noteId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Models.Note>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Models.Note> GetById(Guid noteId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNote(Domain.Models.Note note)
        {
            throw new NotImplementedException();
        }
    }
}
