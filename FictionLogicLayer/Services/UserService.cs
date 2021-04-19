using FictionDataLayer.Entity;
using FictionLogicLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FictionLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Author> _userManager;
        private readonly SignInManager<Author> _signInManager;

        public UserService(UserManager<Author> userManager, SignInManager<Author> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(string email, string userName, string password)
        {
            Author author = new Author { Email = email, UserName = userName };
            return await _userManager.CreateAsync(author, password);
        }
        public async Task<SignInResult> Authenticate(string email, string password)
        {
            return await _signInManager.PasswordSignInAsync(email, password, false, false);
        }

        public async Task<SignInResult> AuthenticateAndRemember(string email, string password)
        {
            return await _signInManager.PasswordSignInAsync(email, password, true, false);

        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
