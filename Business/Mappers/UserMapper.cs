using Business.Dtos.EntityDtos;
using Business.Dtos.RequestDtos;
using Business.Entities;

namespace Business.Mappers;

public static class UserMapper
{
    public static User RegisterDtoToUser(RegisterReq registerReq)
    {
        return new User
        {

            Username = registerReq.Username,
            Password = registerReq.Password,
            
        };
    }
    
    public static UserDto UserToUserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,

        };
    }
}