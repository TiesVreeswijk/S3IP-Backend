using Business.Repositories;
using Business.Entities;
using Business.Exceptions;

namespace DAL.Repositories;

public class UserRepository(MyDbContext context) : IUserRepository
{ 
    public User CreateUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return context.Users.FirstOrDefault(u => u.Id == user.Id) ?? throw new ResourceNotFoundException($"User with id:{user.Id} not found");
    }

    public User? GetUserById(int id)
    {
        return context.Users.FirstOrDefault(u => u.Id == id);
    }
    
    public User? GetUserByUsername(string username)
    {
        return context.Users.FirstOrDefault(u => u.Username == username);
    }
    public List<User> GetAllUsers()
    {
        return context.Users.ToList();
    }
}

