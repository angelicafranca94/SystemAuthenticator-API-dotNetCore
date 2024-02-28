using Dapper;
using System.Data;
using SystemAuthenticator.Domain.Entities;
using SystemAuthenticator.Domain.Interfaces.Repositories;
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
            user.PasswordSalt,
            user.RoleUser,
        };

        return await _db.QuerySingleAsync<UserEntity>(UserQueryBuilder.Insert, parameters);
    }

    public Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return _db.QueryAsync<UserEntity>(UserQueryBuilder.GetAll);
    }

    public async Task<UserEntity> GetByEmailAsync(string email)
    {
        return await _db.QueryFirstOrDefaultAsync<UserEntity>(UserQueryBuilder.GetByEmail, new { Email = email });
    }

    public async Task<UserEntity> GetByIdAsync(int id)
    {
        return await _db.QueryFirstOrDefaultAsync<UserEntity>(UserQueryBuilder.GetById, new { Id = id });
    }

    public async Task RemoveAsync(int id)
    {
        await _db.ExecuteAsync(UserQueryBuilder.Delete, new { Id = id });
    }

    public async Task<UserEntity> Update(UserEntity user)
    {
        var parameters = new
        {
            user.Id,
            user.Name,
            user.Email,
            user.PasswordHash,
            user.PasswordSalt,
            user.RoleUser,
        };

        return await _db.QuerySingleAsync<UserEntity>(UserQueryBuilder.Update, parameters);
    }
}
