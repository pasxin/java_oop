using S7_Filmoteka.Controllers;
using S7_Filmoteka.Models;

namespace S7_Filmoteka.Commands
{
    internal class AuthCommands : ICommands
    {
        public string CommandsHeader  => "Авторизация";

        public List<BaseCommand> GetCommands()
        {
            return new List<BaseCommand>()
            {
                new BaseCommand("Войти", new AuthController(AuthType.Login)),
            };
        }
    }
}
