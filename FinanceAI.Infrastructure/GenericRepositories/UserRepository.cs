using FinanceAI.Core.Entities.AppUserEntity;
using FinanceAI.Core.Interfaces;
using FinanceAI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
