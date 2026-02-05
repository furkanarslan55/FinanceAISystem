namespace UI.Models.ViewModel.Income
{
    public class IncomeCreateDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }    

        public int IncomeCategoryId { get; set; }
    }
}
