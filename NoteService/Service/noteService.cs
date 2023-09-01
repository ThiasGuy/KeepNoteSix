using NoteService.Entities;
using NoteService.Exceptions;
using NoteService.Repository;

namespace NoteService.Service
{
    public class noteService : INoteService
    {
        private readonly INoteRepo _repo;
        public noteService(INoteRepo repo)
        {
            _repo = repo;
        }

        public bool CreateNote(Note note)
        {
            var result = _repo.CreateNote(note);
            if (!result)
            {
                throw new NoteAlreadyExistsException("User Already exists");
            }

            return result;
        }

        public bool DeleteNote(string userId, int noteId)
        {
            var result = _repo.DeleteNote(userId, noteId);
            if (!result)
            {
                throw new NoteNotFoundException($"NoteId {noteId} for user {userId} does not exist");
            }

            return result;
        }

        public List<Note> GetAllNotesByUserId(string userId)
        {
            var result = _repo.FindAllNotesByUser(userId);
            if (result == null)
            {
                throw new NoteNotFoundException("");
            }
            return result;
        }

        public Note GetNoteByNoteId(string userId, int noteId)
        {
            var result = _repo.GetNoteByNoteId(userId, noteId);
            if (result == null)
            {
                throw new NoteNotFoundException("");
            }

            return result;
        }

        public Note UpdateNote(int noteId, string userId, Note note)
        {
            var result = _repo.UpdateNote(noteId, userId, note);
            if (!result)
            {
                throw new NoteNotFoundException($"NoteId {noteId} for user {userId} does not exist");
            }

            return note;
        }
    }
}
