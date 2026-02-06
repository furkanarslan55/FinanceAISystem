namespace FinanceAI.Application.Features.Debts;

public record DebtDto(int Id, string Name, decimal Amount, DateTime DueDate, string? Description, string CategoryName);

