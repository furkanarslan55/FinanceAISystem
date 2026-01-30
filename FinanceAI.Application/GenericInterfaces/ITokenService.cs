using FinanceAI.Application.Dtos.AppUser;
using FinanceAI.Core.Entities.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Interfaces
{
    public interface ITokenService
    {
        TokenResponseDto CreateToken(AppUser user);
    }
}
