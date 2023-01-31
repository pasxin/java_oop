using S7_Filmoteka.Commands;
using S7_Filmoteka.Controllers;
using S7_Filmoteka.Models;

namespace S7_Filmoteka.Views
{
    public class ShowCommandComponent : IView
    {
        private readonly ICommands _commands;

        public ShowCommandComponent(ICommands commands)
        {
            _commands = commands;
        }

        public object? Data { get; set; }

        public void Show()
        {
            if(_commands == default || !_commands.GetCommands().Any())
                return;
            if(!string.IsNullOrEmpty(_commands.CommandsHeader))
                Console.WriteLine(_commands.CommandsHeader);
            
            var commands = _commands.GetCommands();
            
            if (App.LoggedUser is not { Role: Role.Admin })
                commands = commands.Where(x => x.Role != Role.Admin).ToList();

            for (int i = 1; i <=  commands.Count; i++)
            {
                Console.WriteLine($"{i} - {commands[i-1].Description}");
            }

            var choise = Console.ReadKey();
            Console.WriteLine();

            if (char.IsDigit(choise.KeyChar) && int.Parse(choise.KeyChar.ToString()) <= commands.Count)
            {
                commands[int.Parse(choise.KeyChar.ToString()) - 1].Execute();
                return;
            }
            Console.WriteLine("Неправильный ввод, попробуйте снова");
            Show();
        }
    }
}
