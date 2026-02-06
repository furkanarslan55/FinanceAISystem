namespace UI.Models.Incomes
{
    public class IncomeCategoryCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } // kullanıcıdan ıd almıyoruz sistem atayacak
    }
}
