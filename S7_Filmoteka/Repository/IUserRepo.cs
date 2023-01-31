using S7_Filmoteka.Models;

namespace S7_Filmoteka.Repository;

public interface IUserRepo
{
    User? GetUser(string userName);
    User? GetUser(int userId);
}