using SystemAuthenticator.Core.Interfaces.Utils;

namespace SystemAuthenticator.Core.Interfaces.Factories;
public interface IVerifierFactory
{
    IVerifierNotificationUtil<T> Create<T>() where T : class;
}
