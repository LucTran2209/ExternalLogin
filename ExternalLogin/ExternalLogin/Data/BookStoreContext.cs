using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExternalLogin.Data
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> opt) : base(opt)
        {

        }

        #region
        #endregion
    }
}
