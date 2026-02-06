namespace UI.Models.Debt;

public record DebtViewDto(int Id, string Name, decimal Amount, DateTime DueDate, string? Description, string CategoryName);

