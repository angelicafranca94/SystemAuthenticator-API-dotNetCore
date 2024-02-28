using Microsoft.Extensions.DependencyInjection;
using SystemAuthenticator.Core.Interfaces.Factories;
using SystemAuthenticator.Core.Interfaces.Utils;

namespace SystemAuthenticator.Core.Factories;
public class VerifierFactory : IVerifierFactory
{
    private readonly IServiceProvider _serviceProvider;

    public VerifierFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IVerifierNotificationUtil<T> Create<T>() where T : class
    {
        return _serviceProvider.GetRequiredService<IVerifierNotificationUtil<T>>();
    }
}