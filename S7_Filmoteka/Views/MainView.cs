using S7_Filmoteka.Commands;

namespace S7_Filmoteka.Views
{
    public class MainView : IView
    {
        public object? Data { get; set; }

        public void Show()
        {
            new ShowCommandComponent(new AuthCommands()).Show();
        }
    }
}
