using Dapper;
using System.Data;
using SystemAuthenticator.Domain.Entities;
using SystemAuthenticator.Domain.Interfaces;
using SystemAuthenticator.Infra.Data.Repositories.QueryBuilders;

namespace SystemAuthenticator.Infra.Data.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IDbConnection _db;

    public UserRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<UserEntity> AddAsync(UserEntity user)
    {
        var parameters = new
        {
            user.Name,
            user.Email,
            user.PasswordHash,
            user.PasswordSalt
        };

       return await _db.QuerySingleAsync<UserEntity>(UserQueryBuilder.Insert, parameters);
    }

    public Task<bool> Exists(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(string email)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UserEntity user)
    {
        throw new NotImplementedException();
    }
}
