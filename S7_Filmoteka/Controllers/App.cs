using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7_Filmoteka.Models;
using S7_Filmoteka.Views;

namespace S7_Filmoteka.Controllers
{
    public class App
    {
        public static User? LoggedUser { get; set; }

        public void Run()
        {
            try
            {
                if (IsUserValid() == false)
                    throw new ArgumentException("Пользователь не найден");

                new UserView().Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Run();
            }
        }

        private bool IsUserValid()
        {
            if (LoggedUser != null)
                return true;
            new MainView().Show();

            return LoggedUser != null;
        }
    }
}
