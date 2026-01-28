using FinanceAI.Application.Dtos.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Interfaces
{
    public interface ITransactionService
    {
        Task CreateTransactionAsync(TransactionCreateDto dto);
    }
}
