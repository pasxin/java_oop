using S7_Filmoteka.Models;

namespace S7_Filmoteka.Repository
{
    public class MovieRepo : IMovieRepo
    {
        public bool RentMovie(int userId, int moviePrice)
        {
            var data = DataLoader.Load();

            var usr = data.Users.Single(x => x.Id == userId);

            if (usr.FilmRented >= Settings.MaxMoviesInRent)
                return false;

            if (usr.Balance < moviePrice)
                return false;

            usr.Balance -= moviePrice;
            usr.FilmRented += 1;

            DataLoader.Save(data);

            return true;
        }

        public void ReturnMovie(int userId)
        {
            var data = DataLoader.Load();

            var usr = data.Users.Single(x => x.Id == userId);

            usr.FilmRented -= 1;

            DataLoader.Save(data);
        }

        public Movie? GetMovie(string movieName)
        {
            var data = DataLoader.Load();

            return data.Movies.SingleOrDefault(x => x.Name == movieName && x.IsAvailable == true);
        }

        public void AddMovie(Movie movie)
        {
            var data = DataLoader.Load();

            var mv = data.Movies.SingleOrDefault(x => x.Name == movie.Name);
            if (mv != null)
            {
                mv.Name = movie.Name;
                mv.Description = movie.Description;
                mv.Price = movie.Price;
                mv.IsAvailable = movie.IsAvailable;
            }
            else
                data.Movies.Add(movie);

            DataLoader.Save(data);
        }

        public void RemoveMovie(string movieName)
        {
            var data = DataLoader.Load();

            var mv = data.Movies.SingleOrDefault(x => x.Name == movieName);

            if (mv != null)
                mv.IsAvailable = false;

            DataLoader.Save(data);
            
        }
    }
}
