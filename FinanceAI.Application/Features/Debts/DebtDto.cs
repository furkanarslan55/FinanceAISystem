namespace FinanceAI.Application.Features.Debts;

public record DebtDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public DateTime DueDate { get; init; }
    public string? Description { get; init; }
    public string CategoryName { get; init; } = string.Empty;
}
