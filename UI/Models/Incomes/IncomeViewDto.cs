namespace UI.Models.Incomes;

    public record IncomeViewDto(int Id, decimal Amount, DateTime IncomeDate, string? Description, string CategoryName);
