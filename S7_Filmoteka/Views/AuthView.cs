using S7_Filmoteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7_Filmoteka.Views
{
    public class AuthView : IView
    {
        public object? Data { get; set; }

        public void Show()
        {
            Console.Write("Введите имя(User, Admin): ");
            Data = Console.ReadLine();
        }
    }
}
