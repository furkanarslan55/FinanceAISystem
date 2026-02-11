namespace UI.Models.Debt
{
    public class DebtUpdateDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? DueDate { get; set; }
         public string Description { get; set; }
        public string CategoryName { get; set; }


    }
}
