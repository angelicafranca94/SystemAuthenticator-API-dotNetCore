using SystemAuthenticator.Domain.Entities;

namespace SystemAuthenticator.Domain.Interfaces;
public interface IUserRepository
{
    Task<UserEntity> AddAsync(UserEntity user);
    Task<UserEntity> GetByEmail(string email);
    Task<UserEntity> GetById(Guid id);
    Task Update(UserEntity user);
    Task<IEnumerable<UserEntity>> GetAll();
    Task Remove(Guid id);
    Task<bool> Exists(Guid id);
    Task<bool> Exists(string email);
}
