namespace S7_Filmoteka.Views
{
    public interface IView
    {
        public object? Data { get; set; }
        public void Show();
    }
}
