namespace S7_Filmoteka.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public int FilmRented { get; set; }
        public int Balance { get; set; }

    }
}
