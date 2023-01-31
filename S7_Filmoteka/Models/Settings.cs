using S7_Filmoteka.Repository;

namespace S7_Filmoteka.Models
{
    public static class Settings
    {
        public static int MaxMoviesInRent => 10;
        public static IUserRepo UserRepo => new UserRepo();
        public static IMovieRepo MovieRepo => new MovieRepo();
    }
}
