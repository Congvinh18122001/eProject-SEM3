using Project.Core.Objects;

namespace Project.Core.Models
{
    public interface IUserAccount
    {
        User GetUser(int Id);
        void UpdateUser(User user);
    }
}
