using S7_Filmoteka.Models;
using S7_Filmoteka.Repository;
using S7_Filmoteka.Views;

namespace S7_Filmoteka.Controllers
{
    internal class UserController : IController
    {
        private readonly UserMenuCommand _command;
        private readonly IMovieRepo _movieRepo = Settings.MovieRepo;
        public UserController(UserMenuCommand command)
        {
            _command = command;
        }
        public void Execute()
        {
            switch (_command)
            {
                case UserMenuCommand.AddRequest:
                    AddRequest();
                    break;
                case UserMenuCommand.Return:
                    Return();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddRequest()
        {
            var movie = FindMovie();
            if (_movieRepo.RentMovie(App.LoggedUser.Id, movie.Price))
                throw new MovieException("Фильм выдан");
            throw new MovieException("Фильм не может быть выдан проверьте баланс или количество фильмов в аренде");
        }

        private void Return()
        {
            var movie = FindMovie();
            _movieRepo.ReturnMovie(App.LoggedUser.Id);
        }

        private Movie FindMovie()
        {
            var view = new MovieRequestView();
            view.Show();
            if (view.Data == null)
                throw new MovieException("Отказ от ввода названия фильма");
            var movie = _movieRepo.GetMovie(view.Data as string);

            return movie ?? throw new MovieException("Фильм не найден");
        }
        
    }
}
