using S7_Filmoteka.Models;
using System.Text.Json;

namespace S7_Filmoteka.Repository
{
    internal class DataLoader
    {
        private static readonly FileInfo _file = new("Db.json");

        public static Data Load()
        {
            using var stream = _file.OpenRead();
            return JsonSerializer.Deserialize<Data>(stream)
                   ?? throw new InvalidOperationException();
        }

        public static void Save(Data movies)
        {
            FileInfo fi = new FileInfo("data.temp");
            using var stream = fi.OpenWrite();
            JsonSerializer.Serialize(stream, movies);
            stream.Close();
            File.Move(fi.FullName, _file.FullName, true);
        }
    }
}
