using S7_Filmoteka.Commands;

namespace S7_Filmoteka.Views
{
    public class UserView : IView
    {
        public object? Data { get; set; }

        public void Show()
        {
            new ShowCommandComponent(new UserCommands()).Show();
        }
    }
}
