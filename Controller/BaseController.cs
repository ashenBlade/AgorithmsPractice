using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WorkoutApp.Controller
{
    /// <summary>
    /// Contains generic methods to overload
    /// </summary>
    public class BaseController
    {
        /// <summary>
        /// Save object to file
        /// </summary>
        /// <param name="fileName"> File to save </param>
        /// <param name="itemToSave"> Item to save </param>
        protected void Save(string fileName, object itemToSave)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, itemToSave);
            }
        }

        /// <summary>
        /// Load object from file
        /// </summary>
        /// <param name="fileName"> File to read from </param>
        /// <typeparam name="T"> Type of object to load from file </typeparam>
        /// <returns> Serialized object or default(T) </returns>
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            return (0 < fs.Length && formatter.Deserialize(fs) is T t)
                       ? t
                       : default;

        }
    }
}