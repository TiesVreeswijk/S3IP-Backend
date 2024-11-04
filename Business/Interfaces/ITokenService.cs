using Business.Entities;

namespace Business.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);

}