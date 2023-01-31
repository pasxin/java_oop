using S7_Filmoteka.Models;

namespace S7_Filmoteka.Views
{
    public class MovieRequestView : IView
    {
        public object? Data { get; set; }

        public void Show()
        {
            Console.Write("Введите название фильма: ");
            Data =  Console.ReadLine();
        }
    }
}
