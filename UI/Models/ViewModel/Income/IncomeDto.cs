namespace UI.Models.ViewModel.Income;

public record IncomeDto(int Id, decimal Amount, DateTime Date, string? Description, string CategoryName);