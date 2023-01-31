using System.Data;
using S7_Filmoteka.Controllers;
using S7_Filmoteka.Models;

namespace S7_Filmoteka.Commands
{
    public class BaseCommand
    {
        private readonly IController _ctrl;
        public string Description { get; }
        public Role Role { get; } 
        public BaseCommand(string description, IController ctrl, Role role = Role.User)
        {
            Description = description;
            _ctrl = ctrl;
            Role = role;
        }

        public virtual void Execute()
        {
            _ctrl.Execute();
        }
    }
}
