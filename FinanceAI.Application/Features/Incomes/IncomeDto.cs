namespace FinanceAI.Business.Features.Incomes;

public record IncomeDto
{  
    
    public  int Id { get; init; }
    public decimal Amount { get; init; }
    public DateTime IncomeDate { get; init; }
    public string? Description { get; init; }
    public string CategoryName { get; init; }




}