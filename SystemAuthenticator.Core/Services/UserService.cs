using System.Net;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Factories;
using SystemAuthenticator.Core.Interfaces.Mapper;
using SystemAuthenticator.Core.Interfaces.Services;
using SystemAuthenticator.Core.Interfaces.Utils;
using SystemAuthenticator.Domain.Interfaces;
using SystemAuthenticator.Infra.Helpers.Constants;

namespace SystemAuthenticator.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IGenerateResponseUtil _generateResponseUtil;
    private readonly IVerifierFactory _verifierFactory;
    private readonly IGenerateHashAndSaltFactory _generateHashAndSaltFactory;

    public UserService(IUserRepository userRepository, IMapper mapper, IGenerateResponseUtil generateResponseUtil,
    IVerifierFactory verifierFactory, IGenerateHashAndSaltFactory generateHashAndSaltFactory)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _generateResponseUtil = generateResponseUtil;
        _verifierFactory = verifierFactory;
        _generateHashAndSaltFactory = generateHashAndSaltFactory;
    }

    public async Task<NotificationResultDto<UserDto>> AddAsync(UserDto userDto)
    {
        var verifierService = _verifierFactory.Create<UserDto>();

        var verify = verifierService.Execute(userDto);
        if (!verify.Success) return verify;

        var userEntity = await _userRepository.GetByEmailAsync(userDto.Email);

        if (userEntity is not null) return new NotificationResultDto<UserDto>(false, NotificationsConstants.UserAlreadyRegistered, string.Empty, HttpStatusCode.BadRequest, null);

        userEntity = _generateHashAndSaltFactory.GenerateHashAndSalt(userDto);

        var userNew = await _userRepository.AddAsync(userEntity);

        return _generateResponseUtil.GenerateResponse<UserDto>(_mapper.MapToUserDto(userNew));
    }

    public async Task<IEnumerable<NotificationResultDto<UserDto>>> GetAllAsync()
    {
        var usersEntity = await _userRepository.GetAllAsync();
        
        var usersDto = _mapper.MapToUserDto(usersEntity);

        return usersDto.Select(user => _generateResponseUtil.GenerateResponse(user));
    }

    public Task<UserDto> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<NotificationResultDto<UserDto>> GetByIdAsync(int id)
    {
        var userentity = await _userRepository.GetByIdAsync(id);

        return _generateResponseUtil.GenerateResponse<UserDto>(_mapper.MapToUserDto(userentity));
    }

    public async Task RemoveAsync(int id)
    {
        await _userRepository.RemoveAsync(id);
    }

    public async Task<NotificationResultDto<UserDto>> UpdateAsync(UserDto userDto)
    {
        var verifierService = _verifierFactory.Create<UserDto>();

        var verify = verifierService.Execute(userDto);
        if (!verify.Success) return verify;

        var userentity = await _userRepository.Update(_mapper.MapToUserEntity(userDto));

        return _generateResponseUtil.GenerateResponse<UserDto>(_mapper.MapToUserDto(userentity));
    }



}
