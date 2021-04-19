using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FictionLogicLayer.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(string email, string userName, string password);
        Task<SignInResult> Authenticate(string email, string password);
        Task<SignInResult> AuthenticateAndRemember(string email, string password);
        void Logout();
    }
}
