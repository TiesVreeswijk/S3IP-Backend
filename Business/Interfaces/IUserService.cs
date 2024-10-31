using Business.Dtos.RequestDtos;
using Business.Entities;

namespace Business.Interfaces;

public interface IUserService
{
    User GetUserById(int id);
    User RegisterUser(RegisterReq registerReq);
    string LoginUserReturnToken(LoginReq loginReq);
    User GetUserByEmail(string email);
    List<User> GetAllUsers();
    List<User> GetAllUsersExceptCurrentUser(int currentUserId);
}