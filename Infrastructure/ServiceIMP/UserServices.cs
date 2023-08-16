using Domain.UserAgg;
using System.Linq.Expressions;

namespace Infrastructure.ServiceIMP;

public class UserServices : IUserServices
{
    private Context _context;
    public UserServices(Context context)
    {
        _context = context;
    }
    public bool AddUser(User user)
    {
        _context.users.Add(user);
        var saved = _context.SaveChanges();
        if (saved == 1)
            return true;

        return false;
    }

    public bool DeleteUser(int UserId)
    {
        var users = FindUser(u => u.id == UserId);
        _context.users.Remove(users);
        var isSaved = _context.SaveChanges();
        if (isSaved == 1) return true;
        return false;
    }

    public User FindUser(Expression<Func<User, bool>> expression)
    {
        return _context.users.FirstOrDefault(expression);
    }

    public List<User> SelectAllUsers()
    {
        return _context.users.ToList();
    }

    public bool Update(User user)
    {
        _context.Update(user);
        var isSaved = _context.SaveChanges();
        if (isSaved == 1)
            return true;

        return false;
    }
    public List<User> SelectAllUsers(Expression<Func<User, bool>> expression)
    {
        return _context.users.Where(expression).ToList();
    }
}
