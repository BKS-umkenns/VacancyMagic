using System.Security.Principal;

namespace BKS.VacancyMagic.Backend.Models.Auth;

public class UserIdentity : IIdentity
{
    public string? AuthenticationType => "BksAuth";

    public bool IsAuthenticated => true;

    public string? Name => null;
}
