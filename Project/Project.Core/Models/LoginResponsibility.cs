using Project.Core.Objects;
using System.Linq;

namespace Project.Core.Models
{
    public class LoginResponsibility : ILogin
    {
        CompanyDbContext context = new CompanyDbContext();

        public User GetUser(string email, string password)
        {
            return context.Users.SingleOrDefault(p=>p.Password==password&&p.Email==email);
        }
    }
}
