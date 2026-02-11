using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.AppUser
{
    public class TokenResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpireDate { get; set; }
    }
}
