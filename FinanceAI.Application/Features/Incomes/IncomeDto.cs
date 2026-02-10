namespace FinanceAI.Business.Features.Incomes;

public record IncomeDto(int Id, decimal Amount, DateTime IncomeDate, string? Description, string CategoryName);