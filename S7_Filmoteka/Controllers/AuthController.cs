using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7_Filmoteka.Models;
using S7_Filmoteka.Repository;
using S7_Filmoteka.Views;

namespace S7_Filmoteka.Controllers
{
    internal class AuthController : IController
    {
        private readonly AuthType _authType;
        private readonly IView _view;
        private readonly IUserRepo _userRepo = Settings.UserRepo;
        public AuthController(AuthType type)
        {
            _authType = type;
            _view = new AuthView();
        }
        public void Execute()
        {
            _view.Show();
            if (_view.Data == null)
            {
                Console.WriteLine("Ошибка входа");
                return;
            }

            App.LoggedUser = _userRepo.GetUser(_view.Data as string);
        }
    }
}
