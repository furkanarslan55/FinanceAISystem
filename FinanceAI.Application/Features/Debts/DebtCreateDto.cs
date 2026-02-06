namespace FinanceAI.Application.Features.Debts;

    public record DebtCreateDto(string Name, decimal Amount, DateTime DueDate, string? Description, int DebtCategoryId);


