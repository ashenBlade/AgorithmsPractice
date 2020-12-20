using System.IO;
using LiteDB;

namespace WorkoutApp.Controller
{
    public class DatabaseDataManager<T> : IFileDataManager<T> where T : class
    {
        public void Save(string filename, T obj)
        {
            if (filename == null || obj == null)
                return;
            using var db = new LiteDatabase(filename);
            var table = db.GetCollection<T>();
            table.Upsert(obj);
        }

        public T Load(string filename)
        {
            if (filename == null)
                return default;
            using var db = new LiteDatabase(filename);
            if (File.Exists(filename))
                return db.GetCollection<T>()?.FindAll() as T;
            return null;
        }
    }
}