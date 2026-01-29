namespace FinanceAI.Business.Features.Incomes;

public record IncomeCreateDto(decimal Amount, DateTime Date, string? Description, int IncomeCategoryId);