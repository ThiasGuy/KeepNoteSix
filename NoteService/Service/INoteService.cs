using NoteService.Entities;

namespace NoteService.Service
{
    public interface INoteService
    {

        bool CreateNote(Note note);
        bool DeleteNote(string userId, int noteId);
        Note UpdateNote(int noteId, string userId, Note note);
        Note GetNoteByNoteId(string userId, int noteId);
        List<Note> GetAllNotesByUserId(string userId);
    }
}
