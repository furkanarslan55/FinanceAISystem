namespace UI.Models.FixedCost
{
    public class FixedCostCreateDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }


        public int FixedCostCategoryId { get; set; }
    }
}
