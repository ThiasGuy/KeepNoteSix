using NoteService.Entities;

namespace NoteService.Repository
{
    public interface INoteRepo
    {
        bool CreateNote(Note note);
        bool DeleteNote(string userId, int noteId);
        bool UpdateNote(int noteId, string userId, Note note);
        Note GetNoteByNoteId(string userId, int noteId);
        List<Note> FindAllNotesByUser(string userId);
    }
}
