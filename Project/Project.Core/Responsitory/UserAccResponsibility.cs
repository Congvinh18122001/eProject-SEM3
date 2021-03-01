using Project.Core.Objects;
using System;
using System.Linq;

namespace Project.Core.Models
{
    public class UserAccResponsibility : IUserAccount
    {
        CompanyDbContext context = new CompanyDbContext();
        public User GetUser(int Id)
        {
            return context.Users.Single(p=>p.Id==Id);
        }

        public void UpdateUser(User user)
        {
            User GetUser = context.Users.Single(p=>p.Id==user.Id);
            GetUser.Avatar = user.Avatar;
            GetUser.Email = user.Email;
            if (!String.IsNullOrEmpty(user.Password))
            {
                GetUser.Password = user.Password;
            }
            context.SaveChanges();
        }
    }
}
