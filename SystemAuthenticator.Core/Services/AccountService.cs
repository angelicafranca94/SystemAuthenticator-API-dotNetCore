using System.Net;
using SystemAuthenticator.Core.DTOs;
using SystemAuthenticator.Core.Interfaces.Factories;
using SystemAuthenticator.Core.Interfaces.Mapper;
using SystemAuthenticator.Core.Interfaces.Services;
using SystemAuthenticator.Core.Interfaces.Utils;
using SystemAuthenticator.Domain.Account;
using SystemAuthenticator.Domain.Entities;
using SystemAuthenticator.Domain.Interfaces;
using SystemAuthenticator.Infra.Helpers.Constants;

namespace SystemAuthenticator.Core.Services;
public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticate _authenticateService;
    private readonly IMapper _mapper;
    private readonly IGenerateResponseUtil _generateResponseUtil;
    private readonly IVerifierFactory _verifierFactory;
    private readonly IGenerateHashAndSaltFactory _generateHashAndSaltFactory;

    public AccountService(IUserRepository userRepository, IAuthenticate authenticateService, IMapper mapper,
        IGenerateResponseUtil generateResponseUtil, IVerifierFactory verifierFactory, IGenerateHashAndSaltFactory generateHashAndSaltFactory)
    {
        _userRepository = userRepository;
        _authenticateService = authenticateService;
        _mapper = mapper;
        _generateResponseUtil = generateResponseUtil;
        _verifierFactory = verifierFactory;
        _generateHashAndSaltFactory = generateHashAndSaltFactory;
    }

    public async Task<NotificationResultDto<UserDto>> RegisterAsync(UserDto userDto)
    {

        var verifierService = _verifierFactory.Create<UserDto>();
        var verify = verifierService.Execute(userDto);

        if (!verify.Success) return verify;

        var userEntity = await _userRepository.GetByEmailAsync(userDto.Email);

        if (userEntity is not null) return new NotificationResultDto<UserDto>(false, NotificationsConstants.UserAlreadyRegistered, string.Empty, HttpStatusCode.BadRequest, null);

        userEntity = _generateHashAndSaltFactory.GenerateHashAndSalt(userDto);

        userEntity = await _userRepository.AddAsync(userEntity);

        var token = _authenticateService.GenerateToken(userEntity.Id, userEntity.Email, userEntity.IsAdmin);

        return new NotificationResultDto<UserDto>(true, NotificationsConstants.UserRegisteredSuccessfully, token, HttpStatusCode.OK, _mapper.MapToUserDto(userEntity));
    }

    public async Task<NotificationResultDto<LoginDto>> LoginAsync(LoginDto loginDto)
    {

        var verifierService = _verifierFactory.Create<LoginDto>();

        var verify = verifierService.Execute(loginDto);

        if (!verify.Success) return verify;

        var userEntity = await _userRepository.GetByEmailAsync(loginDto.Email);

        if (userEntity is null) return new NotificationResultDto<LoginDto>(false, NotificationsConstants.UserNotFound, string.Empty, HttpStatusCode.BadRequest, null);

        var userAuthenticate = await _authenticateService.AuthenticateAsync(loginDto.Email, loginDto.Password);

        if (!userAuthenticate) return new NotificationResultDto<LoginDto>(false, NotificationsConstants.InvalidEmailOrPassword, string.Empty, HttpStatusCode.Unauthorized, null);

        var token = _authenticateService.GenerateToken(userEntity.Id, userEntity.Email, userEntity.IsAdmin);

        return new NotificationResultDto<LoginDto>(true, string.Empty, token, HttpStatusCode.OK, null);
    }







    public Task<UserEntity> UpdateAccountAsync(UpdateAccountDto updateAccountDto)
    {
        throw new NotImplementedException();
    }

    // Implementação dos métodos da interface
    public Task ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
    {
        throw new NotImplementedException();
    }

}

