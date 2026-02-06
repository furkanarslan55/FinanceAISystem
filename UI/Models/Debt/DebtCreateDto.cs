namespace UI.Models.Debt;

    public record DebtCreateDto(string Name, decimal Amount, DateTime DueDate, string Description, int DebtCategoryId);
    

       