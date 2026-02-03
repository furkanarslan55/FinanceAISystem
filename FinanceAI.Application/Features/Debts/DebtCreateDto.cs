using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.Debts
{
    public class DebtCreateDto
    {


        public string Name { get; set; }
        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set;  }

        public int DebtCategoryId { get; set; }


    }
}
