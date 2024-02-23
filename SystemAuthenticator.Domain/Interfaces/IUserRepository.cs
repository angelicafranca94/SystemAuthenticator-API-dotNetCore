using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Domain.Interfaces;
public interface IUserRepository
{
    Task<UserEntity> AddAsync(UserEntity user);
    Task<UserEntity> GetByEmailAsync(string email);
    Task<UserEntity> GetByIdAsync(int id);
    Task<UserEntity> Update(UserEntity user);
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task RemoveAsync(int id);
}
