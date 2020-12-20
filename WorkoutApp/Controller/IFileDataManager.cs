namespace WorkoutApp.Controller
{
    public interface IFileDataManager<T> where T: class
    {
        void Save(string filename, T obj);
        T Load(string filename);
    }
}