using System.Threading.Tasks;
namespace Note.Application.Service
{
    public interface INoteService
    {
        Task<bool> CreateNote(Domain.Models.Note note);
        Task<bool> UpdateNote(Domain.Models.Note note);
        Task<bool> DeleteNote(Guid noteId);
        Task<IEnumerable<Domain.Models.Note>> GetAll(Guid userId);
        Task<Domain.Models.Note> GetById(Guid noteId);
    }
}
