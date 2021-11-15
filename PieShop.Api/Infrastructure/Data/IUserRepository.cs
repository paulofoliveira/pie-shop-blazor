using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PieShop.Api.Infrastructure.Data
{
    public interface IUserRepository
    {
        Task<User> FindByEmail(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly PieShopContext _context;

        public UserRepository(PieShopContext context)
        {
            _context = context;
        }

        public Task<User> FindByEmail(string email)
        {
            return _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
