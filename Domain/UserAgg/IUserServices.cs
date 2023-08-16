using Domain.UserAgg;
using System.Linq.Expressions;

namespace Domain.UserAgg;

public interface IUserServices
{
    List<User> SelectAllUsers();
    List<User> SelectAllUsers(Expression<Func<User, bool>> expression);
    User FindUser(Expression<Func<User, bool>> expression);
    bool DeleteUser(int UserId);
    bool AddUser(User user);
    bool Update(User user);
}
