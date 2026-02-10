namespace FinanceAI.Application.Features.Incomes
{
    public class IncomeUpdateDto
    {
        public int Id { get; set; }
      
        public decimal Amount { get; set; }
        public DateTime IncomeDate { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }
}
