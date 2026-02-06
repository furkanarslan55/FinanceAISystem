namespace UI.Models.Incomes;

    public record IncomeCreateDto(decimal Amount, DateTime Date, string? Description, int IncomeCategoryId);
