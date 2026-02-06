namespace UI.Models.Incomes;

    public record IncomeViewDto(int Id, decimal Amount, DateTime Date, string? Description, string CategoryName);
