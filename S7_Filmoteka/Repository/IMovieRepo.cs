using S7_Filmoteka.Models;

namespace S7_Filmoteka.Repository
{
    public interface IMovieRepo
    {
        bool RentMovie(int userId, int moviePrice);
        void ReturnMovie(int userId);
        Movie? GetMovie(string movieName);
        void AddMovie(Movie movie);
        void RemoveMovie(string movieName);

    }
}
