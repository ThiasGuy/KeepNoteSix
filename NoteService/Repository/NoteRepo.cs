using MongoDB.Driver;
using NoteService.Entities;

namespace NoteService.Repository
{
    public class NoteRepo : INoteRepo
    {
        private readonly IMongoCollection<NoteUser> _notes;
        public NoteRepo(INoteStoreDatabaseSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            _notes = database.GetCollection<NoteUser>("NoteUser");
        }
        public bool CreateNote(Note note)
        {
            var notes = _notes.Find(x => x.UserId == note.CreatedBy).FirstOrDefault();
            if (notes == null)
            {
                _notes.InsertOne(new NoteUser() { UserId = note.CreatedBy, Notes = new List<Note> { note } });
                return true;
            }
            else
            {
                var filter = Builders<NoteUser>.Filter.Eq("UserId", note.CreatedBy);
                note.Id = notes.Notes?.LastOrDefault()?.Id == null ? 1 : notes.Notes.LastOrDefault().Id + 1;
                notes.Notes.Add(note);
                var result = _notes.ReplaceOne(filter, notes);
                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
        }

        public bool DeleteNote(string userId, int noteId)
        {
            var notes = _notes.Find(p => p.UserId == userId).FirstOrDefault();
            if (notes?.Notes == null)
            {
                return false;
            }

            var note = notes.Notes.Where(p => p.Id  == noteId).SingleOrDefault();
            if (note == null)
            {
                return false;
            }

            var filter = Builders<NoteUser>.Filter.Eq("UserId", userId);
            notes.Notes.Remove(note);
            var result = _notes.ReplaceOne(filter, notes);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public List<Note> FindAllNotesByUser(string userId)
        {
            var result = _notes.Find(p => p.UserId == userId).FirstOrDefault();
            if (result?.Notes == null)
            {
                return null;
            }
            else
            {
                return result.Notes;
            }
        }

        public Note GetNoteByNoteId(string userId, int noteId)
        {
            var notes = _notes.Find(p => p.UserId == userId).FirstOrDefault();
            if (notes?.Notes == null)
            {
                return null;
            }

            return notes.Notes.Where(p => p.Id == noteId).FirstOrDefault();
        }

        public bool UpdateNote(int noteId, string userId, Note note)
        {
            var notes = _notes.Find(p => p.UserId == userId).FirstOrDefault();
            if (notes?.Notes == null)
            {
                return false;
            }

            var noteValue = notes.Notes.Where(p => p.Id == noteId).FirstOrDefault();
            if (noteValue == null)
            {
                return false;
            }

            var filter = Builders<NoteUser>.Filter.Eq("UserId", userId);
            notes.Notes.Remove(noteValue);
            notes.Notes.Add(note);
            var result = _notes.ReplaceOne(filter, notes);

            return result.IsAcknowledged;
        }
    }
}
