namespace FinanceAI.Business.Features.Incomes;

public record IncomeDto(int Id, decimal Amount, DateTime Date, string? Description, string CategoryName);