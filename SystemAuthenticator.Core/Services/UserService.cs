using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Mapper;
using SystemAuthenticator.Core.Interfaces.Services;
using SystemAuthenticator.Domain.Interfaces;

namespace SystemAuthenticator.Core.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IVerifierService<UserDto> _verifierService;

    public UserService(IUserRepository userRepository, IMapper mapper, IVerifierService<UserDto> verifierService
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _verifierService = verifierService;
    }

    public async Task<NotificationResultDto<UserDto>> AddAsync(UserDto user)
    {
       var verify =  _verifierService.Execute(user);

        if (!verify.Success) return verify;

        var userEntity = await _userRepository.AddAsync(_mapper.MapToUserEntity(user));

        return new NotificationResultDto<UserDto>(true, "Success", _mapper.MapToUserDto(userEntity));
    }

    public Task<bool> Exists(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(string email)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(UserDto user)
    {
        await _userRepository.Update(_mapper.MapToUserEntity(user));
    }



}
