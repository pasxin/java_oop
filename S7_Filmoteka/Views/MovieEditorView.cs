using S7_Filmoteka.Models;

namespace S7_Filmoteka.Views
{
    public class MovieEditorView : IView
    {
        public object? Data { get; set; }
        private Movie _movie;
        public void Show()
        {
            if(Data == null)
                _movie = new Movie();
            else
                _movie = Data as Movie;
            EditName();
            EditDescription();
            EditPrice();
        }

        private void EditName()
        {
            if(!string.IsNullOrEmpty(_movie.Name))
                Console.WriteLine("Название: " + _movie.Name);
            Console.Write("Введите название: ");
            _movie.Name = Console.ReadLine();
        }

        private void EditDescription()
        {
            if (!string.IsNullOrEmpty(_movie.Description))
                Console.WriteLine("Описание: " + _movie.Description);
            Console.Write("Введите описание: ");
            _movie.Description = Console.ReadLine();
        }

        private void EditPrice()
        {
            if (_movie.Price > 0)
                Console.WriteLine("Цена: " + _movie.Price);
            Console.Write("Введите цену: ");
            _movie.Price = int.Parse(Console.ReadLine());
        }



    }
}
