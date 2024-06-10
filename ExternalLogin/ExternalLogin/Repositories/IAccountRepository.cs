using ExternalLogin.Models;
using Microsoft.AspNetCore.Identity;

namespace ExternalLogin.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);

        public Task<string> SignInAsync(SignInModel model);
    }
}
