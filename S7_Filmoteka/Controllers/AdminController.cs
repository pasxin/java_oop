using System.ComponentModel;
using S7_Filmoteka.Models;
using S7_Filmoteka.Repository;
using S7_Filmoteka.Views;

namespace S7_Filmoteka.Controllers
{
    internal class AdminController : IController
    {
        private readonly AdminMenuCommand _command;
        private readonly IMovieRepo _movieRepo = Settings.MovieRepo;
        public AdminController(AdminMenuCommand command)
        {
            _command = command;
        }
        public void Execute()
        {
            switch (_command)
            {
                case AdminMenuCommand.Add:
                    Add();
                    break;
                case AdminMenuCommand.Change:
                    Change();
                    break;
                case AdminMenuCommand.Remove:
                    Remove();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Remove()
        {
            var movie = FindMovie();
            _movieRepo.RemoveMovie(movie.Name);
        }

        private void Change()
        {
            var view = new MovieEditorView();
            view.Data = FindMovie();
            view.Show();
            
            _movieRepo.AddMovie(view.Data as Movie);
        }

        private void Add()
        {
            var view = new MovieEditorView();
            view.Show();

            _movieRepo.AddMovie(view.Data as Movie);
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
