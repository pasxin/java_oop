using S7_Filmoteka.Controllers;
using S7_Filmoteka.Models;

namespace S7_Filmoteka.Commands
{
    internal class UserCommands : ICommands
    {
        public string CommandsHeader => "Выберите действие:";
        public List<BaseCommand> GetCommands()
        {
            return new System.Collections.Generic.List<BaseCommand>()
            {
                new("Подать заявку на фильм", new UserController(UserMenuCommand.AddRequest)),
                new("Вернуть фильм", new UserController(UserMenuCommand.Return)),
                new("Добавить фильм", new AdminController(AdminMenuCommand.Add), Role.Admin),
                new("Изменить фильм", new AdminController(AdminMenuCommand.Change), Role.Admin),
                new("Удалить фильм", new AdminController(AdminMenuCommand.Remove), Role.Admin),
            };
        }
    }
}
