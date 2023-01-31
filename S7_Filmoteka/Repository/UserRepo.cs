using S7_Filmoteka.Models;

namespace S7_Filmoteka.Repository
{
    internal class UserRepo : IUserRepo
    {
        public User? GetUser(string userName)
        {
            var data = DataLoader.Load();

            return data.Users.SingleOrDefault(x => x.Name == userName);
        }

        public User? GetUser(int userId)
        {
            var data = DataLoader.Load();

            return data.Users.SingleOrDefault(x => x.Id == userId);
        }
        
    }
}
