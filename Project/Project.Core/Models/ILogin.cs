using Project.Core.Objects;

namespace Project.Core.Models

{
    public interface ILogin
    {
        User GetUser(string email,string password);
    }
}
